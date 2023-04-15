using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Reflection
{
	public class ReflectionTest
	{
		[SetUp]
		public void Setup()
		{
		}

		private class Student
		{
			public int Name { get; set; }
		}
		[Test]
		public void 反射_确定类型是否为泛型_Eq1()
		{
			Type t1 = typeof(Dictionary<string, Student>);
			Console.WriteLine("Namespace>>>" + t1.Namespace);
			Console.WriteLine("Assembly>>>" + t1.Assembly);
			Console.WriteLine("IsGenericType>>>" + t1.IsGenericType);
			Console.WriteLine("IsGenericTypeDefinition>>>" + t1.IsGenericTypeDefinition);
		}

		[Test]
		public void 反射_获取泛型类型参数_Eq2()
		{
			Type t1 = typeof(Dictionary<string, Student>);
			Type[] typeParams = t1.GetGenericArguments();
			Console.WriteLine($"List {typeParams.Length} type arguments:");
			foreach (var item in typeParams)
			{
				if (item.IsGenericParameter)
				{
					DisplayGenericParameter_Eq2(item);
				}
				else
				{
					Console.WriteLine("Type argument: {0}", item);
				}
			}
		}
		private static void DisplayGenericParameter_Eq2(Type tp)
		{
			Console.WriteLine("      Type parameter: {0} position {1}", tp.Name, tp.GenericParameterPosition);
		}

		/// <summary>
		/// Ref:https://learn.microsoft.com/zh-cn/dotnet/framework/reflection-and-codedom/how-to-examine-and-instantiate-generic-types-with-reflection
		/// </summary>
		[Test]
		public void 反射_获取泛型约束_Eq3()
		{

		}
	}
}