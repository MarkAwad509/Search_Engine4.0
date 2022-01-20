using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQA.BLL.Model;

namespace XQA.DAL
{
    public class CorpusDAO
    {
        public CorpusDAO() { }
        public IList<Document> findAllDocuments()
        {
            return SearchEngineRepository.GetInstance().Documents;
        }

        public IList<Document> findDocumentsByTerm(string term)
        {
            return (from d in SearchEngineRepository.GetInstance().Documents 
                    where d.Name.Contains(term)
                    select d).ToList();
        }

        public IList<Document> findDocumentsByMinLength(int minLength) {
            return (from d in SearchEngineRepository.GetInstance().Documents
                    where (d.Name.Split(' ').Length > minLength) //
                    select d).ToList();
        }

        public IList<Document> fetchAllDocuments()
        {
            return (from d in SearchEngineRepository.GetInstance().Documents
                    select d).ToList();
        }

        public IList<Term> fetchAllTerms()
        {
            return (from t in SearchEngineRepository.GetInstance().Terms
                    select t).ToList();
        }
    }
}
