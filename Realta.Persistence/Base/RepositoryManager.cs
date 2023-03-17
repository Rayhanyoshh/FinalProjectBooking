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
        private IBookingRepo _bookRepo;
        private IBookingOrdersRepository _bookingOrdersRepository;
        private IBookingOrderDetailRepo _bordeRepository;
        private IBookingOrderDetailExtraRepo _boexRepository;
        private ISpecialOfferCouponsRepo _socoRepository;
        private ISpecialOffersRepo _spofRepository;
        private IUserBreakfastRepo _usbrRepository;
        private IPrice_ItemsRepository _price_itemsRepository;

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
                    _bookingOrdersRepository = new BookingOrdersRepo(_adoContext);
                }
                return _bookingOrdersRepository;
            }
        }

        public IBookingOrderDetailRepo bookingOrderDetailRepository
        {
            get
            {
                if (_bordeRepository == null)
                {
                    _bordeRepository = new BookingOrderDetailrepo (_adoContext);
                }
                return _bordeRepository;
            }
        }

        public IBookingOrderDetailExtraRepo bookingOrderDetailExtraRepository
        {
            get
            {
                if (_boexRepository == null)
                {
                    _boexRepository = new BookingOrderDetailExtraRepo (_adoContext);
                }
                return _boexRepository;
            }
        }

        public ISpecialOfferCouponsRepo specialOfferCouponsRepository
        {
            get
            {
                if (_socoRepository == null)
                {
                    _socoRepository = new SpecialOfferCouponsRepo(_adoContext);
                }
                return _socoRepository;
            }
        }

        public ISpecialOffersRepo specialOffersRepository
        {
            get
            {
                if (_spofRepository == null)
                {
                    _spofRepository = new SpecialOffersRepo(_adoContext);
                }
                return _spofRepository;
            }
        }

        public IUserBreakfastRepo userBreakfastRepository 
        {
            get
            {
                if(_usbrRepository==null)
                {
                    _usbrRepository = new UserBreakfastRepo(_adoContext);
                }
                return _usbrRepository; 
            }
        
        }

        public IBookingRepo bookingRepo
        {
            get
            {
                if (_bookRepo == null)
                {
                    _bookRepo = new BookingRepo(_adoContext);
                }
                return _bookRepo;
            }
        }

        public IPrice_ItemsRepository price_itemsRepository
        {
            get
            {
                if (_price_itemsRepository == null)
                {
                    _price_itemsRepository = new Price_ItemsRepository(_adoContext);
                }
                return _price_itemsRepository;
            }
        }
    }
}
