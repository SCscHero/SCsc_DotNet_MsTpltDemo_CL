using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CsLangVersion.Fdmts_Keyword
{
	internal class staticSyntaxTest
	{
		public class SimpleClass
		{
			public SimpleClass(string setStatic)
			{
				staticProperty = setStatic;
			}
			public static string staticProperty = "staticProperty";
			public string nonStaticProperty1 = staticProperty;
			//public string nonStaticProperty2 = nonStaticProperty1;//A field initializer cannot reference the non-static field, method, or property 'staticSyntaxTest.SimpleClass.nonStaticProperty1'

			public string nonStaticProperty3 = "xxx";
			//public string nonStaticProperty4 = nonStaticProperty3;//A field initializer cannot reference the non-static field, method, or property 'staticSyntaxTest.SimpleClass.nonStaticProperty3'

			//【https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0236?f1url=%3FappId%3Droslyn%26k%3Dk(CS0236)】
			public int i = 5;
			// To fix the error, remove "= i", and uncomment the line in constructor.
			//public int j = i;  // CS0236:A field initializer cannot reference the non-static field, method, or property 'staticSyntaxTest.SimpleClass.i'

		}
		[Test]
		public void 静态属性与非静态属性()
		{
			Console.WriteLine(SimpleClass.staticProperty);
			Console.WriteLine();
		}
	}
}
