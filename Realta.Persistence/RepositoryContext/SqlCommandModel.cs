using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.RepositoryContext
{
    public class SqlCommandModel
    {
        public string CommandText { get; set; }
        public CommandType CommandType { get; set; }
        public SqlCommandParameterModel[] CommandParameters { get; set; }

    }
}
