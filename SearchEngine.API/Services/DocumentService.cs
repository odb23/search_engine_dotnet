using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDbContext DbContext;
        public DocumentService(IDbContext dbContext) {
            this.DbContext = dbContext;
        } 
        
        public void AddDocument (IDocument doc)
        {
            this.DbContext.DbDocument.AddDocument(doc);
            this.DbContext.SaveDatabase();
        }
        public IDocument GetDocumentById (int id)
        {
            return this.DbContext.DbDocument.GetDocById(id);
        }
        

    }
}
