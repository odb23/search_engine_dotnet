namespace SearchEngine.API.Interfaces
{
    public interface ISearchService
    {
        IList<ISearchResult> GetSearchResult(ISearchQuery query);
    }
}