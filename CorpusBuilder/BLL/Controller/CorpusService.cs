using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusBuilder.BLL.Model;
using CorpusBuilder.DAL;

namespace CorpusBuilder.BLL.Controller
{
    public class CorpusService
    {
        //methods
        public static Corpus buildCorpus(IDocumentDAO dao)
        {
            
            Corpus corpus = new Corpus(dao.fetchAllDocuments());
            return corpus;
        }
    }
}