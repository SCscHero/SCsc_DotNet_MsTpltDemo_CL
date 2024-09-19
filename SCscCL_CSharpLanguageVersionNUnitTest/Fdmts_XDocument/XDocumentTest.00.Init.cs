using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsLangVersion.Fdmts_XDocument {
  public partial class XDocumentTest {
    [Test]
    public void SimplestXmlTree() {

      System.Console.WriteLine(@$"UT Excuted {nameof(XDocumentTest)}_{nameof(SimplestXmlTree)}");
      // 创建一个XDocument实例，它代表整个XML文档  
      XDocument doc = new XDocument(
          // 创建一个XDeclaration实例，指定XML版本、编码和独立状态  
          new XDeclaration("1.0", "utf-8", "yes"),
          // 创建一个XElement实例作为根元素  
          new XElement("Books",
              // 添加子元素  
              new XElement("Book",
                  new XAttribute("ID", "1"), // 添加属性  
                  new XElement("Title", "C# Programming"),
                  new XElement("Author", "SCscHero"),
                  new XElement("Year", "2023")
              ),
              // 可以继续添加更多的Book元素  
              new XElement("Book",
                  new XAttribute("ID", "2"),
                  new XElement("Title", "XML Fundamentals"),
                  new XElement("Author", "SCscHero"),
                  new XElement("Year", "2022")
              )
          )
      );

      // 将构建的XML树保存到控制台  
      Console.WriteLine(doc.ToString());

      // 也可以将XML保存到文件  
      // doc.Save("Books.xml");  

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
