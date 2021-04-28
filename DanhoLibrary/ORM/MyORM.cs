using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static DanhoLibrary.ORM.Types;

namespace DanhoLibrary.ORM
{
    public abstract partial class MyORM : ICRUD
    {
        public Dictionary<string, Field> this[string tableName] => TableCheck(tableName);
        protected abstract ORMDB DB { get; set; }

        public int ID { get; set; } = 0;
        public abstract string TableName { get; }

        public ICRUD CreateTable()
        {
            //Table exists
            try
            {
                if (DB.Query($"SELECT * FROM {TableName}")[0] == null) throw new Exception("No table found");
                return this;
            }
            catch (Exception) { }

            Field primaryKey = primaryKeys[TableName];
            string pkName = string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this[TableName])
            {
                if (kvp.Value.Equals(primaryKey)) pkName = kvp.Key;
                sb.Append($", {kvp.Key} {kvp.Value.SQLType} {(kvp.Value.Equals(primaryKey) ? "IDENTITY(1, 1)" : "")}");
            }

            string columns = sb.ToString()[2..];

            DB.Execute($"CREATE TABLE {TableName} ({columns}, PRIMARY KEY ({pkName}))");
            return this;
        }
        public ICRUD Insert()
        {
            StringBuilder fields = new StringBuilder(),
                values = new StringBuilder();
            Field pk = primaryKeys[TableName];

            foreach (var kvp in this[TableName])
            {
                if (kvp.Value.Equals(pk)) continue;

                fields.Append($", {kvp.Key}");
                values.Append($", {kvp.Value.GetSQLValue(this)}");
            }

            DB.Execute($"INSERT INTO {TableName} ({fields.ToString()[2..]}) VALUES ({values.ToString()[2..]})");
            return this;
        }
        public ICRUD Select(int primaryKey)
        {
            List<object> result = DB.Query($"SELECT * FROM {TableName} WHERE {GetPrimaryKey().Key} = {primaryKey}");
            MyORM lookingFor = result.Find(i => (i as MyORM).ID == primaryKey) as MyORM;

            var keys = this[TableName];
            foreach (var kvp in keys)
                this[TableName][kvp.Key].SetValue(this, this[TableName][kvp.Key].GetSQLValue(lookingFor));
            return this;
        }
        public ICRUD Update()
        {
            Field primaryKey = primaryKeys[TableName];
            string pkName = string.Empty;
            string pkValue = primaryKey.GetSQLValue(this);

            StringBuilder sb = new StringBuilder();

            foreach (var kvp in this[TableName])
                if (kvp.Value.Equals(primaryKey)) pkName = kvp.Key;
                else sb.Append($", {kvp.Key} = {kvp.Value.GetSQLValue(this)}");

            DB.Execute($"UPDATE {TableName} SET {sb.ToString()[2..]} WHERE {pkName} = {pkValue}");
            return this;
        }
        public ICRUD Delete()
        {
            var kvp = GetPrimaryKey();
            DB.Execute($"DELETE FROM {TableName} WHERE {kvp.Key} = {kvp.Value.GetSQLValue(this)}");
            return this;
        }

        private KeyValuePair<string, Field> GetPrimaryKey()
        {
            Field primaryKey = primaryKeys[TableName];

            foreach (var kvp in this[TableName])
                if (kvp.Value.Equals(primaryKey))
                    return kvp;
            return new KeyValuePair<string, Field>();
        }
    }
}