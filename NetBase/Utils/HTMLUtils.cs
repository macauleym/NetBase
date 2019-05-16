using NetBase.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NetBase.Utils
{
	public static class HTMLUtils
	{
		/// <summary>
		/// Gets an HTML element's name.
		/// </summary>
		/// <param name="element">The element string.</param>
		/// <returns>The element's name, e.g. <h1> will return h1.</returns>
		public static string GetElementName(string element)
		{
			if (!IsElementValid(element))
				return null;

			int ltPos = element.IndexOf('<');
			int gtPos = element.IndexOf('>');

			if (ltPos > gtPos)
				return null;

			int? spacePos = null;
			if (element.Contains(' '))
				spacePos = element.IndexOf(' ');

			if (spacePos.HasValue)
				return element.SubstringSafe(ltPos + 1, Math.Min(gtPos, spacePos.Value) - (ltPos + 1));
			return element.SubstringSafe(ltPos + 1, gtPos - (ltPos + 1));
		}

		/// <summary>
		/// Gets an HTML element's value.
		/// </summary>
		/// <param name="element">The element string.</param>
		/// <returns>The element's value, e.g. <h1>A</h1> will return A.</returns>
		public static string GetElementValue(string element)
		{
			if (!IsElementValid(element))
				return null;

			int gtPos = element.IndexOf('>');
			int ltPos = element.LastIndexOf('<');

			if (gtPos > ltPos)
				return null;

			return element.SubstringSafe(gtPos + 1, ltPos - (gtPos + 1));
		}

		public static string GetElementAttribute(string element, string attrName)
		{
			if (!IsElementValid(element))
				return null;

			int ltPos = element.IndexOf('<');
			int gtPos = element.IndexOf('>');

			if (ltPos > gtPos)
				return null;

			if (!element.Contains(' '))
				return null;

			int spacePos = element.IndexOf(' ');
			if (element.Substring(spacePos + 1, attrName.Length) == attrName)
			{
				string sub = element.Substring(spacePos + 1 + attrName.Length + 1);

				int? lastQuotePos = null;
				if (sub.Contains("\""))
					lastQuotePos = sub.IndexOf("\"");
				else if (sub.Contains("'"))
					lastQuotePos = sub.IndexOf("'");

				if (!lastQuotePos.HasValue)
					return null;
				return element.Substring(spacePos + 1 + attrName.Length + 1, lastQuotePos.Value - (spacePos + 1 + attrName.Length + 1));
			}

			return null;
		}

		public static bool IsElementValid(string element)
		{
			return element.Contains('<') && element.Contains('>');
		}

		public static string GenerateHeadingIDs(string html, bool[] includeHeadings)
		{
			string[] lines = html.Split('\n');
			for (int i = 0; i < lines.Length; i++)
			{
				for (int h = 1; h <= 6; h++)
				{
					if (includeHeadings[h - 1] && GetElementName(lines[i]) == $"h{h}")
					{
						string value = GetElementValue(lines[i]);
						lines[i] = $"<h{h} id=\"{value.ToLower().Replace(' ', '-')}\">{value}</h{h}>";
						break;
					}
				}
			}

			return string.Join("\n", lines);
		}

		public static string GenerateTableOfContents(string html, bool[] includeHeadings)
		{
			List<Tuple<int, string>> contents = new List<Tuple<int, string>>();

			string[] lines = html.Split('\n');
			for (int i = 0; i < lines.Length; i++)
			{
				for (int h = 1; h <= 6; h++)
				{
					if (includeHeadings[h - 1] && GetElementName(lines[i]) == $"h{h}")
					{
						contents.Add(Tuple.Create(h, GetElementValue(lines[i])));
						break;
					}
				}
			}

			int currentHeading = 0;
			StringBuilder tableOfContents = new StringBuilder();
			foreach (Tuple<int, string> tuple in contents)
			{
				int difference = tuple.Item1 - currentHeading;

				if (difference > 0)
					for (int i = 0; i < difference; i++)
						tableOfContents.AppendLine($"<ul>\n<li>");
				else if (difference < 0)
					for (int i = 0; i > difference; i--)
						tableOfContents.AppendLine($"</li>\n</ul>\n</li>\n<li>");
				else
					tableOfContents.AppendLine($"</li>\n<li>");

				tableOfContents.AppendLine($"<a href=\"#{tuple.Item2.ToLower().Replace(' ', '-')}\">{tuple.Item2}</a>");

				currentHeading = tuple.Item1;
			}

			while (currentHeading > 0)
			{
				tableOfContents.AppendLine($"</li>\n</ul>");
				currentHeading--;
			}

			return XDocument.Parse(tableOfContents.ToString()).ToString();
		}
	}
}