using Microsoft.AspNetCore.Mvc;
using Realta.Contract.Models;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Realta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsbrController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public UsbrController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }


        // GET: api/<UsbrController>
        [HttpGet]
        public IActionResult Get()
        {
            var usbr = _repositoryManager.usbrRepository.FindAllUsbr();
            var usbrDto = usbr.Select(x => new UsbrDto
            {
                usbr_borde_id=x.usbr_borde_id,
                usbr_modified_date=x.usbr_modified_date,
                usbr_total_vacant=x.usbr_total_vacant,
            });
            return Ok(usbrDto);
        }

        // GET api/<UsbrController>/5
        [HttpGet("{id}",Name ="GetUsbrByID")]
        public IActionResult Get(int id)
        {
            var usbr = _repositoryManager.usbrRepository.FindUsbrById(id);
            if (usbr ==null)
            {
                _loggerManager.LogError("soco object sent from client is null");
                return BadRequest("object is null");
            }
            var usbrDto = new UsbrDto
            {
                usbr_borde_id = usbr.usbr_borde_id,
                usbr_modified_date = usbr.usbr_modified_date,
                usbr_total_vacant = usbr.usbr_total_vacant
            };
            return Ok(usbrDto);
        }

        // POST api/<UsbrController>
        [HttpPost]
        public IActionResult CreateUsbr([FromBody] UsbrDto usbrDto)
        {
            if (usbrDto == null)
            {
                _loggerManager.LogError("soco object sent from client is null");
                return BadRequest("object is null");
            }
            var usbr = new User_breakfast
            {
                usbr_borde_id = usbrDto.usbr_borde_id,
                usbr_modified_date = usbrDto.usbr_modified_date,
                usbr_total_vacant = usbrDto.usbr_total_vacant
            };

            _repositoryManager.usbrRepository.Insert(usbr);
            return Ok(usbr);
        }

        // PUT api/<UsbrController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsbrController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
