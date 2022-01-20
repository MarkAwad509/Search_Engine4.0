using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQA.BLL.Model;

namespace XQA.DAL
{
    public class SearchEngineRepository
    {
        private static SearchEngineRepository Instance = null;
        public IList<Document> Documents { get; set; }
        public IList<Term> Terms { get; set; }
        public IList<Posting> Postings { get; set; }

        private SearchEngineRepository()
        {
            populate();
        }

        public static SearchEngineRepository GetInstance() {
            if (Instance == null)
                Instance = new SearchEngineRepository();
            return Instance;
        }

        private void populate()
        {
            this.Documents = new List<Document>();
            this.Documents.Add(new Document(1, "apple apple orange kiwi apple"));
            this.Documents.Add(new Document(2, "kiwi orange orange kiwi"));
            this.Documents.Add(new Document(3, "grapes grapes apple"));
            this.Documents.Add(new Document(4, "kiwi kiwi orange orange apple"));

            this.Terms = new List<Term>();
            this.Terms.Add(new Term(1,"apple"));
            this.Terms.Add(new Term(2, "grapes"));
            this.Terms.Add(new Term(3, "kiwi"));
            this.Terms.Add(new Term(4, "orange"));

            Document doc = null; Term term = null;

            this.Postings = new List<Posting>();
            term = this.Terms.Where(t => t.Id == 1).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 1).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.1726d, new int[] {0,1,4}));

            term = this.Terms.Where(t => t.Id == 1).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 3).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.0958d, new int[] { 2}));

            term = this.Terms.Where(t => t.Id == 1).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 4).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.0575d, new int[] { 4 }));

            term = this.Terms.Where(t => t.Id == 2).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 3).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.9241d, new int[] { 0, 1}));

            term = this.Terms.Where(t => t.Id == 3).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 1).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.0575d, new int[] { 3 }));

            term = this.Terms.Where(t => t.Id == 3).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 2).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.1438d, new int[] { 0, 3 }));

            term = this.Terms.Where(t => t.Id == 3).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 4).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.115d, new int[] { 0, 1 }));

            term = this.Terms.Where(t => t.Id == 4).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 1).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.0575d, new int[] { 2 }));

            term = this.Terms.Where(t => t.Id == 4).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 2).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.1438d, new int[] { 1, 2 }));

            term = this.Terms.Where(t => t.Id == 4).SingleOrDefault();
            doc = this.Documents.Where(d => d.Id == 4).SingleOrDefault();
            this.Postings.Add(new Posting(term.Id, doc.Id, 0.115d, new int[] { 2, 3 }));

        }

    }
}
