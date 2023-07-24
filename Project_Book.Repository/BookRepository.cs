using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Project_Book.Model;


namespace Project_Book.Repository
{
    public class BookRepository : IBookRepository
    {

        private static List<Book> _books = new List<Book>();
        private static int _id = 1;


        public Book Create(Book mybook)
        {
            mybook.Id = _id;
            _id++;
            _books.Add(mybook);
            return mybook;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Retrive(int id)
        {
            foreach (Book b in _books)
            {
                if (b.Id == id)
                {
                    return b;
                }
            }
            return null;
        }

        public List<Book> RetriveAll()
        {
            return _books;
        }

        public Book Update(Book book)
        {

            foreach (Book b in _books)
            {
                if (b.Id == book.Id)
                {
                    b.Title = book.Title;
                    b.ISBN = book.ISBN;
                    b.Published = book.Published;
                    b.Author = book.Author;
                    b.Publisher = book.Publisher;
                    return b;
                }
            }
            return null;
        } 
    }
}
