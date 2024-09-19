using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  internal partial class switchSyntax {
    private enum HeroLevel {
      Lv1, Lv2, Lv3, Lv4, Cribber = 999
    }

    private HeroLevel JudgeLevel(int judgeInt) {
      switch (judgeInt) {
        case 0:
          return HeroLevel.Lv1;
        case 1:
          return HeroLevel.Lv2;
        case 2:
          return HeroLevel.Lv3;
        case 3:
          return HeroLevel.Lv4;
        default:
          return HeroLevel.Cribber;
      }
    }

    [Test]
    public void Switch_Enum_结合枚举1() {

      System.Console.WriteLine(@$"UT Excuted {nameof(switchSyntax)}_{nameof(Switch_Enum_结合枚举1)}");
      
      Assert.IsTrue(JudgeLevel(3)==HeroLevel.Lv4);
      Assert.IsTrue(JudgeLevel(2) == HeroLevel.Lv3);
      Assert.IsTrue(JudgeLevel(30) == HeroLevel.Cribber);
      Assert.IsFalse(JudgeLevel(1) == HeroLevel.Cribber);

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
