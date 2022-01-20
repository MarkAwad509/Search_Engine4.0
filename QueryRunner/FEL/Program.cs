using System;
using QueryRunner.BLL.Model;
using QueryRunner.BLL.Control;
using QueryRunner.DAL;

namespace QueryRunner.FEL
{
    class Program
    {
        static void Main(string[] args)
        {
            CorpusDAO daoC = new CorpusDAO();
            IndexDAO daoI = new IndexDAO();
            ISearchEngine BBSe = new BasicBooleanSearch();
            ISearchEngine VSSe = new VectorSpaceSearchEngine();

            Query query = new Query("apple grapes");

            //Console.WriteLine("Basic Boolean search in progress..." + "\n" +
            //                                                          "\n" +
            //                  "Result(s) :");

            //foreach (var docsBBS in BBS.runQuery(r)) 
            //{
            //    Console.WriteLine(docsBBS);
            //}

            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Vector Space Search is in progress...");
            Console.Write("All documents: [");
            foreach (int i in daoI.fetchAllDocumentsID())
            {
                Console.Write("{0}, ", i);
            }
            Console.Write("]\n");

            Console.Write("All terms: [");
            foreach (var i in daoI.fetchAllTerms())
            {
                Console.Write("{0}, ", i.Key);
            }
            Console.Write("]\n");

            Console.Write("Query vector is: [");
            foreach (double i in query.buildQueryVector(query))
            {
                Console.Write(i + ", ");
            }
            Console.Write("]\n");

            foreach (var i in VSSe.runQuery(query))
            {
                Console.Write("Vector for document {0} is: [ " + i + ", ]");
            }
            //Console.Write("]");



            //Console.Write("Documents ID : [ ");
            //foreach (int i in daoI.fetchAllDocumentsID())
            //{
            //    Console.Write("{0}, ", i);
            //}
            //Console.Write(" ]");

            //Console.Write("Terms ID : [ ");
            //foreach (int i in daoI.fetchAllTerms().Keys)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.Write("]\n" +
            //              "Query vector is : [ ");

            //foreach (var docsVSS in VSS.runQuery(query)) 
            //{
            //    Console.WriteLine(docsVSS);
            //}
        }
    }
}
