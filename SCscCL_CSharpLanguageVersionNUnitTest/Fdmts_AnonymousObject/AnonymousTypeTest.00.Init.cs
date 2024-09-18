using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_AnonymousObject {
  internal partial class AnonymousTypeTest {
    [Test]
    public void 转换Table() {

      System.Console.WriteLine(@$"UT Excuted {nameof(AnonymousTypeTest)}_{nameof(转换Table)}");
      List<object> listObject = new List<object>();
      listObject.Add(new { Region = "SC北区", DLR = 499, DynamicColumns = "6658", PartABC = 111, PartDEF = 222, Total = 333 });
      listObject.Add(new { Region = "SC西区", DLR = 429, DynamicColumns = "6228", PartABC = 333, PartDEF = 444, Total = 777 });
      DataTable dt = ToDataTable(listObject);
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


    /// <summary>
    /// 利用反射将List<object>转换成DataTable
    /// </summary>
    /// <param name="list">泛类型集合</param>
    /// <returns></returns>
    public static DataTable ToDataTable<T>(List<T> entitys, string tableName = "")
        where T : class {
      int notExportLength = 0;
      var entityType = typeof(T) is object&&entitys.Any() ? entitys[0].GetType() : typeof(T);
      PropertyInfo[] entityProperties = entityType.GetProperties();
      int dynamicLength = 0;
      DataTable dt = new DataTable();
      if(!string.IsNullOrEmpty(tableName)) {
        dt.TableName=tableName;
      }
      for(int i = 0; i<entityProperties.Length; i++) {
        dt.Columns.Add(entityProperties[i].Name);
        if(entityProperties[i].Name=="DynamicColumns") {
          if(entitys==null||entitys.Count<1) {
            continue;
          }
          var dic = (Dictionary<string, int>)entityProperties[i].GetValue(entitys[0]);
          if(dic!=null&&dic.Count>0) {
            foreach(var key in dic.Keys) {
              dt.Columns.Add(key);
              dynamicLength++;
            }
          } else {
            dynamicLength--;
          }
        }
      }
      foreach(object entity in entitys) {
        int count = 0;
        if(entity.GetType()!=entityType) {
          throw new Exception("要转换的集合元素类型不一致");
        }
        object[] entityValues = new object[entityProperties.Length+dynamicLength-notExportLength];
        for(int i = 0; i<entityProperties.Length; i++) {
          if(entityProperties[i].Name=="DynamicColumns") {
            var dic = (Dictionary<string, int>)entityProperties[i].GetValue(entity, null);
            if(dic!=null&&dic.Count>0) {
              int total = dic.Keys.Count;
              foreach(var key in dic.Keys) {
                entityValues[i+count]=dic[key];
                if(count<total-1)
                  count++;
              }
            } else {
              count--;
            }
          } else {
            entityValues[i+count]=entityProperties[i].GetValue(entity, null);
          }

        }
        dt.Rows.Add(entityValues);
      }
      return dt;
    }

  }
}
