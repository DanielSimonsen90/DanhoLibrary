using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DanhoLibrary.SQL
{
    public class Database
    {
        public Table this[string name] => Tables.Find(x => x.Name == name);

        /// <summary>
        /// Database name
        /// </summary>
        public string Name;

        /// <summary>
        /// Tables in database
        /// </summary>
        public Table[] Tables;

        /// <summary>
        /// Connection from database to database server
        /// </summary>
        public SqlConnection Connection => Tables?[0].Connection;

        /// <summary>
        /// Ripoff version of hard SQL stuff
        /// </summary>
        /// <param name="dBName">Name of Database</param>
        /// <param name="tables">Tables in database</param>
        public Database(string dBName, params Table[] tables)
        {
            Name = dBName;
            Tables = SetTables(tables);
        }

        /// <summary>
        /// Sets the tables from constructor to know <see cref="Name"/> to create Tables[x].Connection so we can steal that .Connection and use it as <see cref="Connection"/>
        /// </summary>
        /// <param name="Tables">Tables from constructor</param>
        /// <returns></returns>
        private Table[] SetTables(params Table[] Tables)
        {
            Table[] InternalTables = new Table[Tables.Length];
            for (int x = 0; x < Tables.Length; x++)
                InternalTables[x] = new Table(Tables[x].Name, Tables[x].Columns, Name);
            return InternalTables;
        }
    }
}
