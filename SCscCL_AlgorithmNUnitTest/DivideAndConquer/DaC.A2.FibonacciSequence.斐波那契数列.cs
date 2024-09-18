using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
	internal partial class DaC
	{

		static int f(int n)
		{
			if (n == 0) return 1; // 基本情况1  
			if (n == 1) return 8; // 基本情况2  
														// 递归情况  
			return f(n - 1) + f(n - 2);
		}
		[Test]
		public void FibonacciSequence_斐波那契数列()
		{
			//例如已知f(0)=1，f(1)=8，求解f(30)是多少？
			//这时可以使用递归求解，也是分治算法的常用策略：
			//可以利用F(30)=F(29)+F(28)，以此类推：
			int result1 = f(3);
			Console.WriteLine("f(3) = " + result1);

			int result2 = f(30);
			Console.WriteLine("f(30) = " + result2);
		}

	}
}
