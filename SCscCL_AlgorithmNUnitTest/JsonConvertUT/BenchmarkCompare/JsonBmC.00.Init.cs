using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.JsonConvertUT.BenchmarkCompare {
  internal partial class JsonBmC {
    [Test]
    public void MethodDesc() {

      System.Console.WriteLine(@$"UT Excuted {nameof(JsonBmC)}_{nameof(MethodDesc)}");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
