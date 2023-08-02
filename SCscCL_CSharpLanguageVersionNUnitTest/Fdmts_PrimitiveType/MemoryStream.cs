using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class MemoryStreamTest
	{
		[Test]
		public void MemoryStreamTest通过构造函数将String转换成Stream类型()
		{
			string jsonStrSimple = "{\"msg\":\"failed！\"}";
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonStrSimple));

		}
	}
}
