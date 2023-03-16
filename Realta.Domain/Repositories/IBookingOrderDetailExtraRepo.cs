using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBookingOrderDetailExtraRepo
    {
        IEnumerable<BookingOrderDetailExtra> FindAllBoex();
        Task<IEnumerable<BookingOrderDetailExtra>> FindAllBoexAsync();
        Task<IEnumerable<BookingOrderDetailExtra>> FindAllBoexByBoorId(int id);
        BookingOrderDetailExtra FindBoexById(int id);
        void Insert(BookingOrderDetailExtra boex);
        void Edit(BookingOrderDetailExtra boex);
        void Remove(BookingOrderDetailExtra boex);
    }
}
