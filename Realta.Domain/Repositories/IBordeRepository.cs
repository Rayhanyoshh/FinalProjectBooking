using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBordeRepository
    {
        IEnumerable<Booking_order_detail> FindAllBorde();
        Task<IEnumerable<Booking_order_detail>> FindAllBordeAsync();
        Booking_order_detail FindBordeById(int id);
        void Insert(Booking_order_detail borde);
        void Edit(Booking_order_detail borde);
        void Remove(Booking_order_detail borde);
    }
}
