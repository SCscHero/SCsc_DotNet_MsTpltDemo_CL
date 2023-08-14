using System;
using System.Linq;

namespace CsLangVersion.Fdmts_CollectionType
{
	/// <summary>
	/// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
	/// </summary>
	internal class ArraysTest
	{
		[Test]
		public void Eq100_Array中不同形式的数组()
		{
			// Declare a single-dimensional array of 5 integers.
			int[] array1 = new int[5];

			// Declare and set array element values.
			int[] array2 = new int[] { 1, 3, 5, 7, 9 };

			// Alternative syntax.（Array2等价于array3）
			int[] array3 = { 1, 3, 5, 7, 9 };

			// Declare a two dimensional array.
			int[,] multiDimensionalArray1 = new int[2, 3];

			// Declare and set array element values.
			int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

			// Declare a jagged array.
			int[][] jaggedArray = new int[6][];

			// Set the values of the first array in the jagged array structure.
			jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
		}

		[Test]
		public void Eq101_Array中新增元素()
		{
			var strings = new string[] {};
			strings=strings.Append("xxxx").ToArray();
        }
		/// <summary>
		/// https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/linq/how-to-count-occurrences-of-a-word-in-a-string-linq
		/// </summary>
		[Test]
		public void Eq104_Array中统计各元素出现次数WithLinq()
		{
			string[] strings = new string[] { "BUG", "BUG", "BUG", "BUG", "BUG", "BUG", "CR", "CR", "CR", "CR", "CR", "CR", "Task", "Task", "Task", "Task", "Task", "Task", "BUG", "BUG", "BUG", "CR", "CR", "CR", "CR" };
			var resBugCount = (from type in strings
							  where type.Equals("BUG", StringComparison.InvariantCultureIgnoreCase)
							  select type).ToArray().Count();
            Console.WriteLine();
        }


	}
}

