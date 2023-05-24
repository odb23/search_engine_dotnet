using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Xml;

namespace SearchEngine.API.Services.Parsers
{
    public class XmlParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(FileInfo file)
        {
            return new Document
            {
                Name = file.Name,
                Content = GetTextFromXMLFile(file)
            };
        }

        private static string GetTextFromXMLFile (FileInfo file)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(file.Create());

            string xmlString = xmlDoc.OuterXml;
            return xmlString;
        }
    }
}
