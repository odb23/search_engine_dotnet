using Moq;
using SearchEngine.API.Exceptions;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services;

namespace SearchEngine.API.Tests.Services
{
    public class IndexerTests
    {
        private Indexer indexer;
        private Mock<IDocHandler> docHandlerMock;
        private Mock<IDocumentService> documentServiceMock;
        private Mock<IKeywordService> keywordServiceMock;

        public IndexerTests()
        {
            docHandlerMock = new Mock<IDocHandler>();
            documentServiceMock = new Mock<IDocumentService>();
            keywordServiceMock = new Mock<IKeywordService>();
            indexer = new Indexer(docHandlerMock.Object, documentServiceMock.Object, keywordServiceMock.Object);
        }

        //[Fact]
        //public void IndexDocument_ValidDocument_ExecutesIndexing()
        //{
        //    // Arrange
        //    string doc = "Sample document content";
        //    var fileDocumentMock = new Mock<IDocument>();
        //    docHandlerMock.Setup(x => x.ExtractDataDocumentFromFile(doc)).Returns(fileDocumentMock.Object);
        //    documentServiceMock.Setup(x => x.AddDocument(fileDocumentMock.Object)).Returns(true);

        //    // Act
        //    indexer.IndexDocument(doc);

        //    // Assert
        //    docHandlerMock.Verify(x => x.ExtractDataDocumentFromFile(doc), Times.Once);
        //    documentServiceMock.Verify(x => x.AddDocument(fileDocumentMock.Object), Times.Once);
        //    keywordServiceMock.Verify(x => x.AddOrUpdateKeyWord(It.IsAny<string>(), fileDocumentMock.Object.Id, It.IsAny<int>()), Times.Never);
        //}

        //[Fact]
        //public void IndexDocument_ValidDocumentWithKeywords_ExecutesIndexingAndKeywordIndexing()
        //{
        //    // Arrange
        //    string doc = "Sample document content";
        //    var fileDocumentMock = new Mock<IDocument>();
        //    fileDocumentMock.SetupGet(x => x.Keywords).Returns(new Dictionary<string, int>() { { "keyword1", 1 }, { "keyword2", 2 } });
        //    docHandlerMock.Setup(x => x.ExtractDataDocumentFromFile(doc)).Returns(fileDocumentMock.Object);
        //    documentServiceMock.Setup(x => x.AddDocument(fileDocumentMock.Object)).Returns(true);

        //    // Act
        //    indexer.IndexDocument(doc);

        //    // Assert
        //    docHandlerMock.Verify(x => x.ExtractDataDocumentFromFile(doc), Times.Once);
        //    documentServiceMock.Verify(x => x.AddDocument(fileDocumentMock.Object), Times.Once);
        //    keywordServiceMock.Verify(x => x.AddOrUpdateKeyWord("keyword1", fileDocumentMock.Object.Id, 1), Times.Once);
        //    keywordServiceMock.Verify(x => x.AddOrUpdateKeyWord("keyword2", fileDocumentMock.Object.Id, 2), Times.Once);
        //}

        [Fact]
        public void IndexDocument_InvalidFileType_ThrowsInvalidFileTypeException()
        {
            // Arrange
            string doc = "Sample document path";
            docHandlerMock.Setup(x => x.ExtractDataDocumentFromFile(doc)).Throws<InvalidFileTypeException>();

            // Assert
            Assert.Throws<InvalidFileTypeException>(() => indexer.IndexDocument(doc));
        }
    }
}
