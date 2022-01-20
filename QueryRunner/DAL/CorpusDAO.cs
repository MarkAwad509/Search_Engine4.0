using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QueryRunner.DAL
{
    class CorpusDAO
    {
        private MySqlConnectionStringBuilder Builder { get; set; }
        private MySqlConnection Connection { get; set; }
        private MySqlCommand Command { get; set; }
        private DataSet ds { get; set; }

        public CorpusDAO()
        {
            this.Builder = new MySqlConnectionStringBuilder
            {
                Server = "mysql-cs2zb.alwaysdata.net",
                UserID = "cs2zb",
                Password = "BlueSpot2001",
                Database = "cs2zb_searchdb",
            };
            this.Connection = new MySqlConnection(this.Builder.ConnectionString);
            this.Command = Connection.CreateCommand();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            ds = new DataSet();
            Connection.Open();

            //get Document table from db server
            Command = new MySqlCommand("SELECT * FROM cs2zb_searchdb.Documents", Connection);
            adapter.SelectCommand = Command;
            ds.Tables.Add("Documents");
            adapter.Fill(ds.Tables["Documents"]);

            //get Terms table from db server
            Command = new MySqlCommand("SELECT * FROM cs2zb_searchdb.Terms", Connection);
            adapter.SelectCommand = Command;
            ds.Tables.Add("Terms");
            adapter.Fill(ds.Tables["Terms"]);

            //get Postings table from db server
            /*Command = new MySqlCommand("SELECT * FROM cs2zb_searchdb.Postings", Connection);
            adapter.SelectCommand = Command;
            ds.Tables.Add("Postings");
            adapter.Fill(ds.Tables["Postings"]);*/

            Connection.Close();

            //Next Step : Code Fill (fill dataset)
            //Mount db in memory
            //Check TD and Notes to load database
            //FetchById with dataset (TD06 EX4)
            //MySql, not Sql
        }

        public string fetchDocumentContentById(int docId)
        {
                DataTable documentTable = ds.Tables["Documents"];
            foreach (DataRow row in documentTable.Rows)
                if (Convert.ToString(docId).Equals(row["docId"].ToString()))
                    return row["text"].ToString();
            return null;
        }

        
    }
}
