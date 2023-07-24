using Project_Book.Model;
using Project_Book.Repository;
using System;
using System.Collections.Generic;

namespace Project_Book.Service
{
    public class BookService : IBookService
    {

        //private IBookRepository _bookRepository = new BookRepository();
        private readonly IBookRepository _bookRepository = new BookRepositorySQL();
        public Book Create(Book mybook)
        {
            return _bookRepository.Create(mybook);
        }

        public Book Retrive(int id)
        {
            return _bookRepository.Retrive(id);
        }

        public List<Book> RetriveAll()
        {
            return _bookRepository.RetriveAll();
        }

        public Book Update(Book mybook)
        {
            return _bookRepository.Update(mybook);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
