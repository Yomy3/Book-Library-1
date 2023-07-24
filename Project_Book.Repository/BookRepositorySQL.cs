
using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;

namespace Project_Book.Repository
{
    public class BookRepositorySQL : IBookRepository
    {
        public Book Create(Book book)
        {
            string sql = $"INSERT INTO Book (title, isbn, published, author_id, publisher_id) VALUES ('{book.Title}', '{book.ISBN}', '{book.Published}', {book.Author.Id}, {book.Publisher.Id});";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("book", "id");
            return Retrive(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM Book WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }



        public Book Retrive(int id)// Hacerle un INNER JOIN tambien para que me muestre los nombres de los autores y los publicadores
        {
            string sql = $"SELECT book.id as book_id, title, isbn, available, published, author_id, publisher_id, author.name as author_name, author.birthday as author_DOB, publisher.name as publisher_name FROM Book  INNER JOIN Publisher ON book.publisher_id = publisher.id INNER JOIN Author ON book.author_id = author.id WHERE book.id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Livro de Id: {id} não encontrado.");
        }

        public List<Book> RetriveAll()
        {

            string sql = $"SELECT book.id as book_id, title, isbn, available, published,author_id,publisher_id, author.name as author_name, author.birthday as author_DOB, publisher.name as publisher_name FROM Book INNER JOIN Publisher ON book.publisher_id = publisher.id INNER JOIN Author ON book.author_id = author.id;";
            SqlDataReader reader = SQL.Execute(sql);
            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                books.Add(Parse(reader));
            }
            return books;
        }

        public Book Update(Book book)
        {
            string sql = $"UPDATE Book SET title = '{book.Title}', isbn = '{book.ISBN}', published = '{book.Published}' WHERE id = {book.Id};";

            SQL.ExecuteNonQuery(sql);
            return Retrive(book.Id);
        }



        private Book Parse(SqlDataReader reader)
        {
            Book book = new Book
            {
                Id = Convert.ToInt32(reader["book_id"]),
                Title = Convert.ToString(reader["title"]),
                ISBN = Convert.ToString(reader["isbn"]),
                Published = Convert.ToDateTime(reader["published"]),
                Available = Convert.ToInt32(reader["available"])
                
            };
            Publisher p = new Publisher
            {
                Id = Convert.ToInt32(reader["publisher_id"]),
                Name = Convert.ToString(reader["publisher_name"])

            };

            Author a = new Author
            {
                Id = Convert.ToInt32(reader["author_id"]),
                Name = Convert.ToString(reader["author_name"]),
                Birthday = Convert.ToDateTime(reader["author_DOB"])

            };
            book.Author = a;
            book.Publisher = p; 
            return book;
        }

    }
}
