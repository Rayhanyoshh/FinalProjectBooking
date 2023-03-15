using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using Realta.Contract.Models;
using Realta.Domain.RequestFeatures;

namespace Realta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialoffersController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public SpecialoffersController(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        // GET: api/<SpofController>
        [HttpGet]
        public IActionResult Get()
        {
            var spof = _repositoryManager.spofRepository.FindAllSpof().ToList();

            var spofDto = spof.Select(r => new SpecialOffersDto
            {
                SpofId=r.SpofId,
                SpofName=r.SpofName,
                SpofDescription=r.SpofDescription,
                SpofType=r.SpofType,
                SpofDiscount=r.SpofDiscount,
                SpofStartDate=r.SpofStartDate,
                SpofEndDate=r.SpofEndDate,
                SpofMinQty=r.SpofMinQty,
                SpofMaxQty=r.SpofMaxQty,
                SpofModifiedDate=r.SpofModifiedDate
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

            var spofDto = new SpecialOffersDto
            {
                SpofId=spof.SpofId,
                SpofName=spof.SpofName,
                SpofDescription= spof.SpofDescription,
                SpofType= spof.SpofType,
                SpofDiscount= spof.SpofDiscount,
                SpofStartDate= spof.SpofStartDate,
                SpofEndDate= spof.SpofEndDate,
                SpofMinQty= spof.SpofMinQty,
                SpofMaxQty= spof.SpofMaxQty,
                SpofModifiedDate= spof.SpofModifiedDate
            };
            return Ok(spofDto);
        }

        // POST api/<SpofController>
        [HttpPost]
        public IActionResult CreateSpof([FromBody] SpecialOffersDto spofDto)
        {

            if (spofDto == null)
            {
                _loggerManager.LogError("SpofDto object sent from client is null");
                return BadRequest("Soco object is not found");
            }

            var spof = new SpecialOffers
            {
                SpofId = spofDto.SpofId,
                SpofName = spofDto.SpofName,
                SpofDescription = spofDto.SpofDescription,
                SpofType = spofDto.SpofType,
                SpofDiscount = spofDto.SpofDiscount,
                SpofStartDate = spofDto.SpofStartDate,
                SpofEndDate = spofDto.SpofEndDate,
                SpofMinQty = spofDto.SpofMinQty,
                SpofMaxQty = spofDto.SpofMaxQty,
                SpofModifiedDate = spofDto.SpofModifiedDate
            };

            // post to db
            _repositoryManager.spofRepository.Insert(spof);


            //forward to show result
            var res = _repositoryManager.spofRepository.FindSpofById(spof.SpofId);

            return CreatedAtRoute("GetSpofID", new { id = spof.SpofId }, res);

        }

        // PUT api/<SpofController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSpof(int id, [FromBody] SpecialOffersDto spofDto)
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


            var spof = new SpecialOffers
            {
                SpofId = id,
                SpofName = spofDto.SpofName,
                SpofDescription = spofDto.SpofDescription,
                SpofType = spofDto.SpofType,
                SpofDiscount = spofDto.SpofDiscount,
                SpofStartDate = spofDto.SpofStartDate,
                SpofEndDate = spofDto.SpofEndDate,
                SpofMinQty = spofDto.SpofMinQty,
                SpofMaxQty = spofDto.SpofMaxQty,
                SpofModifiedDate = spofDto.SpofModifiedDate
            };

            _repositoryManager.spofRepository.Edit(spof);

            // Forward to show result
            return CreatedAtRoute("GetSpofID", new { id = spof.SpofId}, new SpecialOffersDto
            {
                SpofId = spof.SpofId,
                SpofName = spof.SpofName,
                SpofDescription = spof.SpofDescription,
                SpofType = spof.SpofType,
                SpofDiscount = spof.SpofDiscount,
                SpofStartDate = spof.SpofStartDate,
                SpofEndDate = spof.SpofEndDate,
                SpofMinQty = spof.SpofMinQty,
                SpofMaxQty = spof.SpofMaxQty,
                SpofModifiedDate = spof.SpofModifiedDate
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

        [HttpGet("paging")]
        public async Task<IActionResult> GetSpofPaging([FromQuery] SpecialOfferParameters specialOfferParameters)
        {
            var specialOffer = await _repositoryManager.spofRepository.GetSpofPaging(specialOfferParameters);
            return Ok(specialOffer);
        } 
        
        [HttpGet("pageList")]
        public async Task<IActionResult> GetSpofPageList([FromQuery] SpecialOfferParameters specialOfferParameters)
        {
            if (!specialOfferParameters.ValidateStockRange)
                return BadRequest("MaxQty must be greater than MinStock");
            
            var specialOffer = await _repositoryManager.spofRepository.GetSpofPageList(specialOfferParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(specialOffer.MetaData));
            return Ok(specialOffer);
        } 
        
    }
}
