using SearchEngine.API.Interfaces;
using SearchEngine.API.Utils;
using System.Runtime.CompilerServices;

namespace SearchEngine.API.Models
{
    public class SearchQuery : ISearchQuery
    {        
        public SearchQuery(string query) {
            this.GetQueryTokens(query);
        }

        public void GetQueryTokens( string query)
        {
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

            var tokens = query.ToLower().Split(delimiterChars).ToList();

            foreach (var sw in StopWords.words)
            {
                if (query.Contains(sw))
                {
                    tokens.RemoveAll(t => t.Equals(sw));
                }
            }


            this.Tokens = tokens.ToArray();
        }

        public string[]? Tokens
        {
            get;
            private set;
        }

    }
}
