namespace SearchEngine.API.Interfaces
{
    public interface IKeywordService
    {
        void AddOrUpdateKeyWord(string keyword, int docId, int occurrence);
        List<IDocKeywordOccurrence> GetDocKeywordOccurrences(string token);
    }
}
