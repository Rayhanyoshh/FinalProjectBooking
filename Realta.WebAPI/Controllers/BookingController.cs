using Microsoft.AspNetCore.Mvc;
using Realta.Contract.Models;
using Realta.Domain.Base;
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
        [HttpPost]
        public IActionResult CreateBooking ([FromBody] BoorBordeDto boorBordeDto)
        {
            if (boorBordeDto != null)
            {
                _serviceManager.BookingService.CreateBooking(boorBordeDto,out var boor_id);
                return Ok(boor_id);
            }
            return BadRequest();
        }

    }
}
