using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Text;

namespace SearchEngine.API.Services.Parsers
{
    public class TxtParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(string file)
        {
            return new Document
            {
                Name = file,
                Content = ExtractText(file)
            };
        }

        private static string ExtractText (string file)
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
