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

  }
}
