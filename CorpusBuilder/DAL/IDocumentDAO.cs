using CorpusBuilder.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusBuilder.DAL
{
    public interface IDocumentDAO
    {
        public IList<Document> fetchAllDocuments();
    }
}