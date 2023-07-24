using Project_Book.Model;
using Project_Book.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository= new AuthorRepositorySQL();
        public Author Create(Author author)
        {
            return _authorRepository.Create(author); ;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> RetrieveAll()
        {
            return _authorRepository.RetriveAll();
        }

        public Author Retrive(int id)
        {
            return _authorRepository.Retrive(id);
        }

        public Author Update(Author myauthor)
        {
            throw new NotImplementedException();
        }
    }
}
