using SearchEngine.API.Interfaces;
using System.Runtime.CompilerServices;

namespace SearchEngine.API.Models
{
    public class SearchQuery : ISearchQuery
    {
        private readonly string _Query;
        
        public SearchQuery(string query) { 
            this._Query = query; 
        }

        public string Query
        {
            get
            {
                return this._Query;
            }
        }
    }
}
