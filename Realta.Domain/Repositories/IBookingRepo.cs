using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBookingRepo
    {
        //IEnumerable<Hotels> FindAllHotels();
        int insertBookingBySP(BookingOrders bookingOrders);
        int insertBookDetailBySP(BookingOrderDetail bookingOrderDetail);
        int insertBookExtraBySP(BookingOrderDetailExtra bookingOrderDetailExtra);
        //int insertSpclOfferCouponBySP(SpecialOfferCoupons specialOfferCoupons);


    }
}
