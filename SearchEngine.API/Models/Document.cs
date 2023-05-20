using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Models
{
    public class Document : IDocument
    {
        public string? Name { get; set; } 
        public string? Content { get; set; }
        public Dictionary<string, int> Keywords { get; private set; } = new();

        public void AddorUpdateKeywordOccurenece (string keyword, int? number)
        {
            if (this.Keywords.ContainsKey(keyword)) {
                this.Keywords[keyword] += number ?? 1;
            } else
            {
                this.Keywords.Add(keyword, number ?? 1);
            }
        }

    }
}
