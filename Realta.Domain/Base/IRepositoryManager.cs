using Realta.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Base
{
    public interface IRepositoryManager
    {
        IBookingOrdersRepository bookingOrdersRepository { get; }

        IBookingOrderDetailRepo bordeRepository { get; }

        IBookingOrderDetailExtraRepo boexRepository { get; }

        ISpecialOfferCouponsRepo socoRepository { get; }
        ISpecialOffersRepo spofRepository { get; }
        IUserBreakfastRepo usbrRepository { get; }
        
    }
}
