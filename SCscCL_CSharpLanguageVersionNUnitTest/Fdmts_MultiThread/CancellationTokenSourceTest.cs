using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_MultiThread
{
	internal class CancellationTokenSourceTest
	{
		[Test]
		public void UseCancellationTokenSourceTest()
		{
			CTSDemo cTSDemo = new CTSDemo();
			var task = Task.Run(async delegate
			{
				//注意这里要用await，如果不用则会继续向下走。
				await Task.Delay(30000);
				cTSDemo.Stop();
			});
			task.Wait();
		}
		private class CTSDemo
		{
			//信号器；
			CancellationTokenSource cts = new CancellationTokenSource();
			public CTSDemo()
			{
				Task.Run(Task01, cts.Token);
			}
			public void Stop()
			{
				cts.Cancel();
			}
			private async void Task01()
			{
				while (cts.IsCancellationRequested == false)
				{
					Console.WriteLine(nameof(Task01) + "...执行中");
					await Task.Delay(100);
				}
			}
		}
	}
}
