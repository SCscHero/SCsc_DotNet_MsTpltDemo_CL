using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CsLangVersion.CsharpFundamentals.lockSyntax;

namespace CsLangVersion.Fdmts_Keyword
{
	public partial class lockSyntax
	{
		private readonly object lockMyDemo = new object();
		int[] amounts = { 0, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 2, -3, 6, -2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31, 200, -50, -20, - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31, 2, -3, 6, -2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31, 200, -50, -20 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31, 2, -3, 6, -2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31, 200, -50, -20 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 - 2, -1, 8, -5, 11, -6, 23, 5, 2, -80, -90, -3, -6, -31 };
		[SetUp]
		public void Setup()
		{

		}


		private class Eq001_Act
		{
			public int balance;
			public Eq001_Act(int initialBalance) => balance = initialBalance;
		}

		private void Eq001_ActUpdate(Eq001_Act act)
		{
			foreach (var amount in amounts)
			{
				Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
				act.balance += amount;
			}

		}

		[Test]
		public async Task MyDemo_Eq001_多线程Test()
		{
			var account = new Eq001_Act(1000);
			var tasks = new System.Threading.Tasks.Task[100];
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = System.Threading.Tasks.Task.Run(() => Eq001_ActUpdate(account));
			}
			await System.Threading.Tasks.Task.WhenAll(tasks);
		}

		private void Eq001_ActUpdateLock(Eq001_Act act)
		{
			lock (lockMyDemo)
			{
				foreach (var amount in amounts)
				{
					Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
					act.balance += amount;
				}
				
			}
		}
		[Test]
		public async Task MyDemo_Eq001_带Lock多线程Test()
		{
			var account = new Eq001_Act(1000);
			var tasks = new System.Threading.Tasks.Task[100];
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = System.Threading.Tasks.Task.Run(() => Eq001_ActUpdateLock(account));
			}
			await System.Threading.Tasks.Task.WhenAll(tasks);
		}

	}
}
