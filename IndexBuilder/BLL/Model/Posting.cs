using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusBuilder.BLL.Model;


namespace IndexBuilder.BLL.Model
{
    class Posting
    {

        public string Term { get; set; }
        public IList<int> Positions { get; set; }
        public double Weight { get; set; }
        public Document Document { get; set; }

        public Posting(string term,Corpus corpus,Document document)
        {
            this.Term = term;
            this.Document = document;
            this.Positions = document.findPositions(term);
            this.Weight = tfidf(term,corpus);
            
        }

        private double tf(string term)
        {
            return this.Document.findOccurences(term) / (double)this.Document.Length;
        }


        private double idf(String term,Corpus corpus)
        {
            double count = 0;
            foreach(Document doc in corpus.Documents)
            {
                foreach(var termInDoc in doc.Terms)
                {
                    if (termInDoc == term) count++;
                }
            }

            return Math.Log(corpus.Documents.Count/(count+1));
        }

        public double tfidf(string term,Corpus corpus)
        {
            return tf(term) * idf(term, corpus);
        }

        public override string ToString()
        {
            string text = $"Document={this.Document.Id} Weight={this.Weight} Term={this.Term}\n";
            text += $"({String.Join(",", Positions)})";
            return text;
        }
    }
}