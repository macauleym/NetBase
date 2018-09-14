using System;
using System.Collections.Generic;
using System.Text;

namespace NetBase.Extensions
{
	public static class EnumeratorExtensions
	{
		public static string ItemsAppended<T>(this IEnumerable<T> enumerator, string separator = "")
		{
			if (separator == null)
				throw new ArgumentNullException("separator");

			StringBuilder sb = new StringBuilder();

			foreach (T item in enumerator)
				sb.Append($"{item}{separator}");

			return sb.ToString().TrimEnd(separator);
		}
	}
}