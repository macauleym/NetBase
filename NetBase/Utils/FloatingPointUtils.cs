using System;

namespace NetBase.Utils
{
	public static class FloatingPointUtils
	{
		public static bool IsInteger(decimal value)
		{
			return value % 1 == 0;
		}
		public static bool IsInteger(double value)
		{
			return value % 1 == 0;
		}

		public static string GetDecimals(decimal value)
		{
			if (!IsInteger(value))
				return string.Empty;

			string d = value.ToString();
			return d.Substring(d.IndexOf('.') + 1);
		}
		public static string GetDecimals(double value)
		{
			if (!IsInteger(value))
				return string.Empty;

			string d = value.ToString();
			return d.Substring(d.IndexOf('.') + 1);
		}

		public static int DigitAt(decimal value, int pos)
		{
			string d = value.ToString().Replace(".", string.Empty);
			if (pos < 0 || pos >= d.Length)
				throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the string.\nParameter name: pos");

			return int.Parse(d[pos].ToString());
		}
		public static int DigitAt(double value, int pos)
		{
			string d = value.ToString().Replace(".", string.Empty);
			if (pos < 0 || pos >= d.Length)
				throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the string.\nParameter name: pos");

			return int.Parse(d[pos].ToString());
		}

		public static string ToHourString(float hours)
		{
			return $"{Math.Floor(hours)}:{(hours % 1 * 60).ToString("00")}";
		}

		public static float ToHourFloat(string hours)
		{
			int pos = hours.IndexOf(':');
			float hour = float.Parse(hours.Substring(0, pos));
			float minute = float.Parse(hours.Substring(pos + 1));
			return hour + minute / 60;
		}
	}
}