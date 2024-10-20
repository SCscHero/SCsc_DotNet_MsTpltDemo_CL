using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
    public class MergeSort {
        public static void Sort(int[] array) {
            if(array==null||array.Length<=1) {
                return;
            }

            int[] temp = new int[array.Length];
            MergeSortRecursive(array, temp, 0, array.Length-1);
        }

        private static void MergeSortRecursive(int[] array, int[] temp, int left, int right) {
            if(left<right) {
                int mid = left+(right-left)/2;

                // 递归排序左半部分
                MergeSortRecursive(array, temp, left, mid);

                // 递归排序右半部分
                MergeSortRecursive(array, temp, mid+1, right);

                // 合并两个已排序的部分
                Merge(array, temp, left, mid, right);
            }
        }

        private static void Merge(int[] array, int[] temp, int left, int mid, int right) {
            for(int i = left; i<=right; i++) {
                temp[i]=array[i];
            }

            int iLeft = left;
            int iRight = mid+1;
            int currentIndex = left;

            while(iLeft<=mid&&iRight<=right) {
                if(temp[iLeft]<=temp[iRight]) {
                    array[currentIndex]=temp[iLeft];
                    iLeft++;
                } else {
                    array[currentIndex]=temp[iRight];
                    iRight++;
                }
                currentIndex++;
            }

            // 复制剩余的左半部分
            int remaining = mid-iLeft;
            for(int k = 0; k<=remaining; k++) {
                array[currentIndex+k]=temp[iLeft+k];
            }
        }
    }

    internal partial class DaC
	{
        [Test]
        public void MergeSort_EmptyArray_ReturnsEmptyArray() {
            int[] array = { };
            MergeSort.Sort(array);

            Assert.AreEqual(0, array.Length);
        }

        [Test]
        public void MergeSort_SingleElementArray_ReturnsSameArray() {
            int[] array = { 1 };
            MergeSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1 }, array);
        }

        [Test]
        public void MergeSort_SortedArray_ReturnsSameArray() {
            int[] array = { 1, 2, 3, 4, 5 };
            MergeSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void MergeSort_ReversedArray_ReturnsSortedArray() {
            int[] array = { 5, 4, 3, 2, 1 };
            MergeSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void MergeSort_UnsortedArray_ReturnsSortedArray() {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            MergeSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, array);
        }

        [Test]
        public void MergeSort_ArrayWithDuplicates_ReturnsSortedArray() {
            int[] array = { 5, 2, 8, 2, 5, 7, 5, 2, 8, 7 };
            MergeSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 2, 2, 2, 5, 5, 5, 7, 7, 8, 8 }, array);
        }

        [Test]
        public void MergeSort_LargeUnsortedArray_ReturnsSortedArray() {
            int[] array = new int[1000];
            Random random = new Random();
            for(int i = 0; i<array.Length; i++) {
                array[i]=random.Next(0, 10000);
            }

            int[] expected = (int[])array.Clone();
            Array.Sort(expected);

            MergeSort.Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }

    }
}
