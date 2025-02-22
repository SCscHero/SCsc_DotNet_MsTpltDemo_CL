using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_ExpressionLambda {
    public partial class LinqTest {
        public class A {
            public Dictionary<string, int>[] Dictionaries { get; set; }
        }

        // 示例数据
        List<A> listOfA = new List<A>
        {
            new A
            {
                Dictionaries = new Dictionary<string, int>[]
                {
                    new Dictionary<string, int> { { "a", 1 }, { "b", 2 } },
                    new Dictionary<string, int> { { "c", 3 } }
                }
            },
            new A
            {
                Dictionaries = new Dictionary<string, int>[]
                {
                    new Dictionary<string, int> { { "x", 4 }, { "y", 5 } },
                    new Dictionary<string, int> { { "z", 6 } }
                }
            }
        };
        [Test]
        public void 字典数组Sum() {
            System.Console.WriteLine(@$"UT Excuted {nameof(LinqTest)}_{nameof(字典数组Sum)}");
            // 使用LINQ计算总和
            int totalSum = listOfA
                .SelectMany(a => a.Dictionaries)        // 将所有的Dictionary展开为一个扁平的序列
                .SelectMany(dict => dict.Values)        // 将所有的Values展开为一个扁平的序列
                .Sum();                                 // 对所有值进行求和

            Console.WriteLine("Total Sum: "+totalSum); // 输出总和
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }


        public class A_Kv {
            public KeyValuePair<string, int> Kvp { get; set; }
        }


        List<A_Kv> listOfA1 = new List<A_Kv>
        {
            new A_Kv { Kvp = new KeyValuePair<string, int>("key1", 10) },
            new A_Kv { Kvp = new KeyValuePair<string, int>("key2", 20) },
            new A_Kv { Kvp = new KeyValuePair<string, int>("key3", 30) }
        };

        [Test]
        public void 字典元素求值() {

            System.Console.WriteLine(@$"UT Excuted {nameof(LinqTest)}_{nameof(字典元素求值)}");
            var sumVal = listOfA1.Select(r => r.Kvp).Sum(r1 => r1.Value);
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }


    }
}
