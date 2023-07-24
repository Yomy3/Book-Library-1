using System;
using System.Data.SqlClient;

namespace Project_Book.Repository
{
    internal class SQL
    {
        private static readonly string _connectionString = @"Server=db.assembly.pt;Database=JD_YV_YR_Library;Trusted_Connection=True;User Id=Students;Password=SkillUpForTomorrow;Integrated Security=False;";
        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        private static bool _isClosed = true;

        public static SqlDataReader Execute(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int GetMax(string tableName, string columnName)
        {
            string sql = $"SELECT MAX({columnName}) as MAX_ID FROM {tableName};";
            SqlDataReader dataReader = Execute(sql);
            if (dataReader.Read())
            {
                return Convert.ToInt32(dataReader["MAX_ID"]);
            }
            return -1;
        }
        private static void HangUpCall()
        {
            if (_isClosed)
            {
                _sqlConnection.Open();
                _isClosed = !_isClosed;
            }
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }
    }
}
