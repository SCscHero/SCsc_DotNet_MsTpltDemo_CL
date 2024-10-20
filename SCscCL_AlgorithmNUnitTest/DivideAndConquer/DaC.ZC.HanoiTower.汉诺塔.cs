using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer
{
    public class HanoiTower {
        public static List<(char from, char to)> Solve(int n, char source, char auxiliary, char destination) {
            var moves = new List<(char from, char to)>();
            SolveRecursive(n, source, auxiliary, destination, moves);
            return moves;
        }

        private static void SolveRecursive(int n, char source, char auxiliary, char destination, List<(char from, char to)> moves) {
            if(n==1) {
                // 移动单个盘子
                moves.Add((source, destination));
            } else {
                // 将 n-1 个盘子从源柱子移动到辅助柱子
                SolveRecursive(n-1, source, destination, auxiliary, moves);

                // 将第 n 个盘子从源柱子移动到目标柱子
                moves.Add((source, destination));

                // 将 n-1 个盘子从辅助柱子移动到目标柱子
                SolveRecursive(n-1, auxiliary, source, destination, moves);
            }
        }
    }
    internal partial class DaC
	{
        [Test]
        public void Solve_OneDisk_ReturnsSingleMove() {
            int n = 1;
            var moves = HanoiTower.Solve(n, 'A', 'B', 'C');

            CollectionAssert.AreEqual(new List<(char, char)> { ('A', 'C') }, moves);
        }

        [Test]
        public void Solve_TwoDisks_ReturnsCorrectMoves() {
            int n = 2;
            var moves = HanoiTower.Solve(n, 'A', 'B', 'C');

            CollectionAssert.AreEqual(new List<(char, char)>
            {
            ('A', 'B'),  // Move disk 1 from A to B
            ('A', 'C'),  // Move disk 2 from A to C
            ('B', 'C')   // Move disk 1 from B to C
        }, moves);
        }

        [Test]
        public void Solve_ThreeDisks_ReturnsCorrectMoves() {
            int n = 3;
            var moves = HanoiTower.Solve(n, 'A', 'B', 'C');

            CollectionAssert.AreEqual(new List<(char, char)>
            {
            ('A', 'C'),  // Move disk 1 from A to C
            ('A', 'B'),  // Move disk 2 from A to B
            ('C', 'B'),  // Move disk 1 from C to B
            ('A', 'C'),  // Move disk 3 from A to C
            ('B', 'A'),  // Move disk 1 from B to A
            ('B', 'C'),  // Move disk 2 from B to C
            ('A', 'C')   // Move disk 1 from A to C
        }, moves);
        }

        [Test]
        public void Solve_FourDisks_ReturnsCorrectMoves() {
            int n = 4;
            var moves = HanoiTower.Solve(n, 'A', 'B', 'C');

            CollectionAssert.AreEqual(new List<(char, char)>
            {
            ('A', 'B'),  // Move disk 1 from A to B
            ('A', 'C'),  // Move disk 2 from A to C
            ('B', 'C'),  // Move disk 1 from B to C
            ('A', 'B'),  // Move disk 3 from A to B
            ('C', 'A'),  // Move disk 1 from C to A
            ('C', 'B'),  // Move disk 2 from C to B
            ('A', 'B'),  // Move disk 1 from A to B
            ('A', 'C'),  // Move disk 4 from A to C
            ('B', 'C'),  // Move disk 1 from B to C
            ('B', 'A'),  // Move disk 2 from B to A
            ('C', 'A'),  // Move disk 1 from C to A
            ('B', 'C'),  // Move disk 3 from B to C
            ('A', 'B'),  // Move disk 1 from A to B
            ('A', 'C'),  // Move disk 2 from A to C
            ('B', 'C')   // Move disk 1 from B to C
        }, moves);
        }

        [Test]
        public void Solve_ZeroDisks_ReturnsEmptyList() {
            int n = 0;
            var moves = HanoiTower.Solve(n, 'A', 'B', 'C');

            CollectionAssert.IsEmpty(moves);
        }
    }
}
