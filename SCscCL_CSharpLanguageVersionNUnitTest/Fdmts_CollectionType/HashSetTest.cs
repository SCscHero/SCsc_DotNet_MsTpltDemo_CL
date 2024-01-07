using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CsLangVersion.Fdmts_CollectionType.ListTest;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CsLangVersion.Fdmts_CollectionType
{
	//【官方Summary】类 HashSet<T> 提供高性能集操作。 集是不包含重复元素且其元素没有特定顺序的集合。
	//【Summary】HashSet是包含不重复项的无序列表；写入速度极快，不需要重排集合；
	//HashSet的优势在与运算快，作为一种存放在内存的数据，可以很快的进行设置和取值的操作。HashSet无法向里面添加重复的数据，避免添加HashSet里面的数据重复。我们使用HashSet常常在集合相加集合相减这些集合与集合之间的操作之中。
	internal class HashSetTest
	{
		HashSet<string> companyTeams = new HashSet<string>() { "Ferrari", "McLaren", "Toyota", "BMW", "Renault", "Honda" };

		HashSet<string> traditionalTeams = new HashSet<string>() { "Ferrari", "McLaren" };

		HashSet<string> privateTeams = new HashSet<string>() { "Red Bull", "Toro Rosso", "Spyker", "Super Aguri" };
		string[] duplicateStrings = { "aa", "aa", "bb", "c", "dd", "bb", "aa", "DD", "ff", "cc" };

		private bool IsDuplicate(IEnumerator<string> strings)
		{
			var set = new HashSet<string>();
			while (strings.MoveNext())
				if (set.Add(strings.Current) == false)
					return true;
			return false;
		}

		private bool IsDuplicate(string[] strings)
		{
			var set = new HashSet<string>();
			foreach (var item in strings)
			{
				if (set.Add(item) == false)
					return true;
			}
			return false;
		}

		[Test]
		public void 使用HashSet编写判断是否重复的算法_时间复杂度更优()
		{
			Console.WriteLine(IsDuplicate(duplicateStrings));
		}

		//【Ref】https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.hashset-1?view=net-8.0
		[Test]
		public void 官方初学者示例()
		{
			HashSet<int> evenNumbers = new HashSet<int>();
			HashSet<int> oddNumbers = new HashSet<int>();
			for (int i = 0; i < 5; i++)
			{
				// Populate numbers with just even numbers.
				evenNumbers.Add(i * 2);

				// Populate oddNumbers with just odd numbers.
				oddNumbers.Add((i * 2) + 1);
			}
			Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
			DisplaySet(evenNumbers);
			Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
			DisplaySet(oddNumbers);
			// Create a new HashSet populated with even numbers.
			HashSet<int> numbers = new HashSet<int>(evenNumbers);
			Console.WriteLine("numbers UnionWith oddNumbers...");
			numbers.UnionWith(oddNumbers);

			Console.Write("numbers contains {0} elements: ", numbers.Count);
			DisplaySet(numbers);

			void DisplaySet(HashSet<int> collection)
			{
				Console.Write("{");
				foreach (int i in collection)
				{
					Console.Write(" {0}", i);
				}
				Console.WriteLine(" }");
			}

			/* This example produces output similar to the following:
			* evenNumbers contains 5 elements: { 0 2 4 6 8 }
			* oddNumbers contains 5 elements: { 1 3 5 7 9 }
			* numbers UnionWith oddNumbers...
			* numbers contains 10 elements: { 0 2 4 6 8 1 3 5 7 9 }
			*/
		}

		//在示例代码中，创建了3个字符串类型的新集，并用一级方程式汽车填充。HashSet类实现了ICollection接口。但是在该类中，Add()方法是显式实现的，还提供了另一个Add()方法。Add()方法的区别是返回类型，它返回一个布尔值，说明是否添加了元素。如果该元素已经在集中，就不添加它，并返回false。
		[Test]
		public void HashSet添加已存在的Key()
		{
			if (privateTeams.Add("Williams"))
				Console.WriteLine("Williams added");
			if (!companyTeams.Add("McLaren"))
				Console.WriteLine("McLaren was already in this set");
		}
		//【Ref】https://blog.csdn.net/baobingji/article/details/105564859
		[Test]
		public void 方法IsSubsetOf和IsSupersetOf()
		{
			//方法IsSubsetOf()和IsSupersetOf()比较集和实现了IEnumerable接口的集合，返回一个布尔结果。这里，IsSubsetOf()验证traditionalTeams中的每个元素是否都包含在companyTeams中，IsSupersetOf()验证traditionalTeams是否没有与companyTeams比较的额外元素。
			if (traditionalTeams.IsSubsetOf(companyTeams))
			{
				Console.WriteLine("traditionalTeams is " + "subset of companyTeams");
			}
			if (companyTeams.IsSupersetOf(traditionalTeams))
			{
				Console.WriteLine("companyTeams is a superset of " + "traditionalTeams");
			}

		}
		[Test]
		public void 两个HashSet的并集()
		{
			HashSet<int> numbers1;
			HashSet<int> numbers2;
			//分别进行numbers1和numbers2的值初始化或赋值
			//numbers1.UnionWith(numbers2);//求两个集合的并集。
		}
		[Test]
		public void 两个HashSet的交集()
		{
			HashSet<int> numbers1;
			HashSet<int> numbers2;
			//分别进行numbers1和numbers2的值初始化或赋值
			//numbers1.IntersectWith(numbers2);//求两个集合的交集。
		}
		[Test]
		public void 两个HashSet的差集()
		{
			HashSet<int> numbers1;
			HashSet<int> numbers2;
			//分别进行numbers1和numbers2的值初始化或赋值
			//numbers1.ExceptWith(numbers2);//求两个集合的差集。
		}
		[Test]
		public void 两个HashSet的对称差集()
		{
			HashSet<int> numbers1;
			HashSet<int> numbers2;
			//分别进行numbers1和numbers2的值初始化或赋值
			//numbers1.SymmetricExceptWith(numbers2);//求两个集合的对称差集。

		}
	}
}
