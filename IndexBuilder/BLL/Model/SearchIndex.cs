using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusBuilder.BLL.Model;

namespace IndexBuilder.BLL.Model
{
    class SearchIndex
    {
        public IDictionary<string,IList<Posting>> Postings { get; set; }

        public SearchIndex()
        {
            this.Postings = new SortedDictionary<string,IList<Posting>>();
        }
        public SearchIndex(IDictionary<string, IList<Posting>> postings)
        {
            this.Postings = postings;
        }

        public IList<Posting> fetchPosting(string term)
        {
            if (this.Postings.ContainsKey(term))
            {
                return this.Postings[term];
            }
            else { return null; }
        }

        public override string ToString()
        {
            string text = "";

            foreach (string key in this.Postings.Keys)
            {
                text += $"{key}:\n";
                foreach (var posting in this.Postings[key]) {
                    text += posting.ToString();
                    text += "\n";
                }
                text += "\n";
            }
            return text;
        }
    }
}