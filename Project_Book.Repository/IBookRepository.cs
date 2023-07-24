using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public interface IBookRepository
    {
        Book Create(Book mybook);
        Book Retrive(int id);

        List<Book> RetriveAll();

        Book Update(Book mybook);

        void Delete(int id);
       
    }
}
