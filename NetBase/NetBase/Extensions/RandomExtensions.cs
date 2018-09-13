using System;

namespace NetBase.Extensions
{
	public static class RandomExtensions
	{
		public static double RandomRange(this Random random, double min, double max)
		{
			return random.NextDouble() * (max - min) + min;
		}
	}
}