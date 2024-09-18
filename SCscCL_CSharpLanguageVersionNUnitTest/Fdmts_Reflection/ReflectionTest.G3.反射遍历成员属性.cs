using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Reflection {
  /// <summary>
  /// 新建一个自定义特性
  /// </summary>
  [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property, AllowMultiple = true)]
  public class SCExcelCellAttibute : Attribute {
    public SCExcelCellAttibute(string CustomCategory) {
      _CustomCategory=CustomCategory;
    }
    protected string _CustomCategory;
    public string CustomCategory {
      get {
        return this._CustomCategory;
      }
    }

    public partial class ReflectionTest {
      [Test]
      public void 使用返回GetProperties遍历属性() {

        System.Console.WriteLine(@$"UT Excuted {nameof(ReflectionTest)}_{nameof(使用返回GetProperties遍历属性)}");
        var Obj = new { Region = "SC北区", DLR = 499, DynamicColumns = "6658", PartABC = 111, PartDEF = 222, Total = 333 };

        foreach(var item in Obj.GetType().GetProperties()) {
          Console.WriteLine(item.Name);
          Console.WriteLine(item.PropertyType.FullName);
          Console.WriteLine(item.PropertyType.Name);


        }
        System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
      }
    }
  }
}
