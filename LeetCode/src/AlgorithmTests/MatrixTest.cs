using AlgorithmProblems;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void Rotate_48()
        {
            int[][] t = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];//[[1, 2], [3, 4]];//[[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            var sut = new MatrixAlgorithm();
            sut.Rotate_48(t);

        }

        [TestMethod]
        public void RotateGrid_1914()
        {
            var sut = new MatrixAlgorithm();


        }

        [TestMethod]
        [DataRow(0, 4, 6, 2, 2, 2)]
        [DataRow(2, 4, 6, 2, 2, 4)]
        [DataRow(4, 4, 6, 2, 2, 6)]
        [DataRow(5, 4, 6, 2, 2, 8)]
        [DataRow(6, 4, 6, 2, 3, 8)]
        [DataRow(9, 4, 6, 2, 6, 6)]
        [DataRow(14, 4, 6, 2, 4, 2)]
        [DataRow(15, 4, 6, 2, 3, 2)]
        public void RotateLevel(int plainIndex, int rectRow, int rectcolumn, int rotateLevel, int expRow, int expCol)
        {
            GetIndexes(plainIndex, rectRow, rectcolumn, rotateLevel).Should().BeEquivalentTo((Row: expRow, Column: expCol));
        }

        static (int Row, int Column) GetIndexes(int plainIndex, int rectRow, int rectColumn, int rotateLevel)
        {
            if (plainIndex < rectColumn - 1)
            {
                return (rotateLevel, rotateLevel + plainIndex);
            }
            else if (plainIndex < rectRow + rectColumn - 2)
            {
                var diff = plainIndex + 1 - rectColumn;
                return (rotateLevel + diff, rotateLevel + rectColumn);
            }
            else if (plainIndex < rectRow * 2 + rectColumn - 3)
            {
                var diff = plainIndex - rectColumn - rectRow + 2;
                return (rotateLevel + rectRow, rotateLevel + rectColumn - diff - 1);
            }
            else
            {
                var diff = plainIndex - rectColumn - rectRow - rectColumn + 3;
                return (rotateLevel + rectRow - diff - 1, rotateLevel);
            }
        }
    }
}
