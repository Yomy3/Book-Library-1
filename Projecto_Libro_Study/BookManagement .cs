using Project_Book.Model;
using Project_Book.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;




namespace Projecto_Libro_Study
{
    public class BookManagement
    {
        public readonly IBookService _bookService = new BookService();
        public readonly IAuthorService _authorService = new AuthorService();
        public readonly IPublisherServices _publisherServices = new PublisherService();
        private bool exit;

        public void Run()
        {

            exit = false;
            do
            {
                Console.WriteLine("Welcome to Book Management: \n");
                Console.WriteLine("Press 1 to create a new book entry :");
                Console.WriteLine("Press 2 to get the desired book :");
                Console.WriteLine("Press 3 to get a list of all of the existing books :");
                Console.WriteLine("Press 4 to Update the book:");
                Console.WriteLine("Press 5 to Delete the desired book:");
                Console.WriteLine("Press 0 to exit the Program :");

                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)


                {
                    case 1:
                        Book book = CreateNewBook();
                        _bookService.Create(book);
                        Console.WriteLine("Keep in creating Authors Y/N ?");
                        char select = Convert.ToChar(Console.ReadLine());
                        break;
                    case 2:
                        Book existingBook = RetrieveBookId();
                        Console.WriteLine(existingBook);
                        break;
                    case 3:
                        List<Book> todosLibros = _bookService.RetriveAll();
                        Console.WriteLine(JsonSerializer.Serialize(todosLibros));
                        break;
                    case 4:
                        Book ubook = UpdateBook();
                        _bookService.Update(ubook);
                        break;
                    case 5:
                        Book deleteBook = DeleteBook();
                        break;
                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine();
                        break;


                }


            } while (exit != true);

        }

        private Book DeleteBook()
        {
            Console.WriteLine(JsonSerializer.Serialize(_bookService.RetriveAll()));
            Console.WriteLine("Please enter the id of the book to select");
            int id = Convert.ToInt32(Console.ReadLine());
            _bookService.Delete(id);
            return null;
        }

        private Book UpdateBook()
        {
            Console.WriteLine(JsonSerializer.Serialize(_bookService.RetriveAll()));
            Console.WriteLine("Please enter the id of the book to Update");
            int updateid = Convert.ToInt32(Console.ReadLine());
            Book bookToUpdate = _bookService.Retrive(updateid);
            Console.WriteLine("Enter the new name for the Book");
            bookToUpdate.Title = Console.ReadLine();
            Console.WriteLine("Enter the new ISBN for the Book");
            bookToUpdate.ISBN = Console.ReadLine();
            Console.WriteLine("Enter the new date of creation for the book");
            bookToUpdate.Published = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Select the Author for the Book to Update");
            Author UpdatedAuthor = ChooseAuthor();
            bookToUpdate.Author = UpdatedAuthor;
            Console.WriteLine("Select the Publisher for the Book to Update");
            Publisher UpdatedPublisher = ChoosePublisher();
            bookToUpdate.Publisher = UpdatedPublisher;
            _bookService.Update(bookToUpdate);
            Console.WriteLine($"Book Updated Successfully {bookToUpdate}");

            return bookToUpdate;
        }

        public Book RetrieveBookId()
        {
            Console.WriteLine(JsonSerializer.Serialize(_bookService.RetriveAll()));
            Console.WriteLine("Please enter the id of the book to select");
            int bookid = Convert.ToInt32(Console.ReadLine());
            return _bookService.Retrive(bookid);
        }

        private Book CreateNewBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter the name of the book to create:");
            book.Title = Console.ReadLine();
            Console.WriteLine("Enter the book ISBN");
            book.ISBN = Console.ReadLine();
            Console.WriteLine("Enter the Publication Date");
            book.Published = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please select the Author of the Book");
            Author author = ChooseAuthor();
            book.Author = author;
            Console.WriteLine("Please select the Publisher of the Book");
            Publisher publisher = ChoosePublisher();
            book.Publisher = publisher;
            //TODO; Add Publisher


            //List<Author>allAuthors =_authorService.RetrieveAll();
            //Author author = new Author();
            //author.Name = Console.ReadLine();
            //Console.WriteLine("Please insert the date of birth of the author");
            //author.Birthday= Convert.ToDateTime(Console.ReadLine());
            //newbook.Author = author;
            /*Publisher publisher = new Publisher();
            Console.WriteLine("Please enter the name of the Publisher of the book");
            publisher.Name = Console.ReadLine();
            newbook.Publisher = publisher;*/
            Console.WriteLine($"Book created successfully: {book}");
            return book;
        }

        private Publisher ChoosePublisher()
        {
            Console.WriteLine(JsonSerializer.Serialize(_publisherServices.RetriveAll()));
            Console.WriteLine("Please insert the ID of the Publisher");
            int publisherId = Convert.ToInt32(Console.ReadLine());
            return _publisherServices.Retrive(publisherId);
        }

        private Author ChooseAuthor()
        {
            Console.WriteLine(JsonSerializer.Serialize(_authorService.RetrieveAll()));
            Console.WriteLine("Please insert the ID of the Author");
            int authorId = Convert.ToInt32(Console.ReadLine());
            return _authorService.Retrive(authorId);
        }
    }

}