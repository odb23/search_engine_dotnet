using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Xml;

namespace SearchEngine.API.Services.Parsers
{
    public class XmlParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(string file)
        {
            return new Document
            {
                Name = file,
                Content = GetTextFromXMLFile(file)
            };
        }

        private static string GetTextFromXMLFile(string file)
        {
            XmlDocument xmlDoc = new();
            xmlDoc.Load(file);

            string xmlString = xmlDoc.OuterXml;
            return xmlString;
        }
    }
}
