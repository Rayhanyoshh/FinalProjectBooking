using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Services.Abstraction
{
    public interface IServiceManager
    {
        IBookingService BookingService { get; } 
    }
}
