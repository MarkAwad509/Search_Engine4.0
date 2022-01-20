using QueryRunner.BLL.Model;
using QueryRunner.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRunner.BLL.Control
{
    public abstract class AbstractSearchEngine : ISearchEngine
    {
        public IndexDAO iDAO = new IndexDAO();
        public Query query { get; set; }
        public abstract IList<string> runQuery(Query UserInput);
    }
}