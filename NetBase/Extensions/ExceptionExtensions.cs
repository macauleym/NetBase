using System;
using System.Text;

namespace NetBase.Extensions
{
	public static class ExceptionExtensions
	{
		public static string AllInnerExceptionMessages(this Exception exception, string separator = "")
		{
			if (separator == null)
				throw new ArgumentNullException(nameof(separator));

			StringBuilder sb = new StringBuilder(exception.Message);
			if (exception.InnerException != null)
			{
				sb.AppendLine(exception.AllInnerExceptionMessages());
				sb.AppendLine(separator);
			}
			return sb.ToString();
		}
	}
}