using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IDbContext DbContext;
        public KeywordService(IDbContext dbContext) {
            this.DbContext = dbContext;
        }
        public void AddOrUpdateKeyWord(string keyword, int docId, int occurrence)
        {
            var keywordsData = this.DbContext.DbDocument.Keywords;
            if (keywordsData.ContainsKey(keyword))
            {
                this.DbContext.DbDocument.UpdateKeyword(keyword, docId, occurrence);
                return;
            }

            this.DbContext.DbDocument.AddKeyword(keyword, docId, occurrence);   
        }

        public List<IDocKeywordOccurrence> GetDocKeywordOccurrences(string token)
        {
           return this.DbContext.DbDocument.GetKeyword(token);
        }
    }
}
