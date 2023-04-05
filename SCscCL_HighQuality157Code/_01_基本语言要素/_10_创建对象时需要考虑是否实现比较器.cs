using System.Collections;

namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _10_创建对象时需要考虑是否实现比较器
	{

		#region TestModel_Eq1
		private class Eq1Salary : IComparable
		{
			public string Name { get; set; }
			public int BaseSalary { get; set; }
			public int Bonus { get; set; }
			/// <summary>
			/// IComparable成员
			/// </summary>
			/// <param name="obj"></param>
			/// <returns></returns>
			/// <exception cref="NotImplementedException"></exception>
			public int CompareTo(object? obj)
			{
				Eq1Salary staff = obj as Eq1Salary;
				//【选择1】实现对比逻辑
				if (BaseSalary > staff.BaseSalary)
				{
					return 1;
				}
				else if (BaseSalary == staff.BaseSalary)
				{
					return 0;
				}
				else
				{
					return -1;
				}
				//【选择2】调用内置方法也可以实现如上的逻辑
				//BaseSalary.CompareTo(staff.BaseSalary);
			}
		}
		#endregion
		[TestMethod]
		public void Eq1IComparable的基础使用()
		{
			//
			ArrayList al = new ArrayList();
			al.Add(new Eq1Salary() { Name = "SCscHero", BaseSalary = 300 });
			al.Add(new Eq1Salary() { Name = "Serral", BaseSalary = 2000 });
			al.Add(new Eq1Salary() { Name = "Maru", BaseSalary = 350 });
			al.Add(new Eq1Salary() { Name = "Reynor", BaseSalary = 1350 });
			al.Add(new Eq1Salary() { Name = "Bruce", BaseSalary = 150 });
			al.Sort();
			foreach (Eq1Salary item in al)
			{
				Console.WriteLine($@"{item.Name}\t BaseSalary:{item.BaseSalary.ToString()}");
			}
		}

		#region TestModel_Eq2
		private class Eq2Salary : IComparable
		{
			public string Name { get; set; }
			public int BaseSalary { get; set; }
			public int Bonus { get; set; }
			/// <summary>
			/// IComparable成员
			/// </summary>
			/// <param name="obj"></param>
			/// <returns></returns>
			/// <exception cref="NotImplementedException"></exception>
			public int CompareTo(object? obj)
			{
				Eq2Salary staff = obj as Eq2Salary;
				//【选择1】实现对比逻辑
				if (BaseSalary > staff.BaseSalary)
				{
					return 1;
				}
				else if (BaseSalary == staff.BaseSalary)
				{
					return 0;
				}
				else
				{
					return -1;
				}
				//【选择2】调用内置方法也可以实现如上的逻辑
				//BaseSalary.CompareTo(staff.BaseSalary);
			}
		}

		private class Eq2BonusComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				Eq2Salary s1 = x as Eq2Salary;
				Eq2Salary s2 = y as Eq2Salary;
				return s1.Bonus.CompareTo(s2.Bonus);
			}
		}
		#endregion

		[TestMethod]
		public void Eq2实现一个新的比较器()
		{
			ArrayList al = new ArrayList();
			al.Add(new Eq2Salary() { Name = "SCscHero", BaseSalary = 300, Bonus = 122 });
			al.Add(new Eq2Salary() { Name = "Serral", BaseSalary = 2000, Bonus = 255 });
			al.Add(new Eq2Salary() { Name = "Maru", BaseSalary = 350, Bonus = 135 });
			al.Add(new Eq2Salary() { Name = "Reynor", BaseSalary = 1350, Bonus = 500 });
			al.Add(new Eq2Salary() { Name = "Bruce", BaseSalary = 150, Bonus = 350 });
			al.Sort(new Eq2BonusComparer());//提供一个非默认的比较器

			foreach (Eq2Salary item in al)
			{
				Console.WriteLine($@"{item.Name}----{item.Bonus}");
			}
		}

		#region TestModel_Eq3
		private class Eq3Salary : IComparable<Eq3Salary>
		{
			public string Name { get; set; }
			public int BaseSalary { get; set; }
			public int Bonus { get; set; }
			public int CompareTo(Eq3Salary other)
			{
				return BaseSalary.CompareTo(other.BaseSalary);
			}
		}
		private class Eq3BonusComparer : IComparer<Eq3Salary>
		{
			public int Compare(Eq3Salary x, Eq3Salary y)
			{
				Eq3Salary s1 = x as Eq3Salary;
				Eq3Salary s2 = y as Eq3Salary;
				return s1.Bonus.CompareTo(s2.Bonus);
			}
		}

		#endregion
		/// <summary>
		/// 函数进行了转型会非常影响性能，使用泛型做优化
		/// </summary>
		[TestMethod]
		public void Eq3进一步优化比较器()
		{
			List<Eq3Salary> companySalary = new List<Eq3Salary>()
				{
					new Eq3Salary() { Name = "SCscHero", BaseSalary = 300, Bonus = 122 },
					new Eq3Salary() { Name = "Serral", BaseSalary = 2000, Bonus = 255 },
					new Eq3Salary() { Name = "Maru", BaseSalary = 350, Bonus = 135 },
					new Eq3Salary() { Name = "Reynor", BaseSalary = 1350, Bonus = 500 },
					new Eq3Salary() { Name = "Bruce", BaseSalary = 150, Bonus = 350 }
				};
			companySalary.Sort(new Eq3BonusComparer());
			foreach (var item in companySalary)
			{
				Console.WriteLine($@"{item.Name}-{item.Bonus}");
			}
		}
	}


}
