using System;
using System.Globalization;

namespace NetBase.Extensions
{
	public static class DateTimeExtensions
	{
		public static int WeekNumber(this DateTime dateTime)
		{
			return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}