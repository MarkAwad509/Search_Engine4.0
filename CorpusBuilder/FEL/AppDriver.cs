using System;
using CorpusBuilder.DAL;
using CorpusBuilder.BLL.Model;
using CorpusBuilder.BLL.Controller;
using System.Collections.Generic;

namespace CorpusBuilder
{
    public class AppDriver
    {
        public static void Main(string[] args)
        {
            //Oublie pas
            IDocumentDAO dao = new InMemoryDocumentDAO();
            Corpus corpus = CorpusService.buildCorpus(dao);

            foreach(Document d in dao.fetchAllDocuments())
            {
                Console.WriteLine(d);
            }
            //Console.WriteLine(corpus.ToString());

            //corpus.addDocument("Test ceci est un texte ecrit");

            //Console.WriteLine(corpus.ToString());
            
            

        }
        
    }
}