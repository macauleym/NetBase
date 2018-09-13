using System;
using System.Collections.Generic;

namespace NetBase.Utils
{
	public static class PrimeUtils
	{
		public static int[] oneDigitPrimes = new int[4] { 2, 3, 5, 7 };

		public static bool IsPrime(long number)
		{
			if (number < 2)
				return false;

			double sqrt = Math.Sqrt(number);
			for (long i = 2; i <= sqrt; i++)
				if (number % i == 0 || number % Math.Ceiling(number / (double)i) == 0)
					return false;

			if (sqrt == Math.Floor(sqrt))
				return false;

			return true;
		}

		public static List<long> GetPrimeList(long max)
		{
			List<long> list = new List<long>();
			for (long i = 2; i < max; i++)
				if (IsPrime(i))
					list.Add(i);
			return list;
		}

		public static bool IsTruncatablePrime(long a)
		{
			if (a < 10)
				return false;

			string s = a.ToString();
			int len = s.Length;

			for (int i = 0; i < oneDigitPrimes.Length; i++)
				if (int.Parse(s[len - 1].ToString()) == oneDigitPrimes[i])
					goto Continue1;
			return false;

			Continue1:
			for (int i = 0; i < oneDigitPrimes.Length; i++)
				if (int.Parse(s[0].ToString()) == oneDigitPrimes[i])
					goto Continue2;
			return false;

			Continue2:
			long b = a;
			s = b.ToString();
			len = s.Length;
			while (len > 1)
				if (IsPrime(b))
					b = long.Parse(s.Substring(0, --len));
				else
					return false;

			b = a;
			s = b.ToString();
			len = s.Length;
			int x = 0;
			while (x < len - 1)
				if (IsPrime(b))
					b = long.Parse(s.Substring(++x, len - x));
				else
					return false;

			for (int i = 0; i < oneDigitPrimes.Length; i++)
				if (b == oneDigitPrimes[i])
					return true;

			return false;
		}

		public static bool IsCircularPrime(long a)
		{
			if (!IsPrime(a))
				return false;

			string r = a.ToString();
			for (int i = 0; i < a.ToString().Length; i++)
			{
				r = r.Substring(1, r.Length - 1) + r[0];
				if (!IsPrime(long.Parse(r)))
					return false;
			}

			return true;
		}
	}
}