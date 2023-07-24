using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Book.Service
{
    public interface IBookService
    {
        Book Create(Book mybook);
        Book Retrive(int id );
        Book Update(Book mybook);

        List<Book> RetriveAll();

        void Delete(int id);
        
    }
}