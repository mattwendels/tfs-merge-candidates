namespace TfsMergeCandidates
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lblTfsServer = new System.Windows.Forms.Label();
			this.txtTfsServerUrl = new System.Windows.Forms.TextBox();
			this.btnTfsConnect = new System.Windows.Forms.Button();
			this.lblSourceBranch = new System.Windows.Forms.Label();
			this.comboSourceBranch = new System.Windows.Forms.ComboBox();
			this.lblTargetBranch = new System.Windows.Forms.Label();
			this.comboTargetBranch = new System.Windows.Forms.ComboBox();
			this.lblProject = new System.Windows.Forms.Label();
			this.comboProject = new System.Windows.Forms.ComboBox();
			this.btnGetMerges = new System.Windows.Forms.Button();
			this.mergeGrid = new System.Windows.Forms.DataGridView();
			this.ChangesetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Developer = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.outputDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnOutputExport = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.loadingSpinner = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.mergeGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.loadingSpinner)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTfsServer
			// 
			this.lblTfsServer.AutoSize = true;
			this.lblTfsServer.Location = new System.Drawing.Point(12, 20);
			this.lblTfsServer.Name = "lblTfsServer";
			this.lblTfsServer.Size = new System.Drawing.Size(62, 13);
			this.lblTfsServer.TabIndex = 0;
			this.lblTfsServer.Text = "TFS server:";
			// 
			// txtTfsServerUrl
			// 
			this.txtTfsServerUrl.Location = new System.Drawing.Point(102, 17);
			this.txtTfsServerUrl.Name = "txtTfsServerUrl";
			this.txtTfsServerUrl.Size = new System.Drawing.Size(511, 20);
			this.txtTfsServerUrl.TabIndex = 1;
			this.txtTfsServerUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTfsServerUrl_KeyUp);
			// 
			// btnTfsConnect
			// 
			this.btnTfsConnect.Location = new System.Drawing.Point(619, 15);
			this.btnTfsConnect.Name = "btnTfsConnect";
			this.btnTfsConnect.Size = new System.Drawing.Size(75, 23);
			this.btnTfsConnect.TabIndex = 2;
			this.btnTfsConnect.Text = "Connect";
			this.btnTfsConnect.UseVisualStyleBackColor = true;
			// 
			// lblSourceBranch
			// 
			this.lblSourceBranch.AutoSize = true;
			this.lblSourceBranch.Location = new System.Drawing.Point(12, 96);
			this.lblSourceBranch.Name = "lblSourceBranch";
			this.lblSourceBranch.Size = new System.Drawing.Size(83, 13);
			this.lblSourceBranch.TabIndex = 3;
			this.lblSourceBranch.Text = "Source branch: ";
			// 
			// comboSourceBranch
			// 
			this.comboSourceBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSourceBranch.FormattingEnabled = true;
			this.comboSourceBranch.Location = new System.Drawing.Point(102, 92);
			this.comboSourceBranch.Name = "comboSourceBranch";
			this.comboSourceBranch.Size = new System.Drawing.Size(202, 21);
			this.comboSourceBranch.TabIndex = 4;
			// 
			// lblTargetBranch
			// 
			this.lblTargetBranch.AutoSize = true;
			this.lblTargetBranch.Location = new System.Drawing.Point(12, 131);
			this.lblTargetBranch.Name = "lblTargetBranch";
			this.lblTargetBranch.Size = new System.Drawing.Size(77, 13);
			this.lblTargetBranch.TabIndex = 5;
			this.lblTargetBranch.Text = "Target branch:";
			// 
			// comboTargetBranch
			// 
			this.comboTargetBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboTargetBranch.FormattingEnabled = true;
			this.comboTargetBranch.Location = new System.Drawing.Point(102, 127);
			this.comboTargetBranch.Name = "comboTargetBranch";
			this.comboTargetBranch.Size = new System.Drawing.Size(202, 21);
			this.comboTargetBranch.TabIndex = 6;
			// 
			// lblProject
			// 
			this.lblProject.AutoSize = true;
			this.lblProject.Location = new System.Drawing.Point(12, 57);
			this.lblProject.Name = "lblProject";
			this.lblProject.Size = new System.Drawing.Size(46, 13);
			this.lblProject.TabIndex = 7;
			this.lblProject.Text = "Project: ";
			// 
			// comboProject
			// 
			this.comboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProject.FormattingEnabled = true;
			this.comboProject.Location = new System.Drawing.Point(102, 54);
			this.comboProject.Name = "comboProject";
			this.comboProject.Size = new System.Drawing.Size(327, 21);
			this.comboProject.TabIndex = 8;
			this.comboProject.SelectedValueChanged += new System.EventHandler(this.comboProject_SelectedValueChanged);
			// 
			// btnGetMerges
			// 
			this.btnGetMerges.Location = new System.Drawing.Point(12, 167);
			this.btnGetMerges.Name = "btnGetMerges";
			this.btnGetMerges.Size = new System.Drawing.Size(143, 23);
			this.btnGetMerges.TabIndex = 10;
			this.btnGetMerges.Text = "Get Merge Candidates";
			this.btnGetMerges.UseVisualStyleBackColor = true;
			this.btnGetMerges.Click += new System.EventHandler(btnGetMerges_Click);
			// 
			// mergeGrid
			// 
			this.mergeGrid.AllowUserToAddRows = false;
			this.mergeGrid.AllowUserToOrderColumns = true;
			this.mergeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mergeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.mergeGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.mergeGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.mergeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mergeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChangesetId,
            this.Developer,
            this.Date,
            this.Comment});
			this.mergeGrid.Location = new System.Drawing.Point(12, 199);
			this.mergeGrid.Name = "mergeGrid";
			this.mergeGrid.ReadOnly = true;
			this.mergeGrid.Size = new System.Drawing.Size(1171, 344);
			this.mergeGrid.TabIndex = 11;
			this.mergeGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.mergeGrid_UserDeletingRow);
			// 
			// ChangesetId
			// 
			this.ChangesetId.HeaderText = "Changeset #";
			this.ChangesetId.Name = "ChangesetId";
			this.ChangesetId.ReadOnly = true;
			this.ChangesetId.Width = 93;
			// 
			// Developer
			// 
			this.Developer.HeaderText = "Developer";
			this.Developer.Name = "Developer";
			this.Developer.ReadOnly = true;
			this.Developer.Width = 81;
			// 
			// Date
			// 
			this.Date.HeaderText = "Date";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.Width = 55;
			// 
			// Comment
			// 
			this.Comment.HeaderText = "Comment";
			this.Comment.Name = "Comment";
			this.Comment.ReadOnly = true;
			this.Comment.Width = 76;
			// 
			// btnOutputExport
			// 
			this.btnOutputExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOutputExport.Location = new System.Drawing.Point(12, 551);
			this.btnOutputExport.Name = "btnOutputExport";
			this.btnOutputExport.Size = new System.Drawing.Size(75, 23);
			this.btnOutputExport.TabIndex = 15;
			this.btnOutputExport.Text = "Export";
			this.btnOutputExport.UseVisualStyleBackColor = true;
			this.btnOutputExport.Click += new System.EventHandler(this.btnOutputExport_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(1108, 549);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 16;
			this.btnExit.Text = "Close";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// loadingSpinner
			// 
			this.loadingSpinner.Image = ((System.Drawing.Image)(resources.GetObject("loadingSpinner.Image")));
			this.loadingSpinner.Location = new System.Drawing.Point(162, 170);
			this.loadingSpinner.Name = "loadingSpinner";
			this.loadingSpinner.Size = new System.Drawing.Size(18, 23);
			this.loadingSpinner.TabIndex = 17;
			this.loadingSpinner.TabStop = false;
			this.loadingSpinner.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1195, 586);
			this.Controls.Add(this.loadingSpinner);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnOutputExport);
			this.Controls.Add(this.mergeGrid);
			this.Controls.Add(this.btnGetMerges);
			this.Controls.Add(this.comboProject);
			this.Controls.Add(this.lblProject);
			this.Controls.Add(this.comboTargetBranch);
			this.Controls.Add(this.lblTargetBranch);
			this.Controls.Add(this.comboSourceBranch);
			this.Controls.Add(this.lblSourceBranch);
			this.Controls.Add(this.btnTfsConnect);
			this.Controls.Add(this.txtTfsServerUrl);
			this.Controls.Add(this.lblTfsServer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "TFS Merge Candidates";
			((System.ComponentModel.ISupportInitialize)(this.mergeGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.loadingSpinner)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTfsServer;
        private System.Windows.Forms.TextBox txtTfsServerUrl;
        private System.Windows.Forms.Button btnTfsConnect;
        private System.Windows.Forms.Label lblSourceBranch;
        private System.Windows.Forms.ComboBox comboSourceBranch;
        private System.Windows.Forms.Label lblTargetBranch;
        private System.Windows.Forms.ComboBox comboTargetBranch;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox comboProject;
        private System.Windows.Forms.Button btnGetMerges;
        private System.Windows.Forms.DataGridView mergeGrid;
        private System.Windows.Forms.FolderBrowserDialog outputDialog;
        private System.Windows.Forms.Button btnOutputExport;
        private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridViewTextBoxColumn ChangesetId;
		private System.Windows.Forms.DataGridViewTextBoxColumn Developer;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.PictureBox loadingSpinner;
	}
}