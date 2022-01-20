using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQA.BLL.Model
{
    public class Document
    {
        public int Id { get; }
        public string Name { get; } 
        public Document(int id, string aName)
        {
            this.Id = id;
            this.Name = aName;
        }
    }
}
