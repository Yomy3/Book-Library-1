using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public class PublisherRepositorySQL : IPublisherRepository
    {
        public Publisher Create(Publisher mypublisher)
        {
            string sql = $"INSERT INTO Publisher (name) VALUES ('{mypublisher.Name}')";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("publisher", "id");
            return Retrive(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELTE FROM Publisher WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Publisher Retrive(int id)
        {
            string sql = $"SELECT * FROM Publisher WHERE id= {id}";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Publisher with Id: {id} not found.");
        }



        public List<Publisher> RetriveAll()
        {
            string sql = $"SELECT * FROM Publisher;";
            SqlDataReader reader = SQL.Execute(sql);
            List<Publisher> publisher = new List<Publisher>();
            while (reader.Read())
            {
                publisher.Add(Parse(reader));
            }
            return publisher;
        }

        public Publisher Update(Publisher mypublisher)
        {
            string sql = $"UPDATE publisher SET name = '{mypublisher.Name}',  WHERE id = {mypublisher.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrive(mypublisher.Id);
            throw new NotImplementedException();
        }

        private Publisher Parse(SqlDataReader reader)
        {
            Publisher publisher = new Publisher
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"])
            };
            return publisher;
        }
    }

}
