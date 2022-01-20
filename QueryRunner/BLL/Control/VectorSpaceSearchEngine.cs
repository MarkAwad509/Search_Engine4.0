using QueryRunner.BLL.Model;
using QueryRunner.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace QueryRunner.BLL.Control
{
    public class VectorSpaceSearchEngine : AbstractSearchEngine
    {
        public override IList<string> runQuery(Query UserInput)
        {
            IList<double> queryVector = new List<double>();
            IList<double> documentVector = new List<double>();
            IDictionary<int, double> qResult = new Dictionary<int, double>();
            IList<string> results = new List<string>();
            CorpusDAO cdao = new CorpusDAO();
            Query query = UserInput;

            queryVector = query.buildQueryVector(UserInput);

            foreach (int Dn in iDAO.fetchAllDocumentsID())
            {
                documentVector = buildDocumentVector(Dn);
                double result = findCosinus(queryVector, documentVector);
                qResult.Add(Dn, result);
            }

            qResult=new DocumentRankingService(qResult).rankDocuments();

            foreach (int i  in qResult.Keys) 
                results.Add(i + " | " + cdao.fetchDocumentContentById(i));
            return results;
        }

        public IList<double> buildDocumentVector(int docId)
        {
            CorpusDAO cDAO = new CorpusDAO();
            IList<double> dVector = new List<double>();
            IList<string> docTerms = new List<string>(cDAO.fetchDocumentContentById(docId).Split(" "));
            docTerms = docTerms.Distinct().ToList();
            IList<string> allTerms = new List<string>(iDAO.fetchAllTerms().Values);
                foreach(string term in allTerms)
                {
                if (docTerms.Contains(term))
                    dVector.Add(iDAO.fetchWeight(iDAO.fetchTermIDByName(term), docId));
                else
                    dVector.Add(0.0000000000000001);
                }
            return dVector;
        }

        public double findCosinus(IList<double> queryVector, IList<double> documentVector)
        {
            return dotProduct(queryVector, documentVector) / (lengthOfVector(queryVector) * lengthOfVector(documentVector));
        }

        private double dotProduct(IList<double> queryVector, IList<double> documentVector)
        {
            double sum = 0;
            foreach (var term in queryVector)
                sum = sum + term * documentVector.IndexOf(term);

            return sum;
        }

        private double lengthOfVector(IList<double> vector)
        {
            double sum = 0;
            foreach (var term in vector)
                sum = sum + Math.Pow(sum, 2);

            return Math.Sqrt(sum);
        }
    }
}