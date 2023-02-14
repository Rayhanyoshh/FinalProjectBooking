using Microsoft.AspNetCore.Mvc;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using Realta.Contract.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Realta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BordeController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public BordeController(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
        // GET: api/<BordeController>
        [HttpGet]
        public IActionResult Get()
        {
            var borde = _repositoryManager.bordeRepository.FindAllBorde().ToList();

            var bordeDto = borde.Select(r => new BordeDto
            {
                borde_id = r.borde_id,
                borde_boor_id = r.borde_boor_id,
                borde_checkin = r.borde_checkin,
                borde_checkout = r.borde_checkout,
                borde_adults = r.borde_adults,
                borde_kids = r.borde_kids,
                borde_price = r.borde_price,
                borde_extra = r.borde_extra,
                borde_discount = r.borde_discount,
                borde_tax = r.borde_tax,
                borde_subtotal = r.borde_subtotal,
                borde_faci_id = r.borde_faci_id
            });

            return Ok(bordeDto);
        }

        // GET api/<BordeController>/5
        [HttpGet("{id}", Name = "GetBordeByID")]
        public IActionResult FindBoorById(int id)
        {
            var borde = _repositoryManager.bordeRepository.FindBordeById(id);
            if (borde == null)
            {
                _logger.LogError("Borde object sent from client is null");
                return BadRequest("Borde object is null");
            }


            var bordeDto = new BordeDto
            {
                borde_id = borde.borde_id,
                borde_boor_id = borde.borde_boor_id,
                borde_checkin = borde.borde_checkin,
                borde_checkout = borde.borde_checkout,
                borde_adults = borde.borde_adults,
                borde_kids = borde.borde_kids,
                borde_price = borde.borde_price,
                borde_extra = borde.borde_extra,
                borde_discount = borde.borde_discount,
                borde_tax = borde.borde_tax,
                borde_subtotal = borde.borde_subtotal,
                borde_faci_id = borde.borde_faci_id

            };
            return Ok(bordeDto);
        }

        // POST api/<BordeController>
        [HttpPost]
            public IActionResult CreateBorde([FromBody] BordeDto bordeDto)
            {
                // Prevent RegionDto from null
                if (bordeDto == null)
                {
                    _logger.LogError("BordeDto object sent from client is null");
                    return BadRequest("Borde object is null");
                }

                var borde = new Booking_order_detail
                {
                    borde_id = bordeDto.borde_id,
                    borde_boor_id = bordeDto.borde_boor_id,
                    borde_checkin = bordeDto.borde_checkin,
                    borde_checkout = bordeDto.borde_checkout,
                    borde_adults = bordeDto.borde_adults,
                    borde_kids = bordeDto.borde_kids,
                    borde_price = bordeDto.borde_price,
                    borde_extra = bordeDto.borde_extra,
                    borde_discount = bordeDto.borde_discount,
                    borde_tax = bordeDto.borde_tax,
                    borde_subtotal = bordeDto.borde_subtotal,
                    borde_faci_id = bordeDto.borde_faci_id
                };

                // post to db
                _repositoryManager.bordeRepository.Insert(borde);


                //forward to show result
                //var res = _repositoryManager.bookingOrdersRepository.FindLastBoorID().ToList();
                //return Ok(res);
                return CreatedAtRoute("GetBordeByID", new { id = bordeDto.borde_id }, bordeDto);

            }

        // PUT api/<BordeController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBorde(int id, [FromBody] BordeDto bordeDto)
        {
            //  Prevent regionDto from null
            if (bordeDto == null)
            {
                _logger.LogError("BordeDto object sent from client is null");
                return BadRequest("Borde object is null");
            }
            var borde = new Booking_order_detail
            {
                borde_id = id,
                borde_boor_id = bordeDto.borde_boor_id,
                borde_checkin = bordeDto.borde_checkin,
                borde_checkout = bordeDto.borde_checkout,
                borde_adults = bordeDto.borde_adults,
                borde_kids = bordeDto.borde_kids,
                borde_price = bordeDto.borde_price,
                borde_extra = bordeDto.borde_extra,
                borde_discount = bordeDto.borde_discount,
                borde_tax = bordeDto.borde_tax,
                borde_subtotal = bordeDto.borde_subtotal,
                borde_faci_id = bordeDto.borde_faci_id
            };

            _repositoryManager.bordeRepository.Edit(borde);

            // Forward to show result
            return CreatedAtRoute("GetBoorByID", new { id = bordeDto.borde_id }, new BordeDto
            {
                borde_id = borde.borde_id,
                borde_boor_id = borde.borde_boor_id,
                borde_checkin = borde.borde_checkin,
                borde_checkout = borde.borde_checkout,
                borde_adults = borde.borde_adults,
                borde_kids = borde.borde_kids,
                borde_price = borde.borde_price,
                borde_extra = borde.borde_extra,
                borde_discount = borde.borde_discount,
                borde_tax = borde.borde_tax,
                borde_subtotal = borde.borde_subtotal,
                borde_faci_id = borde.borde_faci_id
            });
        }

        // DELETE api/<BordeController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBoor(int? id)
        {
            if (id == null)
            {
                _logger.LogError($"Borde ID {id} object sent from client is null");
                return BadRequest($"Borde ID {id} object is null");
            }

            // find id first
            var borde = _repositoryManager.bordeRepository.FindBordeById(id.Value);

            if (borde == null)
            {
                _logger.LogError($"Region with id {id} not found");
                return NotFound();
            }


            _repositoryManager.bordeRepository.Remove(borde);
            return Ok("Data has been remove.");

        }
    }
}
