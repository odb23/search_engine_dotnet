using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;

namespace SearchEngine.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly IDocumentService DocumentService;  
        private readonly IKeywordService KeywordService;   

        public SearchService(IDocumentService docService, IKeywordService kwService)
        {
            this.DocumentService = docService;
            this.KeywordService = kwService;   
        }

        public List<ISearchResult> GetSearchResult(ISearchQuery query)
        {
            return this.HandleQuerySearch(query);
        }

        private List<ISearchResult> HandleQuerySearch(ISearchQuery query)
        {
            var tokens = query.Tokens;

            var tokensInvertedList = this.GetTokensInvertedList(tokens);

            var tokenDocKeysOccurnce = Ranker.RankDocsByKeywordOccurrence(tokensInvertedList);
           
            List<ISearchResult> results = this.GetSearchResultDocuments(tokenDocKeysOccurnce);

            return results;
        }

        private List<ISearchResult> GetSearchResultDocuments (List<IDocKeywordOccurrence> tokenDocKeysOccurnce)
        {
            List<ISearchResult> res = new ();

            foreach (var t in tokenDocKeysOccurnce)
            {
                var doc = this.DocumentService.GetDocumentById(t.DocId);

                res.Add(new SearchResult
                {
                   ResultDocument = doc,
                   DocKeywordOccurrence = t,
                });
            }

            return res;
        }

      
        private List<List<IDocKeywordOccurrence>> GetTokensInvertedList(string[] tokens)
        {
            List<List<IDocKeywordOccurrence>> tokensInvertedIndex = new();

            // get inverted index for every token.
            foreach (var token in tokens)
            {
                var t_invertedIndex = this.KeywordService.GetDocKeywordOccurrences(token);
                tokensInvertedIndex.Add(t_invertedIndex);
            }

            return tokensInvertedIndex;
        }
    }
}
