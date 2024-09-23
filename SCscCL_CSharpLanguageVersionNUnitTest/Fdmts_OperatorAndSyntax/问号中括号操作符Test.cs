using System.Collections.Generic;
using System.Linq;

namespace CsLangVersion.Fdmts_Operator
{
    public class 问号中括号操作符Test
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Eq1_问号中括号操作符()
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

    }
}
