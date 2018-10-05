using NetBase.Extensions;
using System;

namespace NetBase.Utils
{
	public class MessagePart
	{
		public string Message { get; set; }
		public ConsoleColor Color { get; set; }

		public MessagePart(string message, ConsoleColor color)
		{
			Message = message;
			Color = color;
		}
	}

	public static class ConsoleUtils
	{
		public static void WriteColor(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(message);
			Console.ResetColor();
		}

		public static void WriteLineColor(string message, ConsoleColor color)
		{
			WriteColor($"{message}\n", color);
		}

		public static void WriteColorMultiple(params MessagePart[] messageParts)
		{
			foreach (MessagePart mp in messageParts)
			{
				Console.ForegroundColor = mp.Color;
				Console.Write(mp.Message);
			}
			Console.ResetColor();
		}

		public static void WriteLineColorMultiple(params MessagePart[] messageParts)
		{
			WriteColorMultiple(messageParts);
			Console.WriteLine();
		}

		public static void ClearLine(int offset)
		{
			int currentLineCursor = Console.CursorTop + offset;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, currentLineCursor - offset);
		}

		public static void WriteBanner(string name, int paddingHor, int paddingVer, char border, ConsoleColor background, ConsoleColor foreGround)
		{
			Console.BackgroundColor = background;
			Console.ForegroundColor = foreGround;
			for (int i = 0; i < paddingVer * 2 + 1; i++)
			{
				if (i == 0 || i == paddingVer * 2)
					Console.WriteLine(border.ToString().Repeat(name.Length + paddingHor * 2 + 2));
				else if (i == paddingVer)
					Console.WriteLine($"{border}{" ".Repeat(paddingHor)}{name}{" ".Repeat(paddingHor)}{border}");
				else
					Console.WriteLine($"{border}{" ".Repeat(paddingHor * 2 + name.Length)}{border}");
			}
			Console.ResetColor();
		}
	}
}