using System;

namespace CsLangVersion.Fdmts_PrimitiveType
{

	internal partial class DateTimeTest
	{
		[Test]
		public void 时间差计算()
		{
			var tftimeSeconds = 60 * 60 * 24;
			DateTime publishDate = Convert.ToDateTime("2023-11-08 19:21:17.903");
			Console.WriteLine(publishDate.Ticks);
			Console.WriteLine(DateTime.Now.Ticks);
			System.TimeSpan ts1 = new System.TimeSpan(publishDate.Ticks);
			System.TimeSpan ts2 = new System.TimeSpan(DateTime.Now.Ticks);
			System.TimeSpan tsSub = ts2.Subtract(ts1);
			Console.WriteLine(tsSub.Ticks);
			Console.WriteLine(tsSub.TotalSeconds);
			Console.WriteLine(tsSub.TotalMinutes);
			Console.WriteLine(tsSub.TotalHours);
		}
	}
}
