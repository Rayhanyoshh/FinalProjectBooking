using Realta.Domain.Repositories;
using Realta.Persistence.Base;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Repositories
{
    public class Price_ItemsRepository :RepositoryBase<Price_Items> ,IPrice_ItemsRepository
    {
        public Price_ItemsRepository(AdoDbContext adoContext) : base(adoContext)
        {
        }

        public IEnumerable<Price_Items> FindAllPrice_Items()
        {
            IEnumerator<Price_Items> dataset = FindAll<Price_Items>("SELECT * FROM master.Price_items ORDER BY prit_id;");

            while (dataset.MoveNext())
            {
                var data = dataset.Current;
                yield return data;
            }
        }

    }
}
