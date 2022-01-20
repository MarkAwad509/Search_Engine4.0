using System;
using CorpusBuilder.BLL.Model;
using IndexBuilder.BLL.Model;
using IndexBuilder.BLL.Controller;
using CorpusBuilder.DAL;
using CorpusBuilder.BLL.Controller;

namespace IndexBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            IDocumentDAO filedocument = new FileSystemDocumentDAO();
            Corpus corpus = CorpusService.buildCorpus(filedocument);
            SearchIndex index = IndexerService.buildIndex(corpus);

            Console.WriteLine(index.ToString());
        }
    }
}
