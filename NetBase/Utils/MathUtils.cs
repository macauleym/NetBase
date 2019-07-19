using System;

namespace NetBase.Utils
{
	public static class MathUtils
	{
		public static float Lerp(float value1, float value2, float amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
		{
			return (value.CompareTo(min) < 0) ? min : (value.CompareTo(max) > 0) ? max : value;
		}

		public static double Pythagoras(double a, double b)
		{
			return Math.Sqrt(a * a + b * b);
		}

		public static int Collatz(decimal input)
		{
			int count = 0;

			while (input > 1)
			{
				input = input % 2 == 0 ? input / 2 : input * 3 + 1;
				count++;
			}

			return count;
		}

		public static long Fibonacci(long max)
		{
			long a = 0;
			long b = 1;
			long c = 0;

			for (long i = 0; i < max; i++)
			{
				c = a + b;
				a = b;
				b = c;
			}

			return c;
		}

		public static int SquareDigits(int x)
		{
			string s = x.ToString();
			int t = 0;
			foreach (char c in s)
				t += (int)Math.Pow(int.Parse(c.ToString()), 2);
			return t;
		}

		public static int GetNthTriangle(int n)
		{
			return (int)(n * 0.5 * (n + 1));
		}

		public static int GetPentagonal(int n)
		{
			return n * (3 * n - 1) / 2;
		}

		public static bool IsPandigital(long x, bool includeZero)
		{
			string s = x.ToString();
			if (!includeZero && s.Contains("0"))
				return false;

			int len = s.Length;
			for (int i = len - 1; i > 0; i--)
				if (!s.Contains(i.ToString()))
					return false;

			return true;
		}

		public static long GetHexagonal(long n)
		{
			return n * (2 * n - 1);
		}
		public static int GetHexagonal(int n)
		{
			return n * (2 * n - 1);
		}

		public static bool IsTriangle(long n)
		{
			return FloatingPointUtils.IsInteger(Math.Sqrt(8 * n + 1));
		}
		public static bool IsTriangle(int n)
		{
			return FloatingPointUtils.IsInteger(Math.Sqrt(8 * n + 1));
		}

		public static bool IsPentagonal(long x)
		{
			return FloatingPointUtils.IsInteger((1 + Math.Sqrt(24 * x + 1)) / 6);
		}
		public static bool IsPentagonal(int x)
		{
			return FloatingPointUtils.IsInteger((1 + Math.Sqrt(24 * x + 1)) / 6);
		}

		public static long Factorial(long i)
		{
			if (i <= 1)
				return 1;
			return i * Factorial(i - 1);
		}
		public static int Factorial(int i)
		{
			if (i <= 1)
				return 1;
			return i * Factorial(i - 1);
		}
	}
}