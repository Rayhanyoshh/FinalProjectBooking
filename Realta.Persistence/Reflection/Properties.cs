using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Reflection
{
    public class Properties
    {
        public static PropertyInfo GetProperty<T>(string name)
        {
            return typeof(T).GetProperty(name);
        }
        public static T GetValue<T,U> (U source, string name)
        {
            return (T) GetProperty<U>(name).GetValue(source);
        }
        public static int GetFieldCount(DbDataRecord record)
        {
            return GetValue<int, DbDataRecord>(record, "FieldCount");
        }
    }
}
