using System;

namespace NetBase.Utils
{
	public static class ConsoleUtils
	{
		public static void WriteColor(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.Write(message);
		}

		public static void WriteLineColor(string message, ConsoleColor color)
		{
			WriteColor($"{message}\n", color);
		}
	}
}