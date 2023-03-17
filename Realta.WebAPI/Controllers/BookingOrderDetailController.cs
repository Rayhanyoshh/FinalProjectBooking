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
    public class BookingOrderDetailController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public BookingOrderDetailController(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
        // GET: api/<BordeController>
        [HttpGet]
        public IActionResult Get()
        {
            var borde = _repositoryManager.bookingOrderDetailRepository.FindAllBorde().ToList();

            var bordeDto = borde.Select(r => new BookingOrderDetailDto
            {
                BordeId = r.BordeId,  
                BordeBoorId = r.BordeBoorId,
                BordeCheckin = r.BordeCheckin,
                BordeCheckout = r.BordeCheckout,
                BordeAdults = r.BordeAdults,
                BordeKids = r.BordeKids,
                BordePrice = r.BordePrice,
                BordeExtra = r.BordeExtra,
                BordeDiscount = r.BordeDiscount,
                BordeTax = r.BordeTax,
                BordeSubtotal = r.BordeSubtotal,
                BordeFaciId = r.BordeFaciId
            });

            return Ok(bordeDto);
        }

        // GET api/<BordeController>/5
        [HttpGet("{id}", Name = "GetBordeByID")]
        public IActionResult FindBoorById(int id)
        {
            var borde = _repositoryManager.bookingOrderDetailRepository.FindBordeById(id);
            if (borde == null)
            {
                _logger.LogError("Borde object sent from client is null");
                return BadRequest("Borde object is null");
            }


            var bordeDto = new BookingOrderDetailDto
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
                BordeFaciId = borde.BordeFaciId

            };
            return Ok(bordeDto);
        }

        [HttpGet("boor/{id}", Name = "GetBordeByBoorId")]

        public async Task<IActionResult> GetBordeByBoorIdAsync(int id)
        {
            //get and pass to DTO

            var bookingOrderDetails = await _repositoryManager.bookingOrderDetailRepository.FindAllBordeByBoorId(id);
            if (bookingOrderDetails!=null)
            {
                return Ok(bookingOrderDetails);
            }
            return BadRequest(null);
        }

        // POST api/<BordeController>
        [HttpPost]
        public IActionResult CreateBorde([FromBody] BookingOrderDetailDto bordeDto)
            {
                // Prevent RegionDto from null
                if (bordeDto == null)
                {
                    _logger.LogError("BordeDto object sent from client is null");
                    return BadRequest("Borde object is null");
                }

                var borde = new BookingOrderDetail
                {
                    BordeId = bordeDto.BordeId,
                    BordeBoorId = bordeDto.BordeBoorId,
                    BordeCheckin = bordeDto.BordeCheckin,
                    BordeCheckout = bordeDto.BordeCheckout,
                    BordeAdults = bordeDto.BordeAdults,
                    BordeKids = bordeDto.BordeKids,
                    BordePrice = bordeDto.BordePrice,
                    BordeExtra = bordeDto.BordeExtra,
                    BordeDiscount = bordeDto.BordeDiscount,
                    BordeTax = bordeDto.BordeTax,
                    BordeSubtotal = bordeDto.BordeSubtotal,
                    BordeFaciId = bordeDto.BordeFaciId
                };

                // post to db
                _repositoryManager.bookingOrderDetailRepository.Insert(borde);
            // getin latest inserted id
                bordeDto.BordeId = _repositoryManager.bookingOrderDetailRepository.GetBordeDetailSequenceId();
                return CreatedAtRoute("GetBordeByID", new { id = bordeDto.BordeId }, bordeDto);

            }

        // PUT api/<BordeController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBorde(int id, [FromBody] BookingOrderDetailDto bordeDto)
        {
            //  Prevent regionDto from null
            if (bordeDto == null)
            {
                _logger.LogError("BordeDto object sent from client is null");
                return BadRequest("Borde object is null");
            }
            var borde = new BookingOrderDetail
            {
                BordeId = id,
                BordeBoorId = bordeDto.BordeBoorId,
                BordeCheckin = bordeDto.BordeCheckin,
                BordeCheckout = bordeDto.BordeCheckout,
                BordeAdults = bordeDto.BordeAdults,
                BordeKids = bordeDto.BordeKids,
                BordePrice = bordeDto.BordePrice,
                BordeExtra = bordeDto.BordeExtra,
                BordeDiscount = bordeDto.BordeDiscount,
                BordeTax = bordeDto.BordeTax,
                BordeSubtotal = bordeDto.BordeSubtotal,
                BordeFaciId = bordeDto.BordeFaciId
            };

            _repositoryManager.bookingOrderDetailRepository.Edit(borde);

            // Forward to show result
            return CreatedAtRoute("GetBoorByID", new { id = bordeDto.BordeId }, new BookingOrderDetailDto
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
                BordeFaciId = borde.BordeFaciId
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
            var borde = _repositoryManager.bookingOrderDetailRepository.FindBordeById(id.Value);

            if (borde == null)
            {
                _logger.LogError($"Region with id {id} not found");
                return NotFound();
            }


            _repositoryManager.bookingOrderDetailRepository.Remove(borde);
            return Ok("Data has been remove.");

        }
    }
}
