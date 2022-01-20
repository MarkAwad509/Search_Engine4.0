using QueryRunner.BLL.Control;
using QueryRunner.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.API
{
    public class VSSE_Proxy : ISearchEngine
    {
        ISearchEngine VSSE;

        public VSSE_Proxy()
        {
            this.VSSE= new VectorSpaceSearchEngine();
        }

        public IList<string> runQuery(Query query)
        {
            return this.VSSE.runQuery(query);

        }

    }
}
