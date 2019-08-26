using NetBase.Extensions;
using System;

namespace NetBase.Console
{
	public static class ConsoleUtils
	{
		public static void WriteColor(string message, ConsoleColor color)
		{
			System.Console.ForegroundColor = color;
			System.Console.Write(message);
			System.Console.ResetColor();
		}

		public static void WriteLineColor(string message, ConsoleColor color)
		{
			WriteColor($"{message}\n", color);
		}

		public static void WriteColorMultiple(params MessagePart[] messageParts)
		{
			foreach (MessagePart mp in messageParts)
			{
				System.Console.ForegroundColor = mp.Color;
				System.Console.Write(mp.Message);
			}
			System.Console.ResetColor();
		}

		public static void WriteLineColorMultiple(params MessagePart[] messageParts)
		{
			WriteColorMultiple(messageParts);
			System.Console.WriteLine();
		}

		public static void ClearLine(int offset)
		{
			int currentLineCursor = System.Console.CursorTop + offset;
			System.Console.SetCursorPosition(0, System.Console.CursorTop);
			System.Console.Write(new string(' ', System.Console.BufferWidth));
			System.Console.SetCursorPosition(0, currentLineCursor - offset);
		}

		public static void WriteBanner(string name, int paddingHor, int paddingVer, char border, ConsoleColor background, ConsoleColor foreground)
		{
			System.Console.BackgroundColor = background;
			System.Console.ForegroundColor = foreground;
			for (int i = 0; i < paddingVer * 2 + 1; i++)
			{
				if (i == 0 || i == paddingVer * 2)
					System.Console.WriteLine(border.ToString().Repeat(name.Length + paddingHor * 2 + 2));
				else if (i == paddingVer)
					System.Console.WriteLine($"{border}{" ".Repeat(paddingHor)}{name}{" ".Repeat(paddingHor)}{border}");
				else
					System.Console.WriteLine($"{border}{" ".Repeat(paddingHor * 2 + name.Length)}{border}");
			}
			System.Console.ResetColor();
		}
	}
}