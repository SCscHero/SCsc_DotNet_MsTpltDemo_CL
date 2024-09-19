using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType
{
	public partial class ListTest
	{

		List<Eq_009_Person> persons = new List<Eq_009_Person>() {
			new Eq_009_Person("张三", "男", 20, 1500),
			new Eq_009_Person("王成", "男", 32, 3200),
			new Eq_009_Person("李丽", "女", 19, 1700),
			new Eq_009_Person("何英", "女", 35, 3600),
			new Eq_009_Person("何英", "女", 18, 1600),
		};

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

		Person[] duplicatePeopleArray =
{ new Person { PName = "Haas",
			Pets = new Pet[] { new Pet { Name="Barley", Age=10 },
				new Pet { Name="Boots", Age=14 },
				new Pet { Name="Whiskers", Age=6 }}},

					new Person { PName = "Fakhouri",
						Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},
					new Person { PName = "Antebi",
						Pets = new Pet[] { }},
					new Person { PName = "Philips",
						Pets = new Pet[] { new Pet { Name = "Sweetie", Age = 2},
											new Pet { Name = "Rover", Age = 13}} },
					new Person { PName = "Philips",
						Pets = new Pet[] { new Pet { Name = "GouTo1", Age = 5},
											new Pet { Name = "Rover", Age = 13}} },
					new Person { PName = "Philips",
						Pets = new Pet[] { new Pet { Name = "GouTo1", Age = 5},
											new Pet { Name = "Rover", Age = 13}} },
					new Person { PName = "Fakhouri",
						Pets = new Pet[] { new Pet { Name = "Snowball", Age = 1}}},

		};

		[SetUp]
		public void Init_Setup()
		{

		}

		private class Pet
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		private class Person
		{
			public string PName { get; set; }
			public Pet[] Pets { get; set; }
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


	}
}
