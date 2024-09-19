using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType {
  internal partial class DateTimeTest {
    [Test]
    public void ValueProperty() {
      DateTime? dt = null;
      Console.WriteLine(dt.Value.Year);//throw exception
      Console.WriteLine(dt.Value.Month);
      Console.WriteLine();
      /*
Run-time exception (line 8): Nullable object must have a value.

Stack Trace:

[System.InvalidOperationException: Nullable object must have a value.]
   at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
   at System.Nullable`1.get_Value()
   at Program.Main() :line 8
       */

    }

    [Test]
    public void ValuePropertyIfOrJudge() {
      DateTime? dt = null;
      //以下if判断不会抛出异常，因为在第一个条件已经为true了，不会走到第二个条件
      if(dt==null||dt.Value.Year!=2024) {

      }

    }
  }
}
