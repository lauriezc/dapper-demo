using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Entity
{
    public class DbMethod
    {
        public string DatabaseName { get; set; }
        public string MethodName { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
