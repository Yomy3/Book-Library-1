using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private static List<Publisher> _publisherList = new List<Publisher>();
        private static int _id = 1;                                        

        public Publisher Create(Publisher mypublisher)
        {
            mypublisher.Id = _id;
            _id++;
            _publisherList.Add(mypublisher);
            return mypublisher;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Publisher> RetriveAll()
        {
            return _publisherList;
        }

        public Publisher Retrive(int id)
        {
            foreach (Publisher publisher in _publisherList)
            {
                if (publisher.Id == id)
                { return publisher; }
            }return null;
        }

        public Publisher Update(Publisher mypublisher)
        {
            throw new NotImplementedException();
        }
    }
}
