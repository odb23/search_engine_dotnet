using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Models
{
    public class SearchResult : ISearchResult
    {
        public IResultDocument? ResultDocument { get; set; }
        public IDocKeywordOccurrence? DocKeywordOccurrence { get; set; }
    }

    public class ResultDocument : IResultDocument
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
