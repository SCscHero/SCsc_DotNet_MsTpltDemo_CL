using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Delegate {
    public partial class ActionTest {
        public class MyClassGenerics {
            public void ExecuteAction<T>(T parameter, Action<T> action) {
                // 执行传入的Action<T>委托  
                action?.Invoke(parameter);
            }
        }
        [Test]
        public void ExecuteAction_ShouldInvokeActionWithParameter() {
            // 定义一个Action<string>委托  
            Action<string> testAction = (param) =>
            {
                // 这里可以添加任何需要验证的逻辑  
                // 例如，我们可以将参数赋值给一个变量来检查它是否被正确传递  
                Assert.AreEqual("Hello, NUnit!", param, "The parameter was not passed correctly.");
            };

            // 创建MyClassGenerics的实例  
            MyClassGenerics myClass = new MyClassGenerics();

            // 调用ExecuteAction方法并传入testAction和一个字符串参数  
            myClass.ExecuteAction("Hello, NUnit!", testAction);

            // 注意：由于Assert在Action内部被调用，如果参数不正确，测试将立即失败，  
            // 并且不会执行到这一步。但是，为了保持测试的结构清晰，我们仍然保留这个步骤。  
            // 在实际测试中，你可能希望将验证逻辑放在Action外部，通过其他方式（如返回值或输出参数）来检查。  

            // 然而，在这个特定的例子中，由于Action内部已经包含了Assert，  
            // 并且测试框架会捕获并报告这些断言的结果，所以我们不需要额外的验证步骤。  
        }
    }
}
