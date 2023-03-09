using Realta.Domain.Entities;
using Realta.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBookingOrdersRepository
    {
        IEnumerable<BookingOrders> FindAllBookingOrders();
        IEnumerable<Hotels> FindAllHotels();
        Task<IEnumerable<BookingOrders>> FindAllBookingOrdersAsync();
        Task<IEnumerable<BookingOrders>> GetBookingOrdersPaging(BookingOrdersParameters bookingOrdersParameters);
        Task<PageList<BookingOrders>> GetBookingOrderPageList(BookingOrdersParameters bookingOrdersParameters);
        Task<PageList<Hotels>> GetHotelPageList(HotelParameters hotelParameters);
        BookingOrders FindBookingOrdersById(int id);
        BookingOrdersNestedDetail GetBookingDetail(int id);
        void Insert(BookingOrders booking_Orders);
        void Edit(BookingOrders booking_Orders);
        void Remove(BookingOrders booking_Orders);
        IEnumerable<BookingOrders> FindLastBoorID();
    }
}