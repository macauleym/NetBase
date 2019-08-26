using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

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
			return Regex.Replace(s, "[^A-Za-z0-9 ]", "");
		}

		public static string Numeric(this string s)
		{
			return Regex.Replace(s, "[^0-9 ]", "");
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
			catch
			{
				return default;
			}
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

		public static string ChopOffAfter(this string str, int count, string substr)
		{
			return str.Substring(0, RepeatedIndexOf(str, count, substr) + 1);
		}

		public static string ChopOffAt(this string str, int count, string substr)
		{
			return str.Substring(0, RepeatedIndexOf(str, count, substr));
		}

		private static int RepeatedIndexOf(string str, int count, string substr)
		{
			int index = 0;
			do
			{
				index = str.IndexOf(substr, index);
				if (index < 0)
					return index;
				index++;
				count--;
			}
			while (count > 0);

			return index - 1;
		}

		public static int CountOccurrences(this string str, char occurrence)
		{
			return str.Split(occurrence).Length - 1;
		}

		public static int CountOccurrences(this string str, string occurrence)
		{
			return (str.Length - str.Replace(occurrence, string.Empty).Length) / occurrence.Length;
		}
	}
}