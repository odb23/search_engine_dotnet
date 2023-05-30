namespace SearchEngine.API.Interfaces
{
    public interface IIndexer
    {
        IDocument? IndexDocument(FileInfo doc);
    }
}
