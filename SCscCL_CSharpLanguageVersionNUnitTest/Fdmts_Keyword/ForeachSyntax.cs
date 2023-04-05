using System;
using System.Collections.Generic;

namespace CsLangVersion.CsharpFundamentals
{
	public class ForeachSyntax
	{
		private List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 7, 6, 7, 8 };
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void 三个跳出关键字Continue和Return和Break()
		{
			foreach (int i in intList)
			{
				if (i == 2)
				{
					continue;//跳过本次循环
				}
				if (i == 5)
				{
					return;//终止该方法
				}
				else if (i == 7)
				{
					break;//终止Foreach循环
				}
				Console.WriteLine(i);
			}
			Console.WriteLine("foreach end");
			Assert.Pass();

			/*Output:
			    1
				3
				4
			 */
		}

	}
}
