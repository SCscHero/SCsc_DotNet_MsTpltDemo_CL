using System;

namespace CsLangVersion.Fdmts_Operator
{
	internal partial class TernaryTest {
		[Test]
		public void 三目运算符嵌套()
		{
			var scsc = true ? (true || true) ? "AllTrue" : "OuterTrueAndInterLayerFalse"
		: "AllFalse";
			Console.WriteLine(scsc);
		}
	}
}
