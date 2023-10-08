using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CsLangVersion.Fdmts_PrimitiveType
{
	internal class MemoryStreamTest
	{
		[Test]
		public void MemoryStreamTest通过构造函数将String转换成Stream类型()
		{
			string jsonStrSimple = "{\"msg\":\"failed！\"}";
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonStrSimple));

		}
		private class Eq050_Student
		{
			public int StudentId { get; set; }
			public string StudentName { get; set; }
			public string ClassName { get; set; }
			public override string ToString()
			{
				return StudentId + ";" + StudentName + ";" + ClassName;
			}
		}

		/// <summary>
		/// https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide#preferred-alternatives
		/// </summary>
		public void Eq050_废弃_通过BF将字节数组转换为对象()
		{
			Eq050_Student student = new Eq050_Student()
			{
				StudentId = 10001,
				StudentName = "小华",
				ClassName = "软件一班"
			};
            //.Net8·SYSLIB0011:'BinaryFormatter' is obsolete: 'BinaryFormatter serialization is obsolete and should not be used. See https://aka.ms/binaryformatter for more information.' 
            //BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream();
			//SYSLIB0011:“BinaryFormatter。Serialize(Stream, object)'已过时:'BinaryFormatter序列化已过时，不应使用。更多信息请参见https://aka.ms/binaryformatter。
			//serializer.Serialize(memStream, student);

			memStream.Close();

			string info = Encoding.Unicode.GetString(memStream.ToArray());

			Console.WriteLine("二进制序列化结果：");

			Console.WriteLine(Environment.NewLine);

			Console.WriteLine(info);

			Console.WriteLine(Environment.NewLine);

		}

	}
}
