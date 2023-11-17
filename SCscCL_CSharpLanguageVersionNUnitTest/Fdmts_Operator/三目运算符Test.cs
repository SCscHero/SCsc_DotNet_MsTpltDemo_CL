using System;

namespace CsLangVersion.Fdmts_Operator
{
	internal class 三目运算符Test
	{
		[Test]
		public void 三目运算符嵌套()
		{
			var scsc = true ? (true || true) ? "AllTrue" : "OuterTrueAndInterLayerFalse"
		: "AllFalse";
			Console.WriteLine(scsc);
		}
	}
}
