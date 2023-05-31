using SearchEngine.API.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace SearchEngine.API.Models
{
    public class DbDocument : IDbDocument
    {
        public int DocIdCounter { get; set; } = 0;
        public Dictionary<string, List<IDocKeywordOccurrence>> Keywords { get; set; } = new ();
        public Dictionary<int, IDocument> Documents { get; set; } = new();

        public bool AddDocument(IDocument doc)
        {
            var docExist = Documents.Values.Any(t => t.Name == doc.Name);
            if (docExist)
            {
                return false;
            }
            doc.Id = DocIdCounter++;
            this.Documents.Add(doc.Id, doc);
            return true;
        }

        public IDocument GetDocById (int id)
        {
            return  this.Documents
                .FirstOrDefault(x => x.Key == id).Value;
        }

        public List<IDocKeywordOccurrence> GetKeyword(string keyword)
        {
            return this.Keywords.FirstOrDefault(k => k.Key == keyword).Value;
        }

        public void AddKeyword (string keyword, int docId, int occurrence)
        {
            this.Keywords.Add(keyword, new List<IDocKeywordOccurrence> { 
                new DocKeywordOccurence
                {
                    DocId = docId,
                    Occurrence = occurrence 
                }
            });
        }

        public void UpdateKeyword (string keyword, int docId, int occurrence)
        {
            if (!this.Keywords.ContainsKey(keyword)) {
                this.AddKeyword(keyword, docId, occurrence);
            } else
            {
                var newDocIdOccurrence = new DocKeywordOccurence
                {
                    DocId = docId,
                    Occurrence = occurrence
                };

                var index = this.Keywords[keyword].BinarySearch(newDocIdOccurrence);
                if (index < 0) index = ~ index;
                this.Keywords[keyword].Insert(index, newDocIdOccurrence);
            }
        }
    }

    public class DocKeywordOccurence : IDocKeywordOccurrence, IComparable
    {
        public int DocId { get; set; }
        public int Occurrence { get; set; }

        public int CompareTo(object? obj)
        {
            DocKeywordOccurence Temp = (DocKeywordOccurence)obj;
            if (this.DocId < Temp.DocId)
            { return 1; }
            if (this.DocId > Temp.DocId)
            { return -1; }
            else
            { return 0; }
        }
    }
}
