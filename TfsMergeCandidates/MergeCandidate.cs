using System.Collections.Generic;
using System.Xml.Serialization;

namespace TfsMergeCandidates
{
	public class MergeCandidate
    {
        public int ChangesetId { get; set; }

        public string Committer { get; set; }

        public string CheckinDate { get; set; }

        public string Comment { get; set; }
    }

    public class MergeCandidateContainer
    {
        public MergeCandidateContainer()
        {
            Candidates = new List<MergeCandidate>();
        }

		[XmlArrayItem("MergeItem")]
		public List<MergeCandidate> Candidates { get; set; }
	}
}
