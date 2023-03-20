using Microsoft.AspNetCore.Identity;
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

        //POST api/booking
        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingOrdersDto boorBordeDto)
        {
            if (boorBordeDto == null)
            {
                return BadRequest();
            }
            _serviceManager.BookingService.CreateBooking(boorBordeDto, out var boor_id);
            var bookingOrder = _serviceManager.BookingService.GetBookingAsync(boor_id);
            if (bookingOrder == null)
            {
                return BadRequest();
            }
            return Ok(bookingOrder);
        }

        [HttpGet("priceitems")]
        public async Task<IActionResult> GetModifyBooking(int faciId, int userId)
        {
            var prititems = _repositoryManager.price_itemsRepository.FindAllPrice_Items();
            if (prititems!=null)
            {
                return Ok(prititems);
            }
            return BadRequest("Data not found");
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserId(int userId)
        {
            try
            {
                var user = _repositoryManager.bookingRepo.findUserById(userId);
                return Ok(user);


            }
            catch (Exception)
            {
                return BadRequest("Data not found");
            }
        }


        [HttpGet("user/boor/{boorId}")]
        public IActionResult GetUserByBoorId(int boorId)
        {
            var user = _repositoryManager.bookingRepo.findUserByBoorId(boorId);
            if (user!=null)
            {
                return Ok(user);
            }
            return BadRequest("Data Not Found");
        }

        [HttpGet("account/user/{userId}")]
        public IActionResult GetAccountByUserId(int userId)
        {
            var accountuser = _repositoryManager.bookingRepo.FindAccountByUserId(userId);
            if (accountuser!=null)
            {
                return Ok(accountuser);
            }
            return BadRequest("Data Not Found");
        }

        [HttpGet("faci/{faciId}")]
        public IActionResult GetFaciByFaciId(int faciId)
        {
            var faci = _repositoryManager.bookingRepo.FindFacilitiesByFacId(faciId);
            if (faci!=null)
            {
                return Ok(faci);
            }
            return BadRequest("Data Not Found");
        }

        [HttpGet("nested/{boorId}")]
        public async Task<IActionResult> GetBokingNestedAsync(int boorId)
        {
            var bookingdata = await _serviceManager.BookingService.GetBookingAsync2(boorId);
            if (bookingdata==null)
            {
                return BadRequest();
            }
            return Ok(bookingdata);
        }

    }
}
