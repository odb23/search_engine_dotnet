using SearchEngine.API.Exceptions;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services.Parsers;
using SearchEngine.API.Utils;

namespace SearchEngine.API.Services
{
    public class DocParseHandler : IDocHandler
    {
        private static bool IsValidFile(string file)
        {
            var extension = Path.GetExtension(file);
            return ValidFileTypes.types.Contains(extension);
        }

        public IDocument ExtractDataDocumentFromFile(string file)
        {
            IDocParser? parser = this.GetValidExtractor(file) ?? 
                                throw new InvalidFileTypeException("Invalid File Format! File cannot be parsed.");
            var _doc = parser.ExtractDataToDocument(file) ?? 
                                throw new InvalidFileTypeException("Error Occurred! File could not be parsed.");
            return _doc;
        }

        public IDocParser? GetValidExtractor(string file)
        {
            if (!IsValidFile(file)) return null;

            var extension = Path.GetExtension(file);    
            return extension switch
            {
                ".html" => new HTMLParser(),
                ".pdf" => new PdfParser(),
                ".docx" => new WordDocParser(),
                ".doc" => new WordDocParser(),
                ".txt" => new TxtParser(),
                ".xml" => new XmlParser(),
                ".ppt" => new PowerPointParser(),
                ".pptx" => new PowerPointParser(),
                _ => null,
            };
        }


    }
}
