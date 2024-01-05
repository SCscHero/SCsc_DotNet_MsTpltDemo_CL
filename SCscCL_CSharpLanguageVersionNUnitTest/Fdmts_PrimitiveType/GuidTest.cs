using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class GuidTest
	{
		[Test]
		public void Guid_Dollar格式化()
		{
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():D}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():d}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():N}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():n}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():P}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():p}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():B}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():b}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():X}");
			Console.WriteLine($"Files/{"SCscHero/"}{Guid.NewGuid():x}");
			Console.WriteLine();
		}
	}
}
