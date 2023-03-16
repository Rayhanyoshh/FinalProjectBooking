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
    public class SpecialOfferCouponsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public SpecialOfferCouponsController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        // GET: api/<SocoController>
        [HttpGet]
        public IActionResult Get()
        {
            var soco = _repositoryManager.specialOfferCouponsRepository.FindAllSoco().ToList();

            var socoDto = soco.Select(r => new SpecialOfferCoupons
            {                                       
                SocoId = r.SocoId,
                SocoBordeId = r.SocoBordeId,
                SocoSpofId = r.SocoSpofId

            });

            return Ok(socoDto);
        }

        // GET api/<SocoController>/5
        [HttpGet("{id}", Name = "GetSocoID")]
        public IActionResult FindSocoById(int id)
        {
            var soco = _repositoryManager.specialOfferCouponsRepository.FindSocoById(id);
            if (soco == null)
            {
                _loggerManager.LogError("Soco object sent from client is null");
                return BadRequest("Soco object is null");
            }

            var socoDto = new Contract.Models.SpecialOfferCouponsDto
            {
                Socoid = soco.SocoId,
                SocoBordeId = soco.SocoBordeId,
                SocoSpofId = soco.SocoSpofId

            };
            return Ok(socoDto);
        }

        // POST api/<SocoController>
        [HttpPost]
        public IActionResult CreateSoco([FromBody] Contract.Models.SpecialOfferCouponsDto socoDto)
        {

            if (socoDto == null)
            {
                _loggerManager.LogError("SocoDto object sent from client is null");
                return BadRequest("Soco object is null");
            }

            var soco = new Domain.Entities.SpecialOfferCoupons
            {
                SocoBordeId = socoDto.SocoBordeId,
                SocoSpofId = socoDto.SocoSpofId
            };

            // post to db
            _repositoryManager.specialOfferCouponsRepository.Insert(soco);


            //forward to show result
            var res = _repositoryManager.specialOfferCouponsRepository.FindSocoById(soco.SocoId);

            return CreatedAtRoute("GetSocoID", new { id = soco.SocoId }, res);

        }

        // PUT api/<SocoController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSoco(int id, [FromBody] Contract.Models.SpecialOfferCouponsDto socoDto)
        {
            //  Prevent regionDto from null
            if (socoDto == null)
            {
                _loggerManager.LogError("SocoDto object sent from client is null");
                return BadRequest("Soco object is null");
            }
            var soco = new Domain.Entities.SpecialOfferCoupons
            {
                SocoId = id,
                SocoBordeId = socoDto.SocoBordeId,
                SocoSpofId = socoDto.SocoSpofId
            };

            _repositoryManager.specialOfferCouponsRepository.Edit(soco);

            // Forward to show result
            return base.CreatedAtRoute("GetSocoID", new { id = soco.SocoId }, new Contract.Models.SpecialOfferCouponsDto
            {
                Socoid = soco.SocoId,
                SocoBordeId = soco.SocoBordeId,
                SocoSpofId = soco.SocoSpofId
            });
        }

        // DELETE api/<SocoController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSoco(int? id)
        {
            if (id == null)
            {
                _loggerManager.LogError($"Soco ID {id} object sent from client is null");
                return BadRequest($"Soco ID {id} object is null");
            }

            // find id first
            var soco = _repositoryManager.specialOfferCouponsRepository.FindSocoById(id.Value);

            if (soco == null)
            {
                _loggerManager.LogError($"Soco with id {id} not found");
                return NotFound();
            }


            _repositoryManager.specialOfferCouponsRepository.Remove(soco);
            return Ok("Data has been remove.");

        }
    }
}
