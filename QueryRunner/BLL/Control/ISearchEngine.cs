using QueryRunner.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryRunner.BLL.Control
{
    public interface ISearchEngine
    {
        public IList<string> runQuery(Query UserInput);
    }
}