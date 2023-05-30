using SearchEngine.API.Interfaces;

namespace SearchEngine.API.Services
{
    public class Ranker
    {
        public static List<IDocKeywordOccurrence> RankDocsByKeywordOccurrence(List<List<IDocKeywordOccurrence>> tokensInvertedList)
        {
            List<IDocKeywordOccurrence> docKeywordOccurrences = GetDocKeyOccurenceFromTokensInvertedList(tokensInvertedList);
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
                    _docIds.AddRange(tokenList);
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
