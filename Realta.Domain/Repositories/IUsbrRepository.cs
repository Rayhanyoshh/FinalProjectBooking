using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface IUsbrRepository
    {
        IEnumerable<User_breakfast> FindAllUsbr();
        Task<IEnumerable<User_breakfast>> FindAllUsbrAsync();
        User_breakfast FindUsbrById(int id);
        void Insert(User_breakfast usbr);
        void Edit(User_breakfast usbr);
        void Remove(User_breakfast usbr);
    }
}
