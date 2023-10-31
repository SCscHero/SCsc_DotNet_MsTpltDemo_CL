using NUnit.Framework.Internal;
using System;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	public partial class DateTimeTest
	{
		[TestCase(2023, 10, 29, DayOfWeek.Sunday)]
		[TestCase(2023, 10, 30, DayOfWeek.Monday)]
		[Test]
		public void DayOfWeekTest(int inputYear, int inputMonth, int inputDay, DayOfWeek eDof)
		{
			var inputDt = new DateTime(inputYear, inputMonth, inputDay).DayOfWeek;
			Assert.True(inputDt == eDof);
		}

		/// <summary>
		/// 
		/// https://www.codenong.com/20407594/#:~:text=DayOfWeek%20desiredDay%20%3D%20DayOfWeek.Wednesday%3B%20int%20offsetAmount%20%3D%20%28int%29,%2B%20offsetAmount%29%3B%20DateTime%20nextWeekWednesday%20%3D%20DateTime.Now.AddDays%287%20%2B%20offsetAmount%29%3B
		/// </summary>
		/// <param name="inputYear"></param>
		/// <param name="inputMonth"></param>
		/// <param name="inputDay"></param>
		/// <param name="eYear">Expected Year</param>
		/// <param name="eMonth">Expected Month</param>
		/// <param name="eDay">Expected Day</param>
		[TestCase(2023, 10, 29, 2023, 10, 23)]
		[TestCase(2023, 10, 30, 2023, 10, 23)]
		[Test]
		public void 英式思维查询上周一根据指定时间(int inputYear, int inputMonth, int inputDay, int eYear, int eMonth, int eDay)
		{
			DateTime testDt = new DateTime(inputYear, inputMonth, inputDay);
			DateTime expectedDt = new DateTime(eYear, eMonth, eDay);
			DateTime resDt = DateHelper.GetDateForLastDayOfWeek(DayOfWeek.Monday, testDt);
			Assert.True(0 == DateTime.Compare(expectedDt.Date, resDt.Date));
		}

		private DateTime GetCurrentWeekDateInChina(DateTime currentDate, DayOfWeek edow)
		{
			return currentDate.AddDays(1 - (currentDate.DayOfWeek == 0 ? 7 : (int)currentDate.DayOfWeek) + (edow == 0 ? 6 : (int)edow - 1));
		}



		[TestCase(2023, 10, 31, 2023, 11, 2, DayOfWeek.Thursday)]
		[TestCase(2023, 10, 29, 2023, 10, 23, DayOfWeek.Monday)]
		[TestCase(2023, 10, 29, 2023, 10, 29, DayOfWeek.Sunday)]
		[TestCase(2023, 10, 30, 2023, 10, 30, DayOfWeek.Monday)]
		[TestCase(2023, 10, 30, 2023, 11, 5, DayOfWeek.Sunday)]
		[Test]
		public void 中式查询本周日期(int inputYear, int inputMonth, int inputDay, int eYear, int eMonth, int eDay, DayOfWeek edow)
		{
			DateTime testDt = new DateTime(inputYear, inputMonth, inputDay);
			DateTime expectedDt = new DateTime(eYear, eMonth, eDay);
			var dowInt = testDt.DayOfWeek == 0 ? 7 : (int)testDt.DayOfWeek;
			DateTime resDt = GetCurrentWeekDateInChina(testDt, edow);
			Assert.True(0 == DateTime.Compare(expectedDt.Date, resDt.Date));
		}

		private DateTime GetLastWeekDateInChina(DateTime currentDate, DayOfWeek edow)
		{
			return currentDate.AddDays(1 - (currentDate.DayOfWeek == 0 ? 7 : (int)currentDate.DayOfWeek) + (edow == 0 ? -1 : (int)edow - 8));
		}


		[TestCase(2023, 10, 29, 2023, 10, 16, DayOfWeek.Monday)]
		[TestCase(2023, 10, 29, 2023, 10, 22, DayOfWeek.Sunday)]
		[TestCase(2023, 10, 30, 2023, 10, 29, DayOfWeek.Sunday)]
		[Test]
		public void 中式查询上周时间(int inputYear, int inputMonth, int inputDay, int eYear, int eMonth, int eDay, DayOfWeek edow)
		{
			DateTime testDt = new DateTime(inputYear, inputMonth, inputDay);
			DateTime expectedDt = new DateTime(eYear, eMonth, eDay);
			var dowInt = testDt.DayOfWeek == 0 ? 7 : (int)testDt.DayOfWeek;
			DateTime resDt = GetLastWeekDateInChina(testDt, edow);
			Assert.True(0 == DateTime.Compare(expectedDt.Date, resDt.Date));

		}



	}
}
