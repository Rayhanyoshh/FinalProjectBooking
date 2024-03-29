﻿using HotelRealtaPayment.Domain.Dto;
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
        int insertBookingBySP(BookingOrders bookingOrders);
        int insertBookDetailBySP(BookingOrderDetail bookingOrderDetail);
        int insertBookExtraBySP(BookingOrderDetailExtra bookingOrderDetailExtra);
        Task<IEnumerable<Hotels>> FindFaciByHotelIdAsync(int id);
        IEnumerable<AccountUser> FindAccountByUserId(int id);

        UserMembers findUserByBoorId(int id);
        Users findUserById(int id);
        Hotels FindFacilitiesByFacId(int facilitiesId);
    }
}
