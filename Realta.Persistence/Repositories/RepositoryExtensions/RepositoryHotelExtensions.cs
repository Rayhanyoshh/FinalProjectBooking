using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Realta.Persistence.Repositories.RepositoryExtensions;

public static class RepositoryHotelExtensions
{
    public static IQueryable<Hotels> SearchHotel(this IQueryable<Hotels> hotels,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return hotels;

        var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

        return hotels.Where(p => p.HotelName.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<Hotels> Sort(this IQueryable<Hotels> hotels,
        string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return hotels.OrderBy(e => e.HotelName);

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Hotels).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
        }
        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if (string.IsNullOrWhiteSpace(orderQuery))
            return hotels.OrderBy(e => e.HotelName);

        return hotels.OrderBy(orderQuery);

    }
}