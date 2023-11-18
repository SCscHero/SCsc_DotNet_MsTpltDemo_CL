using System;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class EnumTest
	{

		[Test]
		public void Enum遍历Test()
		{
			foreach (DayOfWeek suit in Enum.GetValues(typeof(DayOfWeek)))
			{
				Console.WriteLine((int)suit + ":" + suit);
			}
		}
		[Test]
		public void 枚举值不同类型互相转换()
		{
			//1.string转Enum
			Enum.TryParse("Monday", out DayOfWeek outE);
			DayOfWeek res = outE;
			Console.WriteLine((int)res + ":" + res);
			//1.int转Enum
			var res1 = (DayOfWeek)1;
			Console.WriteLine((int)res1 + ":" + res1);
		}

	}
}
