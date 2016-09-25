using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Entity
{
    public class DataBase
    {
        public string DataBaseName { get; set; }
        public DatabaseType DbType { get; set; }
        public string NameSpace { get; set; }
        public string ConnectionString { get; set; }
    }

    public enum DatabaseType
    {
        SQLServer=0,
        MySql=1
    }

    public static class DbNameFormater
    {
        public static string FormatDbName(this string name,DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.MySql:
                    return string.Format("`{0}`", name);
                case DatabaseType.SQLServer:
                    return string.Format("[{0}]", name);
                default:
                    return name;
            }
        }
    }
}
