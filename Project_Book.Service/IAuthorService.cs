using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Book.Model;
using Project_Book.Repository;



namespace Project_Book.Service
{
    public interface IAuthorService
    {
        Author Create(Author myauthor);
        Author Update(Author myauthor);

        Author Retrive(int id);

        List<Author> RetrieveAll();

        void Delete(int id);



    }
}
