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

		[Test]
		public void UseTask数组加等号()
		{
			var tasks = new List<Task>();
			tasks.Add(Task.Run(() =>
			{
				Console.WriteLine("任务1正在执行...");
			}));
			Task.WaitAll(tasks.ToArray());
		}

		[Test]
		public void UseTask_全局任务等待使用List会造成一直等待()
		{
			var taskList = new List<Task>();
			var task1 = Task.Run(() =>
			{
				Console.WriteLine("任务1正在执行...");
				for (int i = 0; i < 500; i++)
				{
					Console.WriteLine("任务1 - 第" + i + "次循环...");
					Task.Delay(1000).Wait(); // 模拟耗时操作  
				}
				Console.WriteLine("任务1完成。");
			});

			var task2 = Task.Run(() =>
			{
				Console.WriteLine("任务2正在执行...");
				for (int i = 0; i < 800; i++)
				{
					Console.WriteLine("任务2 - 第" + i + "次循环...");
					Task.Delay(1000).Wait(); // 模拟耗时操作  
				}
				Console.WriteLine("任务2完成。");
			});

			taskList.Add(task1);
			taskList.Add(task2);
			//如果这样写会一直等待。
			Task.WaitAll(taskList.ToArray());
			Console.WriteLine("所有任务已完成。");
		}

		[Test]
		public void UseTask_全局任务等待()
		{
			// 创建两个任务  
			Task task1 = Task.Run(() =>
			{
				Console.WriteLine("任务1正在执行...");
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("任务1 - 第" + i + "次循环...");
					Task.Delay(1000).Wait(); // 模拟耗时操作  
				}
				Console.WriteLine("任务1完成。");
			});

			Task task2 = Task.Run(() =>
			{
				Console.WriteLine("任务2正在执行...");
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("任务2 - 第" + i + "次循环...");
					Task.Delay(1000).Wait(); // 模拟耗时操作  
				}
				Console.WriteLine("任务2完成。");
			});

			Task.WaitAll(task1, task2);
			Console.WriteLine("所有任务已完成。");
		}
	}
}
