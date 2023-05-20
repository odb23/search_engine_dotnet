namespace SearchEngine.API.Interfaces
{
    public interface IDocParser
    {
        IDocument? ExtractDataToDocument(FileInfo file);
    }
}
