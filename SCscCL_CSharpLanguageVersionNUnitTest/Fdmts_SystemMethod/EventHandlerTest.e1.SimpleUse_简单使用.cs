using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SystemMethod {
  partial class EventHandlerTest {
    [Test]
    public void DefineEventInPublisher() {
      System.Console.WriteLine(@$"UT Excuted {nameof(EventHandlerTest)}_{nameof(DefineEventInPublisher)}");
      // 创建Publisher实例  
      Publisher publisher = new Publisher();
      // 创建Subscriber实例，并传入Publisher实例，这样Subscriber就会订阅Publisher的事件  
      Subscriber subscriber = new Subscriber(publisher);
      // 调用Publisher的方法，该方法会触发事件  
      publisher.DoSomething();
      // 保持控制台开启，以便查看输出结果  
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }
  }
}