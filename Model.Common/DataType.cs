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
        private Hashtable _MysqlDataType;
        public Hashtable MysqlDataType
        {
            get {
                _MysqlDataType = new Hashtable();
                _MysqlDataType.Add("tinyint", "Byte");
                _MysqlDataType.Add("int", "int");
                _MysqlDataType.Add("bigint", "long");
                _MysqlDataType.Add("datetime", "DateTime");
                _MysqlDataType.Add("bit", "bool");
                _MysqlDataType.Add("double", "double");
                _MysqlDataType.Add("float", "float");
                _MysqlDataType.Add("decimal", "decimal");
                _MysqlDataType.Add("char", "string");
                _MysqlDataType.Add("varchar", "string");
                _MysqlDataType.Add("timestamp", "TimeSpan");
                _MysqlDataType.Add("tinytext", "string");
                _MysqlDataType.Add("text", "string");
                _MysqlDataType.Add("mediumtext", "string");
                _MysqlDataType.Add("longtext", "string");
                return _MysqlDataType;
            }
        }

    }
}
