using System;

namespace CsLangVersion.Fdmts_Concept
{
	//【Ref】https://blog.csdn.net/qiaoquan3/article/details/51202926
	internal class _h0_引用类型和值类型
	{
		[Test]
		public void 值类型()
		{
			//值类型（value type）：byte，short，int，long，float，double，decimal，char，bool 和 struct 统称为值类型。值类型变量声明后，不管是否已经赋值，编译器为其分配内存。
			int i = 0;  // int 是值类型
			Console.WriteLine(i);   // i = 0
			Pass.value(i);          // 值类型使用的是 i 的副本，i不变
			Console.WriteLine(i);   // i = 0
		}
		[Test]
		public void 引用类型()
		{
			//引用类型（reference type）：string 和 class统称为引用类型。当声明一个类时，只在栈中分配一小片内存用于容纳一个地址，而此时并没有为其分配堆上的内存空间。当使用 new 创建一个类的实例时，分配堆上的空间，并把堆上空间的地址保存到栈上分配的小片空间中。
			WrappendInt wi = new WrappendInt(); // 创建类 WrappendInt 的另外一个实例
			Console.WriteLine(wi.Number);   // 0 // 被默认构造器初始化为 0
			Pass.Reference(wi);     // 调用方法，wi 和 param 将引用同一个对象
			Console.WriteLine(wi.Number);   // 42
		}

		class Pass
		{
			public static void value(int param)
			{
				param = 42; // 赋值操作使用的是值类型参数的一个副本，原始参数不受影响
			}

			public static void Reference(WrappendInt param) // 创建类 WrappendInt 的一个实例
			{
				param.Number = 42;  // 此参数是引用类型的参数
			}
		}

		class WrappendInt   // 类是引用类型
		{
			public int Number;
		}
	}
}
