using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  public partial class lockSyntax {
    [SetUp]
    public void Setup() {
      stopwatch.Start();
    }
    private static object lock0 = new object();
    private static object lock1 = new object();
    private static object lock2 = new object();
    private static object lock3 = new object();
    private static object lock4 = new object();
    private static object lock5 = new object();
    private static object lockOther = new object();
    private static Stopwatch stopwatch = new Stopwatch();

    private static bool lockBool0 = false;
    private static bool lockBool1 = false;
    private static bool lockBool2 = false;
    private static bool lockBoolOther = false;

    // 异步方法，模拟耗时操作  
    static async Task LongRunningOperationAsync(int milliseconds, string printContent) {
      // 使用Task.Delay来模拟耗时操作  
      // 注意：Task.Delay本身是一个异步操作，不会阻塞当前线程  
      await Task.Delay(milliseconds);

      // 在这里可以添加耗时操作完成后需要执行的代码  
      // 例如，处理返回的数据或更新UI等  
      Console.WriteLine($"该条线路执行完毕" + printContent);
    }
  }
}
