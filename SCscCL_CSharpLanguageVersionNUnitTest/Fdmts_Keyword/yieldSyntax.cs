using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_Keyword
{
    /// <summary>
    /// 【Ref】https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield?devlangs=csharp&f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(yield_CSharpKeyword)%3Bk(DevLang-csharp)%26rd%3Dtrue
    /// 在迭代器中使用yield语句来提供下一个值或表示迭代结束。
    /// </summary>
    internal class yieldSyntax
    {
        /// <summary>
        /// yield语句有以下两种形式:yield return/yield break
        /// </summary>
        [Test]
        public void 使用yield关键字示例()
        {
            //1/2.yield return
            foreach (int i in ProduceEvenNumbers(9))
            {
                Console.Write(i);
                Console.Write(" ");
            }
            // Output: 0 2 4 6 8
            IEnumerable<int> ProduceEvenNumbers(int upto)
            {
                for (int i = 0; i <= upto; i += 2)
                {
                    yield return i;
                }
            }

            //2/2.yield break
            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 2, 3, 4, 5, -1, 3, 4 })));
            // Output: 2 3 4 5
            Console.WriteLine(string.Join(" ", TakeWhilePositive(new[] { 9, 8, 7 })));
            // Output: 9 8 7
            IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
            {
                foreach (int n in numbers)
                {
                    if (n > 0)
                    {
                        yield return n;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }

        [Test]
        public async void 使用yield关键字示例_异步迭代器()
        {
            //当控制到达迭代器的末尾时，迭代也结束。
            //在前面的例子中，迭代器的返回类型是IEnumerable<T>(在非泛型情况下，使用IEnumerable作为迭代器的返回类型)。你也可以使用IAsyncEnumerable<T> 作为迭代器的返回类型。这使得迭代器是异步的。使用await foreach语句迭代迭代器的结果，如下例所示:
            await foreach (int n in GenerateNumbersAsync(5))
            {
                Console.Write(n);
                Console.Write(" ");
            }
            // Output: 0 2 4 6 8

            async IAsyncEnumerable<int> GenerateNumbersAsync(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    yield return await ProduceNumberAsync(i);
                }
            }

            async Task<int> ProduceNumberAsync(int seed)
            {
                await Task.Delay(1000);
                return 2 * seed;
            }
        }
        private readonly record struct Point(int X, int Y, int Z)
        {
            public IEnumerator<int> GetEnumerator()
            {
                yield return X;
                yield return Y;
                yield return Z;
            }
        }
        [Test]
        public void 使用Yield并且实现GetEnumerator()
        {
            var point = new Point(1, 2, 3);
            foreach (int coordinate in point)
            {
                Console.Write(coordinate);
                Console.Write(" ");
            }
            // Output: 1 2 3
        }
        /// <summary>
        /// The call of an iterator doesn't execute it immediately, as the following example shows:
        /// </summary>
        [Test]
        public void 使用Yield并且迭代器调用并不会立即执行()
        {
            var numbers = ProduceEvenNumbers(5);
            Console.WriteLine("Caller: about to iterate.");
            foreach (int i in numbers)
            {
                Console.WriteLine($"Caller: {i}");
            }
            IEnumerable<int> ProduceEvenNumbers(int upto)
            {
                Console.WriteLine("Iterator: start.");
                for (int i = 0; i <= upto; i += 2)
                {
                    Console.WriteLine($"Iterator: about to yield {i}");
                    yield return i;
                    Console.WriteLine($"Iterator: yielded {i}");
                }
                Console.WriteLine("Iterator: end.");
            }
            // Output:
            // Caller: about to iterate.
            // Iterator: start.
            // Iterator: about to yield 0
            // Caller: 0
            // Iterator: yielded 0
            // Iterator: about to yield 2
            // Caller: 2
            // Iterator: yielded 2
            // Iterator: about to yield 4
            // Caller: 4
            // Iterator: yielded 4
            // Iterator: end.
        }
    }
}
