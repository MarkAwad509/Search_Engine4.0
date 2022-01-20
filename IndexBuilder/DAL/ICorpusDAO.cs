using CorpusBuilder.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexBuilder.DAL
{
    interface ICorpusDAO
    {
       
        public Corpus fetchCorpus();
    }
}
