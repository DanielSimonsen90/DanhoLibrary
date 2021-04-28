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
            this.Initial_Catalog = databaseName;
            this.Data_Source = dataSource;
        }

        private void Connect(string statement, Action<SqlCommand> callback)
        {
            string connectionString = 
                $"Data Source={Data_Source};" + 
                $"Initial Catalog={Initial_Catalog};" + 
                $"Trusted_Connection={Trusted_Connection};";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            callback(new SqlCommand(statement, conn));
            conn.Close();
        }

        public int Execute(string statement)
        {
            int result = -1;
            Connect(statement, cmd => { result = cmd.ExecuteNonQuery(); });
            return result;
        }
        public List<object> Query(string statement)
        {
            List<object> result = new List<object>();
            Connect(statement, cmd =>
            {
                using SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    if (reader[i] != null)
                    {
                        result.Add(reader[i]);
                        i++;
                    }
                }
            });

            return result;
        }
    }
}
