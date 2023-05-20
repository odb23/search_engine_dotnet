using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public abstract class DocParser : IDocParser
    {
        public abstract IDocument? ExtractDataToDocument(FileInfo file);
     
    }
}
