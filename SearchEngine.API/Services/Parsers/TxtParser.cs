using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Text;

namespace SearchEngine.API.Services.Parsers
{
    public class TxtParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(FileInfo file)
        {
            return new Document
            {
                Name = file.Name,
                Content = ExtractText(file)
            };
        }

        private static string ExtractText (FileInfo file)
        {
            StringBuilder sb = new();

            using (StreamReader sr = file.OpenText())
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
