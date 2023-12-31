using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class charTest
	{
		[Test]
		public void Unicode字符的初使用()
		{
			char c = '\u0123'; // 这是一个十进制Unicode转义序列  
			char d = '\u4567'; // 这是一个十六进制Unicode转义序列
			Console.WriteLine();
		}
	}
}
