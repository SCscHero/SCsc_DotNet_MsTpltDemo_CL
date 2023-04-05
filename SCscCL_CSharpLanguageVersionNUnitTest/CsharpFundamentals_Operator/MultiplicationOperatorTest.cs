using NUnit.Framework;
using System;

namespace CsLangVersion.CsharpFundamentals_Operator
{
	/// <summary>
	/// 【操作符】https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/
	/// </summary>
	public class MultiplicationOperatorTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void CompoundAssignment()
		{


		}

		[Test]
		public void Test1()
		{
			Console.WriteLine(5 * 2);         // output: 10
			Console.WriteLine(0.5 * 2.5);     // output: 1.25
			Console.WriteLine(0.1m * 23.4m);  // output: 2.34
			Assert.Pass();
		}
	}
}
