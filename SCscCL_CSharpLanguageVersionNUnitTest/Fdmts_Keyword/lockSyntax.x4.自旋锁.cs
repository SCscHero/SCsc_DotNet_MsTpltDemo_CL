using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  public partial class lockSyntax {
    private SpinLock _spinLock0 = new SpinLock();
    private SpinLock _spinLock1 = new SpinLock();
    private SpinLock _spinLock2 = new SpinLock();
    private SpinLock _spinLockOther = new SpinLock();

    private async Task LongOperationAsyncByDiffLockBool(int milliseconds, int paramInt) {
      var getLockBool = GetStaticBool(paramInt);
      var getSpinLock = GetStaticSpinLock(paramInt);

      getSpinLock.Enter(ref getLockBool);

      Console.WriteLine("线路" + paramInt + "执行开始；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
      Thread.Sleep(milliseconds);
      Console.WriteLine("线路" + paramInt + "执行完毕；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
      if (getLockBool)
        getSpinLock.Exit();
      Console.WriteLine("我是锁外面的，线路" + paramInt + "；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
    }
    private SpinLock GetStaticSpinLock(int paramInt) {
      switch (paramInt) {
        case 0:
          return _spinLock0;
        case 1:
          return _spinLock1;
        case 2:
          return _spinLock2;
        default:
          return _spinLockOther;
      }
    }

    private static bool GetStaticBool(int paramInt) {
      switch (paramInt) {
        case 0:
          return lockBool0;
        case 1:
          return lockBool1;
        case 2:
          return lockBool2;
        default:
          return lockBoolOther;
      }
    }
    [Test]
    public async Task 条件自旋锁() {

      System.Console.WriteLine(@$"UT Excuted {nameof(lockSyntax)}_{nameof(根据Int值获取静态Object)}");

      Task task1 = LongOperationAsyncByDiffLockBool(100, 2);
      Task task2 = LongOperationAsyncByDiffLockBool(100, 2);
      Task task3 = LongOperationAsyncByDiffLockBool(100, 1);
      Task task4 = LongOperationAsyncByDiffLockBool(1000, 1);
      Task task5 = LongOperationAsyncByDiffLockBool(50, 2);
      await Task.WhenAll(task1, task2, task3, task4, task5);

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }



    private async Task LongOperationAsyncByDiffObj(int milliseconds, int paramInt) {
      var getLockBool = GetStaticBool(paramInt);
      var getLockObj = GetStaticObj(paramInt);

      Monitor.Enter(getLockObj);
      try {
        Console.WriteLine("线路" + paramInt + "执行开始；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
        Thread.Sleep(milliseconds);
        Console.WriteLine("线路" + paramInt + "执行完毕；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");
      } finally {
        Monitor.Exit(getLockObj);
      }
      Console.WriteLine("我是锁外面的，线路" + paramInt + "；现在是" + stopwatch.ElapsedMilliseconds + "毫秒");

    }
    [Test]
    public async Task 其他方式实现() {
      System.Console.WriteLine(@$"UT Excuted {nameof(lockSyntax)}_{nameof(根据Int值获取静态Object)}");

      Task task1 = LongOperationAsyncByDiffObj(100, 2);
      Task task2 = LongOperationAsyncByDiffObj(100, 2);
      Task task3 = LongOperationAsyncByDiffObj(100, 1);
      Task task4 = LongOperationAsyncByDiffObj(1000, 1);
      Task task5 = LongOperationAsyncByDiffObj(50, 2);
      await Task.WhenAll(task1, task2, task3, task4, task5);

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");

    }
  }
}
