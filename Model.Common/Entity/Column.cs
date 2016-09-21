using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Entity
{
    public class Column
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public object Default { get; set; }
        public bool IsNullable { get; set; }
        public string DataType { get; set; }
        public int? CharacterMaxLength { get; set; }
        public int? NumbericPrecision { get; set; }
        public int? DatetimePrecision { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrease { get; set; }

    }
}
