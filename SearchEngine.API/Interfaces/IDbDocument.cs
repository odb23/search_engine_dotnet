namespace SearchEngine.API.Interfaces
{
    public interface IDbDocument
    {
        int DocIdCounter { get; set; }
        IDictionary<int, IDocument> Documents { get; set; }
        IDictionary<string, IList<IDocKeywordOccurrence>> Keywords { get; set; }
        void AddDocument(IDocument doc);
    }

    public interface IDocKeywordOccurrence
    {
        int DocId { get; set; }
        int Occurrence { get; set; }
    }
}