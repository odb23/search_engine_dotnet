namespace SearchEngine.API.Interfaces
{
    public interface IDocument
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Content { get; set; }
        Dictionary<string, int> Keywords { get;}
        void AddorUpdateKeywordOccurenece(string keyword);
    }
}
