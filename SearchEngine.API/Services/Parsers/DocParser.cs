using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services.Parsers
{
    public abstract class DocParser : IDocParser
    {
        public abstract IDocument? ExtractDataToDocument(string file);

    }
}
