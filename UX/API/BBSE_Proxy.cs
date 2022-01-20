using QueryRunner.BLL.Control;
using QueryRunner.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.API
{
    class BBSE_Proxy : ISearchEngine
    {
        ISearchEngine BSSE;

        public BBSE_Proxy()
        {
            this.BSSE = new BasicBooleanSearch();
        }

        public IList<string> runQuery(Query query)
        {
            return this.BSSE.runQuery(query);
        }

    }
}
