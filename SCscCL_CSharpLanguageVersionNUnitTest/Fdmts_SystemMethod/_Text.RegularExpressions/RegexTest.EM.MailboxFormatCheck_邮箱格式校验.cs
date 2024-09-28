using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SystemMethod._Text.RegularExpressions {
  partial class RegexTest {
    [Test]
    public void 正则校验邮箱格式() {

      System.Console.WriteLine(@$"UT Excuted {nameof(RegexTest)}_{nameof(正则校验邮箱格式)}");
      var email1 = IsValidMailbox1("scQcxx_@KFCcd.cn");
      var email2 = IsValidMailbox1("qqvv@a.GTA-CSSD.com");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    private static bool IsValidMailbox1(string email) {
      if(string.IsNullOrEmpty(email)) {
        return false;
      }
      email=email.Trim();
      string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
      Regex r = new Regex(pattern);
      return r.IsMatch(email);
    }


    [Test]
    public void 正则校验邮箱格式2_更健壮() {

      System.Console.WriteLine(@$"UT Excuted {nameof(RegexTest)}_{nameof(正则校验邮箱格式2_更健壮)}");
      var email1 = IsValidMailbox2("scQcxx_@KFCcd.cn");
      var email2 = IsValidMailbox2("qqvv@a.GTA-CSSD.com");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    private static readonly string EmailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))"+
                                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z\-]+\.)+[a-zA-Z]{2,}))$";

    public static bool IsValidMailbox2(string email) {
      if(string.IsNullOrWhiteSpace(email)) {
        return false; // 如果邮箱为空或仅包含空白字符，则直接返回false  
      }
      // 使用Regex类的IsMatch方法验证邮箱格式  
      return Regex.IsMatch(email, EmailPattern, RegexOptions.IgnoreCase);
    }

    [Test]
    public void 正则校验邮箱格式3() {

      System.Console.WriteLine(@$"UT Excuted {nameof(RegexTest)}_{nameof(正则校验邮箱格式3)}");

      string[] testEmails = { "example@example.com", "invalid-email", "another.valid+email@example.co.uk", "user@[IPv6:2001:db8::1]", "bad-domain@.com" };
      foreach(string itemEmail in testEmails) {
        Console.WriteLine($"{itemEmail}: {(IsValidMailbox2(itemEmail) ? "Valid" : "Invalid")}");

      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
