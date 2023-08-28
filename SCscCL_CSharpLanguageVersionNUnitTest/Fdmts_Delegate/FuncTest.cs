using System;

namespace CsLangVersion.Fdmts_Delegate
{
    internal class FuncTest
    {
        [Test]
        public void UseFunc_实例化委托并执行()
        {
            //Func<int, int, int> func = new Func<int, int, int>((m, n) => m * n + 2); 
            Func<int, int, int> func = (m, n) => m * n + 2;
            int res = func.Invoke(1, 2);
            Console.WriteLine("Result:" + res);

        }


    }
}
