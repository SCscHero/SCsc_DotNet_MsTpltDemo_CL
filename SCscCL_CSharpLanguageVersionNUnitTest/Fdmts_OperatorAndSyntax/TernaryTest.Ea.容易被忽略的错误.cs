using Aspose.Cells.Rendering;
using System;

namespace CsLangVersion.Fdmts_Operator {
  internal partial class TernaryTest {
    public class School {
      public HeadTeacher headTeacher { get; set; }
    }
    public class HeadTeacher {
      public string Name { get; set; }
    }
    [Test]
    public void 字符串拼接And三目运算符判断Object为NULL的错误() {

      var school = new School();
      var formatStr = @"PrintResult="+school.headTeacher==null ? string.Empty : school.headTeacher.Name;
      Console.WriteLine();

    }
  }
}
