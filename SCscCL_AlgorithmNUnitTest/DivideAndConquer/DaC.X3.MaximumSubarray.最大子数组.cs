using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer {

    //【Ref】Kadane's Algorithm 实现思路
    public class MaxSubArray {
        public static int FindMaxSubArraySum(int[] nums) {
            if(nums==null||nums.Length==0) {
                throw new ArgumentException("Array must not be null or empty");
            }

            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];

            for(int i = 1; i<nums.Length; i++) {
                // 更新当前最大子数组和
                maxEndingHere=Math.Max(nums[i], maxEndingHere+nums[i]);
                // 更新全局最大子数组和
                maxSoFar=Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }

    internal partial class DaC {
        [Test]
        public void FindMaxSubArraySum_SingleElement_ReturnsElement() {
            int[] nums = { 5 };
            int result = MaxSubArray.FindMaxSubArraySum(nums);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void FindMaxSubArraySum_PositiveNumbers_ReturnsTotal() {
            int[] nums = { 1, 2, 3, 4, 5 };
            int result = MaxSubArray.FindMaxSubArraySum(nums);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void FindMaxSubArraySum_NegativeNumbers_ReturnsLargestNegative() {
            int[] nums = { -1, -2, -3, -4, -5 };
            int result = MaxSubArray.FindMaxSubArraySum(nums);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void FindMaxSubArraySum_MixedNumbers_ReturnsCorrectSubarray() {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int result = MaxSubArray.FindMaxSubArraySum(nums);

            Assert.AreEqual(6, result); // 子数组 [4, -1, 2, 1] 的和
        }

        [Test]
        public void FindMaxSubArraySum_AllZeros_ReturnsZero() {
            int[] nums = { 0, 0, 0, 0, 0 };
            int result = MaxSubArray.FindMaxSubArraySum(nums);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void FindMaxSubArraySum_EmptyArray_ThrowsArgumentException() {
            int[] nums = { };

            var ex = Assert.Throws<ArgumentException>(() => MaxSubArray.FindMaxSubArraySum(nums));
            Assert.That(ex.Message, Does.Contain("Array must not be null or empty"));
        }

        [Test]
        public void FindMaxSubArraySum_NullArray_ThrowsArgumentException() {
            int[] nums = null;

            var ex = Assert.Throws<ArgumentException>(() => MaxSubArray.FindMaxSubArraySum(nums));
            Assert.That(ex.Message, Does.Contain("Array must not be null or empty"));
        }
    }
}
