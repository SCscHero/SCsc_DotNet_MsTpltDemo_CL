using System;
using System.Web;

namespace CsLangVersion.Fdmts_HttpMethod
{
	public class HttpEnDeCode
	{
		[SetUp]
		public void Setup()
		{
		}
		/// <summary>
		/// Knowledge1: 注意Url转义不是整个的转义，也不是Key的转义，只转义Value。参数之间的&符号仍然是链接字符串，不做转义。
		/// </summary>
		[Test]
		public void Eq01_EnCode()
		{
			var url = @"http://www.googleSCscHero.com?";
			var urlData = @"Year=""2023&2024""&batch=5";
			Console.WriteLine(HttpUtility.UrlEncodeUnicode(urlData));
			Console.WriteLine(HttpUtility.UrlEncode(urlData));
		}


	}


}

