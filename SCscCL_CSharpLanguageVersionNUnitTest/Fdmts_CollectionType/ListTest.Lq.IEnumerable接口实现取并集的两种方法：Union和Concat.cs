using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLangVersion.Fdmts_CollectionType {
    public partial class ListTest {
        public const string thisClassName = nameof(ListTest);

        /*
         方法介绍
        Union 方法
        Union 方法用于合并两个集合，并返回一个包含两个集合中所有唯一元素的新集合。也就是说，它会自动去除重复元素。
        应用场景：当你需要合并两个集合，并且不希望结果中包含重复元素时，可以使用 Union 方法。例如，合并两个用户 ID 列表，去除重复的用户 ID。
         */
        [Test]
        public void List_Union_Test() {

            // 初始化两个包含整数的列表
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 3, 4, 5 };

            // 使用 Union 方法合并两个列表
            var result = list1.Union(list2).ToList();

            // 验证结果是否包含所有唯一元素
            Assert.AreEqual(5, result.Count);
            Assert.IsTrue(result.Contains(1));
            Assert.IsTrue(result.Contains(2));
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(result.Contains(4));
            Assert.IsTrue(result.Contains(5));

        }

        /*
        Concat 方法
        Concat 方法用于将一个集合的元素追加到另一个集合的末尾，返回一个包含两个集合所有元素的新集合。它不会去除重复元素。
        应用场景：当你需要简单地将两个集合合并在一起，并且希望保留所有元素（包括重复元素）时，可以使用 Concat 方法。例如，合并两个日志记录列表。
        单元测试案例
        */

        [Test]
        public void List_Concat_Test() {
            // 初始化两个包含整数的列表
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 3, 4, 5 };

            // 使用 Concat 方法合并两个列表
            var result = list1.Concat(list2).ToList();

            // 验证结果是否包含所有元素，包括重复元素
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(3, result[3]);
            Assert.AreEqual(4, result[4]);
            Assert.AreEqual(5, result[5]);
        }
    }
}
