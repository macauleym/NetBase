using System;
using System.Collections.Generic;
using System.Reflection;

namespace NetBase.Utils
{
	public static class ReflectionUtils
	{
		public static object GetDefaultValue(Type type)
		{
			if (type.IsValueType)
				return Activator.CreateInstance(type);

			if (type == typeof(string))
				return string.Empty;

			return null;
		}

		public static object GetDefaultValue<T>()
		{
			if (typeof(T).IsValueType)
				return Activator.CreateInstance<T>();

			if (typeof(T) == typeof(string))
				return (T)(object)string.Empty;

			return null;
		}

		public static IEnumerable<T2> GetMemberValues<T1, T2>(this IEnumerable<T1> source, string memberName, bool caseSensitive = true)
			where T2 : class
		{
			MemberInfo memberInfo = GetMemberInfoByName<T1>(memberName, caseSensitive);
			foreach (T1 t in source)
			{
				if (memberInfo is FieldInfo f)
					yield return f.GetValue(t) as T2;
				else if (memberInfo is PropertyInfo p)
					yield return p.GetValue(t) as T2;
			}
		}

		public static MemberInfo GetMemberInfoByName<T>(string memberName, bool caseSensitive = true)
		{
			foreach (MemberInfo member in typeof(T).GetMembers())
				if (member.Name == memberName || (!caseSensitive && member.Name.ToLower() == memberName.ToLower()))
					return member;

			throw new Exception($"Member {memberName} not found in type {typeof(T)}");
		}
	}
}