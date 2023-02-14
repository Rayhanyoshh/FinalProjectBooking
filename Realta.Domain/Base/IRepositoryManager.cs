using Realta.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Base
{
    public interface IRepositoryManager
    {
        IBookingOrdersRepository bookingOrdersRepository { get; }

        IBordeRepository bordeRepository { get; }

        IBoexRepository boexRepository { get; }
    }
}
