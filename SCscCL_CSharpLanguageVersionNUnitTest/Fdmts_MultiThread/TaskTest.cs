using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_MultiThread
{
	/// <summary>
	/// .Net Framework4.0之后推出
	/// </summary>
	internal class TaskTest
	{
		private void compute1()
		{
			for (int i = 0; i < 2000; i++)
			{
			}
		}
		private void compute2()
		{
			for (int i = 0; i < 2000; i++)
			{
			}
		}
		private void compute3()
		{
			for (int i = 0; i < 2000; i++)
			{
			}
		}

		private void computeWithParam(int i)
		{
			for (; i < 2000 + i; i++)
			{
			}
		}

		private int computeWithReturn(int i)
		{
			for (; i < 2000 + i; i++)
			{
			}
			return i;
		}

		private int computeWithReturn线程延时(int i)
		{
			for (; i < 2000 + i; i++)
			{
				Task.Delay(5);
			}
			return i;
		}
		[Test]
		public void UseTask_同时执行三个任务()
		{
			Task.Run(compute1);
			Task.Run(compute2);
			Task.Run(compute3);
		}

		[Test]
		public void UseTask_执行有返回值的参数()
		{
			int res = 0;
			var t = Task.Run(() =>
			{
				res = computeWithReturn(500);
			});
			t.Wait();
            Console.WriteLine(res);
        }

		[Test]
		public void UseTask_执行有延时的操作()
		{
			int res = 0;
			var t = Task.Run(() =>
			{
				res = computeWithReturn线程延时(500);
			});
			t.Wait();
			Console.WriteLine(res);
		}

		[Test]
		public void UseTask_执行带有取消的操作()
		{
			int res = 0;
			var t = Task.Run(() =>
			{
				res = computeWithReturn线程延时(500);
			});
			t.Wait();
			Console.WriteLine(res);
		}
	}
}
