
using Contracts.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Entities.Helpers
{
	public class SortHelper<T> : ISortHelper<T>
	{
		public IQueryable<T> ApplySort(IQueryable<T> entities, string queryString)
		{
			if (!entities.Any())
				return entities;

			if (string.IsNullOrWhiteSpace(queryString))
			{
				return entities;
			}

			var orderParams = queryString.Trim().Split(',');
			var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;

				var propertyFromQueryName = param.Split(" ")[0];
				var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty == null)
					continue;

				var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

				orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',',' ');

			//doesnt work? 
			//return entities.OrderBy(orderQuery);
			return entities.OrderBy(x => x.ToString());
		}
	}
}
