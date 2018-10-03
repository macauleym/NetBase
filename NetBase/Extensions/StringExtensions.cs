using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using NetBase.Utils;

namespace NetBase.Extensions
{
	public static class StringExtensions
	{
		public static string Reverse(this string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);

			return new string(charArray);
		}

		public static bool IsPalindrome(this string s)
		{
			return s == Reverse(s);
		}

		public static string Alphanumeric(this string s)
		{
			return Regex.Replace(s, "[^A-Za-z0-9 ]", ""); ;
		}

		public static string Numeric(this string s)
		{
			return Regex.Replace(s, "[^0-9 ]", ""); ;
		}

		public static bool IsRoman(this string s)
		{
			foreach (char c in s)
				if (!RomanUtils.romanMap.ContainsKey(c))
					return false;
			return true;
		}

		public static string RemoveSubstring(this string s, string from, string to)
		{
			while (s.Contains(from) && s.Contains(to))
			{
				int start = s.IndexOf(from);
				string n = s.Substring(start);
				int count = n.Substring(0, n.IndexOf(to)).Length + to.Length;

				s = s.Remove(start, count);
			}

			return s;
		}

		public static string ReplaceFirst(this string s, string search, string replace)
		{
			int pos = s.IndexOf(search);
			if (pos < 0)
				return s;

			return s.Substring(0, pos) + replace + s.Substring(pos + search.Length);
		}

		public static T Convert<T>(this string s)
		{
			try
			{
				return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(s);
			}
			catch (Exception)
			{
				return default(T);
			}
		}

		public static string NumeralAddition(this string s1, string s2)
		{
			if (s1.Numeric() != s1 || s2.Numeric() != s2)
				return string.Empty;

			string aRev = s1.Reverse();
			string bRev = s2.Reverse();

			int length = Math.Max(aRev.Length, bRev.Length) + 1;
			char[] n = new char[length];

			int remainder = 0;
			for (int i = 0; i < length; i++)
			{
				int aDigit = aRev.Length > i ? int.Parse(aRev[i].ToString()) : 0;
				int bDigit = bRev.Length > i ? int.Parse(bRev[i].ToString()) : 0;
				int result = aDigit + bDigit + remainder;
				string resultStr = result.ToString();
				remainder = (resultStr.Length > 1) ? int.Parse(resultStr[0].ToString()) : 0;

				n[i] = int.Parse(resultStr[resultStr.Length - 1].ToString()).ToString()[0];
			}

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < n.Length; i++)
				sb.Append(n[i]);

			string endResult = sb.ToString();
			for (int i = endResult.Length - 1; i >= 0; i--)
				if (endResult[i] == '0')
					endResult = endResult.Substring(0, endResult.Length - 1);
				else
					break;

			return endResult.Reverse();
		}

		public static string NumeralSubtraction(this string s1, string s2)
		{
			if (s1.Numeric() != s1 || s2.Numeric() != s2)
				return string.Empty;

			string aRev = s1.Reverse();
			string bRev = s2.Reverse();

			int length = Math.Max(aRev.Length, bRev.Length);
			char[] n = new char[length];

			int remainder = 0;
			for (int i = 0; i < length; i++)
			{
				int aDigit = aRev.Length > i ? int.Parse(aRev[i].ToString()) : 0;
				int bDigit = bRev.Length > i ? int.Parse(bRev[i].ToString()) : 0;
				int result = aDigit - bDigit - remainder;

				remainder = 0;
				while (result < 0)
				{
					result += 10;
					remainder++;
				}

				string resultStr = result.ToString();

				n[i] = int.Parse(resultStr[resultStr.Length - 1].ToString()).ToString()[0];
			}

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < n.Length; i++)
				sb.Append(n[i]);

			string endResult = sb.ToString();
			for (int i = endResult.Length - 1; i >= 0; i--)
				if (endResult[i] == '0')
					endResult = endResult.Substring(0, endResult.Length - 1);
				else
					break;

			return endResult.Reverse();
		}

		public static string TrimStart(this string s, string trimChars)
		{
			if (s.StartsWith(trimChars))
				return s.TrimStart(trimChars.ToCharArray());
			return s;
		}

		public static string TrimEnd(this string s, string trimChars)
		{
			if (s.EndsWith(trimChars))
				return s.TrimEnd(trimChars.ToCharArray());
			return s;
		}

		public static List<string> GetPermutations(this string s, string prefix)
		{
			List<string> perms = new List<string>();

			int n = s.Length;
			if (n == 0)
			{
				perms.Add(prefix);
			}
			else
			{
				for (int i = 0; i < n; i++)
					perms.AddRange(GetPermutations(s.Substring(0, i) + s.Substring(i + 1, n - (i + 1)), prefix + s[i]));
			}

			return perms;
		}

		public static int DigitAt(this string s, int pos)
		{
			return int.Parse(s[pos].ToString());
		}

		public static bool ContainsSameChars(this string s1, string s2)
		{
			if (s1.Length != s2.Length)
				return false;

			for (int i = 0; i < s1.Length; i++)
				if (!s1.Contains(s2[i].ToString()))
					return false;

			return true;
		}

		public static string SubstringSafe(this string s, int startIndex, int length)
		{
			return s.Substring(Math.Min(startIndex, s.Length), Math.Min(Math.Max(0, length), Math.Max(0, s.Length - startIndex)));
		}

		public static string Repeat(this string s, int amount)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < amount; i++)
				sb.Append(s);
			return sb.ToString();
		}

		public static IEnumerable<int> AllIndicesOf(this string s, string substring)
		{
			for (int i = 0; ; i += substring.Length)
			{
				i = s.IndexOf(substring, i);
				if (i == -1)
					break;
				yield return i;
			}
		}
	}
}