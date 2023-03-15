using Realta.Domain.Entities;
using Realta.Domain.Repositories;
using Realta.Persistence.Base;
using Realta.Persistence.Interface;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Realta.Persistence.Repositories;

internal class BookingHotelRepo : RepositoryBase<Hotels>, IBookingHotelRepo
{
    public BookingHotelRepo(AdoDbContext AdoContext) : base(AdoContext)
    {
        
    }

    public async Task<IEnumerable<Hotels>> FindAllHotels()
    {
        SqlCommandModel model = new SqlCommandModel()
        {
            CommandText = "SELECT " +
                          "hotel_id AS HotelId " +
                          ",hotel_name AS HotelName " +
                          ",hotel_description AS HotelDescription" +
                          ",hotel_rating_star AS HotelRatingStar " +
                          " FROM Hotel.Hotels;",
            CommandType = CommandType.Text,
            CommandParameters = new SqlCommandParameterModel[] { }
        };

        IAsyncEnumerator<Hotels> dataSet = FindAllAsync<Hotels>(model);
        var item = new List<Hotels>();

        while (await dataSet.MoveNextAsync())
        {
            item.Add(dataSet.Current);
        }
        return item;
    }
}