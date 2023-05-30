namespace SearchEngine.API.Interfaces
{
    public interface ISearchResult
    {
        IDocKeywordOccurrence? DocKeywordOccurrence { get; set; }
        IDocument? ResultDocument { get; set; }
    }
}