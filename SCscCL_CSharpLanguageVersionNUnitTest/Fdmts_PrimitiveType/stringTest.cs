using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class stringTest
	{
		[Test]
		public void LastIndexOf使用()
		{
			var res = "ABCDEFG".LastIndexOf('.');//不存在则返回-1
			var res1 = "ABCD.EF.G.PDF".LastIndexOf('.');//不存在则返回位数
		}

		[Test]
		public void 无法实现_字符串Dollar和艾特语法糖与三目混用()
		{
			bool judge = true;
			//【error example】RootCase是由于冒号在内插字符串中是表示格式的，例如string.Format中的格式转化或ToString()中的格式转换；
			//Console.WriteLine($@"aaa{judge?"11" :"22"}bbb");
			//【Solution】【Ref】https://www.coder.work/article/225796
			Console.WriteLine($@"aaa{(judge ? "11" : "22")}bbb");
		}

		/// <summary>
		/// 在C#中，字符串比较的最佳性能通常是通过使用 string.Equals 方法来实现的。这个方法在比较两个字符串时，会使用一个称为“比较算法”的过程，该算法在比较字符串时非常高效。
		///string.Equals 方法可以接受两个字符串作为参数，并比较它们是否相等。如果两个字符串相等，则返回 true；否则返回 false。这个方法与使用 == 或 != 运算符来比较字符串相比，性能更佳，因为它会使用特定的比较算法来比较字符串中的每个字符，而不是使用默认的引用比较。
		///以下是一个使用 string.Equals 方法进行字符串比较的示例：
		/// </summary>
		[Test]
		public void 字符串比较方法1()
		{
			string str1 = "Hello";
			string str2 = "World";
			bool isEqual = string.Equals(str1, str2);
		}
		[Test]
		public void 字符串比较方法2()
		{
			string str1 = "Hello";
			string str2 = "World";
			String.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);//忽略大小写
			String.Equals(str1, str2, StringComparison.Ordinal);//区分大小写
		}
		[Test]
		public void 字符串比较方法3()
		{

		}

		[Test]
		public void 字符串换行的多种文法()
		{
			string example = "这是第一行\n这是第二行";
			Console.WriteLine(example);
			string example1 = @"这是第一行
这是第二行";
			Console.WriteLine(example1);
			string example2 = "这是第一行" + Environment.NewLine + "这是第二行";
			Console.WriteLine(example2);
		}

		[Test]
		public void Unicode字符串基础使用()
		{
			string s = "Hello\u00A0\u00A0, \n\rWorld!你好，世界！";
			Console.WriteLine("转换前" + s);
			byte[] bytes = Encoding.Unicode.GetBytes(s);
			string unicodeString = Encoding.Unicode.GetString(bytes);
			Console.WriteLine("转换后" + unicodeString);
		}

		[Test]
		public void 字符串解析成Unicode格式即带斜杠U开头的字符串_字节正则匹配()
		{
			string input = "Hello, World!";
			string output = ConvertToUnicode(input);
			Console.WriteLine(output);
			//解析中文失败
			input = "我的中国心XXDD";
			output = ConvertToUnicode(input);
			Console.WriteLine(output);
		}

		public static string ConvertToUnicode(string input)
		{
			// 转换字符串为Unicode编码  
			string output = Regex.Replace(input, "[\x21-\x7E]", match =>
			{
				// 使用十六进制编码表示字符  
				string hex = match.Value.ToUpper().PadLeft(4, '0').PadRight(4, '0');
				return "\\u" + hex;
			});
			return output;
		}

		[Test]
		public void 字符串解析成Unicode格式即带斜杠U开头的字符串_字节16进制()
		{
			string chinese = "我的中国心XXDD";
			byte[] unicodeBytes = System.Text.Encoding.Unicode.GetBytes(chinese);
			var res = string.Empty;
			foreach (byte b in unicodeBytes)
			{
				res += @"\u" + b.ToString("X4"); // 以16进制格式打印每个字节  
			}
			string unicodeString = System.Text.Encoding.Unicode.GetString(unicodeBytes);
		}

		[Test]
		public void 字符串转换成斜杠U开头的Unicode字符串()
		{
			string originalString = "王日天";
			Console.WriteLine(ConvertToModifiedString(originalString)); // Output: \u671d\u65e5\u904e  
		}

		public static string ConvertToModifiedString(string originalString)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(originalString);
			for (int i = 0; i < bytes.Length; i++)
			{
				if (i > 0 && bytes[i] == 0x1b && bytes[i - 1] == 0x1b) // if \u001b (ESC) is followed by another ESC, it's not part of a Unicode escape sequence  
				{
					bytes[i - 1] = (byte)0x2d; // replace ESC by - (hyphen)  
					bytes[i] = (byte)0x2d; // also replace the second ESC by - (hyphen)  
				}
			}
			return Encoding.UTF8.GetString(bytes);
		}


		[Test]
		public void 字符串中替换指定个数()
		{

		}

		[Test]
		public void 字符串中替换全部()
		{
			string oStr = "asada33a23a6a4aaalkjlkjklsdsdbbbssasdawdada";
			Console.WriteLine(oStr.Replace("a", "9"));
		}
	}
}
