using CorpusBuilder.BLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorpusBuilder.DAL
{
    public class FileSystemDocumentDAO : IDocumentDAO
    {
        public static string DATA_PATH = "";


        public FileSystemDocumentDAO()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            FileSystemDocumentDAO.DATA_PATH = projectDirectory + "\\CorpusBuilder\\DL";
        }
        public IList<Document> fetchAllDocuments()
        {
            IList<Document> documents = new List<Document>();
            string[] filePaths = Directory.GetFiles(DATA_PATH, "*.txt");
            foreach (string file in filePaths)
            {
                string text = retrieveFileContent(file);
                documents.Add(new Document(text));
            }
            return documents;
        }


        private string retrieveFileContent(string file)
        {
            string text = "";
            try
            {
                using (var sr = new StreamReader(file))
                {
                    text = sr.ReadToEnd();
                    return text;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }
    }
}
