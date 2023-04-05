using System;

namespace CsLangVersion.Fdmts_PrimitiveType
{
    /// <summary>
    /// 
    /// </summary>
    public class DecimalTest
    {

        #region Eq1_TestModel
        private class Eq1_M1Nullable
        {
            decimal? dec;
        }

        private class Eq1_M1NonNullable
        {
            decimal dec;

        }
        #endregion

        /// <summary>
        /// Decimal allows empty and non-empty contrast
        /// </summary>
        [Test]
        public void Eq1_Decimal可空和非空对比Test()
        {
            decimal? decNull = null;
            decimal? decNull5 = 5;
            decimal dec = 5.0000M;

            try
            {
                Console.WriteLine($@"{nameof(decimal.Compare)}方法：返回-1表示不相同，返回0表示相同。");
                Console.WriteLine(decimal.Compare(decNull.HasValue ? (decimal)decNull : 0, dec));//如果直接强转会报错
                Console.WriteLine(decimal.Compare((decimal)decNull5, dec));
                Console.WriteLine(decimal.Compare(5.000M, dec));
                Console.WriteLine(decimal.Compare(5.000M, 5.000M));

                Console.WriteLine($@"操作符判断：返回True则相同，返回False则不相同");
                Console.WriteLine(decNull.HasValue ? (decimal)decNull : 0 == dec);
                Console.WriteLine(decNull == decNull5);
                Console.WriteLine(decNull5 == dec);
                Console.WriteLine(5.000M == dec);
                Console.WriteLine(5 == 5.000M);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
