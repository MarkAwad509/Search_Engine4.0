using QueryRunner.BLL.Model;
using System.Collections.Generic;
using System.Linq;

namespace QueryRunner.BLL.Control
{
    public class DocumentRankingService
    {
        public IDictionary<int, double> docID_Distance { get; set; }

        public DocumentRankingService (IDictionary <int, double> docID_Distance) 
        {
            this.docID_Distance = new Dictionary<int, double>(docID_Distance);
        }

        public IDictionary<int, double> rankDocuments(double threshold = 0.0d)
        {
            DocumentRankingService docsFound = this;
            foreach (int i in docsFound.docID_Distance.Keys)
            {
                if (threshold < docsFound.docID_Distance[i])
                    docsFound.docID_Distance.Remove(i);
            }

            var SortedDictionary = from entry in docsFound.docID_Distance orderby entry.Value ascending select entry;
            return SortedDictionary.ToDictionary(pair => pair.Key, pair=>pair.Value);

        }
    }
}