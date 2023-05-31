namespace SearchEngine.API.Interfaces
{
    public interface IDbDocument
    {
        Dictionary<int, IDocument> Documents { get; set; }
        Dictionary<string, List<IDocKeywordOccurrence>> Keywords { get; set; }
        bool AddDocument(IDocument doc);
        IDocument GetDocById(int id);
        List<IDocKeywordOccurrence> GetKeyword(string keyword);
        void AddKeyword(string keyword, int docId, int occurrence);
        void UpdateKeyword(string keyword, int docId, int occurrence);
    }

    public interface IDocKeywordOccurrence
    {
        int DocId { get; set; }
        int Occurrence { get; set; }
    }
}