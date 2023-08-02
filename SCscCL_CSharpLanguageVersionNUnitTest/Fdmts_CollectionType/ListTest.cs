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

			List<string> strList = new List<string>() { "4", "4", "5", "6", "6","22","11","22" };
			strList = strList.Distinct().ToList();
			foreach (var item in strList)
			{
				Console.WriteLine(item);
			}
		}



	}
}
