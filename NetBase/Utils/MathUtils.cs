﻿using System;

namespace NetBase.Utils
{
	public static class MathUtils
	{
		public static float Lerp(float value1, float value2, float amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
		{
			return (value.CompareTo(min) < 0) ? min : (value.CompareTo(max) > 0) ? max : value;
		}
	}
}