namespace SearchEngine.API.Interfaces
{
    public interface IDocument
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Content { get; set; }
        IDictionary<string, int> Keywords { get;}
        void AddorUpdateKeywordOccurenece(string keyword);
    }
}
