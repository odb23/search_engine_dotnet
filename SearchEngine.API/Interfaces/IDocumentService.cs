namespace SearchEngine.API.Interfaces
{
    public interface IDocumentService
    {
        void AddDocument(IDocument document);
        IDocument GetDocumentById(int id);
    }
}
