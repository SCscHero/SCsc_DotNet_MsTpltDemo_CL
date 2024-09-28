using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SystemMethod._Text.RegularExpressions {
  partial class RegexTest {
    [Test]
    public void 正则判断是否存在非法字符1() {

      System.Console.WriteLine(@$"UT Excuted {nameof(RegexTest)}_{nameof(正则判断是否存在非法字符1)}");
      Regex regex校验是否存在非法字符 = new Regex("[^\u4e00-\u9fa5a-zA-Z0-9 ，, : ：' a\nb]");
      MatchCollection resMatches = regex校验是否存在非法字符.Matches("SCscHero、SCscCN");
      if(resMatches.Count>0)
        Assert.Pass();
      else
        Assert.Fail();
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
