
namespace SearchEngine.API.Interfaces
{
    public interface IDocHandler
    {
        IDocument ExtractDataDocumentFromFile(FileInfo file);
        IDocParser? GetValidExtractor (FileInfo file);
    }
}
