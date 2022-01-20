using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusBuilder.BLL.Model;

namespace IndexBuilder.DAL
{
    class CorpusDAO:ICorpusDAO
    {
        public Corpus Corpus { get; set; }

        public CorpusDAO(Corpus corpus)
        {
            this.Corpus = corpus;
        }

        public CorpusDAO()
        {
        }

        public Corpus fetchCorpus()
        {
            return this.Corpus;
        }
    }
}