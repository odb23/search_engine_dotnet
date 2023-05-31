using SearchEngine.API.Interfaces;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace SearchEngine.API.Services.Parsers
{
    public class WordDocParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(string file)
        {
            return new Models.Document
            {
                Name = file,
                Content = GetTextFromWord(file)
            };
        }

        /// <summary>  
        /// Reads text content from Word document  
        /// </summary>  
        /// <returns>Word document's text</returns>  
        private string GetTextFromWord(string filePath)
        {
            StringBuilder text = new();
            Application word = new();
            Document docs = word.Documents.Open(filePath);

            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append("\r\n " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }

            docs.Close();
            word.Quit();

            return text.ToString();
        }
    }
}
