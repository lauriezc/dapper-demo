using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common.Entity;

namespace Model.Common
{
    public interface IDataStructure
    {
        List<Table> GetTables(string database);
        List<DbMethod> GetMethods();
        List<Parameter> GetParameters();
    }
}
