using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IBookingOrderDetailRepo
    {
        IEnumerable<BookingOrderDetail> FindAllBorde();
        Task<IEnumerable<BookingOrderDetail>> FindAllBordeAsync();
        BookingOrderDetail FindBordeById(int id);
        int GetBordeDetailSequenceId();
        void Insert(BookingOrderDetail borde);
        void Edit(BookingOrderDetail borde);
        void Remove(BookingOrderDetail borde);
    }
}
