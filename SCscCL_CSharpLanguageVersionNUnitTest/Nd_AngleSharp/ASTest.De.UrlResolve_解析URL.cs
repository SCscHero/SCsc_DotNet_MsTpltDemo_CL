using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Nd_AngleSharp {
  public partial class ASTest {
    /// <summary>
    /// C#使用AngleSharp解析https://visualstudio.microsoft.com/zh-hans/downloads/地址，再根据CSS选择器字符串寻找到某a标签，解析其href属性值。
    /// </summary>
    [Test]
    public async Task 根据CSS选择题解析元素属性() {

      System.Console.WriteLine(@$"UT Excuted {nameof(ASTest)}_{nameof(根据CSS选择题解析元素属性)}");
      string url = "https://visualstudio.microsoft.com/zh-hans/downloads/";
      // 使用 HttpClient 获取网页内容
      using(HttpClient client = new HttpClient()) {
        try {
          // 发送 HTTP GET 请求获取网页内容
          HttpResponseMessage response = await client.GetAsync(url);
          if(response.IsSuccessStatusCode) {
            // 读取响应内容
            string htmlContent = await response.Content.ReadAsStringAsync();
            // 创建 HTML 解析器
            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(htmlContent);

            // 使用 CSS 选择器查找 <a> 标签
            // 请根据实际页面结构调整 CSS 选择器
            var aTag = document.QuerySelector("#dotnet > div > div.fusion-builder-row.fusion-builder-row-inner.fusion-row.fusion-flex-align-items-flex-start.fusion-flex-content-wrap > div > div > div > div.fusion-column.content-box-column.reveal.content-box-column-1.col-lg-4.col-md-4.col-sm-4.fusion-content-box-hover.content-box-column-first-in-row.active > div > div.content-container > div > a");

            if(aTag!=null) {
              // 提取 href 属性值
              string href = aTag.GetAttribute("href");
              Console.WriteLine($"找到的链接: {href}");

              // 如果是相对路径，构建完整 URL
              if(Uri.IsWellFormedUriString(href, UriKind.Relative)) {
                Uri baseUri = new Uri(url);
                Uri fullUrl = new Uri(baseUri, href);
                href=fullUrl.ToString();
                Console.WriteLine($"完整链接: {href}");
              }
            } else {
              Console.WriteLine("未找到指定的 <a> 标签，请检查 CSS 选择器。");
            }
          } else {
            Console.WriteLine($"请求失败，状态码: {response.StatusCode}");
          }
        } catch(Exception ex) {
          Console.WriteLine($"发生错误: {ex.Message}");
        }
      }
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
