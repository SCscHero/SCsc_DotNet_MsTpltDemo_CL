using System;

namespace CsLangVersion.Fdmts_SystemMethod
{
    public class SystemMethodTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void 方法nameof测试()
        {
            Console.WriteLine(nameof(方法nameof测试));
        }

        [Test]
        public void 方法typeof测试()
        {
            Console.WriteLine(typeof(int));
        }

        [Test]
        public void 方法sizeof测试()
        {
            Console.WriteLine($@"bool sizeof:{sizeof(bool)}");
            Console.WriteLine($@"sbyte sizeof:{sizeof(sbyte)}");
            Console.WriteLine($@"byte sizeof:{sizeof(byte)}");
            Console.WriteLine($@"char sizeof:{sizeof(char)}");
            Console.WriteLine($@"short sizeof:{sizeof(short)}");
            Console.WriteLine($@"ushort sizeof:{sizeof(ushort)}");
            Console.WriteLine($@"int sizeof:{sizeof(int)}");
            Console.WriteLine($@"uint sizeof:{sizeof(uint)}");
            Console.WriteLine($@"float sizeof:{sizeof(float)}");
            Console.WriteLine($@"double sizeof:{sizeof(double)}");
            Console.WriteLine($@"Int64 sizeof:{sizeof(long)}");
            Console.WriteLine($@"decimal sizeof:{sizeof(decimal)}");
        }
    }
}
