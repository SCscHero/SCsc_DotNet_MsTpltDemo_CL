using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType {
  internal partial class stringTest {

    [Test]
    public void string_format方法的应用() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(string_format方法的应用)}");
      // 定义一个名字  
      string name = "张三";

      // 定义一个年龄  
      int age = 30;

      // 使用 string.Format 创建一个格式化的字符串  
      string greeting = string.Format("你好，{0}！你今年{1}岁了。", name, age);

      // 打印结果  
      Console.WriteLine(greeting);

      // 你也可以使用命名的参数占位符（C# 6.0 及以上版本）  
      // 注意：这要求使用插值字符串语法（$""），而不是 string.Format  
      // 但为了展示效果，这里仍使用 string.Format 的另一种形式  
      //string greetingWithNamedPlaceholders = string.Format(
      //    "你好，{name}！你今年{age}岁了。其中，{name}代表你的名字，{age}代表你的年龄。",
      //    name: name,
      //    age: age);
      // 打印使用命名参数占位符的结果  
      //Console.WriteLine(greetingWithNamedPlaceholders);

      // 注意：上述使用命名参数的方式在 string.Format 中并不是标准的，  
      // 而是为了说明如何在其他上下文中（如日志记录库）使用命名参数占位符。  
      // 在标准的 string.Format 中，你应该像第一个示例那样使用 {0}, {1} 等占位符。  

      // 对于标准的 string.Format，如果你想要更清晰的代码，  
      // 可以考虑使用索引而不是位置（虽然这并不会改变执行效率）  
      string greetingWithIndexes = string.Format(
          "你好，{1}！你今年{0}岁了。这里的{0}是年龄，{1}是名字。", age, name);

      // 注意：这里的索引是颠倒的，只是为了展示索引的用法  
      // 实际上，这样做可能会让代码更难理解  
      Console.WriteLine(greetingWithIndexes);
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    const string PrintLog = "{0}_to_Retrieve_Cesar_Token StatusCode {1} {2}";
    [Test]
    public void string_formatAndConst() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(string_formatAndConst)}");
      var statusCode = 200;
      var guid = Guid.NewGuid();
      Console.WriteLine(string.Format(PrintLog, statusCode==200 ? "Success" : "Failed", statusCode, guid.ToString()));


      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
