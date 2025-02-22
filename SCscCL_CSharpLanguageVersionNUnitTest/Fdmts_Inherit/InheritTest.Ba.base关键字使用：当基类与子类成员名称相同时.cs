using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Inherit {
    internal partial class InheritTest {
        class BaseClass {
            public int Value { get; set; }
        }

        class DerivedClass : BaseClass {
            new public int Value { get; set; }

            public void ShowBaseValue() {
                Console.WriteLine("Base Value: "+base.Value); // 访问基类的Value属性  
            }
        }


    }
}
