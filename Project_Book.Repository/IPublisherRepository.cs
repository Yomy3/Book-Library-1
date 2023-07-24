using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public interface IPublisherRepository
    {
        Publisher Create(Publisher mypublisher);

        Publisher Retrive(int id);

        List<Publisher> RetriveAll();

        Publisher Update(Publisher mypublisher);

        void Delete(int id);

    }
}
