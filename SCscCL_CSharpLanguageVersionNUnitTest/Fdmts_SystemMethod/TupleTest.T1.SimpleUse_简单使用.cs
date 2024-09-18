using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SystemMethod {
  /// <summary>
  /// 🌈C#中元组使用代码示例
  /// 🤌
  /// </summary>
  partial class TupleTest {
    [Test]
    public void SimpleTuple_Csharp7Before() {
      System.Console.WriteLine(@$"UT Excuted {nameof(TupleTest)}_{nameof(SimpleTuple_Csharp7Before)}");
      var myTuple = Tuple.Create(1, "Hello", true);
      Console.WriteLine($"Item1: {myTuple.Item1}, Item2: {myTuple.Item2}, Item3: {myTuple.Item3}");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    [Test]
    public void SimpleTuple_Csharp7After() {
      System.Console.WriteLine(@$"UT Excuted {nameof(TupleTest)}_{nameof(SimpleTuple_Csharp7After)}");
      // 声明并初始化一个命名元组  
      var myTuple = (Id: 1, Message: "Hello", IsActive: true);

      // 访问元组中的元素  
      Console.WriteLine($"Id: {myTuple.Id}, Message: {myTuple.Message}, IsActive: {myTuple.IsActive}");

      // 还可以将元组解构成单独的变量  
      (int id, string message, bool isActive)=myTuple;
      Console.WriteLine($"Id: {id}, Message: {message}, IsActive: {isActive}");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
