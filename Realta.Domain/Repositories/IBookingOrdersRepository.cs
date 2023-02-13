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
        IEnumerable<Booking_orders> FindAllBookingOrders();
        Task<IEnumerable<Booking_orders>> FindAllBookingOrdersAsync();
        Booking_orders FindBookingOrdersById(int id);
        void Insert(Booking_orders booking_Orders);
        void Edit(Booking_orders booking_Orders);
        void Remove(Booking_orders booking_Orders);
        IEnumerable<Booking_orders> FindLastBoorID();
    }
}