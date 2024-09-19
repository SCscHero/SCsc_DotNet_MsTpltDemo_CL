using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_PrimitiveType {
  internal partial class stringTest {

    [Test]
    public void StringIntern() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(StringIntern)}");
      string str1 = "Hello, World!";
      string str2 = "Hello, World!";

      // 检查两个字符串是否引用相同的对象  
      Console.WriteLine(ReferenceEquals(str1, str2)); // 输出: True  

      // 使用String.Intern()显式地将字符串放入字符串池  
      string str3 = new String(new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'W', 'o', 'r', 'l', 'd', '!' });
      string str4 = String.Intern(str3);

      // 由于str3是new出来的，所以它不在池中  
      // 但str4是显式通过String.Intern()放入池中的，所以它和str1、str2指向同一个对象  
      Console.WriteLine(ReferenceEquals(str1, str3)); // 输出: False  
      Console.WriteLine(ReferenceEquals(str1, str4)); // 输出: True  
      // 注意：虽然使用String.Intern()可以显式地将字符串放入池中，但滥用可能会导致内存问题  

      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


    /*
在.NET/C#中，当你定义一个常量字符串（如使用const关键字），如const string MY_CONST_STRING = "Hello World";，这个常量在编译时会被直接替换为其值。这意味着在编译后的代码中，所有对这个常量的引用都会被替换成实际的字符串字面量"Hello World"。

对于字符串常量（特指由编译器直接处理的字符串字面量），.NET 运行时（CLR）采用了一种称为“字符串驻留”（String Interning）的机制来优化内存使用。这意味着对于字符串常量，CLR 会确保内存中只有一个实例存在。当你在代码中多次使用相同的字符串字面量时（无论是在定义常量时，还是在代码中直接使用时），CLR 都会指向同一个内存地址。

然而，需要明确的是，这个优化是针对字符串字面量的，而不是针对通过const定义的常量本身。const关键字在C#中用于定义编译时常量，这些常量在编译时就已经确定了它们的值，并且这些值会被直接嵌入到编译后的代码中。因此，const常量的“内存中一个实例”的特性实际上是通过字符串驻留机制实现的，而不是const关键字本身的功能。

总结来说，当你使用const定义一个字符串常量时，如const string MY_CONST_STRING = "Hello World";，并且在代码中多次引用这个常量，由于字符串驻留机制，这些引用实际上会指向内存中的同一个字符串实例。但是，这个行为是由字符串驻留机制而不是const关键字直接保证的。

需要注意的是，如果你通过其他方式（如通过字符串构造函数、字符串连接等）创建了与常量值相同的字符串，这些字符串可能不会享受到字符串驻留的优化，因为它们不是通过编译时的字符串字面量创建的。在这种情况下，它们可能会是内存中的独立实例。
     */
    public const string My_Hello_Word = "Hello Word";
    [Test]
    public void 利用常量来减少内存中的字符串实例数() {

      System.Console.WriteLine(@$"UT Excuted {nameof(stringTest)}_{nameof(利用常量来减少内存中的字符串实例数)}");
      string str1 = My_Hello_Word;
      string str2 = string.Intern("Hello Word");
      string str3 = "Hello Word";
      string str4 = "Hello Word";
      string[] strArray1 = new string[] { "Hello Word", "Hello Word1", "Hello Word2" };
      
      Console.WriteLine(ReferenceEquals(str1, str2));
      Console.WriteLine(ReferenceEquals(str1, str3));
      Console.WriteLine(ReferenceEquals(str2, str3));
      Console.WriteLine(ReferenceEquals(str3, str4));
      Console.WriteLine(ReferenceEquals(strArray1[0],str3));
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }


  }
}
