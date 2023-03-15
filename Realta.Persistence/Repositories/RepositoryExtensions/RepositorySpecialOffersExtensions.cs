using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Realta.Persistence.Repositories.RepositoryExtensions;

public static class RepositorySpecialOffersExtensions
{
    public static IQueryable<SpecialOffers> SearchSpof(this IQueryable<SpecialOffers> specialOffers,
        string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return specialOffers;

        var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

        return specialOffers.Where(p => p.SpofName.ToLower().Contains(lowerCaseSearchTerm));
    }

    public static IQueryable<SpecialOffers> Sort(this IQueryable<SpecialOffers> specialOffers,
        string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return specialOffers.OrderBy(e => e.SpofName);

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(SpecialOffers).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
            return specialOffers.OrderBy(e => e.SpofName);

        return specialOffers.OrderBy(orderQuery);

    }
}