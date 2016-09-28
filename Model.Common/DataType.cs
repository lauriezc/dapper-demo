using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Model.Common
{
    public class DataType
    {
        private Hashtable _mySqlDataType;
        public Hashtable MySqlDataType
        {
            get
            {
                _mySqlDataType = new Hashtable();
                _mySqlDataType.Add("bit", "bool");
                _mySqlDataType.Add("tinyint", "sbyte");
                _mySqlDataType.Add("smallint", "short");
                _mySqlDataType.Add("mediumint", "int");
                _mySqlDataType.Add("int", "int");
                _mySqlDataType.Add("integer", "int");
                _mySqlDataType.Add("bigint", "long");
                _mySqlDataType.Add("real", "double");
                _mySqlDataType.Add("double", "double");
                _mySqlDataType.Add("float", "float");
                _mySqlDataType.Add("decimal", "decimal");
                _mySqlDataType.Add("numeric", "decimal");
                _mySqlDataType.Add("char", "string");
                _mySqlDataType.Add("varchar", "string");
                _mySqlDataType.Add("binary", "byte[]");
                _mySqlDataType.Add("varbinary", "byte[]");
                _mySqlDataType.Add("date", "DateTime");
                _mySqlDataType.Add("time", "TimeSpan");
                _mySqlDataType.Add("datetime", "DateTime");
                _mySqlDataType.Add("timestamp", "DateTime");
                _mySqlDataType.Add("year", "short");
                _mySqlDataType.Add("tinyblob", "byte[]");
                _mySqlDataType.Add("blob", "byte[]");
                _mySqlDataType.Add("longblob", "byte[]");
                _mySqlDataType.Add("mediumblob", "byte[]");
                _mySqlDataType.Add("tinytext", "string");
                _mySqlDataType.Add("text", "string");
                _mySqlDataType.Add("mediumtext", "string");
                return _mySqlDataType;
            }
        }
        /*
        public bool bit { get; set; }
        public sbyte tinyint { get; set; }
        public short smallint { get; set; }
        public int mediumint { get; set; }
        public int @int { get; set; }
        public int integer { get; set; }
        public long bigint { get; set; }
        public double real { get; set; }
        public double @double { get; set; }
        public float @float { get; set; }
        public decimal @decimal { get; set; }
        public decimal numeric { get; set; }
        public string @char { get; set; }
        public string varchar { get; set; }
        public byte[] binary { get; set; }
        public byte[] varbinary { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan time { get; set; }
        public System.DateTime datetime { get; set; }
        public System.DateTime timestamp { get; set; }
        public short year { get; set; }
        public byte[] binyblob { get; set; }
        public byte[] blob { get; set; }
        public byte[] mediumblob { get; set; }
        public byte[] longblob { get; set; }
        public string tinytext { get; set; }
        public string text { get; set; }
        public string mediumtext { get; set; }
        */

        private Hashtable _sqlDataType;

        public Hashtable SqlDataType
        {
            get
            {
                _sqlDataType = new Hashtable();
                #region
                _sqlDataType = new Hashtable();
                _sqlDataType.Add("bigint", "long");
                _sqlDataType.Add("binary", "byte[]");
                _sqlDataType.Add("bit", "bool");
                _sqlDataType.Add("char", "string");
                _sqlDataType.Add("date", "DateTime");
                _sqlDataType.Add("datetime", "DateTime");
                _sqlDataType.Add("datetime2", "DateTime");
                _sqlDataType.Add("datetimeoffset", "DateTimeOffset");
                _sqlDataType.Add("decimal", "decimal");
                _sqlDataType.Add("float", "double");
                _sqlDataType.Add("image", "byte[]");
                _sqlDataType.Add("int", "int");
                _sqlDataType.Add("money", "decimal");
                _sqlDataType.Add("nchar", "string");
                _sqlDataType.Add("ntext", "string");
                _sqlDataType.Add("numeric", "decimal");
                _sqlDataType.Add("nvarchar", "string");
                _sqlDataType.Add("real", "float");
                _sqlDataType.Add("smalldatetime", "DateTime");
                _sqlDataType.Add("smallint", "short");
                _sqlDataType.Add("smallmoney", "decimal");
                _sqlDataType.Add("text", "string");
                _sqlDataType.Add("time", "TimeSpan");
                _sqlDataType.Add("timespan", "byte[]");
                _sqlDataType.Add("tinyint", "byte");
                _sqlDataType.Add("uniqueidentifier", "Guid");
                _sqlDataType.Add("varbinary", "byte[]");
                _sqlDataType.Add("varchar", "string");
                _sqlDataType.Add("xml", "string");
                return _sqlDataType;
                #endregion
                /*public long bigint { get; set; }
        public byte[] binary { get; set; }
        public Nullable<bool> bit { get; set; }
        public string @char { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public Nullable<System.DateTime> datetime2 { get; set; }
        public Nullable<System.DateTimeOffset> datetimeoffset { get; set; }
        public Nullable<decimal> @decimal { get; set; }
        public Nullable<double> @float { get; set; }
        public byte[] image { get; set; }
        public Nullable<int> @int { get; set; }
        public Nullable<decimal> money { get; set; }
        public string nchar { get; set; }
        public string ntext { get; set; }
        public Nullable<decimal> numeric { get; set; }
        public string nvarchar { get; set; }
        public Nullable<float> real { get; set; }
        public Nullable<System.DateTime> smalldatetime { get; set; }
        public Nullable<short> smallint { get; set; }
        public Nullable<decimal> smallmoney { get; set; }
        public string text { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<byte> tinyint { get; set; }
        public Nullable<System.Guid> uniqueidentifier { get; set; }
        public byte[] varbinary { get; set; }
        public string varchar { get; set; }
        public string xml { get; set; }
                 */
            }
        }
    }
}
