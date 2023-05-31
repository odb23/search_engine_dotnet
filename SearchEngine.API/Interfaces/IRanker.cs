namespace SearchEngine.API.Interfaces
{
    public interface IRanker
    {
        List<List<IDocKeywordOccurrence>>? GetTokensInvertedList(string[] tokens);
        List<IDocKeywordOccurrence>? RankDocsByKeywordOccurrence(List<List<IDocKeywordOccurrence>> tokensInvertedList);
    }
}