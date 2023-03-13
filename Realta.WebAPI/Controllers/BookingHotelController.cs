using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using Realta.Contract.Models;
using Realta.Domain.RequestFeatures;

namespace Realta.WebAPI.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingHotelController : Controller
    {
        private readonly ILoggerManager _logger;
        private IRepositoryManager _repositoryManager;

        public BookingHotelController(ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        // create class for middleware auth

        // GET: api/<HotelsController>
        [HttpGet]
        public async Task<IActionResult> GetAllHotelAsync()
        {
            var hotels = await _repositoryManager.bookingHotelRepo.FindAllHotels();

            var hotelDto = hotels.Select(h => new HotelsDto
            {
                HotelId = h.HotelId,
                HotelName = h.HotelName,
                HotelRatingStar = h.HotelRatingStar
            });

            return Ok(hotelDto);
        }
    }
}