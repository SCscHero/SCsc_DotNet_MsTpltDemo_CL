namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _02_区别对待强制转换与as和is
	{
		#region TestModel_Eq1
		private class Eq1_Animal { }
		private class Eq1_Tiger : Eq1_Animal { }
		private class Eq1_Lion : Eq1_Animal { }
		#endregion
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 强制转换示例Eq1()
		{
			var lion = new Eq1_Lion();
			var animal = new Eq1_Animal();
			var castAnimal = (Eq1_Animal)lion;
			//以下会报异常：父类不能转换为子类。
			var castLion = (Eq1_Lion)animal;//Exception:System.InvalidCastException: Unable to cast object of type 'Eq1_Animal' to type 'Eq1_Lion'.
		}


		#region TestModel_Eq2
		private class Eq2_Animal { }
		private class Eq2_Tiger : Eq2_Animal
		{
			public static explicit operator Eq2_Tiger(Eq2_Lion eq2_Lion)
			{
				var eq2_Tiger = new Eq2_Tiger();
				return eq2_Tiger;
			}
		}
		private class Eq2_Lion : Eq2_Animal { }
		#endregion
		/// <summary>
		/// 操作转换符重载
		/// </summary>
		[TestMethod]
		public void 强制转换示例Eq2()
		{
			var tiger = new Eq2_Tiger();
			var lion = new Eq2_Lion();

			tiger = (Eq2_Tiger)lion;
			Console.WriteLine();
		}
		#region TestMethod_Eq2
		/// <summary>
		/// 封装一个方法
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		private T Eq2_object2Entity<T>(object obj) where T : class
		{
			return (T)obj;
		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 实体转换编译器转换判断方法Eq2()
		{
			var tiger = new Eq2_Tiger();
			var lion = new Eq2_Lion();
			////直接使用as编译不通过；原因是via a reference conversion, boxing conversion, unboxing conversion, wrapping conversion, or null type conversion
			//var tigerCastRes = lion as Eq2_Tiger;

			//封装一个通过object辅助转换的方法试图转换：虽然编译（由于所有类都继承于object，相当于是父转子）通过了，但是会转换失败。原因如下：
			//1.编译器首先判断要转换的两个类之间是否有继承关系。
			//2.但编译器会在运行时检查，跳过操作转换符，导致转换失败。
			var res = Eq2_object2Entity<Eq2_Lion>(tiger);

		}

		#region TestMethod_Eq3
		private T Eq3_object2Entity<T>(object obj) where T : class
		{
			return obj as T;
		}
		#endregion

		#region TestModel_Eq3
		private class Eq3_Animal { }
		private class Eq3_Tiger : Eq3_Animal
		{
			public static explicit operator Eq3_Tiger(Eq3_Lion eq2_Lion)
			{
				var eq2_Tiger = new Eq3_Tiger();
				return eq2_Tiger;
			}
		}
		private class Eq3_Lion : Eq3_Animal { }
		#endregion


		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 关键字as的正确运用Eq3()
		{
			//如果类型之间都上溯到了某个共同的基类，那么根据此基类进行的转换（即基类转型为子类本身），应该使用as。子类与子类之间的转换，则应该提供转换操作符，以便进行强制转换。

			//使用as有哪些好处？
			//1.保证编译执行都不会报错。
			//2.as操作符永远不会抛出异常，如果类型不匹配（被转换对象的运行时类型既不是所转换的目标类型，也不是其派生类型），或者转型的源对象为null，那么转型之后的值也为null。
			//3.eq2中的Method因为强制类型转换带来的效率问题和异常问题都将被得到解决。
			var animal = new Eq3_Animal();
			var tiger = new Eq3_Tiger();
			var lion = new Eq3_Lion();

			var animal2TigerRes = Eq3_object2Entity<Eq3_Tiger>(animal);//null:父类转子类为null。
			var tiger2AnimalRes = Eq3_object2Entity<Eq3_Animal>(tiger);//success:子类转父类成功。
			var lion2TigerRes = Eq3_object2Entity<Eq3_Tiger>(lion);//null:子类转子类之间没有操作运算符重载，转换为null。
			var tiger2LionRes = Eq3_object2Entity<Eq3_Lion>(tiger);//null:子类之前的转换没有走操作运算符重载。
		}

		#region TestModel_Eq4
		private class Eq4_Animal { }
		private class Eq4_Tiger : Eq4_Animal
		{
			public static explicit operator Eq4_Tiger(Eq4_Lion lion)
			{
				var tiger = new Eq4_Tiger();
				return tiger;
			}
		}
		private class Eq4_Lion : Eq4_Animal { }
		#endregion

		#region TestMethod_Eq4
		private T Eq4_object2Entity<T, O>(O obj) where T : class
			where O : class
		{
			if (obj is T)
			{
				Console.WriteLine($@"{obj.GetType().Name} is {typeof(T).Name};");
				return obj as T;
			}
			else
			{
				Console.WriteLine($@"{typeof(T).Name}:obj");
				return (T)(object)obj;
			}
		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 使用关键字is完善类型转换功能Eq4()
		{
			var animal = new Eq4_Animal();
			var tiger = new Eq4_Tiger();
			var lion = new Eq4_Lion();

			Console.WriteLine("Is关键字的基本使用");
			var animalIsAnimalRes = animal is Eq4_Animal;//true
			var tigerIsAnimalRes = tiger is Eq4_Animal;//true
			var animalIsTigerRes = animal is Eq4_Tiger;//false
			var tigerIsLionRes = tiger is Eq4_Lion;//false
			var lionIsTigerRes = lion is Eq4_Tiger;//false

			Console.WriteLine("Is关键字的完善类型转换方法");
			var tiger2AnimalRes = Eq4_object2Entity<Eq4_Animal, Eq4_Tiger>(tiger);
			var lionD2TigerRes = (Eq4_Tiger)lion;//Success:直接转换会走入操作符重载
			var lion2TigerRes = Eq4_object2Entity<Eq4_Tiger, Eq4_Lion>(lion);//Exception:装箱后再转换会抛异常且不会走入操作符重载(System.InvalidCastException: Unable to cast object of type 'Eq4_Lion' to type 'Eq4_Tiger'.)。

			//【总结】此方法在和上一个方法对比效率明显变慢，因为多了一重检测，当然各有各自的应用场景。
		}
	}
}
