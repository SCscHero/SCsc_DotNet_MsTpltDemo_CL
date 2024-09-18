using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsLangVersion.Fdmts_Reflection {
  partial class ReflectionTest {
    [Test]
    public void 解析复杂结构的对象() {
      System.Console.WriteLine(@$"UT Excuted {nameof(ReflectionTest)}_{nameof(解析复杂结构的对象)}");
      List<object> summaryListObj = new List<object>();
      List<object> detailListObj = new List<object>();

      List<List<object>> dataList = new List<List<object>>();
      dataList.Add(summaryListObj);
      dataList.Add(detailListObj);
      summaryListObj.Add(new {
        Code = "SC-01",
        Wallets = new Dictionary<string, int>() { { "Wallet1", 1000 }, { "Wallet2", 1500 }, { "Wallet3", 2000 } },
        MoneyTotal = 4500
      });
      detailListObj.Add(new {
        Code = "SC-20",
        Wallets = new Dictionary<string, int>() { { "Wallet1", 1200 }, { "Wallet2", 1250 }, { "Wallet3", 50 } },
        MoneyTotal = 3500
      });
      var summaryDt = ComplexClassToDataTable(summaryListObj);
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    private static DataTable ComplexClassToDataTable<T>(List<T> entitys, string tableName = "")
        where T : class {
      DataTable dtRes = new DataTable();
      var entityType = typeof(T) is object&&entitys.Any() ? entitys[0].GetType() : typeof(T);
      PropertyInfo[] entityProperties = entityType.GetProperties();
      int dynamicLength = 0;

      if(!string.IsNullOrEmpty(tableName)) {
        dtRes.TableName=tableName;
      }
      for(int i = 0; i<entityProperties.Length; i++) {
        Console.WriteLine(entityProperties[i].PropertyType);

        if(!(entityProperties[i].Name =="Wallets")) {
          dtRes.Columns.Add(entityProperties[i].Name);
        }
        if(entityProperties[i].Name=="Wallets") {
          var dic = (Dictionary<string, int>)entityProperties[i].GetValue(entitys[0]);
          if(dic!=null&&dic.Count>0) {
            foreach(var key in dic.Keys) {
              dtRes.Columns.Add(key);
              dynamicLength++;
            }
          }
        }
      }
      foreach(object entity in entitys) {
        int objIdx = 0;

        object[] entityValues = new object[entityProperties.Length+dynamicLength-1];
        for(int i = 0; i<entityProperties.Length; i++) {
          if(entityProperties[i].Name=="Wallets") {
            var dic = (Dictionary<string, int>)entityProperties[i].GetValue(entity, null);
            if(dic!=null&&dic.Count>0) {
              int total = dic.Keys.Count;
              foreach(var key in dic.Keys) {
                entityValues[i+objIdx]=dic[key];
                if(objIdx<total-1)
                  objIdx++;
              }
            } else {
              objIdx--;
            }
          } else {
            entityValues[i+objIdx]=entityProperties[i].GetValue(entity, null);
          }
        }
        dtRes.Rows.Add(entityValues);
      }
      return dtRes;
    }


  }
}
