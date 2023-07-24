using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Model
{
    public class Publisher
    {
        public int Id { set; get; }
        public string Name { get; set; }


        public override string ToString()
        {
            return "Publisher Name:\t" + Name + "";
        }
    }
}
 