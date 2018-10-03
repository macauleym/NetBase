using System;
using System.Collections.Generic;

namespace NetBase.Utils
{
	public static class IntegerUtils
	{
		public static long Clamp(long value, long min, long max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

		public static List<int> PowersOfTwo(int exponent)
		{
			List<int> list = new List<int> { 1 };
			int count = list.Count;

			for (int i = 1; i <= exponent; i++)
			{
				count = list.Count;
				for (int j = count - 1; j >= 0; j--)
				{
					if (list[j] >= 5)
					{
						list[j] -= 10 - list[j];
						if (j >= count - 1)
							list.Add(0);
						list[j + 1] += 1;
					}
					else list[j] *= 2;
				}
			}

			list.Reverse();

			return list;
		}

		public static bool IsComposite(int number)
		{
			int factors = 0;
			int root = (int)Math.Sqrt(number);

			for (int i = 2; i <= root; i++)
			{
				while (number % i == 0)
				{
					factors++;
					if (factors > 2)
						return false;

					number /= i;
				}
			}

			if (number != 1)
				factors++;

			if (factors == 2)
				return true;

			return false;
		}

		public static int GetDivisorAmount(long number)
		{
			long sqrt = (long)Math.Sqrt(number);

			int divisors = 0;
			for (long i = 1; i <= sqrt; i++)
			{
				if (number % i == 0 && i * i != number)
					divisors += 2;
				else if (number % i == 0 && i * i == number)
					divisors++;
			}

			return divisors;
		}

		public static List<long> GetDivisors(long number)
		{
			List<long> divisors = new List<long> { 1, number };

			long sqrt = (long)Math.Sqrt(number);
			for (long i = 2; i <= sqrt; i++)
			{
				if (number % i == 0)
				{
					divisors.Add(i);
					if (i != number / i)
						divisors.Add(number / i);
				}
			}

			return divisors;
		}

		public static List<long> GetProperDivisors(long number)
		{
			List<long> divisors = new List<long> { 1 };

			long sqrt = (long)Math.Sqrt(number);
			for (long i = 2; i <= sqrt; i++)
			{
				if (number % i == 0)
				{
					divisors.Add(i);
					if (i != number / i)
						divisors.Add(number / i);
				}
			}

			return divisors;
		}

		public static long GetDivisorSum(long number)
		{
			long divisorSum = 1 + number;

			long sqrt = (long)Math.Sqrt(number);
			for (long i = 2; i <= sqrt; i++)
			{
				if (number % i == 0)
				{
					divisorSum += i;
					if (i != number / i)
						divisorSum += number / i;
				}
			}

			return divisorSum;
		}

		public static long GetProperDivisorSum(long number)
		{
			long divisorSum = 1;

			long sqrt = (long)Math.Sqrt(number);
			for (long i = 2; i <= sqrt; i++)
			{
				if (number % i == 0)
				{
					divisorSum += i;
					if (i != number / i)
						divisorSum += number / i;
				}
			}

			return divisorSum;
		}

		public static int DigitAt(int value, int pos)
		{
			string d = value.ToString();
			if (pos < 0 || pos >= d.Length)
				throw new IndexOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the string.\nParameter name: pos");

			return int.Parse(d[pos].ToString());
		}

		public static bool ContainsSameDigits(int x, int y)
		{
			string a = x.ToString();
			string b = y.ToString();

			if (a.Length != b.Length)
				return false;

			for (int i = 0; i < a.Length; i++)
				if (!a.Contains(b[i].ToString()))
					return false;

			return true;
		}

		public static int Factorial(int i)
		{
			if (i <= 1)
				return 1;
			return i * Factorial(i - 1);
		}

		public static long Factorial(long i)
		{
			if (i <= 1)
				return 1;
			return i * Factorial(i - 1);
		}
	}
}