using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType {
  public partial class DictionaryTest {
    [Test]
    public void Dictionary声明及赋值1() {

      System.Console.WriteLine(@$"UT Excuted {nameof(DictionaryTest)}_{nameof(Dictionary声明及赋值1)}");
      Dictionary<string, string> optionsDic = new Dictionary<string, string>();
      optionsDic.Add("client_id", "client_idTest");
      optionsDic.Add("client_secret", "client_secretTest");
      optionsDic.Add("grant_type", "authorization_codeTest");
      optionsDic.Add("code", "codeTest");
      // 或者使用索引器添加
      optionsDic["code222"]="codeTest222";
      //使用TryAdd尝试添加，如果键不存在则添加
      optionsDic.TryAdd("code222", "codeTest333");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    [Test]
    public void Dictionary声明及赋值2() {

      System.Console.WriteLine(@$"UT Excuted {nameof(DictionaryTest)}_{nameof(Dictionary声明及赋值2)}");
      // 声明并初始化带有初始值的字典
      Dictionary<string, int> myDictionary = new Dictionary<string, int>
      {
      { "apple", 1 },
      { "banana", 2 },
      { "cherry", 3 }
     };
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    [Test]
    public void Dictionary声明及赋值3() {

      System.Console.WriteLine(@$"UT Excuted {nameof(DictionaryTest)}_{nameof(Dictionary声明及赋值3)}");
      // 使用集合初始化器初始化字典
      var myDictionary = new Dictionary<string, int> {
        ["apple"]=1,
        ["banana"]=2,
        ["cherry"]=3
      };
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
