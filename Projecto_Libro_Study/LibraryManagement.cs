using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto_Libro_Study
{
    internal class LibraryManagement
    {
        public void Run()
        {
            Console.WriteLine("Welcome to my Library \n");

            bool exit = false;
            do
            {
                Console.WriteLine("Please select the desired option : \n");
                Console.WriteLine("Press 1 to go to the Author Management Section :");
                Console.WriteLine("Press 2 to go to Publisher Management:");
                Console.WriteLine("Press 3 to go to Book Management: ");
                Console.WriteLine("Press 0 to exit the Program ");


                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    //create del Book que al crearlo también creo el Author
                    case 1: AuthorManagement authorManagement = new AuthorManagement();
                        authorManagement.Run();
                       

                        break;

                    case 2: PublisherManagement publisherManagement = new PublisherManagement();
                        publisherManagement.Run();
                        break;

                    case 3:
                        BookManagement bookManagement = new BookManagement();
                        bookManagement.Run();
                        break;

                    case 4:
                        break;

                    case 0:
                        if (selection == 0)
                        { exit = true; }
                        break;
                }




            } while (!exit);
        }
    }
}
