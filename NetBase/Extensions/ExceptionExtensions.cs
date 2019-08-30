using System;
using System.Text;

namespace NetBase.Extensions
{
	public static class ExceptionExtensions
	{
		public static string AllInnerExceptionMessages(this Exception exception, int depth = 1)
		{
			StringBuilder sb = new StringBuilder(exception.Message);
			if (exception.InnerException != null)
			{
				sb.Append("\n");
				sb.Append("\t".Repeat(depth));
				sb.Append(exception.InnerException.AllInnerExceptionMessages(++depth));
			}
			return sb.ToString();
		}
	}
}