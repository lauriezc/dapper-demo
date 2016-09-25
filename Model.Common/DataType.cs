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
                _sqlDataType.Add("tinyint", "Byte");
                _sqlDataType.Add("int", "int");
                _sqlDataType.Add("bigint", "long");
                _sqlDataType.Add("datetime", "DateTime");
                _sqlDataType.Add("bit", "bool");
                _sqlDataType.Add("double", "double");
                _sqlDataType.Add("float", "float");
                _sqlDataType.Add("decimal", "decimal");
                _sqlDataType.Add("char", "string");
                _sqlDataType.Add("varchar", "string");
                _sqlDataType.Add("timestamp", "TimeSpan");
                _sqlDataType.Add("tinytext", "string");
                _sqlDataType.Add("text", "string");
                _sqlDataType.Add("mediumtext", "string");
                _sqlDataType.Add("longtext", "string");
                return _sqlDataType;
            }
        }
    }
}
