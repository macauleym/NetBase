using System;
using System.Text;

namespace NetBase.Extensions
{
	public static class ExceptionExtensions
	{
		public static string AllInnerExceptionMessages(this Exception e, string separator = "")
		{
			if (separator == null)
				throw new ArgumentNullException("separator");

			StringBuilder sb = new StringBuilder(e.Message);
			if (e.InnerException != null)
			{
				sb.AppendLine(e.AllInnerExceptionMessages());
				sb.AppendLine(separator);
			}
			return sb.ToString();
		}
	}
}