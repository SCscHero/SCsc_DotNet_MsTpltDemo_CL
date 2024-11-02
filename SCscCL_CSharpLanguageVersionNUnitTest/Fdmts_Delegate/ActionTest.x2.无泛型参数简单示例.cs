using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Delegate {
    //Action委托是一种表示对无返回值且无参数的方法的引用的类型。
    internal partial class ActionTest {

        public class MyClass {
            public void ExecuteAction(Action action) {
                // 执行传入的Action委托  
                action?.Invoke();
            }
        }
        [Test]
        public void ExecuteAction_ShouldInvokeAction() {
            // 创建一个标记为已调用的标志  
            bool wasCalled = false;
            // 定义一个Action委托  
            Action testAction = () => wasCalled=true;
            // 创建MyClass的实例  
            MyClass myClass = new MyClass();
            // 调用ExecuteAction方法并传入testAction  
            myClass.ExecuteAction(testAction);
            // 验证testAction是否被调用  
            Assert.True(wasCalled, "The action was not called.");
        }
    }
}
