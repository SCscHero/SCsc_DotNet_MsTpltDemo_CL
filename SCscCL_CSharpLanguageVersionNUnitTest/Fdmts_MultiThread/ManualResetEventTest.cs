using System;
using System.Threading;

namespace CsLangVersion.Fdmts_MultiThread
{
	internal class ManualResetEventTest
	{
		/// <summary>
		/// 简单理解就是用一个开关控制线程的停止和开启。用WaitOne来做校验是停止或继续。
		/// 1/5.true indicates that the default is inactive.
		/// 2/5.Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
		/// 3/5.Wait five seconds.
		/// 4/5.Sets the state of the event to nonsignaled, causing threads to block.
		/// 5/5.Check whether the current signal is normal. Abnormal Blocks the current thread until the current WaitHandle receives a signal.
		/// </summary>
		[Test]
		public void SimpleManualResetEventTest()
		{
			//Console.WriteLine(111);
			var demo = new mreDemo();
			var stopThread = new Thread(() =>
			{
				//3/5.Wait five seconds.
				Thread.Sleep(5000);
				demo.Stop();
			});
			stopThread.Start();
			stopThread.Join();
		}




		private class mreDemo
		{
			//1/5.true indicates that the default is inactive.
			private ManualResetEvent resetEvent = new ManualResetEvent(true);
			public mreDemo()
			{
				Thread thread = new Thread(() => { Thread01(); });
				thread.Start();
				Start();
			}
			public void Start()
			{
				//2/5.Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
				resetEvent.Set();
			}

			public void Stop()
			{
				//4/5.Sets the state of the event to nonsignaled, causing threads to block.
				resetEvent.Reset();
			}

			public void Thread01()
			{
				int i = 0;
				while (true)
				{
					//5/5.Check whether the current signal is normal. Abnormal Blocks the current thread until the current WaitHandle receives a signal.
					resetEvent.WaitOne();
					i++;
					Console.WriteLine("i的值：" + i);
					Thread.Sleep(20);
				}
			}
		}

	}
}
