using System;

namespace NetBase.Console
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
}