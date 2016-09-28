using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Entity
{
    public class Table
    {
        public string DatabaseName { get; set; }
        public string TableCatalog { get; set; }
        public string TableName { get; set; }
        public int Type { get; set; }
        public List<Column> Columns { get; set; }
    }

    public enum TableType
    {
        DataView = 0,
        DataTable =1
    }
}
