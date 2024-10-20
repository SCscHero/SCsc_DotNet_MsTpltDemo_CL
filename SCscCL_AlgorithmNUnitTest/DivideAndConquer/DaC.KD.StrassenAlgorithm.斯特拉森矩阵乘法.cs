using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
    using NUnit.Framework;
    using System;

    public class StrassenMatrixMultiplication {
        public static int[,] Multiply(int[,] A, int[,] B) {
            int n = A.GetLength(0);
            if(n==1) {
                return new int[,] { { A[0, 0]*B[0, 0] } };
            }

            // 如果 n 不是 2 的幂，填充矩阵
            if(n%2!=0) {
                n=NextPowerOfTwo(n);
                A=PadMatrix(A, n);
                B=PadMatrix(B, n);
            }

            int halfSize = n/2;

            // 分割矩阵
            int[,] A11 = Submatrix(A, 0, 0, halfSize, halfSize);
            int[,] A12 = Submatrix(A, 0, halfSize, halfSize, halfSize);
            int[,] A21 = Submatrix(A, halfSize, 0, halfSize, halfSize);
            int[,] A22 = Submatrix(A, halfSize, halfSize, halfSize, halfSize);

            int[,] B11 = Submatrix(B, 0, 0, halfSize, halfSize);
            int[,] B12 = Submatrix(B, 0, halfSize, halfSize, halfSize);
            int[,] B21 = Submatrix(B, halfSize, 0, halfSize, halfSize);
            int[,] B22 = Submatrix(B, halfSize, halfSize, halfSize, halfSize);

            // 计算中间矩阵
            int[,] P1 = Multiply(Add(A11, A22), Add(B11, B22));
            int[,] P2 = Multiply(Add(A21, A22), B11);
            int[,] P3 = Multiply(A11, Subtract(B12, B22));
            int[,] P4 = Multiply(A22, Subtract(B21, B11));
            int[,] P5 = Multiply(Add(A11, A12), B22);
            int[,] P6 = Multiply(Subtract(A21, A11), Add(B11, B12));
            int[,] P7 = Multiply(Subtract(A12, A22), Add(B21, B22));

            // 计算结果矩阵
            int[,] C11 = Add(Subtract(Add(P1, P4), P5), P7);
            int[,] C12 = Add(P3, P5);
            int[,] C21 = Add(P2, P4);
            int[,] C22 = Add(Add(Subtract(P1, P2), P3), P6);

            // 合并结果矩阵
            int[,] C = Combine(C11, C12, C21, C22);

            // 如果原始矩阵不是 2 的幂，去除填充
            if(C.GetLength(0)>A.GetLength(0)) {
                C=TrimMatrix(C, A.GetLength(0));
            }

            return C;
        }

        private static int NextPowerOfTwo(int n) {
            n--;
            n|=n>>1;
            n|=n>>2;
            n|=n>>4;
            n|=n>>8;
            n|=n>>16;
            return n+1;
        }

        private static int[,] PadMatrix(int[,] matrix, int newSize) {
            int oldSize = matrix.GetLength(0);
            int[,] padded = new int[newSize, newSize];
            for(int i = 0; i<oldSize; i++) {
                for(int j = 0; j<oldSize; j++) {
                    padded[i, j]=matrix[i, j];
                }
            }
            return padded;
        }
        private static int[,] Submatrix(int[,] matrix, int row, int col, int size, int size2) {
            int[,] submatrix = new int[size, size2];
            for(int i = 0; i<size; i++) {
                for(int j = 0; j<size2; j++) {
                    submatrix[i, j]=matrix[row+i, col+j];
                }
            }
            return submatrix;
        }
        private static int[,] Add(int[,] A, int[,] B) {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];
            for(int i = 0; i<n; i++) {
                for(int j = 0; j<n; j++) {
                    result[i, j]=A[i, j]+B[i, j];
                }
            }
            return result;
        }
        private static int[,] Subtract(int[,] A, int[,] B) {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];
            for(int i = 0; i<n; i++) {
                for(int j = 0; j<n; j++) {
                    result[i, j]=A[i, j]-B[i, j];
                }
            }
            return result;
        }
        private static int[,] Combine(int[,] A11, int[,] A12, int[,] A21, int[,] A22) {
            int n = A11.GetLength(0);
            int[,] result = new int[2*n, 2*n];
            for(int i = 0; i<n; i++) {
                for(int j = 0; j<n; j++) {
                    result[i, j]=A11[i, j];
                    result[i, j+n]=A12[i, j];
                    result[i+n, j]=A21[i, j];
                    result[i+n, j+n]=A22[i, j];
                }
            }
            return result;
        }
        private static int[,] TrimMatrix(int[,] matrix, int size) {
            int[,] trimmed = new int[size, size];
            for(int i = 0; i<size; i++) {
                for(int j = 0; j<size; j++) {
                    trimmed[i, j]=matrix[i, j];
                }
            }
            return trimmed;
        }
    }

    internal partial class DaC
	{
        [Test]
        public void Multiply_SmallMatrices_ReturnsCorrectResult() {
            int[,] A = { { 1, 2 }, { 3, 4 } };
            int[,] B = { { 5, 6 }, { 7, 8 } };

            int[,] expected = { { 19, 22 }, { 43, 50 } };
            int[,] result = StrassenMatrixMultiplication.Multiply(A, B);

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Multiply_LargeMatrices_ReturnsCorrectResult() {
            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] B = { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } };

            int[,] expected = { { 84, 90, 96 }, { 201, 216, 231 }, { 318, 342, 366 } };
            int[,] result = StrassenMatrixMultiplication.Multiply(A, B);

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Multiply_IdentityMatrix_ReturnsSameMatrix() {
            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] I = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            int[,] expected = A;
            int[,] result = StrassenMatrixMultiplication.Multiply(A, I);

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Multiply_ZeroMatrix_ReturnsZeroMatrix() {
            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] Z = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            int[,] expected = Z;
            int[,] result = StrassenMatrixMultiplication.Multiply(A, Z);

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Multiply_NonSquareMatrices_ThrowsArgumentException() {
            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] B = { { 7, 8 }, { 9, 10 }, { 11, 12 } };

            Assert.Throws<ArgumentException>(() => StrassenMatrixMultiplication.Multiply(A, B));
        }
    }
}
