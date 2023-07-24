using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private static List<Author> _authors = new List<Author>();
        private static int _id = 1;

        public Author Create(Author myauthor)
        {

            myauthor.Id = _id;
            _id++;
            _authors.Add(myauthor);
            return myauthor;


        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Author Retrive(int id)
        {
           foreach (Author author in _authors) 
            {
              if (author.Id == id)
                { return author; }
            }
            return null;
        }

        public List<Author> RetriveAll()
        {
            return _authors;
        }

        public Author Update(Author myauthor)
        {
            throw new NotImplementedException();
        }


    }
}
