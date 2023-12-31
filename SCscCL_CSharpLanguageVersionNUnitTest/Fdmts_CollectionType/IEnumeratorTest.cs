using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType
{
	internal class IEnumeratorTest
	{
		//【Ref】https://www.cnblogs.com/eve612/p/13628231.html
		[Test]
		public void IEnumerator_可以同时遍历多个集合并且节省内存用完一个释放一个()
		{

		}

		[Test]
		public void IEnumerator_使用示例()
		{
			List<int> intList = new List<int>();
			for (int i = 0; i < 10; i++)
			{
				intList.Add(Get());
			}

			int Get()
			{
				Thread.Sleep(1000);
				return DateTime.Now.Second;
			}

			IEnumerator GetEnumerator()
			{
				for (int i = 0; i < intList.Count(); i++)
				{
					yield return intList[i];
				}
			}
		}
	}
}
