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
        IBookingRepo bookingRepo { get; }

        IBookingOrdersRepository bookingOrdersRepository { get; }

        IBookingOrderDetailRepo bookingOrderDetailRepository { get; }

        IBookingOrderDetailExtraRepo bookingOrderDetailExtraRepository { get; }

        ISpecialOfferCouponsRepo specialOfferCouponsRepository { get; }
        ISpecialOffersRepo specialOffersRepository { get; }
        IUserBreakfastRepo userBreakfastRepository { get; }
        
    }
}
