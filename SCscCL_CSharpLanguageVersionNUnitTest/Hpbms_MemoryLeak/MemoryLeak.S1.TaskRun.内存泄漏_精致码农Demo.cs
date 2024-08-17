using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Hpbms_MemoryLeak
{
	//【Ref】https://zhuanlan.zhihu.com/p/334978366
	/*【Ref】
为什么要小心使用 Task.Run [https://www.cnblogs.com/willick/p/14078259.html]
小心使用 Task.Run 续篇 [https://www.cnblogs.com/willick/p/14100973.html]
小心使用 Task.Run 终篇解惑 [https://mp.weixin.qq.com/s/IMPgSsxTW0LGArfPP7rQXw]
	 */
	internal partial class MemoryLeak
	{
		private class MyClass_精致码农
		{
			private int _id = 10;

			public Task Foo()
			{
				return Task.Run(() =>
				{
					Console.WriteLine($"Task.Run is executing with ID {_id}");
				});
			}
		}


		static void Test()
		{
			var myClass = new MyClass_精致码农();
			myClass.Foo();
		}

		[Test]
		public void 内存泄漏_精致码农Demo()
		{
			Test();
			while (true)
			{
				//观测内存
			}
		}

		


	}
}
