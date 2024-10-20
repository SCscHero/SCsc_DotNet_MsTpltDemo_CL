using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
	internal partial class DaC
	{
        public int DichotomySearch(int[] array, int target) {
            if(array==null||array.Length==0) {
                return -1;
            }
            int left = 0;
            int right = array.Length-1;
            while(left<=right) {
                int mid = left+(right-left)/2;

                if(array[mid]==target) {
                    return mid; // 找到目标值，返回索引
                } else if(array[mid]<target) {
                    left=mid+1; // 目标值在右半部分
                } else {
                    right=mid-1; // 目标值在左半部分
                }
            }
            return -1; // 未找到目标值
        }

        [Test]
        public void Search_FindsTarget_ReturnsCorrectIndex() {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int target = 5;
            int expectedIndex = 4;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(expectedIndex, result);
        }

        [Test]
        public void Search_TargetNotInArray_ReturnsNegativeOne() {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int target = 10;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Search_EmptyArray_ReturnsNegativeOne() {
            int[] array = { };
            int target = 5;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Search_NullArray_ReturnsNegativeOne() {
            int[] array = null;
            int target = 5;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Search_SingleElementArray_TargetFound_ReturnsZero() {
            int[] array = { 5 };
            int target = 5;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Search_SingleElementArray_TargetNotFound_ReturnsNegativeOne() {
            int[] array = { 5 };
            int target = 10;
            int result = DichotomySearch(array, target);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Search_DuplicateElements_TargetFound_ReturnsAnyValidIndex() {
            int[] array = { 1, 2, 3, 3, 3, 4, 5, 6, 7, 8, 9 };
            int target = 3;
            int result = DichotomySearch(array, target);
            // 由于数组中有多个3，只要结果是2、3或4中的任何一个都是有效的
            Assert.IsTrue(result>=2&&result<=4);
        }
    }
}
