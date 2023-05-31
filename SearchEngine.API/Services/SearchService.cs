using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;

namespace SearchEngine.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly IDocumentService DocumentService;  
        private readonly IRanker Ranker;   

        public SearchService(IDocumentService docService, IRanker ranker)
        {
            this.DocumentService = docService;
            this.Ranker = ranker;   
        }

        public List<ISearchResult> GetSearchResult(ISearchQuery query)
        {
            return this.HandleQuerySearch(query);
        }

        private List<ISearchResult> HandleQuerySearch(ISearchQuery query)
        {
            List<ISearchResult> results = new();

            var tokens = query.Tokens;

            var tokensInvertedList = this.Ranker.GetTokensInvertedList(tokens);

            if (tokensInvertedList == null)
            {
                return results;
            }

            var tokenDocKeysOccurnce = this.Ranker.RankDocsByKeywordOccurrence(tokensInvertedList);
           
            results = this.GetSearchResultDocuments(tokenDocKeysOccurnce);

            return results;
        }

        private List<ISearchResult> GetSearchResultDocuments (List<IDocKeywordOccurrence> tokenDocKeysOccurnce)
        {
            List<ISearchResult> res = new ();

            if (tokenDocKeysOccurnce == null)
            {
                return res;
            }

            foreach (var t in tokenDocKeysOccurnce)
            {
                var doc = this.DocumentService.GetDocumentById(t.DocId);

                res.Add(new SearchResult
                {
                   ResultDocument = new Document
                   {
                       Id = doc.Id,
                       Name= doc.Name,  
                       Content = doc.Content,
                   },
                   DocKeywordOccurrence = t,
                });
            }

            return res;
        }

      
        
    }
}
