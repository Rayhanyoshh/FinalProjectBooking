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
            var boex = _repositoryManager.bookingOrderDetailExtraRepository.FindAllBoex().ToList();

            var boexDto = boex.Select(r => new BookingOrderDetailExtraDto
            {
                BoexId = r.BoexId,
                BoexPrice = r.BoexPrice,
                BoexQty = r.BoexQty,
                BoexSubtotal = r.BoexSubtotal,
                BoexMeasureUnit = r.BoexMeasureUnit,
                BoexBordeId = r.BoexBordeId,
                BoexPritId = r.BoexPritId
            });

            return Ok(boexDto);
        }

        // GET api/<BoexController>/5
        [HttpGet("{id}", Name = "GetBoexID")]
        public IActionResult FindBoexById(int id)
        {
            var boex = _repositoryManager.bookingOrderDetailExtraRepository.FindBoexById(id);
            if (boex == null)
            {
                _loggerManager.LogError("Boex object sent from client is null");
                return BadRequest("Boex object is null");
            }


            var boexDto = new BookingOrderDetailExtraDto
            {
                BoexId = boex.BoexId,
                BoexPrice = boex.BoexPrice,
                BoexQty = boex.BoexQty,
                BoexSubtotal = boex.BoexSubtotal,
                BoexMeasureUnit = boex.BoexMeasureUnit,
                BoexBordeId = boex.BoexBordeId,
                BoexPritId = boex.BoexPritId

            };
            return Ok(boexDto);
        }

        [HttpGet("boor/{id}", Name = "GetBoexByBoorId")]
        public async Task<IActionResult> FindExtraByBoorIdAsync(int id)
        {
            //get and pass to DTO
            var bookingOrderDetailExtras = await _repositoryManager.bookingOrderDetailExtraRepository.FindAllBoexByBoorId(id);
            if (bookingOrderDetailExtras != null)
            {
                var bookingOrderDetailExtrasDto = bookingOrderDetailExtras.Select(boex => new BookingOrderDetailExtraDto
                {
                    BoexId = boex.BoexId,
                    BoexPrice = boex.BoexPrice,
                    BoexQty = boex.BoexQty,
                    BoexSubtotal = boex.BoexSubtotal,
                    BoexMeasureUnit = boex.BoexMeasureUnit,
                    BoexBordeId = boex.BoexBordeId,
                    BoexPritId = boex.BoexPritId,
                    PritName = boex.PritName
                });
            
                return Ok(bookingOrderDetailExtrasDto);
            }
            return BadRequest();
        }

        // POST api/<BoexController>
        [HttpPost]
        public IActionResult CreateBoex([FromBody] BookingOrderDetailExtraDto boexDto)
        {

            if (boexDto == null)
            {
                _loggerManager.LogError("BoexDto object sent from client is null");
                return BadRequest("Boex object is null");
            }

            var boex = new BookingOrderDetailExtra
            {
                BoexPrice = boexDto.BoexPrice,
                BoexQty = boexDto.BoexQty,
                BoexSubtotal = boexDto.BoexSubtotal,
                BoexMeasureUnit = boexDto.BoexMeasureUnit,
                BoexBordeId = boexDto.BoexBordeId,
                BoexPritId = boexDto.BoexPritId
            };

            // post to db
            _repositoryManager.bookingOrderDetailExtraRepository.Insert(boex);


            //forward to show result
            var res = _repositoryManager.bookingOrderDetailExtraRepository.FindBoexById(boex.BoexId);
            
            return CreatedAtRoute("GetBoexID", new { id = boex.BoexId }, res);

        }

        // PUT api/<BoexController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBoex(int id, [FromBody] BookingOrderDetailExtraDto boexDto)
        {
            //  Prevent regionDto from null
            if (boexDto == null)
            {
                _loggerManager.LogError("BoexDto object sent from client is null");
                return BadRequest("Boex object is null");
            }
            var boex = new BookingOrderDetailExtra
            {
                BoexId = id,
                BoexPrice = boexDto.BoexPrice,
                BoexQty = boexDto.BoexQty,
                BoexSubtotal = boexDto.BoexSubtotal,
                BoexMeasureUnit = boexDto.BoexMeasureUnit,
                BoexBordeId = boexDto.BoexBordeId,
                BoexPritId = boexDto.BoexPritId
            };

            _repositoryManager.bookingOrderDetailExtraRepository.Edit(boex);

            // Forward to show result
            return CreatedAtRoute("GetBoexID", new { id = boexDto.BoexId }, new BookingOrderDetailExtraDto
            {
                BoexId = boex.BoexId,
                BoexPrice = boex.BoexPrice,
                BoexQty = boex.BoexQty,
                BoexSubtotal = boex.BoexSubtotal,
                BoexMeasureUnit = boex.BoexMeasureUnit,
                BoexBordeId = boex.BoexBordeId,
                BoexPritId = boex.BoexPritId
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
            var boex = _repositoryManager.bookingOrderDetailExtraRepository.FindBoexById(id.Value);

            if (boex == null)
            {
                _loggerManager.LogError($"Region with id {id} not found");
                return NotFound();
            }


            _repositoryManager.bookingOrderDetailExtraRepository.Remove(boex);
            return Ok("Data has been remove.");

        }
    }
}
