using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQA.BLL.Model
{
    public class Posting
    {
        public int DocId{ get; set; }

        public int TermId { get; set; }
        public IList<int> Positions { get; set; }
        public double Weight { get; set; }

        public Posting(int termId, int docId, double weight, IList<int> positions)
        {
            this.TermId = termId;
            this.DocId = docId;
            this.Weight = weight;
            this.Positions = positions;
        }

        public override string ToString()
        {
            string positions = string.Join("-", this.Positions.Select(p => p.ToString()));
            return $"doc={this.DocId}," +
                $"term={this.TermId}," +
                $"weight={this.Weight}," +
                $"positions={positions})";
        }
    }
}
