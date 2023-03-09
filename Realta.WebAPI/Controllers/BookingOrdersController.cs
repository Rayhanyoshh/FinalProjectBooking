using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using Realta.Contract.Models;
using Realta.Domain.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Realta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingOrdersController : ControllerBase   
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public BookingOrdersController(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        // GET: api/<BookingOrdersController >
        [HttpGet]
        public IActionResult Get()
        {
            var bookingOrders = _repositoryManager.bookingOrdersRepository.FindAllBookingOrders().ToList();

            var BoorDto = bookingOrders.Select(r => new BookingOrdersDto
            {
                BoorId = r.BoorId,
                BoorOrderNumber = r.BoorOrderNumber,
                BoorOrderDate = r.BoorOrderDate,
                BoorArrivalDate = r.BoorArrivalDate,
                BoorTotalRoom = r.BoorTotalRoom,
                BoorTotalGuest = r.BoorTotalGuest,
                BoorDiscount = r.BoorDiscount,
                BoorTotalTax = r.BoorTotalTax,
                BoorTotalAmmount = r.BoorTotalAmmount,
                BoorDownPayment = r.BoorDownPayment,
                BoorPayType = r.BoorPayType,
                BoorIsPaid = r.BoorIsPaid,
                BoorType = r.BoorType,
                BoorCardnumber = r.BoorCardnumber,
                BoorMemberType = r.BoorMemberType,
                BoorStatus = r.BoorStatus,
                BoorUserId = r.BoorUserId,
                BoorHotelId = r.BoorHotelId
            });

            return Ok(BoorDto);
        }

        // GET api/<BookingOrdersController>/5
        [HttpGet("{id}", Name = "GetBoorByID")]
        public IActionResult FindBoorById(int id)
        {
            var boorBorde = _repositoryManager.bookingOrdersRepository.GetBookingDetail(id);
            //var boor = _repositoryManager.bookingOrdersRepository.FindBookingOrdersById(id);

            if (boorBorde != null)
            {
                return Ok(boorBorde);
            }
            _logger.LogError("Boor object sent from client is null");
            return BadRequest("Boor object is null");

            //var boorDto = new BookingOrdersDto
            //{
            //    BoorId = boor.BoorId,
            //    BoorOrderNumber = boor.BoorOrderNumber,
            //    BoorOrderDate = boor.BoorOrderDate,
            //    BoorArrivalDate = boor.BoorArrivalDate,
            //    BoorTotalRoom = boor.BoorTotalRoom,
            //    BoorTotalGuest = boor.BoorTotalGuest,
            //    BoorDiscount = boor.BoorDiscount,
            //    BoorTotalTax = boor.BoorTotalTax,
            //    BoorTotalAmmount = boor.BoorTotalAmmount,
            //    BoorDownPayment = boor.BoorDownPayment,
            //    BoorPayType = boor.BoorPayType,
            //    BoorIsPaid = boor.BoorIsPaid,
            //    BoorType = boor.BoorType,
            //    BoorCardnumber = boor.BoorCardnumber,
            //    BoorMemberType = boor.BoorMemberType,
            //    BoorStatus = boor.BoorStatus,
            //    BoorUserId = boor.BoorUserId,
            //    BoorHotelId = boor.BoorHotelId
            //};
            //return Ok(boorDto);
        }

        // POST api/<BookingOrdersController>
        [HttpPost]
        public IActionResult CreateBoor([FromBody] BookingOrdersDto bookingOrdersDto)
        {
            // Prevent RegionDto from null
            if (bookingOrdersDto == null)
            {
                _logger.LogError("RegionDto object sent from client is null");
                return BadRequest("Region object is null");
            }

            var boor = new BookingOrders
            {
                BoorId = bookingOrdersDto.BoorId,
                BoorOrderNumber = bookingOrdersDto.BoorOrderNumber,
                BoorOrderDate = bookingOrdersDto.BoorOrderDate,
                BoorArrivalDate = bookingOrdersDto.BoorArrivalDate,
                BoorTotalRoom = bookingOrdersDto.BoorTotalRoom,
                BoorTotalGuest = bookingOrdersDto.BoorTotalGuest,
                BoorDiscount = bookingOrdersDto.BoorDiscount,
                BoorTotalTax = bookingOrdersDto.BoorTotalTax,
                BoorTotalAmmount = bookingOrdersDto.BoorTotalAmmount,
                BoorDownPayment = bookingOrdersDto.BoorDownPayment,
                BoorPayType = bookingOrdersDto.BoorPayType,
                BoorIsPaid = bookingOrdersDto.BoorIsPaid,
                BoorType = bookingOrdersDto.BoorType,
                BoorCardnumber = bookingOrdersDto.BoorCardnumber,
                BoorMemberType = bookingOrdersDto.BoorMemberType,
                BoorStatus = bookingOrdersDto.BoorStatus,
                BoorUserId = bookingOrdersDto.BoorUserId,
                BoorHotelId = bookingOrdersDto.BoorHotelId
            };

            // post to db
            _repositoryManager.bookingOrdersRepository.Insert(boor);


            //forward to show result
            var res = _repositoryManager.bookingOrdersRepository.FindLastBoorID().ToList();
            return Ok(res);
            //return CreatedAtRoute("GetBoorByID", new { id = bookingOrdersDto.boor_id }, bookingOrdersDto);
            
        }

        // PUT api/<BookingOrdersController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBoor(int id, [FromBody] BookingOrdersDto bookingOrdersDto)
        {
            //  Prevent regionDto from null
            if (bookingOrdersDto == null)
            {
                _logger.LogError("RegionDto object sent from client is null");
                return BadRequest("RegionDto object is null");
            }
            var boor = new BookingOrders
            {
                BoorId = id,
                BoorOrderNumber = bookingOrdersDto.BoorOrderNumber,
                BoorOrderDate = bookingOrdersDto.BoorOrderDate,
                BoorArrivalDate = bookingOrdersDto.BoorArrivalDate,
                BoorTotalRoom = bookingOrdersDto.BoorTotalRoom,
                BoorTotalGuest = bookingOrdersDto.BoorTotalGuest,
                BoorDiscount = bookingOrdersDto.BoorDiscount,
                BoorTotalTax = bookingOrdersDto.BoorTotalTax,
                BoorTotalAmmount = bookingOrdersDto.BoorTotalAmmount,
                BoorDownPayment = bookingOrdersDto.BoorDownPayment,
                BoorPayType = bookingOrdersDto.BoorPayType,
                BoorIsPaid = bookingOrdersDto.BoorIsPaid,
                BoorType = bookingOrdersDto.BoorType,
                BoorCardnumber = bookingOrdersDto.BoorCardnumber,
                BoorMemberType = bookingOrdersDto.BoorMemberType,
                BoorStatus = bookingOrdersDto.BoorStatus,
                BoorUserId = bookingOrdersDto.BoorUserId,
                BoorHotelId = bookingOrdersDto.BoorHotelId
            };

            _repositoryManager.bookingOrdersRepository.Edit(boor);

            // Forward to show result
            return CreatedAtRoute("GetBoorByID", new { id = bookingOrdersDto.BoorId }, new BookingOrdersDto 
            {   
                BoorId = id, 
                BoorOrderNumber = boor.BoorOrderNumber,
                BoorOrderDate = boor.BoorOrderDate,
                BoorArrivalDate = boor.BoorArrivalDate,
                BoorTotalRoom = boor.BoorTotalRoom,
                BoorTotalGuest = boor.BoorTotalGuest,
                BoorDiscount = boor.BoorDiscount,
                BoorTotalTax = boor.BoorTotalTax,
                BoorTotalAmmount = boor.BoorTotalAmmount,
                BoorDownPayment = boor.BoorDownPayment,
                BoorPayType = boor.BoorPayType,
                BoorIsPaid = boor.BoorIsPaid,
                BoorType = boor.BoorType,
                BoorCardnumber = boor.BoorCardnumber,
                BoorMemberType = boor.BoorMemberType,
                BoorStatus = boor.BoorStatus,
                BoorUserId = boor.BoorUserId,
                BoorHotelId = boor.BoorHotelId
            });
        }

        // DELETE api/<BookingOrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBoor(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Boor ID {id} object sent from client is null");
                return BadRequest($"Boor ID {id} object is null");
            }

            // find id first
            var boor = _repositoryManager.bookingOrdersRepository.FindBookingOrdersById(id.Value);

            if (boor == null)
            {
                _logger.LogError($"Region with id {id} not found");
                return NotFound();
            }


            _repositoryManager.bookingOrdersRepository.Remove(boor);
            return Ok("Data has been remove.");

        }
        
        [HttpGet("paging")]
        public async Task<IActionResult> GetBookingOrdersPaging ([FromQuery] BookingOrdersParameters  bookingOrdersParameters)
        {
            var bookingOrders = await _repositoryManager.bookingOrdersRepository.GetBookingOrdersPaging(bookingOrdersParameters);
            return Ok(bookingOrders);
        }

        [HttpGet("pageList")]
        public async Task<IActionResult> GetBookingOrdersPageList([FromQuery] BookingOrdersParameters bookingOrdersParameters)
        {

            var bookingOrders =
                await _repositoryManager.bookingOrdersRepository.GetBookingOrderPageList(bookingOrdersParameters);


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(bookingOrders.MetaData));

            return Ok(bookingOrders);
        }
        
        [HttpGet("hotelList")]
        public async Task<IActionResult> GetHotelList([FromQuery] HotelParameters hotelParameters )
        {
            // if (!hotelParameters.ValidatePriceRange)
            //     return BadRequest("MaxPrice must greater than MinPrice");
            var hotel =
                await _repositoryManager.bookingOrdersRepository.GetHotelPageList(hotelParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(hotel.MetaData));
            return Ok(hotel);
        }
    }
}
