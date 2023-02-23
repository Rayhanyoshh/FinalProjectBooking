using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface ISpecialOfferCouponsRepo
    {
        IEnumerable<SpecialOfferCoupons> FindAllSoco();
        Task<IEnumerable<SpecialOfferCoupons>> FindAllSocoAsync();
        SpecialOfferCoupons FindSocoById(int id);
        void Insert(SpecialOfferCoupons soco);
        void Edit(SpecialOfferCoupons soco);
        void Remove(SpecialOfferCoupons soco);
    }
}
