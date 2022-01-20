using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorpusBuilder.BLL.Model
{
    public class Corpus
    {
        //properties
        public IList<Document> Documents { get; set; }

        //ctor
        public Corpus()
        {
            this.Documents = new List<Document>();
        }
        public Corpus(IList<Document> documents)
        {
            this.Documents = documents;
        }

        //methods
        public IList<Document> findDocumentsByTerm(string Term)
        {
            IList<Document> documents = new List<Document>();

            foreach(var doc in Documents)
            {
                if (doc.contains(Term))
                    documents.Add(doc);
             }
            return documents;
        }

        public void addDocument(string text)
        {
            //Ajout du document à la liste de documents en mémoire.
            this.Documents.Add(new Document(text));

        }

        public override string ToString()
        {
            string text = "";

            foreach(Document doc in this.Documents)
            {
                text = text + doc.ToString()+ "\n";
            }
            return text;
        }
    }
}
