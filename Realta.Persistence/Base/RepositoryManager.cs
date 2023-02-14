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
        private IBordeRepository _bordeRepository;
        private IBoexRepository _boexRepository;
        private ISocoRepository _socoRepository;

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

        public IBordeRepository bordeRepository
        {
            get
            {
                if (_bordeRepository == null)
                {
                    _bordeRepository = new BordeRepository (_adoContext);
                }
                return _bordeRepository;
            }
        }

        public IBoexRepository boexRepository
        {
            get
            {
                if (_boexRepository == null)
                {
                    _boexRepository = new BoexRepository (_adoContext);
                }
                return _boexRepository;
            }
        }

        public ISocoRepository socoRepository
        {
            get
            {
                if (_socoRepository == null)
                {
                    _socoRepository = new SocoRepository(_adoContext);
                }
                return _socoRepository;
            }
        }
    }
}
