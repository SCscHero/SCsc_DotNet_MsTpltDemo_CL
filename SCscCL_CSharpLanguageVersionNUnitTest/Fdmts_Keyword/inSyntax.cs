using System;

namespace CsLangVersion.Fdmts_Keyword
{
    /// <summary>
    /// https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/in-parameter-modifier
    /// 
    /// </summary>
    internal class inSyntax
    {
        //1.in 关键字会导致按引用传递参数，但确保未修改参数。 它让形参成为实参的别名，这必须是变量。
        //2.换而言之，对形参执行的任何操作都是对实参执行的。
        //3.它类似于 ref 或 out 关键字，不同之处在于 in 参数无法通过调用的方法进行修改。 out 参数必须由调用的方法进行修改，这些修改在调用上下文中是可观察的，而 ref 参数是可以修改的。
        [Test]
        public void UseIn_引用类型传递参数示例1()
        {
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44

            void InArgExample(in int number)
            {
                // Uncomment the following line to see error CS8331
                //number = 19;
            }
        }
        //in 关键字还作为 foreach 语句的一部分，或作为 LINQ 查询中 join 子句的一部分，与泛型类型参数一起使用来指定该类型参数为逆变。 有关在这些上下文使用 in 关键字的详细信息，请参阅 in，其中提供了所有这些用法的链接。
        [Test]
        public void TODO_UseIn_Foreach和Linq当中的示例()
        {

        }
        //作为 in 参数传递的变量在方法调用中传递之前必须进行初始化。 但是，所调用的方法可能不会分配值或修改参数。
        //尽管 in、out 和 ref 参数修饰符被视为签名的一部分，但在单个类型中声明的成员不能仅因 in、ref 和 out 而签名不同。 因此，如果唯一的不同是一个方法采用 ref 或 out 参数，而另一个方法采用 in 参数，则无法重载这两个方法。 例如，以下代码将不会编译：
        //private class CS0663_Example
        //{
        //    // Compiler error CS0663: "Cannot define overloaded
        //    // methods that differ only on in, ref and out".
        //    public void SampleMethod(in int i) { }
        //    public void SampleMethod(ref int i) { }
        //}
        [Test]
        public void UseInAndref_无法重载的编译错误示例()
        {

        }
        private class InOverloads
        {
            public void SampleMethod(in int i) { }
            public void SampleMethod(int i) { }
        }
        [Test]
        public void UseInAndref_可以重载的编译正确示例()
        {

        }
        private static void Method(int argument)
        {
            // implementation removed
        }

        private static void Method(in int argument)
        {
            // implementation removed
        }
        [Test]
        public void UseIn_值类型使用示例()
        {
            Method(5); // Calls overload passed by value
            //Method(5L); // CS1503: no implicit conversion from long to int
            short s = 0;
            Method(s); // Calls overload passed by value.
            //Method(in s); // CS1503: cannot convert from in short to in int
            int i = 42;
            Method(i); // Calls overload passed by value
            Method(in i); // passed by readonly reference, explicitly using `in`
        }
    }
}
