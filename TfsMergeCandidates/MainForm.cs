using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.VersionControl.Client;
using TfsMergeCandidates.Config;
using TfsMergeCandidates.Extensions;
using TfsMergeCandidates.Output;

namespace TfsMergeCandidates
{
    public partial class MainForm : Form
    {
        private TfsTeamProjectCollection _projectCollection;
        private ICommonStructureService _projectStructure;
        private VersionControlServer _versionControlServer;
        private List<MergeCandidate> _merges;

        private IMergeOutputter _outputter;

        public MainForm()
        {
            InitializeComponent();

            // Load default settings.
            txtTfsServerUrl.Text = AppConfig.DefaultTFSServer;

            SetState(false, 
				comboProject, 
				comboSourceBranch, 
				comboTargetBranch, 
				lblSourceBranch, 
				lblTargetBranch, 
				lblProject,
				btnGetMerges,
				mergeGrid,
				btnOutputExport);

            ShowHideColumns(mergeGrid, false);

            // Wire up some events.
            btnTfsConnect.Click += Connect;
            comboSourceBranch.SelectedValueChanged += ValidateMerge;
            comboTargetBranch.SelectedValueChanged += ValidateMerge;

            comboProject.Items.Add("-- Select a project --");
            comboProject.SelectedIndex = 0;

            _merges = new List<MergeCandidate>();
            _outputter = GetOutputter(MergeOutputType.Html);
        }

        #region Events

        private void txtTfsServerUrl_KeyUp(object sender, KeyEventArgs e)
        {
            btnTfsConnect.Enabled = !String.IsNullOrWhiteSpace(txtTfsServerUrl.Text);

            if (btnTfsConnect.Enabled && e.KeyCode == Keys.Enter)
                Connect(sender, e);
        }

        private void Connect(object sender, EventArgs e)
        {
            try
            {
                _projectCollection = new TfsTeamProjectCollection(new Uri(txtTfsServerUrl.Text));
                _versionControlServer = _projectCollection.GetService<VersionControlServer>();
                _projectStructure = _projectCollection.GetService<ICommonStructureService>();

                // Populate the project selection box.
                foreach (var projectInfo in _projectStructure.ListProjects())
                {
                    comboProject.Items.Add(projectInfo.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to Team Foundation Server. Please enter a valid URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetState(false, btnTfsConnect, txtTfsServerUrl);
            SetState(true, comboProject, lblProject);
        }

        private void comboProject_SelectedValueChanged(object sender, EventArgs e)
        {
            SetState(comboProject.SelectedIndex != 0, comboSourceBranch, comboTargetBranch, lblSourceBranch, lblTargetBranch);

            // Populate the branch selection drop-downs.
            if (_versionControlServer != null)
            {
                var activeBranches = _versionControlServer.QueryRootBranchObjects(RecursionType.Full)
                                                          .Where(x => !x.Properties.RootItem.IsDeleted &&
                                                                 x.Properties.RootItem.Item.Contains(comboProject.SelectedItem.ToString()));

                activeBranches.ToList().ForEach(b =>
                { 
                    comboSourceBranch.Items.Add(b.Properties.RootItem.Item);
                    comboTargetBranch.Items.Add(b.Properties.RootItem.Item); 
                });
            }
        }

        private void ValidateMerge(object sender, EventArgs e)
        {
            bool enableMerge = comboSourceBranch.SelectedItem != null && comboTargetBranch.SelectedItem != null &&
                               comboSourceBranch.SelectedItem != comboTargetBranch.SelectedItem;

            SetState(enableMerge, btnGetMerges);
        }

        private async void btnGetMerges_Click(object sender, EventArgs e)
        {
			try
			{
				loadingSpinner.Visible = true;

				mergeGrid.Rows.Clear();
				_merges.Clear();

				btnGetMerges.Enabled = false;

				var candidates = await QueryMerges(comboSourceBranch.SelectedItem.ToString(),
					comboTargetBranch.SelectedItem.ToString());

				if (candidates.Any())
				{
					ShowHideColumns(mergeGrid, true);

					foreach (var candidate in candidates.OrderByDescending(c => c.Changeset.CreationDate))
					{
						string committer = candidate.Changeset.Owner;

						MergeCandidate merge = new MergeCandidate
						{
							ChangesetId = candidate.Changeset.ChangesetId,
							CheckinDate = candidate.Changeset.CreationDate.ToShortDateString(),
							Comment = candidate.Changeset.Comment,
							Committer = committer.Substring(committer.IndexOf("\\") + 1)
						};

						// Add to grid view and global collection.
						mergeGrid.Rows.Add(merge.ToDataGridStringArray());
						_merges.Add(merge);
					}

					// Re-size grid.
					for (int i = 0; i < mergeGrid.Columns.Count - 1; i++)
					{
						mergeGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					}

					mergeGrid.Columns[mergeGrid.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

					for (int i = 0; i < mergeGrid.Columns.Count; i++)
					{
						var colw = mergeGrid.Columns[i].Width;

						mergeGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
						mergeGrid.Columns[i].Width = colw;
					}

					SetState(true,
						mergeGrid,
						btnGetMerges,
						btnOutputExport);
				}
				else
				{
					ShowHideColumns(mergeGrid, false);

					MessageBox.Show("There are no available merge candidates for the selected branches.", "Information",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			finally
			{
				loadingSpinner.Visible = false;
			}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOutputExport_Click(object sender, EventArgs e)
        {
			outputDialog.ShowDialog();

			var selectedPath = outputDialog.SelectedPath;

			try
            {
                _outputter.WriteOut(new MergeCandidateContainer { Candidates = _merges }, selectedPath);

                MessageBox.Show("Output file created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
					string.Format("An error occurred whilst trying to write the output file.{0}{0}{1}", Environment.NewLine, ex.Message),
					"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void mergeGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Delete the row from the global collection.
            var mergeToRemove = _merges.FirstOrDefault(r => r.ChangesetId == Convert.ToInt32(e.Row.Cells[0].Value));

			if (mergeToRemove != null)
			{
				_merges.Remove(mergeToRemove);
			}
        }

        #endregion
        
        private void SetState(bool enabled, params Control[] controls) 
        {
            controls.ToList().ForEach(x => x.Enabled = enabled);
        }

        private void ShowHideColumns(DataGridView source, bool visible)
        {
			foreach (DataGridViewColumn column in source.Columns)
			{
				column.Visible = visible;
			}
        }

        private IMergeOutputter GetOutputter(MergeOutputType type)
        {
            switch (type)
            {
                case MergeOutputType.Csv:
                case MergeOutputType.Json:
                case MergeOutputType.Xml:
                    throw new NotImplementedException();

                case MergeOutputType.Html:
                    return new HtmlMergeOutputter(AppConfig.XsltOutputTemplateLocation);
            }

            throw new ArgumentException("Unknown/unsupported merge output type.", "type");
        }

		private async Task<Microsoft.TeamFoundation.VersionControl.Client.MergeCandidate[]> QueryMerges(
			string sourceBranch, string targetBranch)
		{
			return await Task.Run(() => 
			{
				return _versionControlServer.GetMergeCandidates(sourceBranch, targetBranch, RecursionType.Full);
			});
		}
	}
}
