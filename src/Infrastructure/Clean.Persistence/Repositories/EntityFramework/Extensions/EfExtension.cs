using Clean.Domain.Contracts.Abstracts;
using Clean.Domain.Contracts.Interfaces;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Clean.Persistence.Repositories.EntityFramework.Extensions;

public static class EfExtension
{

    public static IQueryable<T> Sort<T, TId>(this IQueryable<T> source, string queryString)
        where T : IEntity<TId>
    {
        if (string.IsNullOrEmpty(queryString))
        {
            return source.OrderBy(x => x.Id);
        }

        string[] queryParams = queryString.Trim().Split(',');

        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var queryBuilder = new StringBuilder();

        foreach (var param in queryParams)
        {
            if (string.IsNullOrEmpty(param))
                continue;

            string propertyName = param.Split(' ')[0];

            var objectProperty = propertyInfos.FirstOrDefault(x => x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty is null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";

            queryBuilder.Append($"{objectProperty.Name.ToString()} {direction}");
        }

        var orderQuery = queryBuilder.ToString().TrimEnd(',', ' ');

        if (orderQuery is null)
            return source.OrderBy(x => x.Id);

        return source.OrderBy(orderQuery);

    }


}
