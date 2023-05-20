using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class Indexer : IIndexer
    {
        private IDocHandler DocHandler;

        public Indexer(IDocHandler docHandler) {  this.DocHandler = docHandler; }
        public bool IndexDocument(FileInfo doc)
        {
            // Validate Document type using DocParsehandler and Extract Data into Document representation
            // throw Error if documnet is empty
            IDocument fileDocument = this.DocHandler.ExtractDataDocumentFromFile(doc);

            // Get Valid 

            throw new NotImplementedException();
        }
    }
}
