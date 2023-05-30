using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Models
{
    public class Document : IDocument
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Content { get; set; }
        public Dictionary<string, int> Keywords { get; private set; } = new();

        public void AddorUpdateKeywordOccurenece (string keyword)
        {
            if (this.Keywords.ContainsKey(keyword)) {
                this.Keywords[keyword] +=  1;
            } else
            {
                this.Keywords.Add(keyword, 1);
            }
        }

    }
}
