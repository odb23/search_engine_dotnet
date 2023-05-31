using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class Ranker : IRanker
    {
        private readonly IKeywordService KeywordService;
        public Ranker(IKeywordService keywordService)
        {
            this.KeywordService = keywordService;
        }

        public List<List<IDocKeywordOccurrence>>? GetTokensInvertedList(string[] tokens)
        {
            List<List<IDocKeywordOccurrence>> tokensInvertedIndex = new();

            // get inverted index for every token.
            foreach (var token in tokens)
            {
                var t_invertedIndex = this.KeywordService.GetDocKeywordOccurrences(token);
                tokensInvertedIndex.Add(t_invertedIndex);
            }

            return tokensInvertedIndex;
        }
        public List<IDocKeywordOccurrence>? RankDocsByKeywordOccurrence(List<List<IDocKeywordOccurrence>> tokensInvertedList)
        {
            List<IDocKeywordOccurrence> docKeywordOccurrences = GetDocKeyOccurenceFromTokensInvertedList(tokensInvertedList);
            if (docKeywordOccurrences == null)
            {
                return null;
            }
            docKeywordOccurrences.Sort((a, b) => a.Occurrence.CompareTo(b.Occurrence));
            docKeywordOccurrences.Reverse();
            return docKeywordOccurrences;
        }

        private static List<IDocKeywordOccurrence> GetDocKeyOccurenceFromTokensInvertedList(List<List<IDocKeywordOccurrence>> tokensInvertedList)
        {
            List<IDocKeywordOccurrence> docIds;

            // check for when inverted List is empty.

            if (tokensInvertedList.Count == 1)
            {
                docIds = tokensInvertedList.First();

            }
            else
            {
                List<IDocKeywordOccurrence> _docIds = new();

                foreach (var tokenList in tokensInvertedList)
                {
                    if (tokenList != null)
                    {
                        _docIds.AddRange(tokenList);
                    }
                }

                // Find duplicates and merge occurrence.
                docIds = FindAndMergeDuplicateDocKeyOccurence(_docIds);
            }
            return docIds;
        }

        private static List<IDocKeywordOccurrence> FindAndMergeDuplicateDocKeyOccurence(List<IDocKeywordOccurrence> docKeywordOccurrences)
        {
            List<IDocKeywordOccurrence> newOccurrences = new();

            foreach (var o in docKeywordOccurrences)
            {

                var docKeysInNewOccurrences = newOccurrences.FirstOrDefault(dk => dk.DocId == o.DocId);
                if (docKeysInNewOccurrences == null)
                {
                    newOccurrences.Add(o);
                }
                else
                {
                    docKeysInNewOccurrences.Occurrence += o.Occurrence;
                }
            }

            return newOccurrences;
        }

    }
}
