using System;

namespace NetBase.Utils
{
	public static class RandomUtils
	{
		private static readonly Random random = new Random();

		/// <summary>
		/// Returns a random <see cref="int"/> between 0 and <paramref name="maxValue"/>.
		/// </summary>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>The random <see cref="int"/>.</returns>
		public static int RandomInt(int maxValue)
		{
			return random.Next(maxValue);
		}

		/// <summary>
		/// Returns a random <see cref="int"/> between <paramref name="minValue"/> and <paramref name="maxValue"/>.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>The random <see cref="int"/>.</returns>
		public static int RandomInt(int minValue, int maxValue)
		{
			if (minValue > maxValue) // Prevent Exception from being thrown
				return random.Next(maxValue, minValue);

			return random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Returns a random <see cref="float"/> between 0.0f and <paramref name="maxValue"/>.
		/// </summary>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>The random <see cref="float"/>.</returns>
		public static float RandomFloat(float maxValue)
		{
			return (float)random.NextDouble() * maxValue;
		}

		/// <summary>
		/// Returns a random <see cref="float"/> between <paramref name="minValue"/> and <paramref name="maxValue"/>.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>The random <see cref="float"/>.</returns>
		public static float RandomFloat(float minValue, float maxValue)
		{
			return ((float)random.NextDouble() * (maxValue - minValue)) + minValue;
		}

		/// <summary>
		/// Returns a random item from the given <paramref name="options"/> array.
		/// </summary>
		/// <typeparam name="T">The type of the items in the array.</typeparam>
		/// <param name="options">The array to choose from.</param>
		/// <returns>The randomly chosen item.</returns>
		public static T Choose<T>(params T[] options)
		{
			return options[random.Next(options.Length)];
		}

		/// <summary>
		/// Returns true or false based on the <paramref name="percentage"/>.
		/// </summary>
		/// <param name="percentage">The percentage.</param>
		/// <returns>The result.</returns>
		public static bool Chance(float percentage)
		{
			return RandomFloat(100) < percentage;
		}
	}
}