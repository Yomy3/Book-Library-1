using Project_Book.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Book.Model;
using System.Text.Json;

namespace Projecto_Libro_Study
{
    internal class AuthorManagement
    {
        public readonly IAuthorService _authorService = new AuthorService();
        public void Run()

        {   bool exit = false;

            do
            {
                Console.WriteLine("Welcome to the Author Management, please select the desired option : \n");
                Console.WriteLine("Press 1 to create a new Author entry :");
                Console.WriteLine("Press 2 to update an Author :");
                Console.WriteLine("Press 3 to get a list of all of the existing Author :");
                Console.WriteLine("Press 4 to delete a desired Author :");
                Console.WriteLine("Press 0 to go out of the Author Management :");
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1: 
                        Author author = new Author();
                        Console.WriteLine("Enter Author name:");
                        author.Name = Console.ReadLine();
                        Console.WriteLine("Enter Author date of birth:");
                        author.Birthday=Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine(author);
                        _authorService.Create(author);
                    break ; 
                    case 2:
                    break;
                    case 3:
                        List<Author> allAuthors = _authorService.RetrieveAll();
                        Console.WriteLine(JsonSerializer.Serialize(allAuthors));
                    break ;

                }
            } while (exit);
        }

    }
}
