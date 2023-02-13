using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Interface
{
    public interface IRepositoryBase <T>
    {
        IEnumerator<T> FindAll<T>(string sql);
        IEnumerator<T> FindByCondition<T>(SqlCommandModel model);
        IAsyncEnumerator<T> FindAllAsync<T>(SqlCommandModel model);
        void Create(SqlCommandModel model);
        void Update(SqlCommandModel model);
        void Delete(SqlCommandModel model);
    }
}
