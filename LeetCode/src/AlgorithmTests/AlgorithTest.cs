using AlgorithmProblems;
using FluentAssertions;
using System.Text;

namespace AlgorithmTests
{
    /// <summary>
    /// Summary description for BinaryGapTest_868
    /// </summary>
    [TestClass]
    public class AlgorithTest
    {

        [TestMethod]
        [DataRow(5, 2)]
        [DataRow(22, 2)]
        [DataRow(8, 0)]
        [DataRow(29, 2)]
        public void BinaryGap(int number, int result)
        {
            var sut = new BinaryGap_868();


            sut.BinaryGap(number).Should().Be(result);
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        [DataRow(5, true)]
        [DataRow(121, true)]
        [DataRow(-121, false)]
        [DataRow(10, false)]
        [DataRow(11, true)]
        public void PalindromeNumber(int n, bool res)
        {
            var sut = new PalindromeNumber_9();
            sut.IsPalindromeBest(n).Should().Be(res);
        }

        [TestMethod]
        [DataRow("babad", "bab")]
        [DataRow("cbbd", "bb")]
        public void LongestPalindromicSubstring(string str, string res)
        {
            var sut = new LongestPalindromicSubstring_5();
            sut.LongestPalindrome(str).Should().Be(res);
        }

        [TestMethod]
        [DataRow("00110110", 2, true)]
        [DataRow("0110", 1, true)]
        [DataRow("0110", 2, false)]
        public void CheckIfStringContainsAllBinaryCodes(string str, int k, bool res)
        {
            var sut = new CheckIfStringContainsAllBinaryCodes_1461();
            sut.HasAllCodes(str, k).Should().Be(res);

        }

        [TestMethod]
        [DataRow(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [DataRow(new int[] { 1, 1 }, 1)]
        public void ContainerWithMostWater(int[] arr, int res)
        {
            var sut = new ContainerWithMostWater_11();
            sut.MaxArea(arr).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { -1, 2, 1, -4 }, 1, 2)]
        [DataRow(new int[] { 0, 0, 0 }, 1, 0)]
        [DataRow(new int[] { 7, 8, 9 }, -1, 24)]
        public void Sum3ClosestTest(int[] arr, int target, int res)
        {
            var sut = new Sum3_15();
            sut.ClosestSum(arr, target).Should().Be(res);
        }

        [TestMethod]
        public void LetterCombinationsOfPhoneNumbers()
        {
            var sut = new LetterCombinationsOfPhoneNumbers_17();
            var res = sut.LetterCombinations("23");
        }

        [TestMethod]
        [DataRow(3, 5)]
        [DataRow(2, 2)]
        [DataRow(1, 1)]
        public void Generate_Parentheses(int npair, int count)
        {
            var sut = new Generate_Parentheses_22();
            sut.GenerateParenthesis(npair).Should().HaveCount(count);
        }

        [TestMethod]
        [DataRow("1101", 6)]
        [DataRow("10", 1)]
        [DataRow("1", 0)]
        public void NumberOfStepsToReduceANumberInBinaryRepToOne(string input, int output)
        {
            var sut = new BinaryAlgorithm();
            sut.NumSteps_1404(input).Should().Be(output);
        }

        [TestMethod]
        [DataRow(5, 0, 4)]
        [DataRow(19, 2, 7)]
        [DataRow(10, 4, 4)]
        //[DataRow(766972377, 92, 4)]
        public void MinimumMovesToReachTargetScore(int target, int maxDoubles, int steps)
        {
            var sut = new MinMovesToTarget_2139();
            sut.MinMoves(target, maxDoubles).Should().Be(steps);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(3, 27)]
        [DataRow(12, 505379714)]
        public void ConcatenationOfConsecutiveBinaryNumbers(int maxNumber, int result)
        {
            var sut = new BinaryAlgorithm();
            sut.ConcatenatedBinary_1680(maxNumber).Should().Be(result);
        }

        [TestMethod]
        [DataRow("32", 3)]
        [DataRow("82734", 8)]
        [DataRow("27346209830709182346", 9)]
        public void MinNumberPartitions(string number, int res)
        {
            var sut = new NumbersAlgorithm();
            sut.MinPartitions_1689(number).Should().Be(res);
        }

        public class MatrixData
        {
            public int[][] Input { get; set; }

            public int Result { get; set; }
        }

        private static IEnumerable<MatrixData> GetMatrixMinSwapData()
        {
            yield return new MatrixData { Input = [[0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0], [0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0], [1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0], [1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0], [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0], [1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0], [0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0], [1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0], [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]], Result = 12 };
            yield return new MatrixData { Input = [[0, 0, 1], [1, 1, 0], [1, 0, 0]], Result = 3 };
            yield return new MatrixData { Input = [[1, 0, 0], [1, 1, 0], [1, 1, 1]], Result = 0 };
            yield return new MatrixData { Input = [[0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0]], Result = -1 };
            yield return new MatrixData { Input = [[1, 0, 0, 0, 0, 0], [0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 1, 0], [0, 0, 1, 0, 0, 0], [0, 1, 0, 0, 0, 0], [0, 0, 0, 0, 0, 1]], Result = 5 };
            yield return new MatrixData { Input = [[1, 0, 0, 0, 0, 0], [0, 1, 0, 1, 0, 0], [1, 0, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0], [1, 1, 0, 1, 0, 0], [1, 0, 0, 0, 0, 0]], Result = 2 };
            yield return new MatrixData { Input = [[1, 0, 0, 0, 0, 0], [0, 0, 0, 1, 0, 0], [0, 0, 0, 1, 0, 0], [0, 1, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0], [0, 0, 0, 0, 0, 1]], Result = 4 };
        }

        private static IEnumerable<MatrixData> GetSpecialPostionsInBinaryMatrixData()
        {
            yield return new MatrixData { Input = [[1, 0, 0], [0, 0, 1], [1, 0, 0]], Result = 1 };
            yield return new MatrixData { Input = [[1, 0, 0], [0, 1, 0], [0, 0, 1]], Result = 3 };
        }


        [TestMethod]
        [DynamicData(nameof(GetMatrixMinSwapData))]
        public void MatrixMinSwaps(MatrixData data)
        {
            var sut = new MatrixAlgorithm();
            sut.MinSwaps_1536(data.Input).Should().Be(data.Result);
        }

        [TestMethod]
        [DynamicData(nameof(GetSpecialPostionsInBinaryMatrixData))]
        public void GetSpecialPostionsInBinaryMatrix(MatrixData data)
        {
            var sut = new MatrixAlgorithm();
            sut.GetSpecialPostionsInBinaryMatrix_1582(data.Input).Should().Be(data.Result);
        }

        //[TestMethod]
        ////[DataRow(10,3, 3)]
        ////[DataRow(7, -3, -2)]
        //[DataRow(-2147483648, -1, 2147483647)]
        //public void DivideNumbers(int divident, int divisor, int result)
        //{
        //    var sut = new NumbersAlgorithm();
        //    sut.Divide_29(divident, divisor).Should().Be(result);
        //}

        [TestMethod]
        [DataRow(3, 1,'0')]
        [DataRow(4, 11, '1')]
        public void FindKthBit_1545(int n, int k, char res)
        {
            var sut = new BinaryAlgorithm();
            sut.FindKthBit_1545(n, k).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int [] {-1, -1, -1})]
        [DataRow(new int[] { 1, 2, 3, 4 }, new int[] { -1, -1, -1, -1 })]
        [DataRow(new int[] { 1, 2, 0, 0, 2, 1 }, new int[] { -1, -1, 2, 1, -1, -1 })]
        [DataRow(new int[] { 1, 2, 0, 1, 3, 0, 4, 5, 0, 0, 5, 4, 3, 0, 2 }, new int[] { -1, -1, 1, -1, -1, 3, -1, -1, 5, 4, -1, -1, -1, 2, -1  })]
        [DataRow(new int[] { 1, 0, 2, 0, 3, 0, 2, 0, 0, 0, 1, 2, 3 }, new int[] { -1, 1, -1, 2, -1, 3, -1, 2, 1, 1, -1, -1, -1 })]
        public void AvoidFlood(int[] rains, int[] res)
        {
            var sut = new LifeProblem();
            sut.AvoidFlood_1488(rains).Should().Equal(res);
        }

        [TestMethod]
        [DataRow("0100", 1)]
        [DataRow("10", 0)]
        [DataRow("1111", 2)]
        public void MinOperations_1758(string s, int res)
        {
            var sut = new BinaryAlgorithm();
            sut.MinOperations_1758(s).Should().Be(res);
        }

        [TestMethod]
        [DataRow("111000", 2)]
        [DataRow("10", 0)]
        [DataRow("010", 0)]
        [DataRow("1110", 1)]
        [DataRow("01001001101", 2)]
        public void MinFlips_1888(string s, int res)
        {
            var sut = new BinaryAlgorithm();
            sut.MinFlips_1888(s).Should().Be(res);
        }

        [TestMethod]
        [DataRow("1001", false)]
        [DataRow("110", true)]
        public void CheckOnesSegment_1784(string s, bool res)
        {
            var sut = new BinaryAlgorithm();
            sut.CheckOnesSegment_1784(s).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new string[] { "01", "10" }, "11")]
        [DataRow(new string[] { "00", "01" }, "10")]
        [DataRow(new string[] { "111", "011", "001" }, "000")]
        public void FindDifferentBinaryString_1980(string[] s, string res)
        {
            var sut = new BinaryAlgorithm();
            sut.FindDifferentBinaryString_1980(s).Should().Be(res);
        }

        [TestMethod]
        [DataRow(5, 2)]
        [DataRow(7, 0)]
        [DataRow(10, 5)]
        [DataRow(2, 1)]
        [DataRow(3, 0)]
        public void ComplementofBase10Integer_1009(int n, int res)
        {
            var sut = new BinaryAlgorithm();
            sut.ComplementofBase10Integer_1009(n).Should().Be(res);
        }
    }
}
