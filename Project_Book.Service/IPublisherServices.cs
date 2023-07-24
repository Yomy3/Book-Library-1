using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Book.Repository;


namespace Project_Book.Service
{
  
    public interface IPublisherServices
    {
        Publisher Create(Publisher mypublisher);

        Publisher Retrive(int id);

        Publisher Update(Publisher mypublisher);

        List<Publisher> RetriveAll();

        void Delete(int id);

    }
}
