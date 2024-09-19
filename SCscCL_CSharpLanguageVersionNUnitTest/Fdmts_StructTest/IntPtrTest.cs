using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_StructTest
{
	/// <summary>
	/// 【FullName】IntPtr=>IntPointer
	/// 【Ref】https://blog.csdn.net/sinat_40003796/article/details/127244155
	/// 【Ref】https://learn.microsoft.com/zh-cn/dotnet/api/system.intptr?view=net-6.0
	/// </summary>
	internal class IntPtrTest
	{
		[SetUp]
		public void Setup()
		{
		}



		[Test]
		public void Origin_由来()
		{
			/*
			 .NET提供了一个结构体System.IntPtr专门用来代表句柄或指针。
			 句柄是对象的标识符，当调用这些API创建对象时，它们并不直接返回指向对象的指针，而是会返回一个32位或64位的整数值，这个在进程或系统范围内唯一的整数值就是句柄（Handle）,随后程序再次访问对象，或者删除对象，都将句柄作为Windows API的参数来间接对这些对象进行操作。

			句柄指向就是指向文件开头，在windows系统所有的东西都是文件，对象也是文件。所以句柄和指针是一样的意思。句柄是面向对象的指针的称呼

			指针是对存储区域的引用，该区域包含您感兴趣的一些数据。指针是面向过程编程的称呼。
			 */

			//SCscHero重点：面向对象、面向过程的概念；
			Assert.Pass();
		}

		[Test]
		public void DefinitionOfType_类型的定义()
		{
			/*
			intPtr 类是 intPointer 的简写。在 C# 中，它被用作指针的替代品，可以说它是对指针的封装形式。intPtr 用于指向非托管内存。然而，在 C# 项目中，由于指针的使用已被弃用，因此这个封装指针的句柄（即 intPtr）也不常被使用。

但总有一些特殊情况需要用到指针，比如调用 C++ 动态库时。因此，微软为了方便开发者，为我们提供了一个句柄的概念。毕竟直接使用指针有时会很繁琐。

简而言之，句柄是一个结构体，它是指针的一个封装形式，可以看作是 C# 中指针的替代方案。接下来，我们来看一下句柄的具体定义。
			 */
			IntPtr unmanagedResource;
			/*
		我们可以清晰地看到，IntPtr 这个句柄类包含了创建指针、获取指针长度、设置偏移量等多种方法，并且为了编程的便利性，还声明了一些强制类型转换的方法。

		仔细查看句柄的结构体定义后，相信有一定基础的开发者已经明白了：在C#中，微软是希望用更加出色的IntPtr来替代传统的指针。

		然而，我们还会发现，句柄中还提供了一个名为ToPointer()的方法，其返回类型是Void*，这意味着我们仍然可以从句柄中获取到C++中的指针。既然微软希望在C#中避免使用指针，那为何还要提供这样的方法呢？

		原因在于，在项目开发中总会遇到一些特殊情况。比如，你可能有一段用C++编写的极其复杂且高效的函数，而将其转换为C#代码会相当耗时。在这种情况下，最简单直接的方式就是在C#中直接使用指针进行移植。

		因此，C#支持指针并非鼓励大家去使用它，而是为了体现其语言的兼容性和灵活性。
			 */
			Assert.Pass();
		}

		[Test]
		public void ApplicableScenarios_基础原理()
		{
			/*
			 1.在C#中，IntPtr类型是一个与平台相关的整数类型，它主要用于处理本地资源，比如窗口句柄。	其大小根据所使用的硬件和操作系统的位数而定，即在32位环境中为32位整数，而在64位环境中则为64位整数。不过，无论在哪种环境中，其大小都足以容纳系统指针，进而也能包含资源标识符。
  			2.IntPtr类型的设计初衷是作为一个整数，其大小能够适应不同的平台。
				3.当调用API函数时，特别是那些接受窗口句柄（HANDLE）作为参数的函数，我们应将参数类型显式声明为IntPtr。
			  4.此外，IntPtr类型在处理多线程操作时是安全的，这意味着在多线程环境中使用它不会导致线程冲突或数据不一致。
				5.同时，IntPtr类型可以被那些支持指针操作的语言所使用，它提供了一种在支持和不支持指针的语言之间传递数据的通用机制。
			  6.不仅如此，IntPtr对象还常被用来保存句柄，例如，在System.IO.FileStream类中，就使用了IntPtr实例来保存文件句柄。
			  7.实质上，IntPtr可以看作是HANDLE的一种表现形式，即一个无类型的指针。但需要注意的是，这样的无类型指针不能直接使用，它必须传递给能够处理它的函数。
			 */
			Assert.Pass();
		}
	}
}
