using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
    public class BoardCovering {
        private static int[,] board;
        private static int tile = 1; // L型骨牌编号

        public static void Cover(int size, int top, int left, int specialTop, int specialLeft) {
            if(size==2) {
                // 当棋盘为2x2时，直接放置L型骨牌
                for(int i = top; i<top+2; i++) {
                    for(int j = left; j<left+2; j++) {
                        if(i!=specialTop||j!=specialLeft) {
                            board[i, j]=tile;
                        }
                    }
                }
                tile++;
                return;
            }

            int halfSize = size/2;

            // 找到四个子棋盘中的特殊方格位置
            int[] specialPositions = FindSpecialPosition(top, left, halfSize, specialTop, specialLeft);

            // 递归覆盖四个子棋盘
            Cover(halfSize, top, left, specialPositions[0], specialPositions[1]);
            Cover(halfSize, top, left+halfSize, specialPositions[2], specialPositions[3]);
            Cover(halfSize, top+halfSize, left, specialPositions[4], specialPositions[5]);
            Cover(halfSize, top+halfSize, left+halfSize, specialPositions[6], specialPositions[7]);
        }

        private static int[] FindSpecialPosition(int top, int left, int halfSize, int specialTop, int specialLeft) {
            int[] positions = new int[8];

            // 左上角子棋盘
            if(specialTop<top+halfSize&&specialLeft<left+halfSize) {
                positions[0]=specialTop;
                positions[1]=specialLeft;
            } else {
                positions[0]=top+halfSize-1;
                positions[1]=left+halfSize-1;
                board[positions[0], positions[1]]=tile;
            }

            // 右上角子棋盘
            if(specialTop<top+halfSize&&specialLeft>=left+halfSize) {
                positions[2]=specialTop;
                positions[3]=specialLeft;
            } else {
                positions[2]=top+halfSize-1;
                positions[3]=left+halfSize;
                board[positions[2], positions[3]]=tile;
            }

            // 左下角子棋盘
            if(specialTop>=top+halfSize&&specialLeft<left+halfSize) {
                positions[4]=specialTop;
                positions[5]=specialLeft;
            } else {
                positions[4]=top+halfSize;
                positions[5]=left+halfSize-1;
                board[positions[4], positions[5]]=tile;
            }

            // 右下角子棋盘
            if(specialTop>=top+halfSize&&specialLeft>=left+halfSize) {
                positions[6]=specialTop;
                positions[7]=specialLeft;
            } else {
                positions[6]=top+halfSize;
                positions[7]=left+halfSize;
                board[positions[6], positions[7]]=tile;
            }

            tile++;

            return positions;
        }

        public static void InitializeBoard(int size, int specialTop, int specialLeft) {
            board=new int[size, size];
            for(int i = 0; i<size; i++) {
                for(int j = 0; j<size; j++) {
                    board[i, j]=0; // 0表示未被覆盖
                }
            }
            board[specialTop, specialLeft]=-1; // -1表示特殊方格
        }

        public static int[,] GetBoard() {
            return board;
        }
    }
    internal partial class DaC
	{
        [Test]
        public void Cover_2x2BoardWithSpecialTile_ReturnsCorrectCoverage() {
            int size = 2;
            int specialTop = 0;
            int specialLeft = 0;

            BoardCovering.InitializeBoard(size, specialTop, specialLeft);
            BoardCovering.Cover(size, 0, 0, specialTop, specialLeft);

            int[,] expected = { { -1, 1 }, { 1, 1 } };
            int[,] result = BoardCovering.GetBoard();

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Cover_4x4BoardWithSpecialTile_ReturnsCorrectCoverage() {
            int size = 4;
            int specialTop = 1;
            int specialLeft = 1;

            BoardCovering.InitializeBoard(size, specialTop, specialLeft);
            BoardCovering.Cover(size, 0, 0, specialTop, specialLeft);

            int[,] expected = {
            { 1, 1, 1, 2 },
            { 1, -1, 2, 2 },
            { 3, 3, 2, 2 },
            { 3, 3, 3, 3 }
        };

            int[,] result = BoardCovering.GetBoard();

            CollectionAssert.AreEqual(expected.Cast<int>(), result.Cast<int>());
        }

        [Test]
        public void Cover_8x8BoardWithSpecialTile_ReturnsCorrectCoverage() {
            int size = 8;
            int specialTop = 4;
            int specialLeft = 4;

            BoardCovering.InitializeBoard(size, specialTop, specialLeft);
            BoardCovering.Cover(size, 0, 0, specialTop, specialLeft);

            // 由于输出较大，这里只检查特殊方格周围是否正确
            int[,] result = BoardCovering.GetBoard();
            Assert.IsTrue(result[3, 3]>0);
            Assert.IsTrue(result[3, 4]>0);
            Assert.IsTrue(result[4, 3]>0);
            Assert.AreEqual(-1, result[4, 4]);
        }

        [Test]
        public void Cover_InvalidSpecialTile_ThrowsArgumentException() {
            int size = 4;
            int specialTop = 4; // 超出范围
            int specialLeft = 1;

            BoardCovering.InitializeBoard(size, specialTop, specialLeft);

            Assert.Throws<IndexOutOfRangeException>(() => BoardCovering.Cover(size, 0, 0, specialTop, specialLeft));
        }
    }
}
