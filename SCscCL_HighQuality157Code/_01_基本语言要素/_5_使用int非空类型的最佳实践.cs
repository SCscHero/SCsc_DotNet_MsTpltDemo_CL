namespace SCscCL_HighQuality157Code._01_基本语言要素
{
    [TestClass]
    public class _5_使用int非空类型的最佳实践
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void 剖析单问号语法糖()
        {
            double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
            {
                return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            }

            double SumNumbers1(List<double[]> setsOfNumbers, int indexOfSetToSum)
            {
                return setsOfNumbers[indexOfSetToSum]?.Sum() ?? double.NaN;
            }

            var res = SumNumbers(null, 0);
            var res1 = SumNumbers1(null, 0);//System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
                                            //【总结】集合和索引中间若无问号，当集合为null时将报错。

            //TODO:单问号官方Demo。
            ////threw exception:System.ArgumentOutOfRangeException: Index was out of range. Must be non - negative and less than the size of the collection. (Parameter 'index')
            //var dbList = new List<double[]>() { new double[] { } };
            //var res = dbList?[0]?.Sum();


        }

        /// <summary>
        ///TODO:参考资料：https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(%253F%253F_CSharpKeyword)%3Bk(SolutionItemsProject)%3Bk(DevLang-csharp)%26rd%3Dtrue#code-try-4
        /// </summary>
        [TestMethod]
        public void 剖析双问号语法糖以及DoubleNaN()
        {
            double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
            {
                return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
            }
            var sum = SumNumbers(null, 0);//NaN
            var sum2 = SumNumbers(new List<double[]>() { new double[] { 22.12, 22.13 } }, 0);//44.25
        }


        #region TestModel_Eq1
        private int? eq1IntNullQuestionMark = null;
        private Nullable<int> eq1IntNullNullable = null;
        #endregion

        [TestMethod]
        public void 剖析Nullable()
        {
            //Nullable本身是个结构体。
            Console.WriteLine($@"{eq1IntNullQuestionMark ?? -1}");
        }

        [TestMethod]
        public void 使用int问号代替Nullable写法Eq1()
        {

        }


    }
}
