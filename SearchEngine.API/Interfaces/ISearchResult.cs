namespace SearchEngine.API.Interfaces
{
    public interface ISearchResult
    {
        IDocKeywordOccurrence? DocKeywordOccurrence { get; set; }
        IResultDocument? ResultDocument { get; set; }
    }
}