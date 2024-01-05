using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CsLangVersion.Fdmts_SystemMethod
{
	internal class RegexTest
	{


		/// <summary>
		/// 如果单纯为了一次性的替换，建议不使用正则，效率低于string.Replace，内部实现使用哈希值来查找子字符串，时间复杂度是O(n); 
		/// 如果是多次计算多次替换，Regex.Replace内部实现替换的效率高于字符串替换；
		/// </summary>
		[Test]
		public void 低水平的正则替换()
		{
			string text = "asada33a23a6a4aaalkjlkjklsdsdbbbssasdawdada";
			var regReplaceWrap = new Regex(@"[a]");
			while (regReplaceWrap.IsMatch(text))
			{
				text = regReplaceWrap.Replace(text, "9");
			}
			Console.WriteLine(text);

		}

		public void RegexSearch的案例()
		{
			var oStr = @" 其他
 
 Exc";
		}

		[Test]
		public void RegexReplace的替换()
		{
			string input = "My email is SCscHero@example.com. Can you help me?";
			string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
			string replacement = "***";

			string result = Regex.Replace(input, pattern, replacement);
			Console.WriteLine(result);
		}
	}
}
