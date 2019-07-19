using System;
using System.Linq;
using System.Linq.Expressions;

namespace NetBase.Extensions
{
	public static class LinqExtensions
	{
		public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string propertyName, bool ascending)
		{
			ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
			MemberExpression property = Expression.Property(parameter, propertyName);
			LambdaExpression expression = Expression.Lambda(property, parameter);
			Type[] types = new Type[] { query.ElementType, expression.Body.Type };

			string method = ascending ? "OrderBy" : "OrderByDescending";
			MethodCallExpression mce = Expression.Call(typeof(Queryable), method, types, query.Expression, expression);

			return query.Provider.CreateQuery<T>(mce);
		}
	}
}