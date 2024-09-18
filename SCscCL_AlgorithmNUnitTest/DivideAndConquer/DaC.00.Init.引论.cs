using NUnit.Framework;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
	/// <summary>
	/// 分治算法
	/// </summary>
	internal partial class DaC
	{
		[SetUp]
		public void TestSetup()
		{

		}
		[Test]
		public void 分治理解1()
		{
			//正如名字divide and conquer所言，分治算法分为两步，一步是divide，一步是conquer。
			//Divide：Smaller Problems are solved recursively except base cases.
			//Conquer：The solution to the original problem is then formed from the solutions to the sub-problem.
			//说白了，分治算法就是把一个大的问题分为若干个子问题，然后在子问题继续向下分，一直到base cases，通过base cases的解决，一步步向上，最终解决最初的大问题。分治算法是递归的典型应用。
			//常见的利用分治算法思想的有快速排序以及合并排序等等。
		}

		[Test]
		public void 分治理解2()
		{
			//对于一个复杂度为小容易解决的问题直接解决；对于复杂度高的问题A，分解成K个规模较小的子问题，然后将各个子问题互相独立，形式相同的使用递归求解，然后各个子问题合并为得到问题A的解。这种策略称之为分治。
		}
	}
}
