using Project_Book.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Book.Repository
{
    public class AuthorRepositorySQL : IAuthorRepository
    {
        public Author Create(Author myauthor)
        {
            string sql = $"INSERT INTO Author (name, birthday) VALUES ('{myauthor.Name}', '{myauthor.Birthday}');";
            SQL.ExecuteNonQuery(sql);
            int maxId = SQL.GetMax("author", "id");
            return Retrive(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELTE FROM Author WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Author Retrive(int id)
        {
            string sql = $"SELECT * FROM Author WHERE id= {id}";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Author with Id: {id} not found.");
        }

        public List<Author> RetriveAll()
        {
            string sql = $"SELECT * FROM Author;";
            SqlDataReader reader = SQL.Execute(sql);
            List<Author> authors = new List<Author>();
            while (reader.Read())
            {
                authors.Add(Parse(reader));
            }
            return authors;
        }

        public Author Update(Author myauthor)
        {
            string sql = $"UPDATE author SET name = '{myauthor.Name}', birthday = '{myauthor.Birthday}' WHERE id = {myauthor.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrive(myauthor.Id);
            throw new NotImplementedException();
        }

        private Author Parse(SqlDataReader reader)
        {
            Author author = new Author
            {
                Id = Convert.ToInt32(reader["id"]),
                Name = Convert.ToString(reader["name"]),
                Birthday = Convert.ToDateTime(reader["birthday"])
            };
            return author;
        }
    }
}
