namespace SearchEngine.API.Interfaces
{
    public interface ISearchService
    {
        List<ISearchResult> GetSearchResult(ISearchQuery query);
    }
}