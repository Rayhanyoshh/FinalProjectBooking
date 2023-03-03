
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


        //private readonly Lazy<IProductPhotoServices> _lazyProductPhotoServices;
        //private readonly Lazy<ISupplierServices> _lazySupplierServices;
        //private readonly Lazy<IUtilityService> _lazyUtilityService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            //_lazyProductPhotoServices = new Lazy<IProductPhotoServices>(() => new ProductPhotoServices(repositoryManager, _lazyUtilityService));
            //_lazySupplierServices = new Lazy<ISupplierServices>(() => new SupplierServices(repositoryManager));
        }


        //public IProductPhotoServices ProductPhotoService => _lazyProductPhotoServices.Value;

        //public ISupplierServices SupplierService => _lazySupplierServices.Value;
    }
}

