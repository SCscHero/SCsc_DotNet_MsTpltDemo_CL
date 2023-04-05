using System.Runtime.CompilerServices;

namespace SCscCL_HighQuality157Code._60_结构体优化程序
{
	[TestClass]
	public class _1_使用结构体数组优化程序
	{
		#region TestModel_Eq1
		struct structArray { int id; string Name; }
		class classArray { int id; string Name; }

		#endregion
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 结构体数组查询及赋值Eq1()
		{
			//TODO:【参考文章】使用结构体数组改善程序性能：https://blog.csdn.net/zeroflamy/article/details/52081462
			var length = 100_000;
			var sa = new structArray[length];
			var ca = new classArray[length];
			

		}

		[TestMethod]
		public void 使用结构体Linq改善程序性能()
		{
			//TODO:【参考文章】使用结构体Linq改善程序性能：https://www.cnblogs.com/InCerry/p/Dotnet-Perf-Opt-Use-StructLinq-For-ValueType.html
		}
	}
}