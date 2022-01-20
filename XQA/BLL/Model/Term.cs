using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQA.BLL.Model
{
    public class Term
    {
        public int Id { get; }
        public string Text { get; }
        public Term(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}
