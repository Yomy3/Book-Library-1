using Project_Book.Model;
using Project_Book.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Service
{
    public class PublisherService : IPublisherServices
    {
        private readonly IPublisherRepository _publisherRepository = new PublisherRepositorySQL();
        public Publisher Create(Publisher mypublisher)
        {
            return _publisherRepository.Create(mypublisher);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Publisher Retrive(int id)
        {
            return _publisherRepository.Retrive(id);
        }

        public List<Publisher> RetriveAll()
        {
            return _publisherRepository.RetriveAll();
        }

        public Publisher Update(Publisher mypublisher)
        {
            throw new NotImplementedException();
        }
    }
}
