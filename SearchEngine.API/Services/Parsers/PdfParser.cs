using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Pdfa;
using SearchEngine.API.Interfaces;
using System.Text;
using SearchEngine.API.Models;

namespace SearchEngine.API.Services.Parsers
{
    public class PdfParser : DocParser
    {
        public override IDocument? ExtractDataToDocument(string file)
        {
            string content = ExtractTextFromPdf(file);

            return new Document
            {
                Name = file,
                Content = content
            };
        }

        private static string ExtractTextFromPdf(string file)
        {
            StringBuilder pageText = new();

            using (var pdfDoc = new PdfDocument(new PdfReader(file)))
            {
                int pageNumbers = pdfDoc.GetNumberOfPages();

                for (int i = 0; i < pageNumbers; i++)
                {
                    LocationTextExtractionStrategy strategy = new();
                    PdfCanvasProcessor parser = new(strategy);
                    parser.ProcessPageContent(pdfDoc.GetFirstPage());
                    pageText.Append(strategy.GetResultantText());
                }
            }

            return pageText.ToString();
        }
    }
}
