using Moq;
using Xunit;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Services;

namespace SearchEngine.API.Tests.Services
{
    public class DocumentServiceTests
    {
        private DocumentService documentService;
        private Mock<IDbContext> dbContextMock;

        public DocumentServiceTests()
        {
            dbContextMock = new Mock<IDbContext>();
            documentService = new DocumentService(dbContextMock.Object);
        }

        [Fact]
        public void AddDocument_ValidDocument_ReturnsTrue()
        {
            // Arrange
            var docMock = new Mock<IDocument>();
            dbContextMock.Setup(x => x.DbDocument.AddDocument(It.IsAny<IDocument>())).Returns(true);

            // Act
            var result = documentService.AddDocument(docMock.Object);

            // Assert
            Assert.True(result);
            dbContextMock.Verify(x => x.DbDocument.AddDocument(docMock.Object), Times.Once);
            dbContextMock.Verify(x => x.SaveDatabase(), Times.Once);
        }

        [Fact]
        public void AddDocument_InvalidDocument_ReturnsFalse()
        {
            // Arrange
            var docMock = new Mock<IDocument>();
            dbContextMock.Setup(x => x.DbDocument.AddDocument(It.IsAny<IDocument>())).Returns(false);

            // Act
            var result = documentService.AddDocument(docMock.Object);

            // Assert
            Assert.False(result);
            dbContextMock.Verify(x => x.DbDocument.AddDocument(docMock.Object), Times.Once);
            dbContextMock.Verify(x => x.SaveDatabase(), Times.Never);
        }

        [Fact]
        public void GetDocumentById_ExistingId_ReturnsDocument()
        {
            // Arrange
            var docId = 123;
            var expectedDoc = new Mock<IDocument>();
            dbContextMock.Setup(x => x.DbDocument.GetDocById(docId)).Returns(expectedDoc.Object);

            // Act
            var result = documentService.GetDocumentById(docId);

            // Assert
            Assert.Equal(expectedDoc.Object, result);
            dbContextMock.Verify(x => x.DbDocument.GetDocById(docId), Times.Once);
        }

        [Fact]
        public void GetDocumentById_NonExistingId_ReturnsNull()
        {
            // Arrange
            var docId = 456;
            dbContextMock.Setup(x => x.DbDocument.GetDocById(docId)).Returns((IDocument)null);

            // Act
            var result = documentService.GetDocumentById(docId);

            // Assert
            Assert.Null(result);
            dbContextMock.Verify(x => x.DbDocument.GetDocById(docId), Times.Once);
        }
    }
}
