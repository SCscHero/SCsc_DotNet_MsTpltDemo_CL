using System;
using System.Collections.Generic;
using System.Linq;

namespace CsLangVersion.Fdmts_CollectionType
{
	public class ListTest
	{


		/// <summary>
		/// 结果集合并方法：Range
		/// </summary>
		[Test]
		public void Eq001_ListM_Range()
		{
			List<int> intList1 = new List<int>() { 1, 2, 3, 4, 5, 7, 6, 7, 8 };
			List<int> intList2 = new List<int>() { 60, 70 };
			//public void AddRange(IEnumerable<T> collection)
			intList1.AddRange(intList2);
			if (intList1.Count == 11)
			{
				Assert.Pass();
			}
		}


		#region Eq002_TestModel
		private class Eq002_Pet
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		private class Eq002_Person
		{
			public string LastName { get; set; }
			public Eq002_Pet[] Pets { get; set; }
		}
		#endregion

		/// <summary>
		/// Any无参函数：判断集合是否为空
		/// </summary>
		[Test]
		public void Eq002_ListM_Any()
		{
			List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 7, 6, 7, 8 };
			{
				bool hasElements = numbers.Any();
				Console.WriteLine("The list {0} empty.",
					hasElements ? "is not" : "is");
			}
			{
				List<Eq002_Person> people = new List<Eq002_Person>
				{ new Eq002_Person { LastName = "Haas",
						 Pets = new Eq002_Pet[] { new Eq002_Pet { Name="Barley", Age=10 },
											new Eq002_Pet { Name="Boots", Age=14 },
											new Eq002_Pet { Name="Whiskers", Age=6 }}},
					new Eq002_Person { LastName = "Fakhouri",
						 Pets = new Eq002_Pet[] { new Eq002_Pet { Name = "Snowball", Age = 1}}},
					new Eq002_Person { LastName = "Antebi",
						 Pets = new Eq002_Pet[] { }},
					new Eq002_Person { LastName = "Philips",
						 Pets = new Eq002_Pet[] { new Eq002_Pet { Name = "Sweetie", Age = 2},
											new Eq002_Pet { Name = "Rover", Age = 13}} }
		};
				// Determine which people have a non-empty Pet array.
				IEnumerable<string> names = from person in people
																		where person.Pets.Any()
																		select person.LastName;

				//筛选Pets有值的Person
				foreach (string name in names)
				{
					Console.WriteLine(name);
				}
				/* This code produces the following output:
				   Haas
				   Fakhouri
				   Philips
				*/
			}
		}

		#region Eq003_TestModel
		private class Eq003_Pet
		{
			public string Name { get; set; }
			public int Age { get; set; }
			public bool Vaccinated { get; set; }
		}

		#endregion

		/// <summary>
		/// Any带条件判断集合中是否有符合条件的记录
		/// </summary>
		[Test]
		public void Eq003_ListM_AnyWithArguments()
		{
			Eq003_Pet[] pets = { new Eq003_Pet { Name="Barley", Age=8, Vaccinated=true },
			new Eq003_Pet { Name="Boots", Age=4, Vaccinated=false },
			new Eq003_Pet { Name="Whiskers", Age=1, Vaccinated=false } };
			// Determine whether any pets over age 1 are also unvaccinated.
			bool unvaccinated = pets.Any(p => p.Age > 1 && p.Vaccinated == false);

			Console.WriteLine(
			"There {0} unvaccinated animals over age one.",
			unvaccinated ? "are" : "are not any");
		}

		#region 
		private class Eq004_Pet
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		#endregion

		[Test]
		public void Eq004_ListM_All()
		{
			// Create an array of Pets.
			Eq004_Pet[] pets = { new Eq004_Pet { Name="Barley", Age=10 },
					 new Eq004_Pet { Name="Boots", Age=4 },
					 new Eq004_Pet { Name="Whiskers", Age=6 } };

			// Determine whether all pet names
			// in the array start with 'B'.
			bool allStartWithB = pets.All(pet =>
												pet.Name.StartsWith("B"));

			Console.WriteLine(
				"{0} pet names start with 'B'.",
				allStartWithB ? "All" : "Not all");
		}

		[Test]
		public void Eq005_ListM_ToArrayStringJoin()
		{
			var intId = new List<int>() { 1, 5, 6, 7, 8 };
			Console.WriteLine(string.Join(',', intId.ToArray()));

		}

		#region Eq006_TestModel
		private class Eq006_Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		#endregion

		[Test]
		public void Eq006_ListEm_Foreach()
		{
			var personList = new List<Eq006_Person>()
			{
				new Eq006_Person(){Name="SCscHero",Age=30},
				new Eq006_Person(){Name="Jack",Age=40},
				new Eq006_Person(){Name="Bruce",Age=35}
			};

			personList.ForEach(r => r.Age += 1);
			personList.ForEach(r => { Console.WriteLine(r.Name + r.Age); });
			/*Output:
			    SCscHero31
				Jack41
				Bruce36
			 */
		}

		[Test]
		public void Eq007_ListPTType_Distinct()
		{
			List<int> ilist = new List<int>() { 1, 2, 3, 4, 2, 3 };
			ilist = ilist.Distinct().ToList();
			foreach (var item in ilist)
			{
				Console.WriteLine(item);
			}

			List<string> strList = new List<string>() { "4", "4", "5", "6", "6", "22", "11", "22" };
			strList = strList.Distinct().ToList();
			foreach (var item in strList)
			{
				Console.WriteLine(item);
			}
		}

		private class Eq008_User
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public int Age { get; set; }
		}
		List<Eq008_User> Eq8list = new List<Eq008_User>()
 {
	new Eq008_User() { Id = 1, Name = "张三", Age = 11 } ,
	new Eq008_User() { Id = 1, Name = "张三", Age = 11} ,
	new Eq008_User() { Id = 3, Name = "李四", Age = 13 } ,
	new Eq008_User() { Id = 7, Name = "王五", Age = 15 } ,
	new Eq008_User() { Id = 8, Name = "王五", Age = 16 } ,
	new Eq008_User() { Id = 8, Name = "王五", Age = 17 } ,
	new Eq008_User() { Id = 10, Name = "陈六", Age = 17 } ,
	new Eq008_User() { Id = 11, Name = "马户", Age = 25 } ,
	new Eq008_User() { Id = 11, Name = "马户", Age = 25 } ,
	new Eq008_User() { Id = 11, Name = "马户", Age = 25 } ,
	new Eq008_User() { Id = 11, Name = "又鸟", Age = 25 } ,
	new Eq008_User() { Id = 11, Name = "又鸟", Age = 26 } ,
	new Eq008_User() { Id = 11, Name = "又鸟", Age = 26 } ,
 };
		[Test]
		public void Eq008_ListEntityType_Distinct_使用GroupBy的错误示例()
		{

			//【缺陷方案】使用List对象GroupBy方法一条一条去实现。
			Eq8list = Eq8list.GroupBy(p => p.Name).Select(q => q.First()).ToList();
			Eq8list = Eq8list.GroupBy(p => p.Id).Select(q => q.First()).ToList();
			Eq8list = Eq8list.GroupBy(p => p.Age).Select(q => q.First()).ToList();
			foreach (var item in Eq8list)
			{
				Console.WriteLine("Id:" + item.Id + ", Name:" + item.Name + ", Age:" + item.Age);
			}
		}

		private class Eq008_Product
		{
			public string Name { get; set; }
			public int Code { get; set; }
		}
		// Custom comparer for the Product class
		private class Eq008_ProductComparer : IEqualityComparer<Eq008_Product>
		{
			// Products are equal if their names and product numbers are equal.
			public bool Equals(Eq008_Product x, Eq008_Product y)
			{
				//Check whether the compared objects reference the same data.
				if (Object.ReferenceEquals(x, y)) return true;
				//Check whether any of the compared objects is null.
				if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
					return false;
				//Check whether the products' properties are equal.
				return x.Code == y.Code && x.Name == y.Name;
			}
			// If Equals() returns true for a pair of objects
			// then GetHashCode() must return the same value for these objects.
			public int GetHashCode(Eq008_Product product)
			{
				//Check whether the object is null
				if (Object.ReferenceEquals(product, null)) return 0;
				//Get hash code for the Name field if it is not null.
				int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();
				//Get hash code for the Code field.
				int hashProductCode = product.Code.GetHashCode();
				//Calculate the hash code for the product.
				return hashProductName ^ hashProductCode;
			}
		}

		/// <summary>
		/// https://learn.microsoft.com/zh-cn/dotnet/api/system.linq.enumerable.distinct?view=net-7.0
		/// </summary>
		[Test]
		public void Eq008_ListEntityType_Distinct_Entity实现比较器后去重()
		{
			Eq008_Product[] products = { new Eq008_Product { Name = "apple", Code = 9 },
						 new Eq008_Product { Name = "orange", Code = 4 },
						 new Eq008_Product { Name = "apple", Code = 9 },
						 new Eq008_Product { Name = "orange", Code = 4 },
						 new Eq008_Product { Name = "orange", Code = 4 },
						 new Eq008_Product { Name = "apple", Code = 25 },
						 new Eq008_Product { Name = "orange", Code = 4 },
						 new Eq008_Product { Name = "apple11", Code = 25 },
						 new Eq008_Product { Name = "orange", Code = 4 },
						 new Eq008_Product { Name = "lemon", Code = 12 } };
			// Exclude duplicates.
			IEnumerable<Eq008_Product> noduplicates =
				products.Distinct(new Eq008_ProductComparer());

			foreach (var product in noduplicates)
				Console.WriteLine(product.Name + " " + product.Code);
		}

		/// <summary>
		/// 【稳定方案1】使用Linq实现。
		/// </summary>
		[Test]
		public void Eq008_ListEntityType_Distinct_使用Linq去重()
		{
			var list1 = (from p in Eq8list
									 group p by new { p.Id, p.Name, p.Age } into g
									 select g).ToList();
			foreach (var item in list1)
			{
				Console.WriteLine("Id:" + item.Key.Id + ", Name:" + item.Key.Name + ", Age:" + item.Key.Age);
			}
		}

		public class Eq_009_Pet
		{
			public string Name { get; set; }
			public double Age { get; set; }
		}
		public class Eq_009_Person
		{
			public string Name { get; set; }
			public int Age { get; private set; }
			public string Sex { get; set; }
			public int Money { get; set; }

			public Eq_009_Person(string name, string sex, int age, int money)
			{
				Name = name;
				Age = age;
				Sex = sex;
				Money = money;
			}
		}

		[Test]
		public void Eq_009_List使用GroupBy示例()
		{
			List<Eq_009_Pet> petsList =
			 new List<Eq_009_Pet>{ new Eq_009_Pet { Name="Barley", Age=8.3 },
			 new Eq_009_Pet { Name="Barley", Age=8.3 },
			 new Eq_009_Pet { Name="Barley", Age=8.3 },
			 new Eq_009_Pet { Name="Boots", Age=4.9 },
				new Eq_009_Pet { Name="废物", Age=8.3 },
				new Eq_009_Pet { Name="废物", Age=4.9 },
				new Eq_009_Pet { Name="混混", Age=4.9 },
				new Eq_009_Pet { Name="Boots", Age=5.8 },
				new Eq_009_Pet { Name="Boots", Age=6.9 },
				new Eq_009_Pet { Name="Boots", Age=7.9 },
				new Eq_009_Pet { Name="Whiskers", Age=1.5 },
				new Eq_009_Pet { Name="Daisy", Age=4.3 } };
			//去重Name输出该列
			var distinctList = petsList.GroupBy(pet => pet.Name).ToList();
			//分组求和：按宠物名输出分别出现多少次；
			var petName_CountList = petsList.GroupBy(pet => pet.Name).Select(g => (new { name = g.Key, count = g.Count(), ageC = g.Sum(item => item.Age) }));

			List<Eq_009_Person> personsList = new List<Eq_009_Person>();
			personsList.Add(new Eq_009_Person("张三", "男", 20, 1500));
			personsList.Add(new Eq_009_Person("王成", "男", 32, 3200));
			personsList.Add(new Eq_009_Person("李丽", "女", 19, 1700));
			personsList.Add(new Eq_009_Person("何英", "女", 35, 3600));
			personsList.Add(new Eq_009_Person("何英", "女", 18, 1600));
			//分组求和：按性别输出男女分别多少；
			//写法1：Lambda 表达式写法（推荐）  
			var ls = personsList.GroupBy(a => a.Name).Select(g => (new { name = g.Key, count = g.Count(), ageC = g.Sum(item => item.Age), moneyC = g.Sum(item => item.Money) }));
			//写法2：类SQL语言写法 最终编译器会把它转化为lamda表达式  
			var ls2 = from ps in personsList
								group ps by ps.Name
									 into g
								select new { name = g.Key, count = g.Count(), ageC = g.Sum(item => item.Age), moneyC = g.Sum(item => item.Money) };
			Console.WriteLine();

		}
	}
}
