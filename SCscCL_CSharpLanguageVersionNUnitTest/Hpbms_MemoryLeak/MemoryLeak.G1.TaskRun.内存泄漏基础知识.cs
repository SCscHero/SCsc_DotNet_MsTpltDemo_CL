using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsLangVersion.Hpbms_MemoryLeak
{
	internal partial class MemoryLeak
	{
		private int _id;

		private List<string> _list;
		//【Ref】https://zhuanlan.zhihu.com/p/668484756
		[Test]
		public Task TaskRun内存泄漏()
		{
			//由于值类型是拷贝方式的赋值，捕获的本地变量和类成员是指向各自的值，对本地变量的捕获不会影响到整个类。但如果把类中的值类型改为引用类型，那这两者最终指向的是同一个对象值，这是否意味着使用本地变量还是无法避免内存泄漏？

			//GC在第一次回收时，发现某实例还存在被捕获成员，则认为它不应该被回收。假如这个实例对象中存在Task.Run，当Task.Run执行完毕后，GC不就可以回收这个实例了吗？
			//【结论】_id无论是int类型还是string类型，都会被回收；
			var LocalID = _id;

			return Task.Run(() =>
			{
				Console.WriteLine("Task.Run is executing with ID={0}", LocalID);
				Thread.Sleep(1500);
			});
		}

		[Test]
		public void 声明引用类型开辟内存空间()
		{
			//在栈上存储变量名称；
			//在托管堆上存储对应的值；
		}

		[Test]
		public void 作用域捕获_GC分带算法_Gen1Gen2Gen3()
		{
			//GC回收原理；
			//所谓被捕获就是被作用域捕获，当作用域结束时，该作用域内成员的地址空间也会被释放，至于地址指向的托管堆中的字符串，则不是作用域该关心的事情。当字符串值对应的地址空间没有变量指向时，就会被GC回收。

			//当CLR尝试搜索不再使用的对象时，它需要遍历托管堆上的对象。随着程序的不断运行，托管堆可能会不断变大，如果GC对整个托管堆回收，势必会造成对程序性能的影响，甚至崩溃。所以，为了优化这个过程，微软在CLR中使用了分带算法。

			//分带算法就是把内存中的资源划分为三代，分别是Gen 0、Gen 1、Gen 2，GC遍历它们的频率由高到低。新创建对象的会被标记为Gen 0，GC扫描它们的频率最高；当GC进行一次扫描后，未被回收的对象会被标记为Gen 1；当GC扫描被标记为Gen 1的对象时，未被回收的对象被标记为Gen 2，Gen 2的回收被称为Full GC，只有在满足一定条件时才会执行。资源在内存中停留的时间越长，越不容易被回收。
			//【架构图】
			//https://pic1.zhimg.com/80/v2-04dbeae704e41d17d020a4ac89f33da0_720w.webp

			//当我们理解分带算法后，上面那段代码相应的三个时间点：1、作用域的结束时间点；2、GC回收的时间点；3、Task.Run执行的结束点。

			//一、如果程序的执行顺序是1、3、2，那么就不会存在内存泄漏问题。
			//二、但实际情况是，Task.Run一般是执行耗时操作，非耗时任务一般是不会使用Task.Run。所以程序执行的时间顺序可能是1、2、3，当GC回收该对象时，由于该对象的作用域还未被释放，GC会将该对象标记为Gen 1。如果Task.Run执行的时间够长，该对象会被标记为Gen 2，若没有相应的触发条件，该对象永远都不会被回收。

			//在大部分场景中，我们还是可以放心的去使用Task.Run。如果Task.Run中的局部变量捕获了类中的成员，使该对象进入Gen 2，Gen 2中未被释放的资源也是有限的，不可能是无限增加。当Gen 2中的资源累积到一定程度时，就会触发相应的条件，GC会将Gen 2中未被使用的资源释放。当然，我们还是要尽可能避免在Task.Run匿名类中捕获类成员。
		}
	}
}
