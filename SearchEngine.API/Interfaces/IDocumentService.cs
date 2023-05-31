namespace SearchEngine.API.Interfaces
{
    public interface IDocumentService
    {
        bool AddDocument(IDocument document);
        IDocument GetDocumentById(int id);
    }
}
