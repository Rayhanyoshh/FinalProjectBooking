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
    public class SpofController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public SpofController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        // GET: api/<SpofController>
        [HttpGet]
        public IActionResult Get()
        {
            var spof = _repositoryManager.spofRepository.FindAllSpof().ToList();

            var spofDto = spof.Select(r => new SpofDto
            {
                spof_id=r.spof_id,
                spof_name=r.spof_name,
                spof_description=r.spof_description,
                spof_type=r.spof_type,
                spof_discount=r.spof_discount,
                spof_start_date=r.spof_start_date,
                spof_end_date=r.spof_end_date,
                spof_min_qty=r.spof_min_qty,
                spof_max_qty=r.spof_max_qty,
                spof_modified_date=r.spof_modified_date
            });

            return Ok(spofDto);
        }

        // GET api/<SpofController>/5
        [HttpGet("{id}", Name = "GetSpofID")]
        public IActionResult FindSpofById(int id)
        {
            var spof = _repositoryManager.spofRepository.FindSpofById(id);
            if (spof == null)
            {
                _loggerManager.LogError("spof object sent from client is null");
                return BadRequest("Spof object is not found");
            }

            var spofDto = new SpofDto
            {
                spof_id=spof.spof_id,
                spof_name=spof.spof_name,
                spof_description= spof.spof_description,
                spof_type= spof.spof_type,
                spof_discount= spof.spof_discount,
                spof_start_date= spof.spof_start_date,
                spof_end_date= spof.spof_end_date,
                spof_min_qty= spof.spof_min_qty,
                spof_max_qty= spof.spof_max_qty,
                spof_modified_date= spof.spof_modified_date
            };
            return Ok(spofDto);
        }

        // POST api/<SpofController>
        [HttpPost]
        public IActionResult CreateSpof([FromBody] SpofDto spofDto)
        {

            if (spofDto == null)
            {
                _loggerManager.LogError("SpofDto object sent from client is null");
                return BadRequest("Soco object is not found");
            }

            var spof = new Special_offers
            {
                spof_id = spofDto.spof_id,
                spof_name = spofDto.spof_name,
                spof_description = spofDto.spof_description,
                spof_type = spofDto.spof_type,
                spof_discount = spofDto.spof_discount,
                spof_start_date = spofDto.spof_start_date,
                spof_end_date = spofDto.spof_end_date,
                spof_min_qty = spofDto.spof_min_qty,
                spof_max_qty = spofDto.spof_max_qty,
                spof_modified_date = spofDto.spof_modified_date
            };

            // post to db
            _repositoryManager.spofRepository.Insert(spof);


            //forward to show result
            var res = _repositoryManager.spofRepository.FindSpofById(spof.spof_id);

            return CreatedAtRoute("GetSpofID", new { id = spof.spof_id }, res);

        }

        // PUT api/<SpofController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSpof(int id, [FromBody] SpofDto spofDto)
        {


            //  Prevent  from null
            if (spofDto == null)
            {
                _loggerManager.LogError("Spof object sent from client is null");
                return BadRequest("Spof object is not found");
            }

            // find id first
            var spofcheck = _repositoryManager.spofRepository.FindSpofById(id);

            if (spofcheck == null)
            {
                _loggerManager.LogError($"Spof with id {id} not found");
                return NotFound();
            }


            var spof = new Special_offers
            {
                spof_id = id,
                spof_name = spofDto.spof_name,
                spof_description = spofDto.spof_description,
                spof_type = spofDto.spof_type,
                spof_discount = spofDto.spof_discount,
                spof_start_date = spofDto.spof_start_date,
                spof_end_date = spofDto.spof_end_date,
                spof_min_qty = spofDto.spof_min_qty,
                spof_max_qty = spofDto.spof_max_qty,
                spof_modified_date = spofDto.spof_modified_date
            };

            _repositoryManager.spofRepository.Edit(spof);

            // Forward to show result
            return CreatedAtRoute("GetSpofID", new { id = spof.spof_id}, new SpofDto
            {
                spof_id = spof.spof_id,
                spof_name = spof.spof_name,
                spof_description = spof.spof_description,
                spof_type = spof.spof_type,
                spof_discount = spof.spof_discount,
                spof_start_date = spof.spof_start_date,
                spof_end_date = spof.spof_end_date,
                spof_min_qty = spof.spof_min_qty,
                spof_max_qty = spof.spof_max_qty,
                spof_modified_date = spof.spof_modified_date
            });
        }

        // DELETE api/<SpofController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSpof(int? id)
        {
            if (id == null)
            {
                _loggerManager.LogError($"Spof ID {id} object sent from client is null");
                return BadRequest($"Spof ID {id} object is not found");
            }

            // find id first
            var spof = _repositoryManager.spofRepository.FindSpofById(id.Value);

            if (spof == null)
            {
                _loggerManager.LogError($"Spof with id {id} not found");
                return NotFound();
            }


            _repositoryManager.spofRepository.Remove(spof);
            return Ok("Data has been remove.");

        }
    }
}
