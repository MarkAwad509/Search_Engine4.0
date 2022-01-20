using QueryRunner.BLL.Model;
using QueryRunner.DAL;
using System.Collections.Generic;
using System.Linq;

namespace QueryRunner.BLL.Control
{
    public class BasicBooleanSearch : AbstractSearchEngine
    {
        public override IList<string> runQuery(Query r)
        {
            return this.DocInString(this.intersectDocuments(r));   
        }

        private IList<int> intersectDocuments(Query r) 
        {
            IndexDAO iDAO = new IndexDAO();
            IList<string> queryTerms = new List<string>(r.Terms);
            IList<int> AllDocID = new List<int>(iDAO.fetchAllDocumentsID());
            IList<int> DocIdWithTerm = new List<int>();

            foreach (string t in queryTerms)
            {
                DocIdWithTerm = iDAO.fetchDocumentIdByTerm(t);
                AllDocID = AllDocID.Intersect(DocIdWithTerm).ToList();
            }

            if (!AllDocID.Any())
            {
                AllDocID.Add(0);
            }
            return AllDocID;
        }

        private IList<string> DocInString(IList<int> docIds) {
            CorpusDAO cDAO = new CorpusDAO();
            IList<string> Results = new List<string>();
            foreach (int Id in docIds) 
            {
                if (Id == 0)
                    Results.Add("No results found");
                else
                Results.Add(Id + " | " + cDAO.fetchDocumentContentById(Id));
            }

            return Results;
        }
    }
}
