using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  public partial class lockSyntax {

    private static object GetStaticObj(int paramInt) {
      switch (paramInt) {
        case 0:
          return lock0;
        case 1:
          return lock1;
        case 2:
          return lock2;
        case 3:
          return lock3;
        case 4:
          return lock4;
        case 5:
          return lock5;
        default:
          return lockOther;
      }
    }

    private static async Task LongRunningOperationAsyncByDiffLockObj(int milliseconds, int paramInt) {
      var getLockObj = GetStaticObj(paramInt);
      lock (getLockObj) {
        Console.WriteLine("线路" + paramInt + "执行开始；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
        Thread.Sleep(milliseconds);
        Console.WriteLine("线路" + paramInt + "执行完毕；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
      }
      Console.WriteLine("我是锁外面的，线路" + paramInt + "；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
    }

    [Test]
    public async Task 根据Int值获取静态Object() {

      System.Console.WriteLine(@$"UT Excuted {nameof(lockSyntax)}_{nameof(根据Int值获取静态Object)}");
      
      Task task1 = LongRunningOperationAsyncByDiffLockObj(100,2);
      Task task2 = LongRunningOperationAsyncByDiffLockObj(100,2);
      Task task3 = LongRunningOperationAsyncByDiffLockObj(100,1);
      Task task4 = LongRunningOperationAsyncByDiffLockObj(1000,1);
      Task task5 = LongRunningOperationAsyncByDiffLockObj(50, 2);
      await Task.WhenAll(task1,task2, task3, task4, task5);

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
