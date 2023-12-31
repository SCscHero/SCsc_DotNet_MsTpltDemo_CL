using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class byteTest
	{
		[TestCase("AbcXXDD", 14, 7)]
		[TestCase("我的中国心XXDD", 18, 9)]
		[TestCase("我的中国心", 10, 5)]
		[Test]
		public void 查询字符串的字节数量使用不同编码获取(string param, int byteUniLen, int byteLatinLen)
		{
			byte[] unicodeBytes = System.Text.Encoding.Unicode.GetBytes(param);
			byte[] latin1Bytes = Encoding.Latin1.GetBytes(param);
			Assert.True(byteUniLen == unicodeBytes.Length && latin1Bytes.Length == byteLatinLen);
		}


		[Test]
		public void 字节转换成十进制字符串_双字节Unicode字符失败()
		{
			byte[] unicodeBytes = System.Text.Encoding.Unicode.GetBytes("我的中国心");
			foreach (byte b in unicodeBytes)
			{
				Console.WriteLine("0x{0:X2} ({1})", b, b);
				//Console.WriteLine(b.ToString("X2"));//十进制
				//Console.WriteLine(b.ToString("X4"));//十六进制
			}

			string unicodeString = string.Join("", unicodeBytes.Select(b => string.Format("0x{0:X2}", b)));


			//Unicode编码：
			//将汉字进行UNICODE编码，如：“王”编码后就成了“\王”，UNICODE字符以\u开始，后面有4个数字或者字母，所有字符都是16进制的数字，每两位表示的256以内的一个数字。而一个汉字是由两个字符组成，于是就很容易理解了，“738b”是两个字符，分别是“73”“8b”。但是在将 UNICODE字符编码的内容转换为汉字的时候，字符是从后面向前处理的，所以，需要把字符按照顺序“8b”“73”进行组合得到汉字。
		}
		/// <summary>
		/// 【Ref】https://blog.csdn.net/qq_26422355/article/details/82716824
		/// </summary>
		[Test]
		public void 支持双字节转Unicode十进制格式()
		{
			string res = String2Unicode("我的中国心XXDD");
		}
		/// <summary>
		/// Unicode转字符串
		/// </summary>
		/// <param name="source">经过Unicode编码的字符串</param>
		/// <returns>正常字符串</returns>
		public static string Unicode2String(string source)
		{
			return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
									 source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
		}
		public static string String2Unicode(string source)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(source);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < bytes.Length; i += 2)
			{
				stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
	}
}
