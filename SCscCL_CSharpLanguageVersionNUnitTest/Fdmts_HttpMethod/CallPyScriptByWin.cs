using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CsLangVersion.Fdmts_HttpMethod
{
	public class CallPyScriptByWin
	{
		[Test]
		public void RequestByPython()
		{
			var cmdArgs = "{'url':'" + "xxxx" + "'}";
			Process process = new Process();
			//py脚本地址
			string path = @"C:\Users\SCscHero\Python\Http\httpClient.py";
			//本地python安装路径/python.exe
			process.StartInfo.FileName = @"C:\LIST.ENV\env.006.Python_ALL\64bit_3.9.6\python.exe";
			//使用命令行调用py脚本 约定命令格式
			string sArguments = path;
			//sArguments += " " + cmdArgs;
			process.StartInfo.Arguments = sArguments;
			//process.StartInfo.UseShellExecute = false;
			//process.StartInfo.RedirectStandardOutput = true;
			//process.StartInfo.RedirectStandardInput = true;
			//process.StartInfo.RedirectStandardError = true;
			//process.StartInfo.CreateNoWindow = true;
			process.Start();
			StringBuilder stringBuilder = new StringBuilder();
			StreamReader streamReader = process.StandardOutput;
			while (!streamReader.EndOfStream)
			{
				stringBuilder.Append(streamReader.ReadLine());
			}
			process.WaitForExit();
			var result = stringBuilder.ToString();
            Console.WriteLine(result);
		}
	}
}
