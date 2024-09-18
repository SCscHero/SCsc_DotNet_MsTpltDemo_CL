using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Advcd_MemoryOperation
{
	internal struct Point
	{
		public Int32 x, y;
	}
	//【Ref】https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.interopservices.marshal?view=net-8.0
	internal class MarshalTest
	{
		[Test]
		public void Origin_由来()
		{
			//命名空间:System.Runtime.InteropServices
			//程序集:System.Runtime.InteropServices.dll
			//public static class Marshal

			//提供了一个方法集合，这些方法用于分配非托管内存、复制非托管内存块、将托管类型转换为非托管类型，此外还提供了在与非托管代码交互时使用的其他杂项方法。
		}
		// This is a platform invoke prototype. SetLastError is true, which allows
		// the GetLastWin32Error method of the Marshal class to work correctly.
		//这是一个平台调用原型。SetLastError为true，它允许Marshal类的GetLastWin32Error方法正确工作。
		[DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
		static extern Boolean CloseHandle(IntPtr h);
		[Test]
		public void FirstMet_初识()
		{
			// Demonstrate the use of public static fields of the Marshal class.
			//演示Marshal类的公共静态字段的使用。
			Console.WriteLine("SystemDefaultCharSize={0}, SystemMaxDBCSCharSize={1}",
					Marshal.SystemDefaultCharSize, Marshal.SystemMaxDBCSCharSize);

			// Demonstrate the use of the SizeOf method of the Marshal class.
			Console.WriteLine("Number of bytes needed by a Point object: {0}",
					Marshal.SizeOf(typeof(Point)));
			Point p = new Point();
			Console.WriteLine("Number of bytes needed by a Point object: {0}",
					Marshal.SizeOf(p));

			// Demonstrate how to call GlobalAlloc and
			// GlobalFree using the Marshal class.
			IntPtr hglobal = Marshal.AllocHGlobal(100);
			Marshal.FreeHGlobal(hglobal);

			// Demonstrate how to use the Marshal class to get the Win32 error
			// code when a Win32 method fails.
			Boolean f = CloseHandle(new IntPtr(-1));
			if (!f)
			{
				Console.WriteLine("CloseHandle call failed with an error code of: {0}",
						Marshal.GetLastWin32Error());
			}
		}
	}
}
