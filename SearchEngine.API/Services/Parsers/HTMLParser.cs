using HtmlAgilityPack;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Text;

namespace SearchEngine.API.Services.Parsers
{
    public class HTMLParser : DocParser
    {

        public override IDocument? ExtractDataToDocument(string file)
        {
            string htmlTextContent = ExtractFromFileAsText(file);

            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(htmlTextContent);

            string content = htmlDoc.DocumentNode.OuterHtml;

            var document = new Document
            {
                Name = file,
                Content = content
            };

            return document;
        }

        private static string ExtractFromFileAsText(string file)
        {

            StringBuilder sb = new();

            using (StreamReader sr = File.OpenText(file))
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    sb.AppendLine(s);
                }
            }

            return sb.ToString();
        }
    }
}
