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
        private Hashtable _sqlDataType;
        public Hashtable SqlDataType
        {
            get {
                _sqlDataType = new Hashtable();
                _sqlDataType.Add("bit", "bool");
                _sqlDataType.Add("tinyint", "sbyte");
                _sqlDataType.Add("smallint", "short");
                _sqlDataType.Add("mediumint", "int");
                _sqlDataType.Add("int", "int");
                _sqlDataType.Add("integer", "int");
                _sqlDataType.Add("bigint", "long");
                _sqlDataType.Add("real", "double");
                _sqlDataType.Add("double", "double");
                _sqlDataType.Add("float", "float");
                _sqlDataType.Add("decimal", "decimal");
                _sqlDataType.Add("numeric", "decimal");
                _sqlDataType.Add("char", "string");
                _sqlDataType.Add("varchar", "string");
                _sqlDataType.Add("binary", "byte[]");
                _sqlDataType.Add("varbinary", "byte[]");
                _sqlDataType.Add("date", "DateTime");
                _sqlDataType.Add("time", "TimeSpan");
                _sqlDataType.Add("datetime", "DateTime");
                _sqlDataType.Add("timestamp", "DateTime");
                _sqlDataType.Add("year", "short");
                _sqlDataType.Add("tinyblob", "byte[]");
                _sqlDataType.Add("blob", "byte[]");
                _sqlDataType.Add("longblob", "byte[]");
                _sqlDataType.Add("mediumblob", "byte[]");
                _sqlDataType.Add("tinytext", "string");
                _sqlDataType.Add("text", "string");
                _sqlDataType.Add("mediumtext", "string");
                return _sqlDataType;
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
    }
}
