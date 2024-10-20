using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{

    public class LinearTimeSelection {
        public static int Select(int[] array, int k) {
            if(array==null||array.Length==0||k<1||k>array.Length) {
                throw new ArgumentException("Invalid input");
            }

            return Select(array, 0, array.Length-1, k);
        }

        private static int Select(int[] array, int left, int right, int k) {
            if(left==right) {
                return array[left];
            }

            int pivotIndex = PartitionAroundPivot(array, left, right);

            if(k-1==pivotIndex) {
                return array[pivotIndex];
            } else if(k-1<pivotIndex) {
                return Select(array, left, pivotIndex-1, k);
            } else {
                return Select(array, pivotIndex+1, right, k);
            }
        }

        private static int PartitionAroundPivot(int[] array, int left, int right) {
            int pivot = ChoosePivot(array, left, right);
            int pivotValue = array[pivot];
            Swap(array, pivot, right); // Move pivot to end
            int storeIndex = left;

            for(int i = left; i<right; i++) {
                if(array[i]<pivotValue) {
                    Swap(array, storeIndex, i);
                    storeIndex++;
                }
            }

            Swap(array, right, storeIndex); // Move pivot to its final place
            return storeIndex;
        }

        private static int ChoosePivot(int[] array, int left, int right) {
            if(right-left<5) {
                InsertionSort(array, left, right);
                return (left+right)/2;
            }

            int numMedians = (right-left+1)/5;
            int[] medians = new int[numMedians];

            for(int i = 0; i<numMedians; i++) {
                int subLeft = left+i*5;
                int subRight = Math.Min(subLeft+4, right);
                InsertionSort(array, subLeft, subRight);
                medians[i]=array[(subLeft+subRight)/2];
            }

            return Select(medians, (numMedians+1)/2);
        }

        private static void InsertionSort(int[] array, int left, int right) {
            for(int i = left+1; i<=right; i++) {
                int key = array[i];
                int j = i-1;

                while(j>=left&&array[j]>key) {
                    array[j+1]=array[j];
                    j--;
                }

                array[j+1]=key;
            }
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
        public void Select_SingleElementArray_ReturnsElement() {
            int[] array = { 5 };
            int k = 1;
            int result = LinearTimeSelection.Select(array, k);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Select_SortedArray_ReturnsKthElement() {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 5;
            int result = LinearTimeSelection.Select(array, k);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Select_UnsortedArray_ReturnsKthElement() {
            int[] array = { 3, 2, 1, 5, 6, 4 };
            int k = 3;
            int result = LinearTimeSelection.Select(array, k);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Select_LargeUnsortedArray_ReturnsKthElement() {
            int[] array = new int[1000];
            Random random = new Random();
            for(int i = 0; i<array.Length; i++) {
                array[i]=random.Next(0, 10000);
            }

            int k = 500;
            int result = LinearTimeSelection.Select(array, k);

            Array.Sort(array);
            Assert.AreEqual(array[k-1], result);
        }

        [Test]
        public void Select_FirstElement_ReturnsFirstElement() {
            int[] array = { 5, 3, 8, 1, 2, 7, 4, 6 };
            int k = 1;
            int result = LinearTimeSelection.Select(array, k);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Select_LastElement_ReturnsLastElement() {
            int[] array = { 5, 3, 8, 1, 2, 7, 4, 6 };
            int k = 8;
            int result = LinearTimeSelection.Select(array, k);

            Assert.AreEqual(8, result);
        }

        [Test]
        public void Select_InvalidK_ThrowsArgumentException() {
            int[] array = { 5, 3, 8, 1, 2, 7, 4, 6 };
            int k = 9;

            Assert.Throws<ArgumentException>(() => LinearTimeSelection.Select(array, k));
        }
    }
}
