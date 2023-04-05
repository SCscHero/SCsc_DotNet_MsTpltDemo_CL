namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _12_区别对待双等号和Equals
	{
		#region TestModel_Eq1
		private class Eq1Person
		{
			public string Name { get; set; }
			public Eq1Person(string name) { Name = name; }
		}
		#endregion
		/// <summary>
		/// 概念：值相等性和引用类型相等性
		/// 验证目标：Equals比较的永远是变量的内容是否相同，而==比较的则是引用地址是否相同(前提:此种类型内部没有对Equals 或= = 进行重写操作，否则输出可能会有不同)
		/// </summary>
		[TestMethod]
		public void Eq1概念_值相等性和引用类型相等性()
		{
			//1.前言：相等分几部分：值相等，值类型相等、若为引用类型的地址相等。
			//
			//

			//2.比较值类型
			void ValueTypeOpEquals()
			{
				int i = 1;
				int j = 1;
				//True
				Console.WriteLine(i == j);
				j = i;
				//True
				Console.WriteLine(i == j);
			}
			void ValueTypeEquals()
			{
				int i = 1;
				int j = 1;
				//True
				Console.WriteLine(i.Equals(j));
				j = i;
				Console.WriteLine(j.Equals(i));
			}
			//3.比较引用类型
			void ReferenceTypeOpEquals()
			{
				object a = 1;
				object b = 1;
				//False
				Console.WriteLine(a == b);
				b = a;
				//True
				Console.WriteLine(a == b);
			}
			void ReferenceTypeEqualsObject()
			{
				object a = 1;
				object b = 1;
				//True
				Console.WriteLine(a.Equals(b));
				b = a;
				//True
				Console.WriteLine(a.Equals(b));

			}
			void ReferenceTypeOpEqualsObjEntity()
			{
				object a = new Eq1Person("NB123");
				object b = new Eq1Person("NB123");
				//False
				Console.WriteLine(a == b);
				//True
				b = a;
				Console.WriteLine(a == b);
			}
			void ReferenceTypeEqualsObjEntity()
			{
				object a = new Eq1Person("NB123");
				object b = new Eq1Person("NB123");
				//False
				Console.WriteLine(a.Equals(b));
				//True
				b = a;
				Console.WriteLine(a.Equals(b));
			}
			void ReferenceTypeOpEqualsEntity()
			{
				Eq1Person a = new Eq1Person("NB123");
				Eq1Person b = new Eq1Person("NB123");
				//False
				Console.WriteLine(a == b);
				//True
				b = a;
				Console.WriteLine(a == b);
			}
			void ReferenceTypeEqualsEntity()
			{
				Eq1Person a = new Eq1Person("NB123");
				Eq1Person b = new Eq1Person("NB123");
				//False
				Console.WriteLine(a.Equals(b));
				//True
				b = a;
				Console.WriteLine(a.Equals(b));
			}

			//4.比较String类型
			void StringTypeOpEquals()
			{
				string s1 = "abc";
				string s2 = "abc";
				Console.WriteLine(s1 == s2);
				s2 = s1;
				Console.WriteLine(s1 == s2);
			}
			void StringTypeEquals()
			{
				string s1 = "abc";
				string s2 = "abc";
				Console.WriteLine(s1.Equals(s2));
				s2 = s1;
				Console.WriteLine(s1.Equals(s2));
			}
			Console.WriteLine($@"2.比较值类型：{nameof(ValueTypeOpEquals)}");
			ValueTypeOpEquals();
			Console.WriteLine($@"{nameof(ValueTypeEquals)}");
			ValueTypeEquals();
			Console.WriteLine($@"3.比较引用类型：{nameof(ReferenceTypeOpEquals)}");
			ReferenceTypeOpEquals();
			Console.WriteLine($@"{nameof(ReferenceTypeEqualsObject)}");
			ReferenceTypeEqualsObject();
			Console.WriteLine($@"{nameof(ReferenceTypeOpEqualsObjEntity)}");
			ReferenceTypeOpEqualsObjEntity();
			Console.WriteLine($@"{nameof(ReferenceTypeEqualsObjEntity)}");
			ReferenceTypeEqualsObjEntity();
			Console.WriteLine($@"{nameof(ReferenceTypeOpEqualsEntity)}");
			ReferenceTypeOpEqualsEntity();
			Console.WriteLine($@"{nameof(ReferenceTypeEqualsEntity)}");
			ReferenceTypeEqualsEntity();

			Console.WriteLine($@"4.比较String类型：{nameof(StringTypeOpEquals)}");
			//由于string是微软封装的一个字符串类，本身是引用类型。但由于其现实意义和综合各方面考虑，在内部他已经对 == 操作符进行了重写。重写后他比较的则是两个变量的内容是否相同。
			StringTypeOpEquals();
			Console.WriteLine($@"{nameof(StringTypeEquals)}");
			StringTypeEquals();
			//【结论】初步看，==操作运算符和Equals方法是等效的。
		}


		#region TestModel_Eq2
		private class Eq2Person : IEquatable<Eq2Person>
		{
			public string Name { get; set; }
			public Eq2Person(string name)
			{
				Name = name;
			}

			public bool Equals(Eq2Person? other)
			{
				//this非空，obj如果为空，则返回false
				if (ReferenceEquals(null, other)) return false;
				//如果为同一对象，必然相等
				if (ReferenceEquals(this, other)) return true;
				//对比各个字段值
				if (!string.Equals(Name, other.Name, StringComparison.InvariantCulture))
					return false;
				//如果基类不是从Object继承，需要调用base.Equals(other)
				//如果从Object继承，直接返回true
				return true;
			}
		}
		#endregion
		[TestMethod]
		public void Eq2对象重写Equals方法做比较()
		{
			//【注意】此处声明需要用实体声明，才能走进重写的Equals方法之中。
			void ReferenceTypeOpEqualsEntity()
			{
				Eq2Person a = new Eq2Person("NB123");
				Eq2Person b = new Eq2Person("NB123");
				//False
				Console.WriteLine(a == b);
				//True
				b = a;
				Console.WriteLine(a == b);
			}
			void ReferenceTypeEqualsEntity()
			{
				Eq2Person a = new Eq2Person("NB123");
				Eq2Person b = new Eq2Person("NB123");
				//False
				Console.WriteLine(a.Equals(b));
				//True
				b = a;
				Console.WriteLine(a.Equals(b));
			}
			Console.WriteLine($@"Method:{nameof(ReferenceTypeOpEqualsEntity)}");
			ReferenceTypeOpEqualsEntity();
			Console.WriteLine($@"Method:{nameof(ReferenceTypeEqualsEntity)}");
			ReferenceTypeEqualsEntity();
		}

		#region TestModel_Eq3
		private class Eq3Person : IEquatable<Eq3Person>
		{
			public string Name { get; set; }
			public Eq3Person(string name)
			{
				Name = name;
			}
			public bool Equals(Eq3Person? other)
			{
				//this非空，obj如果为空，则返回false
				if (ReferenceEquals(null, other)) return false;
				//如果为同一对象，必然相等
				if (ReferenceEquals(this, other)) return true;
				//对比各个字段值
				if (!string.Equals(Name, other.Name, StringComparison.InvariantCulture))
					return false;
				//如果基类不是从Object继承，需要调用base.Equals(other)
				//如果从Object继承，直接返回true
				return true;
			}
		}

		private class Eq3PersonDefault
		{
			public string Name { get; set; }
			public Eq3PersonDefault(string name) { Name = name; }
		}
		#endregion
		[TestMethod]
		public void Eq3方法GetHashCode结合使用()
		{
			void ConsoleWriteHashCode(string strValue)
			{
				int HashCode = strValue.GetHashCode();
				Console.WriteLine($"The hash code for \"{strValue}\" is: 0x{{1:X8}}, {HashCode}");
			}
			//【验证1】是否是Equals一致的情况，则GetHashCode()必定相等。
			Console.WriteLine("【验证1.1-符合】当Equals方法被重写的情况下。");
			Eq3Person eq3Person1 = new Eq3Person("Hero");
			Eq3Person eq3Person2 = new Eq3Person("Hero");
			Console.WriteLine(eq3Person1.Equals(eq3Person2));
			Console.WriteLine(eq3Person1.GetHashCode() == eq3Person2.GetHashCode());//false
			eq3Person2 = eq3Person1;
			Console.WriteLine(eq3Person1.Equals(eq3Person2));
			Console.WriteLine(eq3Person1.GetHashCode() == eq3Person2.GetHashCode());//true
			Console.WriteLine("【验证1.2-符合】使用object对象赋值为1。");
			object obj1 = 1;
			object obj2 = 1;
			Console.WriteLine(obj1.Equals(obj2));//true
			Console.WriteLine(obj1.GetHashCode() == obj2.GetHashCode());
			Console.WriteLine("【验证1.3-符合】使用string对象赋值为相同的。");
			ConsoleWriteHashCode("stringVar");
			ConsoleWriteHashCode("stringVar");
			Console.WriteLine(obj1.GetHashCode() == obj2.GetHashCode());//true
			Console.WriteLine("【验证1.4-符合】当Equals方法未被重写的情况下。");
			Eq3PersonDefault default1 = new Eq3PersonDefault("var");
			Eq3PersonDefault default2 = new Eq3PersonDefault("var");
			Console.WriteLine(default1.Equals(default2));
			Console.WriteLine(default1.GetHashCode() == default2.GetHashCode());
			default2 = default1;
			Console.WriteLine(default1.Equals(default2));
			Console.WriteLine(default1.GetHashCode() == default2.GetHashCode());

			//【验证2】不同值相同的HashCode。原因是HashCode是一个整型，而整型容量难以满足string类型的容量。
			Console.WriteLine("不同值相同的HashCode。原因是HashCode是一个整型，而整型容量难以满足string类型的容量。");
			string str1 = "NB0903100006";
			string str2 = "NB0904140001";
			Console.WriteLine(str1.GetHashCode());
			Console.WriteLine(str2.GetHashCode());
			Console.WriteLine(str1.GetHashCode() == str2.GetHashCode());
			//但可以改用新的获取HashCode的方法，降低不同值相同HashCode的概率。
			Console.WriteLine($"Method:{nameof(GetHashCode_New)}");
			int GetHashCode_New(string str)
			{
				return (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + str).GetHashCode();
			}
			Console.WriteLine(GetHashCode_New(str1));
			Console.WriteLine(GetHashCode_New(str2));
			Console.WriteLine(GetHashCode_New(str1) == GetHashCode_New(str2));



		}

		[TestMethod]
		public void Eq4方法ReferenceEquals查询两个变量是否是相同地址()
		{
			object obj1 = 1;
			object obj2 = 1;
			Console.WriteLine(ReferenceEquals(obj1, obj2));
			obj2 = obj1;
			Console.WriteLine(ReferenceEquals(obj1, obj2));
		}
	}
}