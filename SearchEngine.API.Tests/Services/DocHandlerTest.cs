using SearchEngine.API.Services;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services.Parsers;

namespace SearchEngine.API.Tests.Services
{
    public class DocHandlerTest
    {
        [Fact]
        public void GetValidExtractor_WithHtmlExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.html";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<HTMLParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithPowerPointDocExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.ppt";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<PowerPointParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithXmlExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.xml";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<XmlParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithTxtExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.txt";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<TxtParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithWordDocExtension_ShouldReturnIDOcParser()
        {
            string fileName = "anyfile.docx";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<WordDocParser>(res);
        }

        [Fact]
        public void GetValidExtractor_WithPdfExtension_ShouldReturnIDOcParser ()
        {
            string fileName = "anyfile.pdf";

            DocParseHandler handler = new DocParseHandler();
            var res = handler.GetValidExtractor(fileName);

            Assert.NotNull(res);
            Assert.IsAssignableFrom<IDocParser>(res);
            Assert.IsType<PdfParser>(res);
        }
        [Fact]
        public void GetValidExtractor_WithInvalidFileExtension_ShouldReturnNull ()
        {
            string fileName = "invalidFile.tcxt";

            DocParseHandler handler = new DocParseHandler();

            var result = handler.GetValidExtractor(fileName);

            Assert.Null(result);    
        }
    }
}
