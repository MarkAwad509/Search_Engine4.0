using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueryRunner.BLL.Control;
using MySql.Data.MySqlClient;
using System.Data;

namespace QueryRunner.DAL
{
    public class IndexDAO
    {
        MySqlConnectionStringBuilder builder;
        MySqlConnection connection;
        MySqlCommand command;
        public AbstractSearchEngine searchEngine {get; set;}

        public IndexDAO()
        {
            this.builder = new MySqlConnectionStringBuilder
            {
                Server = "mysql-cs2zb.alwaysdata.net",
                UserID = "cs2zb",
                Password = "BlueSpot2001",
                Database = "cs2zb_searchdb",
            };
            this.connection = new MySqlConnection(this.builder.ConnectionString);
            this.command = connection.CreateCommand();
        }

        public IList<int> fetchAllDocumentsID()
        {
            IList<int> allId = new List<int>();
            string queryString = "SELECT docId FROM cs2zb_searchdb.Documents";
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 foundId = reader.GetInt32("docId");
                allId.Add(foundId);
            }
            connection.Close();
            return allId;
        }

        public IDictionary<int,string> fetchAllTerms()
        {
            IDictionary<int, string> allterms = new Dictionary<int, string>();
            string queryString = "SELECT * FROM cs2zb_searchdb.Terms";
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int foundId = reader.GetInt32("termId");
                string foundName = reader.GetString("name");
                allterms.Add(foundId, foundName);
            }
            connection.Close();
            return allterms;
        }

        public IList<int> fetchDocumentIdByTerm(string term)
        {
            IList<int> Documents = new List<int>();
            string queryString = "SELECT *  FROM cs2zb_searchdb.Documents WHERE text regexp '(^|[[:space:]])" + term + "([[:space:]]|$)'";
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int foundId = reader.GetInt32("docId");
                Documents.Add(foundId);
            }
            connection.Close();
            return Documents;
        }

        public string fetchTermNameByID(int termID)
        {
            string queryString = "SELECT name FROM cs2zb_searchdb.Terms WHERE termId=" + termID.ToString();
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string foundText = reader.GetString("name");
            connection.Close();
            return foundText;
        }

        public int fetchTermIDByName(string term)
        {
            string queryString = "SELECT termId FROM cs2zb_searchdb.Terms WHERE name=\"" + term + "\"";
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int foundId = reader.GetInt32("termId");
            connection.Close();
            return foundId;
        }

        public float fetchWeight(int termID, int docID)
        {
            string queryString = "SELECT weight FROM cs2zb_searchdb.Postings WHERE termId=" + termID.ToString() + " AND docId=" + docID.ToString();
            command.CommandText = queryString;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            float foundweight = reader.GetFloat("weight");
            connection.Close();
            return foundweight;
        }
    }
}
