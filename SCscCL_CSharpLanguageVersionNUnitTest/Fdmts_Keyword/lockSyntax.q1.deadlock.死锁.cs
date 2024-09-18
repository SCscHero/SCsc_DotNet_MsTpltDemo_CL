using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword {
  public partial class lockSyntax {
    //For deadlock UT


    public static void Thread1() {
      lock (lock1) {
        Console.WriteLine("Thread 1: Locked lock1");
        Thread.Sleep(100); // 模拟一些工作  

        try {
          lock (lock2) {
            Console.WriteLine("Thread 1: Locked lock2");
          }
        } catch (Exception e) {
          Console.WriteLine("Thread 1: Exception - " + e.Message);
        }
      }
    }

    public static void Thread2() {
      lock (lock2) {
        Console.WriteLine("Thread 2: Locked lock2");
        Thread.Sleep(100); // 模拟一些工作  

        try {
          lock (lock1) {
            Console.WriteLine("Thread 2: Locked lock1");
          }
        } catch (Exception e) {
          Console.WriteLine("Thread 2: Exception - " + e.Message);
        }
      }
    }

    [Test]
		public void deadlock_死锁1() {
			System.Console.WriteLine(@$"UT Excuted {nameof(lockSyntax)}_{nameof(deadlock_死锁1)}");
      Thread t1 = new Thread(Thread1);
      Thread t2 = new Thread(Thread2);

      t1.Start();
      t2.Start();
      //在C#中，Thread.Join 方法用于阻塞当前线程，直到调用 Join 的线程完成执行为止。
      t1.Join();
      t2.Join();
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
		}


	}
}
