using Realta.Domain.Base;
using Realta.Domain.Repositories;
using Realta.Persistence.Repositories;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private AdoDbContext _adoContext;
        private IBookingOrdersRepository _bookingOrdersRepository;

        public RepositoryManager(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }


        public IBookingOrdersRepository bookingOrdersRepository
        {
            get
            {
                if (_bookingOrdersRepository == null)
                {
                    _bookingOrdersRepository = new BookingOrdersRepository(_adoContext);
                }
                return _bookingOrdersRepository;
            }
        }
    }
}
