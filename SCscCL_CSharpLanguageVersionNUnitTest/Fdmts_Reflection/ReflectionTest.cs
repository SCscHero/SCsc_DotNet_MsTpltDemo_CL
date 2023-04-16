using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
		public void 反射_获取父类类型_Eq3()
		{
			//1.获取其基类的类型
			var rflRes = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
				(type.BaseType?.IsGenericType ?? false)
					&& (type.BaseType.GetGenericTypeDefinition() == typeof(EfTypeMap_Eq3<>)));
			foreach (var item in rflRes)
			{
				Console.WriteLine("Assembly：" + item.Assembly);
				Console.WriteLine("FullName：" + item.FullName);
				Console.WriteLine("GenericTypeArguments：" + item.GenericTypeArguments);
				Console.WriteLine("BaseType：" + item.BaseType);//获取其基类的类型
				Console.WriteLine("ParentClassName：" + item.BaseType.Name);
				var parentClassGenericT = item?.BaseType?.GetGenericArguments().Where(r => r == typeof(Bas_Menu)).FirstOrDefault();
				Console.WriteLine("ParentClass.IsGenericType：" + ((item.BaseType?.IsGenericType ?? false)).ToString());//获取其基类的类型

				Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

				//var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
				//configuration.ApplyConfiguration(modelBuilder);
			}

		}
		private class BaseEntity_Eq3 { }
		private interface IEfTypeMap_Eq3<T> where T : BaseEntity_Eq3
		{
			void Configure();
		}
		private class EfTypeMap_Eq3<T> : IEfTypeMap_Eq3<T> where T : BaseEntity_Eq3
		{
			public void Configure()
			{

			}
		}
		private class Bas_Menu : BaseEntity_Eq3 { public string MenuName { get; set; } }
		private class Bas_MenuFl : EfTypeMap_Eq3<Bas_Menu> { }


		private class Room_Eq4 { }
		private class Kitchen_Eq4 : Room_Eq4 { }
		private class Bedroom_Eq4 : Room_Eq4 { }
		private class Guestroom_Eq4 : Bedroom_Eq4 { }
		private class MasterBedroom_Eq4 : Bedroom_Eq4 { }
		/// <summary>
		/// https://learn.microsoft.com/en-us/dotnet/api/system.type.isassignablefrom?view=net-8.0
		/// </summary>
		[Test]
		public void 反射_IsAssignableFrom函数根据基类Type获取遍历_Eq4()
		{
			// Demonstrate classes:
			Console.WriteLine("Defined Classes:");
			Room_Eq4 room1 = new Room_Eq4();
			Kitchen_Eq4 kitchen1 = new Kitchen_Eq4();
			Bedroom_Eq4 bedroom1 = new Bedroom_Eq4();
			Guestroom_Eq4 guestroom1 = new Guestroom_Eq4();
			MasterBedroom_Eq4 masterbedroom1 = new MasterBedroom_Eq4();

			Type room1Type = room1.GetType();
			Type kitchen1Type = kitchen1.GetType();
			Type bedroom1Type = bedroom1.GetType();
			Type guestroom1Type = guestroom1.GetType();
			Type masterbedroom1Type = masterbedroom1.GetType();

			Console.WriteLine("room assignable from kitchen: {0}", room1Type.IsAssignableFrom(kitchen1Type));
			Console.WriteLine("bedroom assignable from guestroom: {0}", bedroom1Type.IsAssignableFrom(guestroom1Type));
			Console.WriteLine("kitchen assignable from masterbedroom: {0}", kitchen1Type.IsAssignableFrom(masterbedroom1Type));

			// Demonstrate arrays:
			Console.WriteLine();
			Console.WriteLine("Integer arrays:");

			int[] array2 = new int[2];
			int[] array10 = new int[10];
			int[,] array22 = new int[2, 2];
			int[,] array24 = new int[2, 4];

			Type array2Type = array2.GetType();
			Type array10Type = array10.GetType();
			Type array22Type = array22.GetType();
			Type array24Type = array24.GetType();

			Console.WriteLine("int[2] assignable from int[10]: {0}", array2Type.IsAssignableFrom(array10Type));
			Console.WriteLine("int[2] assignable from int[2,4]: {0}", array2Type.IsAssignableFrom(array24Type));
			Console.WriteLine("int[2,4] assignable from int[2,2]: {0}", array24Type.IsAssignableFrom(array22Type));

			// Demonstrate generics:
			Console.WriteLine();
			Console.WriteLine("Generics:");

			// Note that "int?[]" is the same as "Nullable<int>[]"
			int?[] arrayNull = new int?[10];
			List<int> genIntList = new List<int>();
			List<Type> genTList = new List<Type>();

			Type arrayNullType = arrayNull.GetType();
			Type genIntListType = genIntList.GetType();
			Type genTListType = genTList.GetType();

			Console.WriteLine("int[10] assignable from int?[10]: {0}", array10Type.IsAssignableFrom(arrayNullType));
			Console.WriteLine("List<int> assignable from List<Type>: {0}", genIntListType.IsAssignableFrom(genTListType));
			Console.WriteLine("List<Type> assignable from List<int>: {0}", genTListType.IsAssignableFrom(genIntListType));

			Console.ReadLine();
		}


	}
}