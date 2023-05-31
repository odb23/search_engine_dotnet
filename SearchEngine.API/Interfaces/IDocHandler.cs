
namespace SearchEngine.API.Interfaces
{
    public interface IDocHandler
    {
        IDocument ExtractDataDocumentFromFile(string file);
        IDocParser? GetValidExtractor (string file);
    }
}
