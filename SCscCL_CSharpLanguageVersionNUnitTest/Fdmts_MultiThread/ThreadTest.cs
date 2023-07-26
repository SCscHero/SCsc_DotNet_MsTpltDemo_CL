using System;
using System.Diagnostics;
using System.Threading;

namespace CsLangVersion.Fdmts_MultiThread
{
	internal class ThreadTest
	{
		[SetUp]
		public void Setup()
		{

		}
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

		private int computeWithReturn线程等待(int i)
		{
			for (; i < 2000 + i; i++)
			{
				Thread.Sleep(2);
			}
			return i;
		}


		[Test]
		public void SynchronousTest()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			compute1();
			compute2();
			compute3();

			sw.Stop();
			TimeSpan ts2 = sw.Elapsed;
			Console.WriteLine($"Stopwatch总共花费{ts2.TotalSeconds}s.");

		}

		[Test]
		public void UseThreadTest()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			Thread t1 = new Thread(compute1);
			t1.Start();
			Thread t2 = new Thread(compute2);
			t2.Start();
			Thread t3 = new Thread(compute3);
			t3.Start();
			sw.Stop();
			TimeSpan ts2 = sw.Elapsed;
			Console.WriteLine($"Stopwatch总共花费{ts2.TotalSeconds}s.");
		}
		[Test]
		public void UseThread_ExeMtdWithParam()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			Thread t1 = new Thread(() =>
			{
				computeWithParam(200);
			});
			t1.Start();
			sw.Stop();
			TimeSpan ts2 = sw.Elapsed;
			Console.WriteLine($"Stopwatch总共花费{ts2.TotalSeconds}s.");
		}

		[Test]
		public void UseThread_ExeMtdWithReturn()
		{
			int res = 0;
			Thread thread = new Thread(() =>
			{
				res = computeWithReturn(200);
			});
			thread.Start();
            Console.WriteLine(res);
        }
		[Test]
		public void UseThread_等待线程执行完毕()
		{
			int res = 0;
			Thread thread = new Thread(() =>
			{
				res = computeWithReturn(200);
			});
			thread.Start();
			thread.Join();
			Console.WriteLine(res);
		}
		[Test]
		public void UseThread_计时等待()
		{
			int res = 0;
			Thread thread = new Thread(() =>
			{
				res = computeWithReturn线程等待(200);
			});
			thread.Start();
			thread.Join();
			Console.WriteLine(res);
		}
		/// <summary>
		/// 尽量不要使用手动中止线程。会抛出异常使程序不稳定。
		/// </summary>
		[Test]
		public void UseThread_中止线程()
		{
			int res = 0;
			Thread thread = new Thread(() =>
			{
				res = computeWithReturn线程等待(200);
			});
			thread.Start();
			thread.Abort();
			Console.WriteLine(res);
		}

		[Test]
		public void UseThread_前后台属性()
		{
			Thread thread = new Thread(() =>
			{
				Console.WriteLine("output..");
			});
			//当这个线程IsBackground为true的时候，则当进程结束时也不会停止，需要等其执行完毕。
			//当这个线程IsBackground为false的时候，则当进程结束时会停止此线程。
			thread.IsBackground = true; 
		}

		[Test]
		public void UseThread_打印当前线程唯一ID()
		{
			Thread t1 = new Thread(() =>
			{
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
			Thread t2 = new Thread(() =>
			{
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			});
			Thread t3 = new Thread(() =>
			{
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			});
			t1.Start();
			t2.Start();
			t3.Start();
		}
	}
}
