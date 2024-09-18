using System;
using System.Threading.Tasks;

namespace CsLangVersion.CsharpFundamentals
{
	public partial class lockSyntax
	{
		private readonly object lockX = new object();

		#region 互斥锁_需要同步对共享资源访问时
		/// <summary>
		/// 
		/// https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/lock
		/// </summary>
		[Test]
		public void lock确保对共享资源的独占访问权限()
		{
			lock (lockX)
			{
				// Your code...
			}
			Assert.Pass();
		}

		[Test]
		public void 使用MonitorEnter确保对共享资源的独占访问权限()
		{
			object __lockObj = lockX;
			bool __lockWasTaken = false;
			try
			{
				System.Threading.Monitor.Enter(__lockObj, ref __lockWasTaken);
				// Your code...
			}
			finally
			{
				if (__lockWasTaken) System.Threading.Monitor.Exit(__lockObj);
			}
			Assert.Pass();
		}


		public class Account
		{
			private readonly object balanceLock = new object();
			private decimal balance;
			public Account(decimal initialBalance) => balance = initialBalance;
			public decimal Debit(decimal amount)
			{
				if (amount < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
				}
				decimal appliedAmount = 0;
				lock (balanceLock)
				{
					Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
					if (balance >= amount)
					{
						balance -= amount;
						appliedAmount = amount;
					}
				}
				return appliedAmount;
			}
			public void Credit(decimal amount)
			{
				if (amount < 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
				}
				lock (balanceLock)
				{
					Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
					balance += amount;
				}
			}

			public decimal GetBalance()
			{
				lock (balanceLock)
				{
					Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId); return balance;
				}
			}
		}
		static async Task Update(Account account)
		{
			decimal[] amounts = { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };
			foreach (var amount in amounts)
			{
				if (amount >= 0)
				{
					account.Credit(amount);
				}
				else
				{
					account.Debit(Math.Abs(amount));
				}
			}
		}

		[Test]
		public async Task 同步锁场景实战Test()
		{
			var account = new Account(1000);
			var tasks = new System.Threading.Tasks.Task[100];
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = System.Threading.Tasks.Task.Run(() => Update(account));
			}
			await System.Threading.Tasks.Task.WhenAll(tasks);
			Console.WriteLine($"Account's balance is {account.GetBalance()}");
			// Output:
			// Account's balance is 2000
		}

		#endregion




	}
}
