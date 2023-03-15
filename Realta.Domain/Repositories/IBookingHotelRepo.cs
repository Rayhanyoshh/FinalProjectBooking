using Realta.Domain.Entities;

namespace Realta.Domain.Repositories;

public interface IBookingHotelRepo
{
    Task<IEnumerable<Hotels>> FindAllHotels();
}