using SearchEngine.API.Exceptions;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Utils;

namespace SearchEngine.API.Services
{
    public class Indexer : IIndexer
    {
        private readonly IDocHandler DocHandler;
        private readonly IDocumentService DocumentService;
        private readonly IKeywordService KeywordService;

        public Indexer(IDocHandler docHandler, IDocumentService docService, IKeywordService keywordService)
        {
            this.DocHandler = docHandler;
            this.DocumentService = docService;
            this.KeywordService = keywordService;
        }
        public void IndexDocument(string doc)
        {
            // Validate Document type using DocParsehandler and Extract Data into Document representation
            // throw Error if documnet is empty
            IDocument fileDocument;
            try
            {
                fileDocument = this.DocHandler.ExtractDataDocumentFromFile(doc);
                var res = this.HandleDocumentIndexing(fileDocument);
                if (res) this.HandleKeywordsIndexing(fileDocument);
            } catch (InvalidFileTypeException ex)
            {
                throw ex;
            }
        }

        private void HandleKeywordsIndexing (IDocument doc)
        {
            if (doc == null)
            {
                return;
            }

            if (doc.Keywords == null)
            {
                return;
            }

            foreach (string word in doc.Keywords.Keys)
            {
                KeywordService.AddOrUpdateKeyWord(word, doc.Id, doc.Keywords[word]);
            }
        }

        private bool HandleDocumentIndexing (IDocument doc)
        {
            var tokens = SplitDocumentContentIntoCleanTokens(doc.Content!);

            foreach (string token in tokens) { 
                doc.AddorUpdateKeywordOccurenece(token);
            }

             return this.DocumentService.AddDocument(doc);
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
