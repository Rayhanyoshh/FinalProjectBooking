using Microsoft.AspNetCore.Mvc;
//using Realta.Contract.Model;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using Realta.Contract.Models;

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
                boor_id = r.boor_id,
                boor_order_number = r.boor_order_number,
                boor_order_date = r.boor_order_date,
                boor_arrival_date = r.boor_arrival_date,
                boor_total_room = r.boor_total_room,
                boor_total_guest = r.boor_total_guest,
                boor_discount = r.boor_discount,
                boor_total_tax = r.boor_total_tax,
                boor_total_ammount = r.boor_total_ammount,
                boor_down_payment = r.boor_down_payment,
                boor_pay_type = r.boor_pay_type,
                boor_is_paid = r.boor_is_paid,
                boor_type = r.boor_type,
                boor_cardnumber = r.boor_cardnumber,
                boor_member_type = r.boor_member_type,
                boor_status = r.boor_status,
                boor_user_id = r.boor_user_id,
                boor_hotel_id = r.boor_hotel_id
            });


            return Ok(BoorDto);
        }

        // GET api/<BookingOrdersController>/5
        [HttpGet("{id}", Name = "GetBoorByID")]
        public IActionResult FindBoorById(int id)
        {
            var boor = _repositoryManager.bookingOrdersRepository.FindBookingOrdersById(id);
            if (boor == null)
            {
                _logger.LogError("Boor object sent from client is null");
                return BadRequest("Boor object is null");
            }


            var boorDto = new BookingOrdersDto
            {
                boor_id = boor.boor_id,
                boor_order_number = boor.boor_order_number,
                boor_order_date = boor.boor_order_date,
                boor_arrival_date = boor.boor_arrival_date,
                boor_total_room = boor.boor_total_room,
                boor_total_guest = boor.boor_total_guest,
                boor_discount = boor.boor_discount,
                boor_total_tax = boor.boor_total_tax,
                boor_total_ammount = boor.boor_total_ammount,
                boor_down_payment = boor.boor_down_payment,
                boor_pay_type = boor.boor_pay_type,
                boor_is_paid = boor.boor_is_paid,
                boor_type = boor.boor_type,
                boor_cardnumber = boor.boor_cardnumber,
                boor_member_type = boor.boor_member_type,
                boor_status = boor.boor_status,
                boor_user_id = boor.boor_user_id,
                boor_hotel_id = boor.boor_hotel_id
            };
            return Ok(boorDto);
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

            var boor = new Booking_orders
            {
                boor_id = bookingOrdersDto.boor_id,
                boor_order_number = bookingOrdersDto.boor_order_number,
                boor_order_date = bookingOrdersDto.boor_order_date,
                boor_arrival_date = bookingOrdersDto.boor_arrival_date,
                boor_total_room = bookingOrdersDto.boor_total_room,
                boor_total_guest = bookingOrdersDto.boor_total_guest,
                boor_discount = bookingOrdersDto.boor_discount,
                boor_total_tax = bookingOrdersDto.boor_total_tax,
                boor_total_ammount = bookingOrdersDto.boor_total_ammount,
                boor_down_payment = bookingOrdersDto.boor_down_payment,
                boor_pay_type = bookingOrdersDto.boor_pay_type,
                boor_is_paid = bookingOrdersDto.boor_is_paid,
                boor_type = bookingOrdersDto.boor_type,
                boor_cardnumber = bookingOrdersDto.boor_cardnumber,
                boor_member_type = bookingOrdersDto.boor_member_type,
                boor_status = bookingOrdersDto.boor_status,
                boor_user_id = bookingOrdersDto.boor_user_id,
                boor_hotel_id = bookingOrdersDto.boor_hotel_id
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
            var boor = new Booking_orders
            {
                boor_id = id,
                boor_order_number = bookingOrdersDto.boor_order_number,
                boor_order_date = bookingOrdersDto.boor_order_date,
                boor_arrival_date = bookingOrdersDto.boor_arrival_date,
                boor_total_room = bookingOrdersDto.boor_total_room,
                boor_total_guest = bookingOrdersDto.boor_total_guest,
                boor_discount = bookingOrdersDto.boor_discount,
                boor_total_tax = bookingOrdersDto.boor_total_tax,
                boor_total_ammount = bookingOrdersDto.boor_total_ammount,
                boor_down_payment = bookingOrdersDto.boor_down_payment,
                boor_pay_type = bookingOrdersDto.boor_pay_type,
                boor_is_paid = bookingOrdersDto.boor_is_paid,
                boor_type = bookingOrdersDto.boor_type,
                boor_cardnumber = bookingOrdersDto.boor_cardnumber,
                boor_member_type = bookingOrdersDto.boor_member_type,
                boor_status = bookingOrdersDto.boor_status,
                boor_user_id = bookingOrdersDto.boor_user_id,
                boor_hotel_id = bookingOrdersDto.boor_hotel_id
            };

            _repositoryManager.bookingOrdersRepository.Edit(boor);

            // Forward to show result
            return CreatedAtRoute("GetBoorByID", new { id = bookingOrdersDto.boor_id }, new BookingOrdersDto 
            {   
                boor_id = id, 
                boor_order_number = boor.boor_order_number,
                boor_order_date = boor.boor_order_date,
                boor_arrival_date = boor.boor_arrival_date,
                boor_total_room = boor.boor_total_room,
                boor_total_guest = boor.boor_total_guest,
                boor_discount = boor.boor_discount,
                boor_total_tax = boor.boor_total_tax,
                boor_total_ammount = boor.boor_total_ammount,
                boor_down_payment = boor.boor_down_payment,
                boor_pay_type = boor.boor_pay_type,
                boor_is_paid = boor.boor_is_paid,
                boor_type = boor.boor_type,
                boor_cardnumber = boor.boor_cardnumber,
                boor_member_type = boor.boor_member_type,
                boor_status = boor.boor_status,
                boor_user_id = boor.boor_user_id,
                boor_hotel_id = boor.boor_hotel_id
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
    }
}
