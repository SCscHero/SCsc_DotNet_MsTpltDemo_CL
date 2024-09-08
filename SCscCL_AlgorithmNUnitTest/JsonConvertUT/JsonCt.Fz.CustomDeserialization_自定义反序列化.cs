using Aplc4FileTransHp.NPOIHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SCscCL_AlgorithmNUnitTest.JsonConvertUT {
  internal partial class JsonCt {
    private class NonJsonClass1 { public string name { get; set; } };

    [Test]
    public void NonJsonProcessToJson() {
      System.Console.WriteLine(@$"UT Excuted {nameof(JsonCt)}_{nameof(NonJsonProcessToJson)}");
      //定义一个非标准JSON示例
      string nonStandardJson = "[{name=azureScwaf:managed:azureCS:core-rule-set:SCscRestrictions_XXXX}, {name=azureScwaf:managed:azureCS:Hql-database:SQLi_X1234}]";
      // 使用Replace方法替换非标准的格式  
      string standardJson = nonStandardJson.Replace("{name=", "{\"name\":\"").Replace("}]", "\"}]").Replace("},", "\"},");
      //当然这里有更好的方法，例如正则，这里用最简单粗暴的方式。
      // 替换后的字符串是有效的JSON，如果不是标准JSON是无法反序列化的；
      var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NonJsonClass1>>(standardJson);

      foreach(var item in result) {
        Console.WriteLine($"Name: {item.name}");
      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

    [Test]
    public void BatchNonJsonProcessToJson() {

      System.Console.WriteLine(@$"UT Excuted {nameof(JsonCt)}_{nameof(BatchNonJsonProcessToJson)}");
      var path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads\20240908_CustomFormat");
      var dt = NPOIExcelHp.ToDataTable(path, "规则去重", false);
      var stringHs = new HashSet<string>();
      foreach(DataRow row in dt.Rows) {
        string standardJson = row[0].ToString().Replace("{name=", "{\"name\":\"").Replace("}]", "\"}]").Replace("},", "\"},");
        //当然这里有更好的方法，例如正则，这里用最简单粗暴的方式。
        // 替换后的字符串是有效的JSON，如果不是标准JSON是无法反序列化的；
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NonJsonClass1>>(standardJson);
        foreach(NonJsonClass1 item in result) {
          stringHs.Add(item.name);
        }
      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
