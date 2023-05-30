using SearchEngine.API.Exceptions;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Utils;

namespace SearchEngine.API.Services
{
    public class Indexer : IIndexer
    {
        private readonly IDocHandler DocHandler;
        private readonly IDocumentService DocumentService;

        public Indexer(IDocHandler docHandler, IDocumentService docService) {
            this.DocHandler = docHandler; 
            this.DocumentService = docService; 
        }
        public IDocument? IndexDocument(FileInfo doc)
        {
            // Validate Document type using DocParsehandler and Extract Data into Document representation
            // throw Error if documnet is empty
            IDocument fileDocument;
            try
            {
                fileDocument = this.DocHandler.ExtractDataDocumentFromFile(doc);
                this.HandleDocumentIndexing(fileDocument);
            } catch (InvalidFileTypeException ex)
            {
                return null;
            }

            return fileDocument;
        }

        private void HandleDocumentIndexing (IDocument doc)
        {
            var tokens = SplitDocumentContentIntoCleanTokens(doc.Content!);

            foreach (string token in tokens) { 
                doc.AddorUpdateKeywordOccurenece(token);
            }

            this.DocumentService.AddDocument(doc);
        }

        private static List<string> SplitDocumentContentIntoCleanTokens (string content)
        {

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            var tokens = content.Split(delimiterChars).ToList();

            foreach (var sw in StopWords.words)
            {
                if (content.Contains(sw))
                {
                    tokens.RemoveAll(t => t.Equals(sw));
                }
            }
            return tokens;

        } 
    }
}
