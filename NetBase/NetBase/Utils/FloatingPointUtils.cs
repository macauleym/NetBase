using System;

namespace NetBase.Utils
{
	public static class FloatingPointUtils
	{
		public static decimal Clamp(decimal value, decimal min, decimal max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}
		public static double Clamp(double value, double min, double max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

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
	}
}