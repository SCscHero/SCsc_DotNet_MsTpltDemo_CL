namespace SCscCL_HighQuality157Code._01_基本语言要素
{
	[TestClass]
	public class _1_使用默认转型方法
	{
		/// <summary>
		/// 隐式转换和显式转换
		/// </summary>
		[TestMethod]
		public void 使用默认转型方法()
		{
			//所谓“基元类型”，是指编译器直接支持的数据类型。基元类型包括：sbyte、byte、short、ushort、int、uint、long、ulong、char、float、double、bool、decimal、object、string。
			int i = 0;
			float j = 0;
			j = i;//int到float存在一个隐式转换
			i = (int)j;//float到int必需存在一个显示转换
		}

		/// <summary>
		/// TODO:
		/// </summary>
		[TestMethod]
		public void 运算符重载()
		{
			//TODO:待填坑。

		}

		/// <summary>
		/// 使用类型内置的Parse、TryParse，或者如ToString、ToDouble、ToDateTime等方法
		/// </summary>
		[TestMethod]
		public void Int2String转换()
		{
			string str = "12345";
			int parseInt = int.Parse(str);
			int tryParseInt;
			bool success = int.TryParse(str, out tryParseInt);
			if (success)
			{
				Console.WriteLine($"Converted '{str}' to {tryParseInt}.");
			}
			else
			{
				Console.WriteLine($"Attempted conversion of '{str ?? "<null>"}' failed.");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void String2Int转换()
		{
			int i = 12345;
			string toStringStr = i.ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void String2Double转换()
		{
			string str = "12345.222";
			var db = double.Parse(str);
			double tryParseDouble;
			bool success = double.TryParse(str, out tryParseDouble);
			if (success)
			{
				Console.WriteLine($"Converted '{str}' to {tryParseDouble}.");
			}
			else
			{
				Console.WriteLine($"Attempted conversion of '{str ?? "<null>"}' failed.");
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void String2DateTime转换()
		{
			DateTime dt = DateTime.Now;
			string str = "1/23/2023 4:56:08 PM";
			DateTime tryParseDt;
			bool IsSuccess = DateTime.TryParse(str, out tryParseDt);
			if (IsSuccess)
			{
				Console.WriteLine($"Converted '{str}' to {tryParseDt}.");
			}
			else
			{
				Console.WriteLine($"Attempted conversion of '{str ?? "<null>"}' failed.");
			}
		}

		/// <summary>
		/// TODO:待填坑
		/// </summary>
		[TestMethod]
		public void 字符类相互转换()
		{
			//TODO:待填坑。
		}

	}
}
