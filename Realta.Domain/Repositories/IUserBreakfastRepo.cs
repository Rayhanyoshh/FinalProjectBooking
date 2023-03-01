using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IUserBreakfastRepo
    {
        IEnumerable<UserBreakfast> FindAllUsbr();
        Task<IEnumerable<UserBreakfast>> FindAllUsbrAsync();
        UserBreakfast FindUsbrByIdDate(int usbr_borde_id, DateTime date);
        void Insert(UserBreakfast usbr);
        void Edit(UserBreakfast usbr);
        void Remove(UserBreakfast usbr);
    }
}
