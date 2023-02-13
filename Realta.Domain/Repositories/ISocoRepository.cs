using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface ISocoRepository
    {
        IEnumerable<Special_offer_coupons> FindAllSoco();
        Task<IEnumerable<Special_offer_coupons>> FindAllSocoAsync();
        Special_offer_coupons FindSocoById(int id);
        void Insert(Special_offer_coupons soco);
        void Edit(Special_offer_coupons soco);
        void Remove(Special_offer_coupons soco);
    }
}
