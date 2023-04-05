namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _6_区别readonly和const
	{
		#region TestModel_Eq1
		//readonly int eq1Crvar1;//Error CS0106 The modifier 'readonly' is not valid for this item
		private class Eq1_User
		{
			public readonly string Name;
			public Eq1_User(string name)
			{
				Name = name;
			}
		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 关键字readonly的用法Eq1()
		{
			var user = new Eq1_User("Name");
			////readonly修饰的变量只能在构造函数赋值，而不能直接调用赋值
			//user.Name = "xxx";//Error CS0191: A readonly field cannot be assigned to(except in a constructor or init - only setter of the type in which the field is defined or a variable initializer)
		}


		#region TestModel_Eq2
		private class Eq2_User
		{
			public string Name;
			public Eq2_User(string name)
			{
				Name = name;
			}
		}

		private class Eq2_UserGroup
		{
			public readonly Eq2_User User;
			public Eq2_UserGroup(Eq2_User user)
			{
				User = user;
			}
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 关键字readonly对象的属性是可以修改Eq2()
		{
			var group = new Eq2_UserGroup(new Eq2_User("Name"));
			group.User.Name = "AlterName";
		}

		#region TestModel_Eq3
		//静态常量
		//编译阶段就对常量进行解析，并将常量的值替换成初始化的那个值。
		private const int Eq3Constvar1 = 5;//仅使用const修饰，则必需赋初始值。

		//const int Eq3constvar2; //若不赋初始值，则编译报错。Error CS0145  A const field requires a value to be provided 


		//动态常量
		//运行时赋值，相当于延迟到程序启动时初始化。使用readonly且需要使用修饰符static或private系列修饰。
		static readonly int Eq3A = Eq3B * 10;
		static readonly int Eq3B = 10;
		static readonly int Eq3C = Eq3B * 10;
		#endregion

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 关键字static和readonly联用的用法Eq3()
		{
			//动态常量初始值都为默认值，只有执行到才会赋值。
			//当执行到A时候，B还未赋值故为默认值0，因此A初始值是0*10。
			Console.WriteLine($"Eq3A is {Eq3A};Eq3B is {Eq3B}");
			//Eq3A is 0;Eq3B is 10

			////当执行到C时候，B已赋值为10，因此C初始值是10*10。
			Console.WriteLine($"Eq3C is {Eq3C};Eq3B is {Eq3B}");
			//Eq3C is 100; Eq3B is 10
		}



	}
}
