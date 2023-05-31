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
                KeywordService.AddOrUpdateKeyWord(word.ToLower(), doc.Id, doc.Keywords[word]);
            }
        }

        private bool HandleDocumentIndexing (IDocument? doc)
        {
            if (doc == null)
            {
                return false;
            }
            var tokens = SplitDocumentContentIntoCleanTokens(doc.Content!);

            if (tokens == null || tokens.Count < 1)
            {
                return false;
            }
            foreach (string token in tokens) { 
                doc.AddorUpdateKeywordOccurenece(token.ToLower());
            }

             return this.DocumentService.AddDocument(doc);
        }

        private static List<string>? SplitDocumentContentIntoCleanTokens (string content)
        {
            if (content == null)
            {
                return null;
            }

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '\r'
                                   , '\n', '&', '=', '_', '-', '+',
                                      '!', '@', '#', '$', '%', '^',
                                      '*','(', ')', '"', '<', '>', '/',
                                      '?', '|', '\\', ':', '~', '`',  
                                    '\u0009',  '\u000A',  '\u000B',  '\u000C',  '\u000D',
                                     '\u0020',  '\u0085',  '\u00A0',  '\u1680',  '\u2000',
                                        '\u2001',  '\u2002',  '\u2003',  '\u2004',  '\u2005',
                                    '\u2006',  '\u2007',  '\u2008',  '\u2009',  '\u200A',
                                    '\u2028',  '\u2029',  '\u202F',  '\u205F',  '\u3000',
                                    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };

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
