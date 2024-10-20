using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
	internal partial class DaC
	{
        public BigInteger BigNumberMultiply(string number1, string number2) {
            // 将字符串转换为BigInteger
            BigInteger bigNumber1 = BigInteger.Parse(number1);
            BigInteger bigNumber2 = BigInteger.Parse(number2);

            // 进行乘法运算
            return BigInteger.Multiply(bigNumber1, bigNumber2);
        }

        [Test]
        public void Multiply_SmallNumbers_ReturnsCorrectResult() {
            string number1 = "123";
            string number2 = "456";
            string expectedResult = "56088";

            string result = BigNumberMultiply(number1, number2).ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Multiply_LargeNumbers_ReturnsCorrectResult() {
            string number1 = "123456789012345678901234567890";
            string number2 = "987654321098765432109876543210";
            string expectedResult = "1219326311370217952237463801111263526900";

            string result = BigNumberMultiply(number1, number2).ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Multiply_ZeroAndNonZero_ReturnsZero() {
            string number1 = "0";
            string number2 = "123456789012345678901234567890";
            string expectedResult = "0";

            string result = BigNumberMultiply(number1, number2).ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Multiply_NegativeNumbers_ReturnsCorrectResult() {
            string number1 = "-123";
            string number2 = "456";
            string expectedResult = "-56088";

            string result = BigNumberMultiply(number1, number2).ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Multiply_OneAndAnyNumber_ReturnsTheSameNumber() {
            string number1 = "1";
            string number2 = "123456789012345678901234567890";
            string expectedResult = "123456789012345678901234567890";

            string result = BigNumberMultiply(number1, number2).ToString();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Multiply_EmptyString_ThrowsArgumentException() {
            string number1 = "";
            string number2 = "123456789012345678901234567890";

            Assert.Throws<FormatException>(() => BigNumberMultiply(number1, number2));
        }

        [Test]
        public void Multiply_InvalidString_ThrowsFormatException() {
            string number1 = "abc";
            string number2 = "123456789012345678901234567890";

            Assert.Throws<FormatException>(() => BigNumberMultiply(number1, number2));
        }
    }
}
