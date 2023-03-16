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
    public class UserBreakfastController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public UserBreakfastController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }


        // GET: api/<UsbrController>
        [HttpGet]
        public IActionResult Get()
        {
            var usbr = _repositoryManager.userBreakfastRepository.FindAllUsbr();
            var usbrDto = usbr.Select(x => new UserBreakfastDto
            {
                UsbrBordeId =x.UsbrBordeId,
                UsbrModifiedDate =x.UsbrModifiedDate,
                UsbrTotalVacant =x.UsbrTotalVacant,
            });
            return Ok(usbrDto);
        }

        // GET api/<UsbrController>/5/2022-1-11
        [HttpGet("{id}/{yyyy}/{mm}/{dd}",Name ="GetUserBreakfast")]
        public IActionResult Get(int id, int yyyy, int mm, int dd)
        {
            var date = new DateTime(yyyy, mm, dd);
            var usbr = _repositoryManager.userBreakfastRepository.FindUsbrByIdDate(id,date);
            if (usbr ==null)
            {
                _loggerManager.LogError("User Breakfast object cannot found ");
                return BadRequest("object is null");
            }
            var usbrDto = new UserBreakfastDto
            {
                UsbrBordeId = id,
                UsbrModifiedDate = date,
                UsbrTotalVacant = usbr.UsbrTotalVacant
            };
            return Ok(usbrDto);
        }

        // POST api/<UsbrController>
        [HttpPost]
        public IActionResult CreateUsbr([FromBody] UserBreakfastDto? usbrDto)
        {
            if (usbrDto == null)
            {
                _loggerManager.LogError("special offer object sent from client is null");
                return BadRequest("object is null");
            }
            var usbr = new UserBreakfast
            {
                UsbrBordeId = usbrDto.UsbrBordeId,
                UsbrModifiedDate = usbrDto.UsbrModifiedDate,
                UsbrTotalVacant = usbrDto.UsbrTotalVacant
            };

            _repositoryManager.userBreakfastRepository.Insert(usbr);
            return Ok(usbr);
        }

        // PUT api/<UsbrController>/5
        [HttpPut("{id}/{yyyy}/{mm}/{dd}")]
        public IActionResult Put(int id, int yyyy, int mm, int dd, [FromBody] UserBreakfastDto? UsbrDto)
        {
            //1. prevent regiondto from null
            if (UsbrDto == null)
            {
                _loggerManager.LogError("UserBreakfast object sent from client is null");
                return BadRequest("UserBreakfast object is null");
            }
            var date = new DateTime(yyyy, mm, dd);

            var usbr = new UserBreakfast()
            {
                UsbrBordeId=id,
                UsbrModifiedDate=date,
                UsbrTotalVacant = UsbrDto.UsbrTotalVacant
            };

            _repositoryManager.userBreakfastRepository.Edit(usbr);

            //forward 
            return CreatedAtRoute("GetUserBreakfast", new { id = UsbrDto.UsbrBordeId,yyyy=date.Year,mm=date.Month,dd=date.Date}, new UserBreakfast { UsbrBordeId=id,UsbrModifiedDate=date,UsbrTotalVacant=usbr.UsbrTotalVacant});
        }

        // DELETE api/<UsbrController>/5
        [HttpDelete("{id}/{yyyy}/{mm}/{dd}")]
        public IActionResult Delete(int id,int yyyy,int mm, int dd)
        {
            var date = new DateTime(yyyy, mm, dd);
            if (id==null || date==null)
            {
                _loggerManager.LogError($"{nameof(id)} or {nameof(date)} object from client is null"); 
                return BadRequest("Object is null");
            }
            var userbreakfast = _repositoryManager.userBreakfastRepository.FindUsbrByIdDate(id, date);
            if (userbreakfast==null)
            {
                _loggerManager.LogError($"UserBreakfast not found");
                return NotFound();
            }
            _repositoryManager.userBreakfastRepository.Remove(userbreakfast);
            return Ok("Data has been removed");
        }
    }
}
