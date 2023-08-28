using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType
{
    internal class IQueryableTest
    {
        [Test]
        public void IQueryable_使用示例()
        {
            IQueryable<int> _IntList = null;
            int Get()
            {
                Thread.Sleep(1000);
                return DateTime.Now.Second;
            }
            IEnumerator GetEnumerator()
            {
                for (int i = 0; i < 10; i++)
                {
                    yield return Get();
                }
            }
        }
    }
}
