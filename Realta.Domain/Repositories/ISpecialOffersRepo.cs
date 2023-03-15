using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realta.Domain.RequestFeatures;

namespace Realta.Domain.Repositories
{
    public interface ISpecialOffersRepo
    {
        IEnumerable<SpecialOffers> FindAllSpof();
        Task<IEnumerable<SpecialOffers>> FindAllSpofAsync();
        Task<IEnumerable<SpecialOffers>> GetSpofPaging(SpecialOfferParameters specialOfferparameters);
        Task<PagedList<SpecialOffers>> GetSpofPageList(SpecialOfferParameters specialOfferparameters);
        SpecialOffers FindSpofById(int id);
        void Insert(SpecialOffers spof);
        void Edit(SpecialOffers spof);
        void Remove(SpecialOffers spof);
    }
}
