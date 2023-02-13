using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBoexRepository
    {
        IEnumerable<Booking_order_detail_extra> FindAllBoex();
        Task<IEnumerable<Booking_order_detail_extra>> FindAllBoexAsync();
        Booking_order_detail_extra FindBoexById(int id);
        void Insert(Booking_order_detail_extra boex);
        void Edit(Booking_order_detail_extra boex);
        void Remove(Booking_order_detail_extra boex);
    }
}
