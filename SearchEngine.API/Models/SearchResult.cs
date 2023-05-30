using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Models
{
    public class SearchResult : ISearchResult
    {
        public IDocument? ResultDocument { get; set; }
        public IDocKeywordOccurrence? DocKeywordOccurrence { get; set; }
    }
}
