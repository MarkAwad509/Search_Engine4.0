using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQA.BLL.Model;

namespace XQA.DAL
{
    public class IndexDAO
    {
        public IndexDAO() { }

        public IList<Posting> findPostingsByTerm(string term, float minWeight)
        {
            return (from p in SearchEngineRepository.GetInstance().Postings
                    join t in SearchEngineRepository.GetInstance().Terms on p.TermId equals t.Id
                    where term.Contains(t.Text) && minWeight < p.Weight
                    select p).ToList();
        }

        public int findTotalNumberOfOccurencesByTermId(int termId) 
        {
            return (from p in SearchEngineRepository.GetInstance().Postings
                    where termId == p.TermId
                    select p.Positions).Count();
        }

        //method to test using xUnit
        public int findNumberOfDocumentsByTermIdUsingLinq(int termId)
        {
            return (from p in SearchEngineRepository.GetInstance().Postings
                    where p.TermId == termId
                    select p.DocId).Count();
        }

        //method to test using xUnit
        public int findNumberOfDocumentsByTermIdUsingLambda(int termId)
        {
            return SearchEngineRepository.GetInstance().Postings
                .Where(p => p.TermId == termId)
                .Select(p => p.DocId)
                .Count();
        }

        public IList<Posting> fetchAllPostings()
        {
            return (from p in SearchEngineRepository.GetInstance().Postings
                    select p).ToList();
        }
    }
}
