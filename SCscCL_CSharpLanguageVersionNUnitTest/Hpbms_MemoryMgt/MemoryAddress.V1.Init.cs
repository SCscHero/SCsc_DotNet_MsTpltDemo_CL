using System;

namespace CsLangVersion.Hpbms_MemoryMgt {
  public partial class MemoryAddress {
    [Test]
    public static void PrintMemoryAddress_打印内存地址() {

      System.Console.WriteLine(@$"UT Excuted {nameof(MemoryAddress)}_{nameof(PrintMemoryAddress_打印内存地址)}");

      // 允许在Main方法中使用不安全代码  
      unsafe {
        MyClass obj = new MyClass();

        // 获取对象在内存中的地址  
        TypedReference tr = __makeref(obj);
        IntPtr ptr = **(IntPtr**)(&tr);

        // 输出地址（注意：这可能会因平台和运行时版本而异）  
        Console.WriteLine("Memory address of obj: " + ptr.ToString("X"));

        var obj2 = obj;//新创建一个对象指向obj，由于引用类型赋值是 指向的地址，因此理论上是相等的；
        TypedReference tr1 = __makeref(obj);
        IntPtr ptr1 = **(IntPtr**)(&tr);
        Console.WriteLine("Memory address of obj: " + ptr1.ToString("X"));
        Console.WriteLine(ptr1.ToString() == ptr.ToString());
      }

      System.Console.WriteLine(@$"Finished local time is {System.DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
