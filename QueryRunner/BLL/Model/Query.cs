using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryRunner.BLL.Control;
using QueryRunner.DAL;

namespace QueryRunner.BLL.Model
{
    public class Query
    {
        public string Text { get; set; }
        public IList<string> Terms { get; set; }
        public AbstractSearchEngine ASearchEngine { get; set; }

        public Query(string text)
        {
            this.Text = text;
            this.Terms = new List<string>(text.Split(" "));
        }

        public IList<double> buildQueryVector(Query UserInput)
        {
            IList<double> qVector = new List<double>();
            IndexDAO iDAO = new IndexDAO();

            foreach (var pair in iDAO.fetchAllTerms())
            {
                if (UserInput.Terms.Contains(pair.Value))
                    qVector.Add(1);
                else qVector.Add(0);
            }
            return qVector;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
