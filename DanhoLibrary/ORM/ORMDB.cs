using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DanhoLibrary.ORM
{
    public class ORMDB
    {
        private string Data_Source { get; set; }
        private string Initial_Catalog { get; set; } 
        private bool Trusted_Connection { get; set; } = true;

        public ORMDB(string databaseName, string dataSource = "DANIEL-SIMONSEN\\MASTERRUNEUWU")
        {
            Initial_Catalog = databaseName;
            Data_Source = dataSource;
        }

        private T Connect<T>(string statement, Func<SqlCommand, T> callback)
        {
            string connectionString = 
                $"Data Source={Data_Source};" + 
                $"Initial Catalog={Initial_Catalog};" + 
                $"Trusted_Connection={Trusted_Connection};";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            T result = callback(new SqlCommand(statement, conn));
            conn.Close();
            return result;
        }

        public int Execute(string statement) => Connect(statement, cmd => cmd.ExecuteNonQuery());

        public List<object> Query(string statement) => Connect(statement, cmd =>
        {
            using SqlDataReader reader = cmd.ExecuteReader();
            List<object> result = new List<object>();
            int i = 0;
            while (reader.Read())
            {
                if (reader[i] != null)
                {
                    result.Add(reader[i]);
                    i++;
                }
            }
            return result;
        });
    }
}
