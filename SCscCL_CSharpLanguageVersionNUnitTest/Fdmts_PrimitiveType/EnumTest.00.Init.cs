using System;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal partial class EnumTest
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
		public void string转enum()
		{
			Enum.TryParse("Monday", out DayOfWeek outE);
			Assert.IsTrue(DayOfWeek.Monday==outE);
		}

		[Test]
		public void Int转enum() {
            var res1 = (DayOfWeek)1;
			Assert.True(DayOfWeek.Monday==res1);
		}


	}
}
