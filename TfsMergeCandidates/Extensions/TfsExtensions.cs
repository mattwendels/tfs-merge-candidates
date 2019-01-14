using System;

namespace TfsMergeCandidates.Extensions
{
    public static class TfsExtensions
    {
        public static string[] ToDataGridStringArray(this MergeCandidate candidate)
        {
            string comment = candidate.Comment ?? String.Empty;
            comment = comment.Length > 100 ? comment.Substring(0, 100) + "..." : comment;

            return new string[] 
            { 
                candidate.ChangesetId.ToString(),
                candidate.Committer,
                candidate.CheckinDate.ToString(),
                comment
            };
        }

        public static string MakePathSafe(this string url)
        {
            return url.Replace("/", "-").Replace(":", "-");
        }
    }
}
