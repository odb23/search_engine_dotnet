namespace SearchEngine.API.Interfaces
{
    public interface IIndexer
    {
        bool IndexDocument(FileInfo doc);
    }
}
