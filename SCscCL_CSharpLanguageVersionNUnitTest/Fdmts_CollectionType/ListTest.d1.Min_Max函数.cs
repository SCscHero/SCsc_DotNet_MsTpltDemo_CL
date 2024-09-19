using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsLangVersion.Fdmts_Keyword.recordSyntax;

namespace CsLangVersion.Fdmts_CollectionType
{
	public partial class ListTest
	{
		[Test]
		public void List_Min函数()
		{
			var minPersonAge = persons.Min(r => r.Age);
			System.Console.WriteLine(@$"UT Excuted {nameof(ListTest)}_{nameof(List_Min函数)}=>{minPersonAge}");
			System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")}；");
		}

		[Test]
		public void List_Max函数()
		{
			var maxPersonAge = persons.Max(r => r.Age);
			System.Console.WriteLine(@$"UT Excuted {nameof(ListTest)}_{nameof(List_Max函数)}=>{maxPersonAge}");
			System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")}；");
		}

	}
}
