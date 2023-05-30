namespace SearchEngine.API.Interfaces
{
    public interface IKeywordService
    {
        void AddOrUpdateKeyWord(string keyword, int docId, int occurrence);
        IList<IDocKeywordOccurrence> GetDocKeywordOccurrences(string token);
    }
}
