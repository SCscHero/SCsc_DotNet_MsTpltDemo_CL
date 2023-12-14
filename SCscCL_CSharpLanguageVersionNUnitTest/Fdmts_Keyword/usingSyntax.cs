using System.IO;

namespace CsLangVersion.Fdmts_Keyword
{
	internal class usingSyntax
	{
		[Test]
		public void using等价写法()
		{

			using (var stream1 = new FileStream("file.txt", FileMode.Open))
			{

			}// 这里会自动调用stream.Close()方法
			 //⬇️⬇️⬆️⬆️“等价于”以下写法
			Stream stream2 = null;
			try
			{
				stream2 = new FileStream("file.txt", FileMode.Open);
				// 读取或写入文件操作  
			}
			finally
			{
				if (stream2 != null)
				{
					stream2.Close(); // 确保关闭流对象  
				}
			}
		}
	}
}
