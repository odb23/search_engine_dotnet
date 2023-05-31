using SearchEngine.API.Services;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services.Parsers;
using SearchEngine.API.Exceptions;

namespace SearchEngine.API.Tests.Services
{
    public class DocHandlerTest
    {
        [Fact]
        public void ExtractDataDocumentFromFile_WithhtmlFile_ShouldCreateDocument()
        {

            string fileName = GetDataSourcePath() + @"\file.html";

            DocParseHandler handler = new ();

            var res = handler.ExtractDataDocumentFromFile(fileName);
            Assert.IsAssignableFrom<IDocument>(res);
        }

        [Fact]
        public void ExtractDataDocumentFromFile_WithxmlFile_ShouldCreateDocument()
        {

            string fileName = GetDataSourcePath() + @"\file.xml";

            DocParseHandler handler = new ();

            var res = handler.ExtractDataDocumentFromFile(fileName);
            Assert.IsAssignableFrom<IDocument>(res);
        }

        [Fact]
        public void ExtractDataDocumentFromFile_WithpptxFile_ShouldCreateDocument()
        {

            string fileName = GetDataSourcePath() + @"\file.pptx";

            DocParseHandler handler = new();

            var res = handler.ExtractDataDocumentFromFile(fileName);
            Assert.IsAssignableFrom<IDocument>(res);
        }

        //[Fact]
        //public void ExtractDataDocumentFromFile_WithxlsFile_ShouldCreateDocument()
        //{

        //    string fileName = GetDataSourcePath() + @"\file.xls";

        //    DocParseHandler handler = new DocParseHandler();

        //    var res = handler.ExtractDataDocumentFromFile(fileName);
        //    Assert.IsAssignableFrom<IDocument>(res);
        //}

        //[Fact]
        //public void ExtractDataDocumentFromFile_WithtdocFile_ShouldCreateDocument()
        //{

        //    string fileName = GetDataSourcePath() + @"\file.doc";

        //    DocParseHandler handler = new DocParseHandler();

        //    var res = handler.ExtractDataDocumentFromFile(fileName);
        //    Assert.IsAssignableFrom<IDocument>(res);
        //}

        //[Fact]
        //public void ExtractDataDocumentFromFile_WithdocxFile_ShouldCreateDocument()
        //{

        //    string fileName = GetDataSourcePath() + @"\file.docx";

        //    DocParseHandler handler = new DocParseHandler();

        //    var res = handler.ExtractDataDocumentFromFile(fileName);
        //    Assert.IsAssignableFrom<IDocument>(res);
        //}

        [Fact]
        public void ExtractDataDocumentFromFile_WithtxtFile_ShouldCreateDocument()
        {

            string fileName = GetDataSourcePath() + @"\file.txt";

            DocParseHandler handler = new();

            var res = handler.ExtractDataDocumentFromFile(fileName);
            Assert.IsAssignableFrom<IDocument>(res);
        }

        //[Fact]
        //public void ExtractDataDocumentFromFile_WithxlsxFile_ShouldCreateDocument()
        //{

        //    string fileName = GetDataSourcePath() + @"\file.xlsx";

        //    DocParseHandler handler = new DocParseHandler();

        //    var res = handler.ExtractDataDocumentFromFile(fileName);
        //    Assert.IsAssignableFrom<IDocument>(res);
        //}

        //[Fact]
        //public void ExtractDataDocumentFromFile_WithpptFile_ShouldCreateDocument()
        //{

        //    string fileName = GetDataSourcePath() + @"\file.ppt";

        //    DocParseHandler handler = new DocParseHandler();

        //    var res = handler.ExtractDataDocumentFromFile(fileName);
        //    Assert.IsAssignableFrom<IDocument>(res);
        //}

        [Fact]
        public void ExtractDataDocumentFromFile_WithPdfFile_ShouldCreateDocument() {

            string fileName = GetDataSourcePath() + @"\file.pdf";

            DocParseHandler handler = new();

            var res = handler.ExtractDataDocumentFromFile(fileName);
            Assert.IsAssignableFrom<IDocument>(res);
        }
        private static string GetDataSourcePath()
        {

            string dir = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net7.0", "");

            return Path.Join(dir, "files");
        }

        [Fact]
        public void ExtractDataDocumentFromFile_WithInvalidFile_ShouldThrowErrow()
        {
            string fileName = "anyfile.html";

            DocParseHandler handler = new();

          
            Assert.Throws<FileNotFoundException>(() =>
                    handler.ExtractDataDocumentFromFile(fileName));
        }
        [Fact]
        public void ExtractDataDocumentFromFile_WithInvalidFileExtension_ShouldThrowErrow ()
        {
            string fileName = "anyfile.xxhtml";

            DocParseHandler handler = new();


            Assert.Throws<InvalidFileTypeException> (() =>
                    handler.ExtractDataDocumentFromFile(fileName));
        }
        [Fact]
        public void GetValidExtractor_WithHtmlExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.html";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<HTMLParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithPowerPointDocExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.ppt";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<PowerPointParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithXmlExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.xml";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<XmlParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithTxtExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.txt";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<TxtParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithWordDocExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.docx";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<WordDocParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithPdfExtension_ShouldReturnIDOcParser ()
        {
            string fileName = "anyfile.pdf";

            DocParseHandler handler = new();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<PdfParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithInvalidFileExtension_ShouldReturnNull ()
        {
            string fileName = "invalidFile.tcxt";

            DocParseHandler handler = new();

            var result = handler.GetValidExtractor(fileName);

            Assert.Null(result);    
        }
    }
}
