using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Delegate
{
	internal class DelegateSyntaxTest
	{

		public delegate void MyDelegate(string message);
		public static void MethodToInvoke1(string message)
		{
			Console.WriteLine($"Method 1: {message}");
		}
		public static void MethodToInvoke2(string message)
		{
			Console.WriteLine($"Method 2: {message}");
		}
		public static void MethodToInvoke3(string message)
		{
			Console.WriteLine($"Method 3: {message}");
		}
		[Test]
		public void delegate初使用()
		{
			MyDelegate delegate1 = MethodToInvoke1;
			MyDelegate delegate2 = MethodToInvoke2;
			MyDelegate delegate3 = MethodToInvoke3;
			List<MyDelegate> delegateList = new List<MyDelegate> { delegate1, delegate2, delegate3 };
			foreach (MyDelegate del in delegateList)
			{
				del("Hello from delegate");
			}
		}
	}
}
