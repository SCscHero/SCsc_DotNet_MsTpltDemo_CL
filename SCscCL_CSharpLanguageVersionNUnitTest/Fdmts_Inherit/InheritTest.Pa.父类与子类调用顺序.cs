using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Inherit {
    internal partial class InheritTest {
        public class Parent {
            public int Value;
            // 父类的构造函数  
            public Parent(int value) {
                Value=value;
            }
        }

        public class Child : Parent {
            public string Name;
            // 子类的构造函数，显式调用父类的构造函数  
            public Child(string name, int value) : base(value) {
                Name=name;
            }
        }
        /// <summary>
        /// The order in which the parent class and the subclass are called
        /// </summary>
        [Test]
        public void 父类与子类调用顺序() {
            System.Console.WriteLine(@$"UT Excuted {nameof(InheritTest)}_{nameof(父类与子类调用顺序)}");
            var child = new Child("Hero",1);
            //调用顺序是先初始化父类，再初始化子类。
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }



    }
}
