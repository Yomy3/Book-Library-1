using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        

        public override string ToString()
        {
            return "Author Name:"+Name+" Birthday:"+Birthday+"";
        }

    }
}
