namespace TfsMergeCandidates.Output
{
    public enum MergeOutputType
    {
        Html,
        Csv,
        Xml,
        Json
    }

    public interface IMergeOutputter
    {
        void WriteOut(MergeCandidateContainer merges, string outputPath);
    }
}
