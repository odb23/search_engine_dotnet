namespace SearchEngine.API.Interfaces
{
    public interface IDocParser
    {
        IDocument? ExtractDataToDocument(string file);
    }
}
