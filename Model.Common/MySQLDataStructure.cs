using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model.Common.Entity;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model.Common
{
    public class MySqlDataStructure : IDataStructure
    {
        private string _connectionString { get; set; }
        public MySqlDataStructure(string connectionString)
        {
            this._connectionString = connectionString;
        }
        private string _tableSQL = "SELECT c.`TABLE_SCHEMA`,c.`TABLE_NAME`,c.`COLUMN_NAME`,c.`ORDINAL_POSITION`,c.`COLUMN_DEFAULT`,c.`IS_NULLABLE`,c.`DATA_TYPE`,c.`CHARACTER_MAXIMUM_LENGTH`,c.`CHARACTER_OCTET_LENGTH`,c.`NUMERIC_PRECISION`,c.`NUMERIC_SCALE`,c.`DATETIME_PRECISION`,c.`CHARACTER_SET_NAME`,c.`COLUMN_KEY`,c.`EXTRA`,t.TABLE_TYPE from   information_schema.`COLUMNS` c LEFT JOIN information_schema.`TABLES` t ON t.TABLE_NAME=c.TABLE_NAME  WHERE c.`TABLE_SCHEMA`='{0}'";
        private string _procedureSQL = "SELECT `SPECIFIC_SCHEMA`,`SPECIFIC_NAME`,`ORDINAL_POSITION`,`PARAMETER_MODE`,`PARAMETER_NAME`,`DATA_TYPE`,`CHARACTER_MAXIMUM_LENGTH`,`CHARACTER_OCTET_LENGTH`,`NUMERIC_PRECISION`,`NUMERIC_SCALE`,`DATETIME_PRECISION`,`CHARACTER_SET_NAME`,`DTD_IDENTIFIER`,`ROUTINE_TYPE` FROM information_schema.PARAMETERS WHERE SPECIFIC_SCHEMA='DAPPER-TEST';";


        public List<Table> GetTables(string database)
        {
            List<Table> tbList = new List<Table>();
            using (MySqlConnection con = new MySqlConnection(this._connectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = string.Format(_tableSQL,database);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var db = reader["TABLE_SCHEMA"].ToString();
                    var tableName = reader["TABLE_NAME"].ToString();
                    var type = reader["TABLE_TYPE"].ToString()== "BASE TABLE"?(int)TableType.DataTable:(int)TableType.DataView;
                    Table tb = tbList.FirstOrDefault(m => m.DatabaseName == db && m.TableName == tableName);
                    if (tb == null)
                    {
                        tb = new Table();
                        tb.DatabaseName = db;
                        tb.TableName = tableName;
                        tb.Type = type;
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
                    if (reader["CHARACTER_MAXIMUM_LENGTH"]!=null&&!string.IsNullOrEmpty(reader["CHARACTER_MAXIMUM_LENGTH"].ToString()))
                        column.CharacterMaxLength = Convert.ToInt64(reader["CHARACTER_MAXIMUM_LENGTH"]);
                    if (reader["NUMERIC_PRECISION"] != null&&!string.IsNullOrEmpty(reader["NUMERIC_PRECISION"].ToString()))
                        column.NumbericPrecision = Convert.ToInt64(reader["NUMERIC_PRECISION"]);
                    if (reader["DATETIME_PRECISION"] != null&&!string.IsNullOrEmpty(reader["DATETIME_PRECISION"].ToString()))
                        column.DatetimePrecision = Convert.ToInt64(reader["DATETIME_PRECISION"]);
                    column.IsAutoIncrease = reader["EXTRA"].ToString().ToLower().IndexOf("auto_increment") > -1 ? true : false;
                    column.IsPrimaryKey = reader["COLUMN_KEY"].ToString().ToLower().IndexOf("pri") > -1 ? true : false;
                    tb.Columns.Add(column);
                    //c.`TABLE_SCHEMA`,
                    //c.`TABLE_NAME`,
                    //c.`COLUMN_NAME`,
                    //c.`ORDINAL_POSITION`,
                    //c.`COLUMN_DEFAULT`,
                    //c.`IS_NULLABLE`,
                    //c.`DATA_TYPE`,
                    //c.`CHARACTER_MAXIMUM_LENGTH`,
                    //c.`CHARACTER_OCTET_LENGTH`,
                    //c.`NUMERIC_PRECISION`,
                    //c.`NUMERIC_SCALE`,
                    //c.`DATETIME_PRECISION`,
                    //c.`CHARACTER_SET_NAME`,
                    //c.`COLUMN_TYPE`,
                    //c.`COLUMN_KEY`,
                    //c.`EXTRA` 

                }
            }
            return tbList;
        }

        public List<DbMethod> GetMethods()
        {
            throw new NotImplementedException();
        }

        public List<Parameter> GetParameters()
        {
            throw new NotImplementedException();
        }
    }
}
