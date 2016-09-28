using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common.Entity;
using System.Data.SqlClient;

namespace Model.Common
{
    public class SQLServerDataStructure : IDataStructure
    {
        private string _connectionString { get; set; }
        public SQLServerDataStructure(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public List<DbMethod> GetMethods()
        {
            throw new NotImplementedException();
        }

        public List<Parameter> GetParameters()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetTables(string database)
        {
            string sql = "SELECT c.TABLE_CATALOG,c.TABLE_SCHEMA,c.TABLE_NAME,c.COLUMN_NAME,c.ORDINAL_POSITION,c.COLUMN_DEFAULT,c.IS_NULLABLE,c.DATA_TYPE,c.CHARACTER_MAXIMUM_LENGTH,c.CHARACTER_OCTET_LENGTH,c.NUMERIC_PRECISION,c.NUMERIC_SCALE,c.DATETIME_PRECISION,c.CHARACTER_SET_NAME,tv.TYPE,";
            sql += " (SELECT COUNT(0) FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS T JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K";
            sql += " ON T.TABLE_NAME = K.TABLE_NAME ";
            sql += " AND T.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG ";
            sql += " AND T.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA ";
            sql += " AND T.CONSTRAINT_NAME = K.CONSTRAINT_NAME ";
            sql += " WHERE T.CONSTRAINT_TYPE = 'PRIMARY KEY' ";
            sql += " AND K.COLUMN_NAME = c.COLUMN_NAME ";
            sql += " AND K.TABLE_NAME = c.TABLE_NAME ";
            sql += " AND K.TABLE_CATALOG = c.TABLE_CATALOG) AS ISPRIMARYKEY,COLUMNPROPERTY(OBJECT_ID(c.TABLE_NAME),c.COLUMN_NAME,'IsIdentity') AS ISAUTOINCREASE ";
            sql += " from (SELECT TABLE_SCHEMA,TABLE_NAME,1 AS TYPE FROM information_schema.TABLES WHERE TABLE_CATALOG='{0}' UNION SELECT TABLE_SCHEMA,TABLE_NAME,0 AS TYPE FROM information_schema.VIEWS WHERE TABLE_CATALOG='{0}') tv LEFT JOIN information_schema.COLUMNS c ON tv.TABLE_NAME=c.TABLE_NAME;";
            sql = string.Format(sql, database);

            List<Table> tbList = new List<Table>();
            using (SqlConnection con = new SqlConnection(this._connectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = string.Format(sql, database);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var db = reader["TABLE_SCHEMA"].ToString();
                    var tableName = reader["TABLE_NAME"].ToString();
                    var type = Convert.ToInt32(reader["TYPE"]);
                    var tableCatalog = reader["TABLE_CATALOG"].ToString();
                    Table tb = tbList.FirstOrDefault(m => m.DatabaseName == db && m.TableName == tableName);
                    if (tb == null)
                    {
                        tb = new Table();
                        tb.DatabaseName = db;
                        tb.TableName = tableName;
                        tb.Type = type;
                        tb.TableCatalog = tableCatalog;
                        tb.Columns = new List<Column>();
                        tbList.Add(tb);
                    }
                    var column = new Column();
                    column.DatabaseName = reader["TABLE_SCHEMA"].ToString();
                    column.TableName = reader["TABLE_NAME"].ToString();
                    column.Name = reader["COLUMN_NAME"].ToString();
                    column.Order = Convert.ToInt64(reader["ORDINAL_POSITION"]);
                    column.Default = reader["COLUMN_DEFAULT"];
                    column.IsNullable = reader["IS_NULLABLE"].ToString().ToLower() == "yes" ? true : false;
                    column.DataType = reader["DATA_TYPE"].ToString();
                    if (reader["CHARACTER_MAXIMUM_LENGTH"] != null && !string.IsNullOrEmpty(reader["CHARACTER_MAXIMUM_LENGTH"].ToString()))
                        column.CharacterMaxLength = Convert.ToInt64(reader["CHARACTER_MAXIMUM_LENGTH"]);
                    if (reader["NUMERIC_PRECISION"] != null && !string.IsNullOrEmpty(reader["NUMERIC_PRECISION"].ToString()))
                        column.NumbericPrecision = Convert.ToInt64(reader["NUMERIC_PRECISION"]);
                    if (reader["DATETIME_PRECISION"] != null && !string.IsNullOrEmpty(reader["DATETIME_PRECISION"].ToString()))
                        column.DatetimePrecision = Convert.ToInt64(reader["DATETIME_PRECISION"]);
                    column.IsAutoIncrease = Convert.ToInt32(reader["ISAUTOINCREASE"]) > 0 ? true : false;
                    column.IsPrimaryKey = Convert.ToInt32(reader["ISPRIMARYKEY"]) > 0 ? true : false;
                    tb.Columns.Add(column);
                }
            }
            return tbList;
        }
    }
}
