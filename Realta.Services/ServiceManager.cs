
using Realta.Domain.Base;
using Realta.Services;
using Realta.Services.Abstraction;
using Realta.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookingService> _bookingService;
        public ServiceManager()
        {
        }
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _bookingService=new Lazy<IBookingService>(()=>new BookingService(repositoryManager));
            //_lazyProductPhotoServices = new Lazy<IProductPhotoServices>(() => new ProductPhotoServices(repositoryManager, _lazyUtilityService));
            //_lazySupplierServices = new Lazy<ISupplierServices>(() => new SupplierServices(repositoryManager));
        }

        public IBookingService BookingService => _bookingService.Value;
    }
}

