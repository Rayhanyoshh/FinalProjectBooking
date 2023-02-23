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
    public class BookingOrderDetailExtraController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public BookingOrderDetailExtraController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }
        // GET: api/<BoexController>
        [HttpGet]
        public IActionResult Get()
        {
            var boex = _repositoryManager.boexRepository.FindAllBoex().ToList();

            var boexDto = boex.Select(r => new BookingOrderDetailExtraDtoDto
            {
                boex_id = r.boex_id,
                boex_price = r.boex_price,
                boex_qty = r.boex_qty,
                boex_subtotal = r.boex_subtotal,
                boex_measure_unit = r.boex_measure_unit,
                boex_borde_id = r.boex_borde_id,
                boex_prit_id = r.boex_prit_id
            });

            return Ok(boexDto);
        }

        // GET api/<BoexController>/5
        [HttpGet("{id}", Name = "GetBoexID")]
        public IActionResult FindBoexById(int id)
        {
            var boex = _repositoryManager.boexRepository.FindBoexById(id);
            if (boex == null)
            {
                _loggerManager.LogError("Boex object sent from client is null");
                return BadRequest("Boex object is null");
            }


            var boexDto = new BookingOrderDetailExtraDtoDto
            {
                boex_id = boex.boex_id,
                boex_price = boex.boex_price,
                boex_qty = boex.boex_qty,
                boex_subtotal = boex.boex_subtotal,
                boex_measure_unit = boex.boex_measure_unit,
                boex_borde_id = boex.boex_borde_id,
                boex_prit_id = boex.boex_prit_id

            };
            return Ok(boexDto);
        }

        // POST api/<BoexController>
        [HttpPost]
        public IActionResult CreateBoex([FromBody] BookingOrderDetailExtraDtoDto boexDto)
        {

            if (boexDto == null)
            {
                _loggerManager.LogError("BoexDto object sent from client is null");
                return BadRequest("Boex object is null");
            }

            var boex = new BookingOrderDetailExtra
            {
                boex_price = boexDto.boex_price,
                boex_qty = boexDto.boex_qty,
                boex_subtotal = boexDto.boex_subtotal,
                boex_measure_unit = boexDto.boex_measure_unit,
                boex_borde_id = boexDto.boex_borde_id,
                boex_prit_id = boexDto.boex_prit_id
            };

            // post to db
            _repositoryManager.boexRepository.Insert(boex);


            //forward to show result
            var res = _repositoryManager.boexRepository.FindBoexById(boex.boex_id);
            
            return CreatedAtRoute("GetBoexID", new { id = boex.boex_id }, res);

        }

        // PUT api/<BoexController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBoex(int id, [FromBody] BookingOrderDetailExtraDtoDto boexDto)
        {
            //  Prevent regionDto from null
            if (boexDto == null)
            {
                _loggerManager.LogError("BoexDto object sent from client is null");
                return BadRequest("Boex object is null");
            }
            var boex = new BookingOrderDetailExtra
            {
                boex_id = id,
                boex_price = boexDto.boex_price,
                boex_qty = boexDto.boex_qty,
                boex_subtotal = boexDto.boex_subtotal,
                boex_measure_unit = boexDto.boex_measure_unit,
                boex_borde_id = boexDto.boex_borde_id,
                boex_prit_id = boexDto.boex_prit_id
            };

            _repositoryManager.boexRepository.Edit(boex);

            // Forward to show result
            return CreatedAtRoute("GetBoexID", new { id = boexDto.boex_id }, new BookingOrderDetailExtraDtoDto
            {
                boex_id = boex.boex_id,
                boex_price = boex.boex_price,
                boex_qty = boex.boex_qty,
                boex_subtotal = boex.boex_subtotal,
                boex_measure_unit = boex.boex_measure_unit,
                boex_borde_id = boex.boex_borde_id,
                boex_prit_id = boex.boex_prit_id
            });
        }

        // DELETE api/<BoexController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBoex(int? id)
        {
            if (id == null)
            {
                _loggerManager.LogError($"Boex ID {id} object sent from client is null");
                return BadRequest($"Boex ID {id} object is null");
            }

            // find id first
            var boex = _repositoryManager.boexRepository.FindBoexById(id.Value);

            if (boex == null)
            {
                _loggerManager.LogError($"Region with id {id} not found");
                return NotFound();
            }


            _repositoryManager.boexRepository.Remove(boex);
            return Ok("Data has been remove.");

        }
    }
}
