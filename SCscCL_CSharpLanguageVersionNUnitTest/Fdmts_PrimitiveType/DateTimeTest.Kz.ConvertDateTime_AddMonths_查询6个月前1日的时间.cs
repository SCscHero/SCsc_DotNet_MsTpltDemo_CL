using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType
{
  internal partial class DateTimeTest
  {
    [Test]
    public void 转换_AddMonths计算六个月前1日()
    {
      int Monthts = -5;
      var StartTime = Convert.ToDateTime($"{DateTime.Now.AddMonths(-1).Year}/{DateTime.Now.AddMonths(-1).Month}/01");
      var time = StartTime.AddMonths(Monthts);

      if (!string.IsNullOrWhiteSpace("-5") && int.TryParse("-5", out Monthts) && Monthts < 0)
        time = StartTime.AddMonths(Monthts);
      Console.WriteLine(nameof(StartTime) + StartTime);
      Console.WriteLine(nameof(time) + time);
    }



  }
}
