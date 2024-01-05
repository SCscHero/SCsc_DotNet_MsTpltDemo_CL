using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SyntacticSugar
{
	internal class StringDollar
	{
		/// <summary>
		/// 优点：简洁可读性高；优雅；
		/// </summary>
		[Test]
		public void StringDollar_StringFormat1()
		{
			{
				var k = "a";
				var a0 = "User";
				var a1 = "Id";
				var a2 = 5;
				var ccc = string.Format("select * from {0} where {1} = {2}", a0, a1, a2);
				var ccb = $"select * from {a0} where {a1}={a2}";
			}
			{
				var k = "a";
				var k4 = $"{k,5}";
				var k3 = string.Format("{0,5}", k);

				var k2 = DateTime.Now;
				var c = $"{k2:yyyy}";
				c = string.Format("{0:yyyy}", k2);

			}
		}
		//另一个Demo
		//【Ref】https://www.coder.work/article/225796
		[Test]
		public void StringDollar格式转换()
		{
			Console.WriteLine($"The current hour is {DateTime.Now:hh}");
		}
	}
}
