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
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            var tokens = query.Split(delimiterChars).ToList();

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
