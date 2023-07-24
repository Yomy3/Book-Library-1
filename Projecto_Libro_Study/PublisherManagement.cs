using Project_Book.Model;
using Project_Book.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace Projecto_Libro_Study
{
    internal class PublisherManagement
    {
        public readonly IPublisherServices _publisherServices = new PublisherService();
        
        public void Run()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome to the Publisher Management, please select the desired option : \n");
                Console.WriteLine("Press 1 to create a new Publisher entry :");
                Console.WriteLine("Press 2 to update an Publisher :");
                Console.WriteLine("Press 3 to get a list of all of the existing Publisher:");
                Console.WriteLine("Press 4 to delete a desired Publisher :");
                Console.WriteLine("Press 0 to go out of the Publisher Management :");
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection) 
                { 
                    case 1:
                        Publisher publisher = new Publisher();
                        Console.WriteLine("Enter the ne Publisher name:");
                        publisher.Name = Console.ReadLine();
                        _publisherServices.Create(publisher);
                        Console.WriteLine(publisher);
                    break;
                    case 2:
                    break; 
                    case 3:
                        List<Publisher> allPublishers = _publisherServices.RetriveAll();
                        Console.WriteLine(JsonSerializer.Serialize(allPublishers));
                     break;

                }
            }while (exit);

        }
    }
}
