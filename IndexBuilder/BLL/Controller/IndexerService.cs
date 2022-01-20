using CorpusBuilder.BLL.Model;
using IndexBuilder.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndexBuilder.DAL;


namespace IndexBuilder.BLL.Controller
{
    class IndexerService
    {
        public static SearchIndex buildIndex(Corpus corpus)
        {
            IDictionary<string, IList<Posting>> postings = new SortedDictionary<string, IList<Posting>>();
            foreach(Document d in corpus.Documents)
            {
                foreach(string term in d.Terms)
                {
                    if (postings.ContainsKey(term))
                    {
                        if (postings[term].Any(p => p.Document.Id == d.Id)) continue;
                        postings[term].Add(new Posting(term, corpus, d));
                    }
                    else
                    {
                        IList<Posting> postingA = new List<Posting>();
                        postingA.Add(new Posting(term, corpus, d));
                        postings.Add(term, postingA);
                    }
                }
            }
            return new SearchIndex(postings);
        }

        public IList<Posting> getPosting(string term, Document doc)
        {
            throw new NotImplementedException();
        }
    }
}
