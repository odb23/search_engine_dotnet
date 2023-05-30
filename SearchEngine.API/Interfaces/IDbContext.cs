namespace SearchEngine.API.Interfaces
{
    public interface IDbContext
    {
        IDbDocument DbDocument { get; }

        void InitDbDocument();
        IDbDocument LoadDatabase();
        void SaveDatabase();
    }
}