using System;
using System.Diagnostics;

namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _4_TryParse比Parse好
	{
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void 早期的Parse方法痛点()
		{
			//1.早期在没有TryParse方法的时候，
			string str = string.Empty;
			double db;
			try
			{
				db = double.Parse(str);
			}
			catch (Exception ex)
			{
				db = 0;
				throw;
			}

			//2.
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Eq2Parse和TryParse()
		{
			//重点为Parse易引发异常，而TryParse不会引发异常。且TryParse比Parse在引发异常和不引发异常的情况下，效率都要高。
			long length = 100_000_000;
			int numLength = 7;
			string[] strNomalArray = new string[length];
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < numLength; j++)
				{
					strNomalArray[i] += random.Next(0, 9).ToString();
				}
			}
			string[] strErrorArray = new string[length];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					strErrorArray[i] += random.Next(0, 9).ToString();
				}
				strErrorArray[i] += "a";
			}
			//性能对比场景1：无异常情况下转换一亿次。
			//	性能对比场景1：Parse耗费时间为3518毫秒。
			//性能对比场景1：TryParse耗费时间为3255毫秒。
			{
				int resint;
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				for (int i = 0; i < length; i++)
				{
					resint = int.Parse(strNomalArray[i]);
				}
				stopwatch.Stop();
				Console.WriteLine($@"性能对比场景1：{nameof(int.Parse)}耗费时间为{stopwatch.ElapsedMilliseconds.ToString()}毫秒。");
			}
			{
				int resint;
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				for (int i = 0; i < length; i++)
				{
					int.TryParse(strNomalArray[i], out resint);
				}
				stopwatch.Stop();
				Console.WriteLine($@"性能对比场景1：{nameof(int.TryParse)}耗费时间为{stopwatch.ElapsedMilliseconds.ToString()}毫秒。");
			}
			//性能对比场景2：异常情况下转换一亿次。
			{
				int resint;
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				for (int i = 0; i < length; i++)
				{
					try
					{
						resint = int.Parse(strErrorArray[i]);
					}
					catch (Exception)
					{
						resint = 0;
					}

				}
				stopwatch.Stop();
				Console.WriteLine($@"性能对比场景2：{nameof(int.Parse)}耗费时间为{stopwatch.ElapsedMilliseconds.ToString()}毫秒。");
			}
			{
				int resint;
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				for (int i = 0; i < length; i++)
				{
					int.TryParse(strErrorArray[i], out resint);
				}
				stopwatch.Stop();
				Console.WriteLine($@"性能对比场景2：{nameof(int.TryParse)}耗费时间为{stopwatch.ElapsedMilliseconds.ToString()}毫秒。");
			}

		}
	}
}
