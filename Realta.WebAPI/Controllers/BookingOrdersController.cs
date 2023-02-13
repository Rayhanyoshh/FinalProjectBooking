using Microsoft.AspNetCore.Mvc;
//using Realta.Contract.Model;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;

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
            try
            {
                var bookingOrders = _repositoryManager.bookingOrdersRepository.FindAllBookingOrders().ToList();
                return Ok(bookingOrders);
            }
            catch (Exception)
            {
                _logger.LogError($"Error : {nameof(Get)}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET api/<BookingOrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingOrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingOrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingOrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
