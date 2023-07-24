using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public interface IAuthorRepository
    {
        Author Create(Author myauthor);
        Author Retrive(int id);
        List<Author> RetriveAll();
        Author Update(Author myauthor);

        void Delete(int id);
    }
}
