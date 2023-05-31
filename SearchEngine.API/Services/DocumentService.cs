using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDbContext DbContext;
        public DocumentService(IDbContext dbContext) {
            this.DbContext = dbContext;
        } 
        
        public bool AddDocument (IDocument doc)
        {
            var res = this.DbContext.DbDocument.AddDocument(doc);
            if (res)  this.DbContext.SaveDatabase();
            return res;
        }
        public IDocument GetDocumentById (int id)
        {
            return this.DbContext.DbDocument.GetDocById(id);
        }
        

    }
}
