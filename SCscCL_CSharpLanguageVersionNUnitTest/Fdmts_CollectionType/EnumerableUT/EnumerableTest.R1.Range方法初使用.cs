using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType.EnumerableUT {
    public partial class EnumerableTest {
        [Test]
        public void Range方法生成IPV4地址() {
            System.Console.WriteLine(@$"UT Excuted {nameof(EnumerableTest)}_{nameof(Range方法生成IPV4地址)}");

            var origins = Enumerable.Range(1, 256)
                        .SelectMany(i => Enumerable.Range(1, 256)
                        .Select(j => $"http://192.168.{i}.{j}:24578"))
                        .ToArray();

            Assert.IsTrue(origins.Count()==65536);
            System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
        }

    }
}
