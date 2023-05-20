namespace SearchEngine.API.Interfaces
{
    public interface IDocument
    {
        string? Name { get; set; }
        string? Content { get; set; }
        Dictionary<string, int> Keywords { get;}
        void AddorUpdateKeywordOccurenece(string keyword, int? number);
    }
}
