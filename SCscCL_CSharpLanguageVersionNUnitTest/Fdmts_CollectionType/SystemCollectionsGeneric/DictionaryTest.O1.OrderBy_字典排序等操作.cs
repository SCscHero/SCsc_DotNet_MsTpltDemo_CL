using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType {
  public partial class DictionaryTest {

    [Test]
    public void 字典排序方法() {
      System.Console.WriteLine(@$"UT Excuted {nameof(DictionaryTest)}_{nameof(字典排序方法)}");
      Dictionary<string, int> dict = new Dictionary<string, int>{
            { "apple", 1 },
            { "orange", 2 },
            { "banana", 3 },
            { "grape", 4 }
        };
      // 使用 LINQ 按键排序  
      var sortedDict = dict.OrderBy(kvp => kvp.Key).ToList();

      // 打印排序后的键值对  
      foreach(var kvp in sortedDict) {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
      }

      var sortedDict2 = dict.OrderBy(kvp => kvp.Key)
                                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

      // 打印排序后的键值对  
      foreach(var kvp in sortedDict2) {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
