using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DanhoLibrary.SQL
{
    public class Table
    {
        #region Properties
        /// <summary>
        /// Name of Table
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Columns in table
        /// </summary>
        public Column[] Columns;

        /// <summary>
        /// Connection from database to database server
        /// </summary>
        public readonly SqlConnection Connection;
        #endregion

        #region Constructor
        public Table(string name, Column[] columns)
        {
            Name = name;
            Columns = columns;
            Create();
        }
        /// <summary>
        /// Do NOT use - meant for <see cref="Database"/> to modify!
        /// </summary>
        internal Table(string name, Column[] columns, string dbName) : this(name, columns) => Connection = new SqlConnection(
                new SqlConnectionStringBuilder() { DataSource = @".", InitialCatalog = dbName, IntegratedSecurity = true }.InitialCatalog);
        #endregion

        /// <summary>
        /// Returns list of rows
        /// </summary>
        /// <returns></returns>
        public List<T> GetDataList<T>(string command)
        {
            using (IDbConnection connection = Connection)
            {
                List<T> DataList = new List<T>();
                connection.Open();
                DataList.AddRange(connection.Query<T>(command).AsList());
                connection.Close();

                return DataList;
            }
        }
        public List<T> GetDataList<T>() => GetDataList<T>($"SELECT * FROM {Name}").AsList();
        /// <summary>
        /// Establishes connection to database and runs <paramref name="command"/> as a query
        /// </summary>
        /// <param name="command">SQL command</param>
        /// <returns></returns>
        public int ExecuteQuery(string command)
        {
            if (Connection is null) return -1;
            using (Connection)
            {
                Connection.Open();
                var cmd = new SqlCommand(command).ExecuteNonQuery();
                Connection.Close();
                return cmd;
            }
        }
        public string[] ExecuteReader(string command)
        {
            using (Connection)
            {
                Connection.Open();
                SqlDataReader reader = new SqlCommand(command).ExecuteReader();

                string[] result = new string[reader.FieldCount];
                for (int x = 0; x < reader.FieldCount; x++)
                    result[x] = reader.GetString(x);

                Connection.Close();
                return result;
            }
        }

        #region SQL Commands
        /// <summary>
        /// Adds <paramref name="column"/> to table
        /// </summary>
        /// <param name="column"></param>
        public void Alter(Column column) => ExecuteQuery($"ALTER TABLE {Name} ADD {column.ToString()}");

        /// <summary>
        /// Same thing as <see cref="Alter(Column)"/>
        /// </summary>
        /// <param name="column"></param>
        public void AddColumn(Column column) => Alter(column);

        /// <summary>
        /// Creates a new table in database, defined by <see cref="Name"/> & <see cref="Columns"/>
        /// </summary>
        public void Create() => ExecuteQuery($"CREATE TABLE {Name}({ConsoleItems.ToString(true, Columns)});");

        /// <summary>
        /// Calls <see cref="Drop"/>, then <see cref="Create"/>
        /// </summary>
        public void Recreate() { Drop(); Create(); }

        /// <summary>
        /// Inserts a new row into table
        /// </summary>
        /// <param name="Values">Values of table</param>
        public void InsertInto(string Values) => ExecuteQuery($"INSERT INTO {Name} VALUES {Values}");

        /// <summary>
        /// Deletes table
        /// </summary>
        public void Drop() => ExecuteQuery($"DROP TABLE {Name}");
        #endregion
    }
}
