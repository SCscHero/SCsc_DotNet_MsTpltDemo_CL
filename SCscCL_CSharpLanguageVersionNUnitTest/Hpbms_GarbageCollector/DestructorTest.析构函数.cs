using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Hpbms_GarbageCollector
{
	class ResourceHolder
	{
		// 一个非托管资源：比如一个文件句柄或者一个数据库连接等  
		private IntPtr unmanagedResource;
		// 构造函数，用于初始化资源  
		public ResourceHolder()
		{
			// 分配非托管资源  
			unmanagedResource = Marshal.AllocHGlobal(100);
			Console.WriteLine("非托管资源已分配。");
		}
		// 析构函数（终结器），用于释放非托管资源  
		~ResourceHolder()
		{
			// 释放非托管资源  
			Console.WriteLine("在析构函数中释放非托管资源。");
			Marshal.FreeHGlobal(unmanagedResource);
		}
		// 提供一个显示调用以释放资源的方法（可选）  
		public void Dispose()
		{
			Console.WriteLine("在Dispose方法中释放非托管资源。");
			// 释放非托管资源  
			Marshal.FreeHGlobal(unmanagedResource);
			// 通知垃圾回收器，无需再调用终结器  
			GC.SuppressFinalize(this);
		}
	}


	internal class Destructor
	{

	}
}
