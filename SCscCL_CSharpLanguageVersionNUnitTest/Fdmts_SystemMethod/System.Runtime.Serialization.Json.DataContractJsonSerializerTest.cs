using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CsLangVersion.Fdmts_SystemMethod
{
	internal partial class SystemMethodTest
	{

		[DataContract]
		private class Person
		{
			[DataMember]
			internal string name;

			[DataMember]
			internal int age;
		}
		/// <summary>
		/// 参考链接：https://learn.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
		/// 这种方式更安全：https://learn.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide#preferred-alternatives
		/// </summary>
		[Test]
		public void UseDataContractJsonSerializer_序列化()
		{
			var p = new Person();
			p.name = "John";
			p.age = 42;

			var stream1 = new MemoryStream();
			var ser = new DataContractJsonSerializer(typeof(Person));

			ser.WriteObject(stream1, p);

			stream1.Position = 0;
			var sr = new StreamReader(stream1);
			Console.Write("JSON form of Person object: ");
			Console.WriteLine(sr.ReadToEnd());
		}

		/// <summary>
		/// 参考链接：https://learn.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data
		/// </summary>
		[Test]
		public void UseDataContractJsonSerializer_反序列化()
		{
			var p = new Person();
			p.name = "John";
			p.age = 42;

			var stream1 = new MemoryStream();
			var ser = new DataContractJsonSerializer(typeof(Person));

			ser.WriteObject(stream1, p);

			stream1.Position = 0;
			var p2 = (Person)ser.ReadObject(stream1);

			Console.WriteLine($"Deserialized back, got name={p2.name}, age={p2.age}");
		}
	}
}
