using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_SystemMethod {
 

  partial class EventHandlerTest {

    public class Publisher {
      // 定义一个事件  
      public event EventHandler MyEvent;

      // 一个方法来触发事件  
      protected virtual void OnMyEvent() {
        MyEvent?.Invoke(this, EventArgs.Empty); // 使用?.操作符来安全地调用事件  
      }

      // 一个示例方法，当某些条件满足时触发事件  
      public void DoSomething() {
        Console.WriteLine("Doing something...");

        // 假设这里有一些逻辑，满足某个条件时触发事件  
        OnMyEvent(); // 触发事件  
      }
    }
    public class Subscriber {
      // 构造函数，接收一个Publisher实例，并订阅其事件  
      public Subscriber(Publisher publisher) {
        // 订阅事件  
        publisher.MyEvent+=MyEventHandler;
      }

      // 事件处理程序  
      private void MyEventHandler(object sender, EventArgs e) {
        Console.WriteLine("MyEvent was raised!");
      }
    }
  }
}