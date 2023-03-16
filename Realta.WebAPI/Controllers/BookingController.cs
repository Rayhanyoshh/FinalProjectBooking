using Microsoft.AspNetCore.Mvc;
using Realta.Contract.Models;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Realta.WebAPI.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryManager _repositoryManager;
        private readonly IServiceManager _serviceManager;

        public BookingController(ILoggerManager logger, IRepositoryManager repositoryManager, IServiceManager serviceManager)
        {
            this._logger = logger;
            _repositoryManager = repositoryManager;
            this._serviceManager = serviceManager;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaciByHotelId(int id)
        {
            var hotel = await _repositoryManager.bookingRepo.FindFaciByHotelIdAsync(id);
            if (hotel==null)
            {
                _logger.LogError($"Hotel with id {id} not found");
                return NotFound();
            }

            var hotelDto = hotel.Select(v => new HotelsDto
            {
                HotelId=v.HotelId,
                HotelName=v.HotelName,
                HotelAddress=v.HotelAddress,
                HotelRatingStar=v.HotelRatingStar,
                HotelDescription = v.HotelDescription,
                HotelCity=v.HotelCity,
                FaciId=v.FaciId,
                FaciName=v.FaciName,
                FaciStartdate=v.FaciStartdate,
                FaciEnddate=v.FaciEnddate,
                FaciPrice=v.FaciPrice,
                FaciDiscount=v.FaciDiscount,
                FaciTaxRate=v.FaciTax,
                FaciMaxNumber=v.FaciMaxNumber,
                FaciPhotoUrl=v.FaciPhotoUrl
            });
            return Ok(hotelDto);
        }

        // POST api/<BookingController>
        //[HttpPost]
        //public IActionResult CreateBooking ([FromBody] BookingListOrderDetailExtraDto boorBordeDto)
        //{
        //    //if (boorBordeDto != null)
        //    //{
        //    //    _serviceManager.BookingService.CreateBooking(boorBordeDto,out var boor_id);
        //    //    return Ok(boor_id);
        //    //}
        //    //return BadRequest();
        //}

        [HttpGet("{id}/invoice")]
        public async Task<IActionResult> GetInvoiceByBoorIdAsync(int id)
        {
            var bookingOrders = _repositoryManager.bookingOrdersRepository.FindBookingOrdersById(id);
            if (bookingOrders == null)
            {
                _logger.LogError($"Booking data not found");
                return BadRequest();
            }
            var bookingOrderDtos = new BookingOrdersDto
            {
              BoorId=bookingOrders.BoorId,
              BoorOrderNumber=bookingOrders.BoorOrderNumber,
              BoorOrderDate=bookingOrders.BoorOrderDate,
              BoorArrivalDate=bookingOrders.BoorArrivalDate,
              BoorTotalRoom=bookingOrders.BoorTotalRoom,
              BoorTotalGuest=bookingOrders.BoorTotalGuest,
              BoorDiscount=bookingOrders.BoorDiscount,
              BoorTotalTax=bookingOrders.BoorTotalTax,
              BoorTotalAmmount=bookingOrders.BoorTotalAmmount,
              BoorDownPayment=bookingOrders.BoorDownPayment,
              BoorPayType=bookingOrders.BoorPayType,
              BoorIsPaid=bookingOrders.BoorIsPaid,
              BoorType = bookingOrders.BoorType,
              BoorCardnumber = bookingOrders.BoorCardnumber,
              BoorMemberType = bookingOrders.BoorMemberType ,
              BoorStatus = bookingOrders.BoorStatus,
              BoorUserId = bookingOrders.BoorUserId,
              BoorHotelId = bookingOrders.BoorHotelId,
              TrxNumber=bookingOrders.TrxNumber
            };

            var bookingOrderDetails = await _repositoryManager.bookingOrderDetailRepository.FindAllBordeByBoorId(id);
            var bookingOrderDetailsDto = bookingOrderDetails.Select(borde => new BookingOrderDetailDto
            {
                BordeId = borde.BordeId,
                BordeBoorId = borde.BordeBoorId,
                BordeCheckin = borde.BordeCheckin,
                BordeCheckout = borde.BordeCheckout,
                BordeAdults = borde.BordeAdults,
                BordeKids = borde.BordeKids,
                BordePrice = borde.BordePrice,
                BordeExtra = borde.BordeExtra,
                BordeDiscount = borde.BordeDiscount,
                BordeTax = borde.BordeTax,
                BordeSubtotal = borde.BordeSubtotal,
                BordeFaciId = borde.BordeFaciId,
                FaciName=borde.FaciName
            });

            var bookingOrderDetailExtras = await _repositoryManager.bookingOrderDetailExtraRepository.FindAllBoexByBoorId(id);
            var bookingOrderDetailExtrasDto = bookingOrderDetailExtras.Select(boex => new BookingOrderDetailExtraDto
            {
                BoexId = boex.BoexId,
                BoexPrice = boex.BoexPrice,
                BoexQty = boex.BoexQty,
                BoexSubtotal = boex.BoexSubtotal,
                BoexMeasureUnit = boex.BoexMeasureUnit,
                BoexBordeId = boex.BoexBordeId,
                BoexPritId = boex.BoexPritId,
                PritName = boex.PritName
            });

            var result = new BookingListOrderDetailExtraDto()
            {
                bookingOrders = bookingOrderDtos,
                bookingOrderDetail = bookingOrderDetailsDto,
                bookingOrderDetailExtra = bookingOrderDetailExtrasDto
            };
            return Ok(result);    
        }


    }
}
