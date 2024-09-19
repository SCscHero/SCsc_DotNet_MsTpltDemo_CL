using System;
using System.Runtime.CompilerServices;
namespace CsLangVersion.Fdmts_PrimitiveType
{
	public static class DateHelper
	{
		public static DateTime GetDateForLastDayOfWeek(DayOfWeek dow, DateTime date)
		{
			int adjustment = ((int)date.DayOfWeek < (int)dow ? 7 : 0);
			return date.AddDays(0 - (((int)(date.DayOfWeek) + adjustment) - (int)dow));
		}

		public static DateTime GetDateForNextDayOfWeek(DayOfWeek DOW, DateTime DATE)
		{
			int adjustment = ((int)DATE.DayOfWeek < (int)DOW ? 0 : 7);
			return DATE.AddDays(((int)DOW) - ((int)(DATE.DayOfWeek)) + adjustment);
		}
	}

	internal partial class DateTimeTest
	{
		private DateTime LastDayOfWeek(DateTime _date, DayOfWeek dayofweek)
		{
			return _date.AddDays(-1 * ((_date.DayOfWeek - dayofweek) % 7)).Date;
		}

		private DateTime NextDayOfWeek(DateTime _date, DayOfWeek dayofweek)
		{
			return LastDayOfWeek(_date, dayofweek).AddDays(7).Date;
		}

		private DateTime GetPreviousWeekDay(DateTime currentDate, DayOfWeek dow)
		{
			int currentDay = (int)currentDate.DayOfWeek, gotoDay = (int)dow;
			return currentDate.AddDays(-7).AddDays(gotoDay - currentDay);
		}

		private DateTime GetNextWeekDay(DateTime currentDate, DayOfWeek dow)
		{
			int currentDay = (int)currentDate.DayOfWeek, gotoDay = (int)dow;
			return currentDate.AddDays(7).AddDays(gotoDay - currentDay);
		}

		private DateTime GetDateForLastDayOfWeek(DayOfWeek DOW, DateTime DATE)
		{
			int adjustment = ((int)DATE.DayOfWeek < (int)DOW ? 7 : 0);
			return DATE.AddDays(0 - (((int)(DATE.DayOfWeek) + adjustment) - (int)DOW));
		}

		private DateTime GetDateForNextDayOfWeek(DayOfWeek DOW, DateTime DATE)
		{
			int adjustment = ((int)DATE.DayOfWeek < (int)DOW ? 0 : 7);
			return DATE.AddDays(((int)DOW) - ((int)(DATE.DayOfWeek)) + adjustment);
		}

		[Test]
		public void 时间输出成文件时间()
		{
			Console.WriteLine(DateTime.Now.ToFileTime());
		}

		[Test]
		public void 时间输出成毫秒格式()
		{
			Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssffff"));//24小时
			Console.WriteLine(DateTime.Now.ToString("yyyyMMddhhmmssffff"));//12小时
		}


		[Test]
		public void 中式思维查询当前时间是星期几()
		{
			var dow = DateTime.Now.DayOfWeek;
			Console.WriteLine("今天是星期几？" + dow.ToString());
			Console.WriteLine("上周星期1是几月几号？" + LastDayOfWeek(DateTime.Now, DayOfWeek.Monday));//出错，返回了下周1
			Console.WriteLine("下周星期2是几月几日？" + NextDayOfWeek(DateTime.Now, DayOfWeek.Tuesday));

			var res = DayOfWeek.Sunday - DayOfWeek.Monday;


			Console.WriteLine("上周星期1是几月几号？" + GetPreviousWeekDay(DateTime.Now, DayOfWeek.Monday));
			Console.WriteLine("下周星期2是几月几日？" + GetNextWeekDay(DateTime.Now, DayOfWeek.Tuesday));//出错了，返回了下下周一，可能是外国理解把周日当做了起点；

			Console.WriteLine("上周星期1是几月几号？" + GetDateForLastDayOfWeek(DayOfWeek.Monday, DateTime.Now));//错误
			Console.WriteLine("下周星期2是几月几日？" + GetDateForNextDayOfWeek(DayOfWeek.Tuesday, DateTime.Now));

			Console.WriteLine();

		}

		/// <summary>
		///  构造函数初始化
		/// </summary>
		[Test]
		public void DateTimeConstructor()
		{
			var date = new DateTime(2023, 5, 1);
			Console.WriteLine(date);
		}

		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void String2DateTime()
		{
			//【错误示例1】
			//System.FormatException : String '20230807' was not recognized as a valid DateTime.
			//DateTime dt = Convert.ToDateTime("20230807");

			//【正确示例1】https://learn.microsoft.com/zh-cn/dotnet/api/system.datetime.tryparseexact?view=net-7.
			DateTime dt;
			DateTime.TryParseExact("20230807", "yyyyMMdd", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.AllowWhiteSpaces, out dt);
			Console.WriteLine(dt);
			//【正确示例2】
			dt = DateTime.ParseExact("20230807", "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
			Console.WriteLine(dt);
		}

		/// <summary>
		/// https://www.cnblogs.com/net-sky/p/12706916.html
		/// </summary>
		[Test]
		public void DateTimeTransfer()
		{
			// C 货币
			2.5.ToString("C"); // ￥2.50
												 // D 10进制数
			25.ToString("D5"); // 25000
												 // E 科学型
			25000.ToString("E"); // 2.500000E+005
													 // F 固定点
			25.ToString("F2"); // 25.00
												 // G 常规
			2.5.ToString("G"); // 2.5
												 // N 数字
			2500000.ToString("N"); // 2,500,000.00
														 // X 16进制
			255.ToString("X"); // FF
												 // C# 日期格式
			DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
			DateTime dt = DateTime.Now;
			dt.ToString();//2005-11-5 13:21:25
			dt.ToFileTime().ToString();//127756416859912816
			dt.ToFileTimeUtc().ToString();//127756704859912816
			dt.ToLocalTime().ToString();//2005-11-5 21:21:25
			dt.ToLongDateString().ToString();//2005年11月5日
			dt.ToLongTimeString().ToString();//13:21:25
			dt.ToOADate().ToString();//38661.5565508218
			dt.ToShortDateString().ToString();//2005-11-5
			dt.ToShortTimeString().ToString();//13:21
			dt.ToUniversalTime().ToString();//2005-11-5 5:21:25
			dt.Year.ToString();//2005
			dt.Date.ToString();//2005-11-5 0:00:00
			dt.DayOfWeek.ToString();//Saturday
			dt.DayOfYear.ToString();//309
			dt.Hour.ToString();//13
			dt.Millisecond.ToString();//441
			dt.Minute.ToString();//30
			dt.Month.ToString();//11
			dt.Second.ToString();//28
			dt.Ticks.ToString();//632667942284412864
			dt.TimeOfDay.ToString();//13:30:28.4412864
			dt.ToString();//2005-11-5 13:47:04
			dt.AddYears(1).ToString();//2006-11-5 13:47:04
			dt.AddDays(1.1).ToString();//2005-11-6 16:11:04
			dt.AddHours(1.1).ToString();//2005-11-5 14:53:04
			dt.AddMilliseconds(1.1).ToString();//2005-11-5 13:47:04
			dt.AddMonths(1).ToString();//2005-12-5 13:47:04
			dt.AddSeconds(1.1).ToString();//2005-11-5 13:47:05
			dt.AddMinutes(1.1).ToString();//2005-11-5 13:48:10
			dt.AddTicks(1000).ToString();//2005-11-5 13:47:04
			dt.CompareTo(dt).ToString();//0
																	//dt.Add().ToString();//问号为一个时间段
			dt.Equals("2005-11-6 16:11:04").ToString();//False
			dt.Equals(dt).ToString();//True
			dt.GetHashCode().ToString();//1474088234
			dt.GetType().ToString();//System.DateTime
			dt.GetTypeCode().ToString();//DateTime

			dt.GetDateTimeFormats('s')[0].ToString();//2005-11-05T14:06:25
			dt.GetDateTimeFormats('t')[0].ToString();//14:06
			dt.GetDateTimeFormats('y')[0].ToString();//2005年11月
			dt.GetDateTimeFormats('D')[0].ToString();//2005年11月5日
			dt.GetDateTimeFormats('D')[1].ToString();//2005 11 05
			dt.GetDateTimeFormats('D')[2].ToString();//星期六 2005 11 05
			dt.GetDateTimeFormats('D')[3].ToString();//星期六 2005年11月5日
			dt.GetDateTimeFormats('M')[0].ToString();//11月5日
			dt.GetDateTimeFormats('f')[0].ToString();//2005年11月5日 14:06
			dt.GetDateTimeFormats('g')[0].ToString();//2005-11-5 14:06
			dt.GetDateTimeFormats('r')[0].ToString();//Sat, 05 Nov 2005 14:06:25 GMT
			string.Format("{0:d}", dt);//2005-11-5
			string.Format("{0:D}", dt);//2005年11月5日
			string.Format("{0:f}", dt);//2005年11月5日 14:23
			string.Format("{0:F}", dt);//2005年11月5日 14:23:23
			string.Format("{0:g}", dt);//2005-11-5 14:23
			string.Format("{0:G}", dt);//2005-11-5 14:23:23
			string.Format("{0:M}", dt);//11月5日
			string.Format("{0:R}", dt);//Sat, 05 Nov 2005 14:23:23 GMT
			string.Format("{0:s}", dt);//2005-11-05T14:23:23
			string.Format("{0:t}", dt);//14:23
			string.Format("{0:T}", dt);//14:23:23
			string.Format("{0:u}", dt);//2005-11-05 14:23:23Z
			string.Format("{0:U}", dt);//2005年11月5日 6:23:23
			string.Format("{0:Y}", dt);//2005年11月
			string.Format("{0}", dt);//2005-11-5 14:23:23
			string.Format("{0:yyyyMMddHHmmssffff}", dt);
			// 计算2个日期之间的天数差
			DateTime dt1 = Convert.ToDateTime("2007-8-1");
			DateTime dt2 = Convert.ToDateTime("2007-8-15");
			TimeSpan span = dt2.Subtract(dt1);
			int dayDiff = span.Days + 1;
			// 计算某年某月的天数
			int days = DateTime.DaysInMonth(2007, 8);
			days = 31;
			// 给日期增加一天、减少一天
			DateTime dt5 = DateTime.Now;
			dt5.AddDays(1); //增加一天
			dt5.AddDays(-1);//减少一天
											//            日期格式模式 说明
											//d 月中的某一天。一位数的日期没有前导零。
											//dd 月中的某一天。一位数的日期有一个前导零。
											//ddd 周中某天的缩写名称，在 AbbreviatedDayNames 中定义。
											//dddd 周中某天的完整名称，在 DayNames 中定义。
											//M 月份数字。一位数的月份没有前导零。
											//MM 月份数字。一位数的月份有一个前导零。
											//MMM 月份的缩写名称，在 AbbreviatedMonthNames 中定义。
											//MMMM 月份的完整名称，在 MonthNames 中定义。
											//y 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示不具有前导零的年份。
											//yy 不包含纪元的年份。如果不包含纪元的年份小于 10，则显示具有前导零的年份。
											//yyyy 包括纪元的四位数的年份。
											//gg 时期或纪元。如果要设置格式的日期不具有关联的时期或纪元字符串，则忽略该模式。
											//h 12 小时制的小时。一位数的小时数没有前导零。
											//hh 12 小时制的小时。一位数的小时数有前导零。
											//H 24 小时制的小时。一位数的小时数没有前导零。
											//HH 24 小时制的小时。一位数的小时数有前导零。
											//m 分钟。一位数的分钟数没有前导零。
											//mm 分钟。一位数的分钟数有一个前导零。
											//s 秒。一位数的秒数没有前导零。
											//ss 秒。一位数的秒数有一个前导零。
											//f 秒的小数精度为一位。其余数字被截断。
											//ff 秒的小数精度为两位。其余数字被截断。
											//fff 秒的小数精度为三位。其余数字被截断。
											//ffff 秒的小数精度为四位。其余数字被截断。
											//fffff 秒的小数精度为五位。其余数字被截断。
											//ffffff 秒的小数精度为六位。其余数字被截断。
											//fffffff 秒的小数精度为七位。其余数字被截断。
											//t 在 AMDesignator 或 PMDesignator 中定义的 AM / PM 指示项的第一个字符（如果存在）。
											//tt 在 AMDesignator 或 PMDesignator 中定义的 AM / PM 指示项（如果存在）。
											//z 时区偏移量（“+”或“-”后面仅跟小时）。一位数的小时数没有前导零。例如，太平洋标准时间是“-8”。
											//zz 时区偏移量（“+”或“-”后面仅跟小时）。一位数的小时数有前导零。例如，太平洋标准时间是“-08”。
											//zzz 完整时区偏移量（“+”或“-”后面跟有小时和分钟）。一位数的小时数和分钟数有前导零。例如，太平洋标准时间是“-08:00”。
											//: 在 TimeSeparator 中定义的默认时间分隔符。
			/// 在 DateSeparator 中定义的默认日期分隔符。
			//% c 其中 c 是格式模式（如果单独使用）。如果格式模式与原义字符或其他格式模式合并，则可以省略“%”字符。
			//\ c 其中 c 是任意字符。照原义显示字符。若要显示反斜杠字符，请使用“\\”。
			//只有上面第二个表中列出的格式模式才能用于创建自定义模式；在第一个表中列出的标准格式字符不能用于创建自定义模式。
			//自定义模式的长度至少为两个字符；例如，
			DateTime.Now.ToString("d"); // 返回 DateTime 值；“d”是标准短日期模式。
			DateTime.Now.ToString("%d"); // 返回月中的某天；“%d”是自定义模式。
			DateTime.Now.ToString("d "); // 返回后面跟有一个空白字符的月中的某天；“d”是自定义模式。
		}
	}
}
