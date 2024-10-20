using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType.SystemCollectionsGeneric {
  public partial class SortedDictionaryTest {
    [Test]
    public void 初使用_自动按照Key排序() {
      System.Console.WriteLine(@$"UT Excuted {nameof(SortedDictionaryTest)}_{nameof(初使用_自动按照Key排序)}");
      // 创建一个 SortedDictionary，它会自动按键排序  
      SortedDictionary<string, int> sortedDict = new SortedDictionary<string, int>
      {
            { "apple", 1 },
            { "orange", 2 },
            { "banana", 3 },
            { "grape", 4 }
        };

      // 打印排序后的键值对（实际上是按插入顺序打印的，但 SortedDictionary 保证按键排序）  
      foreach(var kvp in sortedDict) {
        Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
