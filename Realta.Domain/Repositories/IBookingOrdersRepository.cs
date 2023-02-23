using Realta.Domain.Entities;
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
        Task<IEnumerable<BookingOrders>> FindAllBookingOrdersAsync();
        BookingOrders FindBookingOrdersById(int id);
        void Insert(BookingOrders booking_Orders);
        void Edit(BookingOrders booking_Orders);
        void Remove(BookingOrders booking_Orders);
        IEnumerable<BookingOrders> FindLastBoorID();
    }
}