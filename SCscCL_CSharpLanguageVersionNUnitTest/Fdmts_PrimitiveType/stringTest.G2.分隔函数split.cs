using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CsLangVersion.Fdmts_PrimitiveType {
  internal partial class stringTest {
    [Test]
    public void split函数分隔不含分隔符的string () {
      var emailTos = "scschero@foxmail.com".Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
      foreach(var item in emailTos) {
        Console.WriteLine(item);
        //output:scschero@foxmail.com
      }
    }

    [Test]
    public void split分隔函数遍历结果集() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(split分隔函数遍历结果集)}");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
