using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	
	
	internal partial class DateTimeTest
	{
		
    public static DateTime? ParseYearMonth(string input)  
    {  
        string[] formats = { "yyyy.MM", "yyyy-MM" };  
        DateTime result;  
        if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))  
        {  
            // 修正DateTime，因为我们只关心年和月，所以将日设置为1  
            return new DateTime(result.Year, result.Month, 1);  
        }  
        else  
        {  
            // 输入字符串不符合任何指定的格式  
            return null;  
        }  
    }
		
		[Test]
		public void 转换根据指定的时间格式()
		{
			string[] formats = { "yyyy.MM", "yyyy-MM" };
			DateTime result;
			bool isTPSuccess = false;
			string input = string.Empty;

			input = "2024.10";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Assert.IsTrue(isTPSuccess);
			Assert.IsTrue(result == new DateTime(2024, 10, 1));

			input = "2024.21";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Assert.IsFalse(isTPSuccess);
			Assert.IsTrue(result == new DateTime());

			input = "2024.05";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Console.WriteLine(result);
			Assert.IsTrue(isTPSuccess);
			Assert.IsTrue(result == new DateTime(2024, 5, 1));

			input = "2024-10";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Console.WriteLine(result);
			Assert.IsTrue(isTPSuccess);
			Assert.IsTrue(result == new DateTime(2024, 10, 1));


			input = "2024-05";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Console.WriteLine(result);
			Assert.IsTrue(isTPSuccess);
			Assert.IsTrue(result == new DateTime(2024, 5, 1));

			input = "2024-10-5";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Assert.IsFalse(isTPSuccess);
			Assert.IsTrue(result == new DateTime());

			input = "2024-10-05";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Assert.IsFalse(isTPSuccess);
			Assert.IsTrue(result == new DateTime());

			input = "2024-10-05 22:24:01";
			isTPSuccess = DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			Assert.IsFalse(isTPSuccess);
			Assert.IsTrue(result == new DateTime());

		}
	}
}
