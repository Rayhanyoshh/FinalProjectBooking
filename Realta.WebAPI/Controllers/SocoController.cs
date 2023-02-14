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
    public class SocoController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public SocoController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        // GET: api/<SocoController>
        [HttpGet]
        public IActionResult Get()
        {
            var soco = _repositoryManager.socoRepository.FindAllSoco().ToList();

            var socoDto = soco.Select(r => new SocoDto
            {
                soco_id = r.soco_id,
                soco_borde_id = r.soco_borde_id,
                soco_spof_id = r.soco_spof_id

            });

            return Ok(socoDto);
        }

        // GET api/<SocoController>/5
        [HttpGet("{id}", Name = "GetSocoID")]
        public IActionResult FindSocoById(int id)
        {
            var soco = _repositoryManager.socoRepository.FindSocoById(id);
            if (soco == null)
            {
                _loggerManager.LogError("Soco object sent from client is null");
                return BadRequest("Soco object is null");
            }

            var socoDto = new SocoDto
            {
                soco_id = soco.soco_id,
                soco_borde_id = soco.soco_borde_id,
                soco_spof_id = soco.soco_spof_id

            };
            return Ok(socoDto);
        }

        // POST api/<SocoController>
        [HttpPost]
        public IActionResult CreateSoco([FromBody] SocoDto socoDto)
        {

            if (socoDto == null)
            {
                _loggerManager.LogError("SocoDto object sent from client is null");
                return BadRequest("Soco object is null");
            }

            var soco = new Special_offer_coupons
            {
                soco_borde_id = socoDto.soco_borde_id,
                soco_spof_id = socoDto.soco_spof_id
            };

            // post to db
            _repositoryManager.socoRepository.Insert(soco);


            //forward to show result
            var res = _repositoryManager.socoRepository.FindSocoById(soco.soco_id);

            return CreatedAtRoute("GetSocoID", new { id = soco.soco_id }, res);

        }

        // PUT api/<SocoController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSoco(int id, [FromBody] SocoDto socoDto)
        {
            //  Prevent regionDto from null
            if (socoDto == null)
            {
                _loggerManager.LogError("SocoDto object sent from client is null");
                return BadRequest("Soco object is null");
            }
            var soco = new Special_offer_coupons
            {
                soco_id = id,
                soco_borde_id = socoDto.soco_borde_id,
                soco_spof_id = socoDto.soco_spof_id
            };

            _repositoryManager.socoRepository.Edit(soco);

            // Forward to show result
            return CreatedAtRoute("GetSocoID", new { id = soco.soco_id }, new SocoDto
            {
                soco_id = soco.soco_id,
                soco_borde_id = soco.soco_borde_id,
                soco_spof_id = soco.soco_spof_id
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
            var soco = _repositoryManager.socoRepository.FindSocoById(id.Value);

            if (soco == null)
            {
                _loggerManager.LogError($"Soco with id {id} not found");
                return NotFound();
            }


            _repositoryManager.socoRepository.Remove(soco);
            return Ok("Data has been remove.");

        }
    }
}
