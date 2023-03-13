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
        private IBookingOrderDetailRepo _bordeRepository;
        private IBookingOrderDetailExtraRepo _boexRepository;
        private ISpecialOfferCouponsRepo _socoRepository;
        private ISpecialOffersRepo _spofRepository;
        private IUserBreakfastRepo _usbrRepository;
        private IBookingHotelRepo _bookingHotelRepo;


        public RepositoryManager(AdoDbContext adoContext)
        {
            _adoContext = adoContext;
        }
        

        public IBookingHotelRepo bookingHotelRepo { 
            get
            {
                if (_bookingHotelRepo == null)
                {
                    _bookingHotelRepo = new BookingHotelRepo (_adoContext);
                }
                return _bookingHotelRepo;
            } 
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

        public IBookingOrderDetailRepo bordeRepository
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

        public IBookingOrderDetailExtraRepo boexRepository
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

        public ISpecialOfferCouponsRepo socoRepository
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

        public ISpecialOffersRepo spofRepository
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

        public IUserBreakfastRepo usbrRepository 
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
    }
}
