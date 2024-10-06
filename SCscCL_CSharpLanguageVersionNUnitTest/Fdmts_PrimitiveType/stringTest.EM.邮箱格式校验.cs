using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType {
  partial class stringTest {

    [Test]
    public void 邮箱格式校验简单测试() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(邮箱格式校验简单测试)}");

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }
    private static bool IsEmailAddress(string email) {
      //如果为空，认为验证不合格
      if(string.IsNullOrEmpty(email)) {
        return false;
      }
      //清除要验证字符串中的空格
      email=email.Trim();
      //模式字符串
      string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
      Regex r = new Regex(pattern);
      // 验证
      return r.IsMatch(email);
    }

  }
}
