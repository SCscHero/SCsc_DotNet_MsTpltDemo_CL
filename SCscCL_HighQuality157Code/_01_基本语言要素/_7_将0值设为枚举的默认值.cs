using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System;

namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _7_将0值设为枚举的默认值
	{
		#region TestModel_Eq1
		private enum Eq1Race
		{
			TE = 1,
			OR = 2,
			NE = 3,
			UD = 4,
			CustomRace = 4
		}
		#endregion

		[TestMethod]
		public void Eq1枚举值相同时候Issue示例()
		{
			var ud = Eq1Race.UD;
			var customRace = Eq1Race.CustomRace;
			if (ud == customRace)
				Console.WriteLine($@"Enum Compare:{nameof(ud)} Equals {nameof(customRace)}");
			if ((int)ud == (int)customRace)
				Console.WriteLine($@"(int)Enum Compare:{nameof(ud)} Equals {nameof(customRace)}");
			var enum4 = (Eq1Race)4;//CustomRace
			Console.WriteLine(enum4.ToString());//UD

			//【总结】切记枚举值不能相同，否则会造成很多紊乱的问题。
		}

		#region TestModel_Eq2
		[Flags]
		private enum Eq2Days
		{
			None = 0b_0000_0000,  // 0
			Monday = 0b_0000_0001,  // 1
			Tuesday = 0b_0000_0010,  // 2
			Wednesday = 0b_0000_0100,  // 4
			Thursday = 0b_0000_1000,  // 8
			Friday = 0b_0001_0000,  // 16
			Saturday = 0b_0010_0000,  // 32
			Sunday = 0b_0100_0000,  // 64
			Weekend = Saturday | Sunday
		}

		#endregion

		[TestMethod]
		public void Eq2枚举类型作为位标识()
		{
			Eq2Days meetingEq2Days = Eq2Days.Monday | Eq2Days.Wednesday | Eq2Days.Friday;
			Console.WriteLine(meetingEq2Days);
			// Output:
			// Monday, Wednesday, Friday

			Eq2Days workingFromHomeEq2Days = Eq2Days.Thursday | Eq2Days.Friday;
			Console.WriteLine($"Join a meeting by phone on {meetingEq2Days & workingFromHomeEq2Days}");
			// Output:
			// Join a meeting by phone on Friday

			bool isMeetingOnTuesday = (meetingEq2Days & Eq2Days.Tuesday) == Eq2Days.Tuesday;
			Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
			// Output:
			// Is there a meeting on Tuesday: False
			var a = (Eq2Days)37;
			Console.WriteLine(a);
			// Output:
			// Monday, Wednesday, Saturday
		}

		#region TestModel_Eq3
		private enum Eq3Season
		{
			Spring,
			Summer,
			Autumn,
			Winter
		}
		#endregion
		[TestMethod]
		public void Eq3枚举类型的默认值()
		{
			var a = Eq3Season.Autumn;
			Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

			var b = (Eq3Season)1;
			Console.WriteLine(b);  // output: Summer

			var c = (Eq3Season)4;
			Console.WriteLine(c);  // output: 4
		}

		#region TestModel_Eq4
		private enum Eq4Week
		{
			Mon = 1,
			Tues = 2,
			Web = 3,
			Thur = 4,
			Fri = 5,
			Sat = 6,
			Sun = 7
		};
		#endregion
		/// <summary>
		/// In VS2022 and .Net7:Compile Error CS0165  Use of unassigned local variable 'week' 
		/// </summary>
		[TestMethod]
		public void Eq4将0值设为枚举的默认值()
		{
			Eq4Week week;
			//Console.WriteLine(week);//Compile Error CS0165  Use of unassigned local variable 'week' 

		}
	}
}
