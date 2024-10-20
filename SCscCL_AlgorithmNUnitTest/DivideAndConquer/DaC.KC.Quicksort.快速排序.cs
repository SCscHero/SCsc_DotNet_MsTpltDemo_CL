using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
    public class QuickSort {
        public static void Sort(int[] array) {
            if(array==null||array.Length<=1) {
                return;
            }

            QuickSortRecursive(array, 0, array.Length-1);
        }

        private static void QuickSortRecursive(int[] array, int left, int right) {
            if(left<right) {
                int pivotIndex = Partition(array, left, right);

                // 递归排序左半部分
                QuickSortRecursive(array, left, pivotIndex-1);

                // 递归排序右半部分
                QuickSortRecursive(array, pivotIndex+1, right);
            }
        }

        private static int Partition(int[] array, int left, int right) {
            int pivot = array[right]; // 选择最右边的元素作为基准
            int i = left-1;

            for(int j = left; j<right; j++) {
                if(array[j]<=pivot) {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i+1, right);
            return i+1;
        }

        private static void Swap(int[] array, int i, int j) {
            int temp = array[i];
            array[i]=array[j];
            array[j]=temp;
        }
    }
    internal partial class DaC
	{
        [Test]
        public void Sort_EmptyArray_ReturnsEmptyArray() {
            int[] array = { };
            QuickSort.Sort(array);

            Assert.AreEqual(0, array.Length);
        }

        [Test]
        public void Sort_SingleElementArray_ReturnsSameArray() {
            int[] array = { 1 };
            QuickSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1 }, array);
        }

        [Test]
        public void Sort_SortedArray_ReturnsSameArray() {
            int[] array = { 1, 2, 3, 4, 5 };
            QuickSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void Sort_ReversedArray_ReturnsSortedArray() {
            int[] array = { 5, 4, 3, 2, 1 };
            QuickSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [Test]
        public void Sort_UnsortedArray_ReturnsSortedArray() {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            QuickSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 }, array);
        }

        [Test]
        public void Sort_ArrayWithDuplicates_ReturnsSortedArray() {
            int[] array = { 5, 2, 8, 2, 5, 7, 5, 2, 8, 7 };
            QuickSort.Sort(array);

            CollectionAssert.AreEqual(new int[] { 2, 2, 2, 5, 5, 5, 7, 7, 8, 8 }, array);
        }

        [Test]
        public void Sort_LargeUnsortedArray_ReturnsSortedArray() {
            int[] array = new int[1000];
            Random random = new Random();
            for(int i = 0; i<array.Length; i++) {
                array[i]=random.Next(0, 10000);
            }

            int[] expected = (int[])array.Clone();
            Array.Sort(expected);

            QuickSort.Sort(array);

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
