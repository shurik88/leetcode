using AlgorithmProblems;
using AlgorithmProblems.DFS;
using FluentAssertions;
using System.Text;
using static AlgorithmTests.AlgorithTest;

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

        public class MatrixData<T, TResult>
            where T : struct
            where TResult: struct
        {
            public T[][] Input { get; set; }

            public TResult Result { get; set; }
        }

        private static IEnumerable<MatrixData<int, int>> GetMatrixMinSwapData()
        {
            yield return new MatrixData<int, int> { Input = [[0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0], [0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0], [1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0], [1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0], [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0], [1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0], [0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0], [1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0], [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]], Result = 12 };
            yield return new MatrixData<int, int> { Input = [[0, 0, 1], [1, 1, 0], [1, 0, 0]], Result = 3 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0], [1, 1, 0], [1, 1, 1]], Result = 0 };
            yield return new MatrixData<int, int> { Input = [[0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0], [0, 1, 1, 0]], Result = -1 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0, 0, 0, 0], [0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 1, 0], [0, 0, 1, 0, 0, 0], [0, 1, 0, 0, 0, 0], [0, 0, 0, 0, 0, 1]], Result = 5 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0, 0, 0, 0], [0, 1, 0, 1, 0, 0], [1, 0, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0], [1, 1, 0, 1, 0, 0], [1, 0, 0, 0, 0, 0]], Result = 2 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0, 0, 0, 0], [0, 0, 0, 1, 0, 0], [0, 0, 0, 1, 0, 0], [0, 1, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0], [0, 0, 0, 0, 0, 1]], Result = 4 };
        }

        private static IEnumerable<MatrixData<int, int>> GetSpecialPostionsInBinaryMatrixData()
        {
            yield return new MatrixData<int, int> { Input = [[1, 0, 0], [0, 0, 1], [1, 0, 0]], Result = 1 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0], [0, 1, 0], [0, 0, 1]], Result = 3 };
        }


        [TestMethod]
        [DynamicData(nameof(GetMatrixMinSwapData))]
        public void MatrixMinSwaps(MatrixData<int, int> data)
        {
            var sut = new MatrixAlgorithm();
            sut.MinSwaps_1536(data.Input).Should().Be(data.Result);
        }

        [TestMethod]
        [DynamicData(nameof(GetSpecialPostionsInBinaryMatrixData))]
        public void GetSpecialPostionsInBinaryMatrix(MatrixData<int, int> data)
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

        [TestMethod]
        [DataRow(4, new int[] { 2, 1, 1 }, 3)]
        [DataRow(10, new int[] { 3, 2, 2, 4 }, 12)]
        [DataRow(5, new int[] { 1 }, 15)]
        [DataRow(5, new int[] { 1, 7 }, 10)]
        [DataRow(100000, new int[] { 1  }, 5000050000)]
        [DataRow(100000, new int[] { 1000000 }, 5000050000000000)]
        public void MinNumberOfSeconds_3296(int mountainHeight, int[] workerTimes, long res)
        {
            var sut = new LifeProblem();
            sut.MinNumberOfSeconds_3296(mountainHeight, workerTimes).Should().Be(res);
        }

        [TestMethod]
        [DataRow(1, 3, "c")]
        [DataRow(1, 4, "")]
        [DataRow(3, 9, "cab")]
        public void GetHappyString_1415(int n, int k, string res)
        {
            var sut = new StringAlgorithm();
            sut.GetHappyString_1415(n, k).Should().Be(res);
        }

        private static IEnumerable<MatrixData<int, int>> GetLargestSubmatrixData()
        {
            yield return new MatrixData<int, int> { Input = [[0, 0, 1], [1, 1, 1], [1, 0, 1]], Result = 4 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 1, 0, 1]], Result = 3 };
        }

        [TestMethod]
        [DynamicData(nameof(GetLargestSubmatrixData))]
        public void LargestSubmatrix_1727(MatrixData<int, int> data)
        {
            var sut = new MatrixAlgorithm();
            sut.LargestSubmatrix(data.Input).Should().Be(data.Result);
        }

        private static IEnumerable<MatrixData<char, int>> GetNumberOfSubmatrices_3212()
        {
            yield return new MatrixData<char, int> { Input = [['X', 'Y', '.'], ['Y', '.', '.']], Result = 3 };
            yield return new MatrixData<char, int> { Input = [['X', 'X'], ['X', 'Y']], Result = 0 };
            yield return new MatrixData<char, int> { Input = [['.', '.'], ['.', '.']], Result = 0 };
        }

        [TestMethod]
        [DynamicData(nameof(GetNumberOfSubmatrices_3212))]
        public void NumberOfSubmatrices_3212(MatrixData<char, int> data)
        {
            var sut = new MatrixAlgorithm();
            sut.NumberOfSubmatrices(data.Input).Should().Be(data.Result);
        }

        //[TestMethod]
        //public void ReverseSubmatrix()
        //{
        //    var sut = new MatrixAlgorithm();
        //    int[][] data = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12], [13, 14, 15, 16]];
        //    var res = sut.ReverseSubmatrix(data, 1, 0, 3);
        //}

        private static IEnumerable<MatrixData<int, bool>> GetCanPartitionGrid_3546()
        {
            yield return new MatrixData<int, bool> { Input = [[54756, 54756]], Result = true };
            yield return new MatrixData<int, bool> { Input = [[1, 4], [2, 3]], Result = true };
            yield return new MatrixData<int, bool> { Input = [[1, 3], [2, 4]], Result = false };
            yield return new MatrixData<int, bool> { Input = [[65917, 79299]], Result = false };
        }
        [TestMethod]
        [DynamicData(nameof(GetCanPartitionGrid_3546))]
        public void CanPartitionGrid_3546(MatrixData<int, bool> data)
        {
            var sut = new MatrixAlgorithm();
            sut.CanPartitionGrid(data.Input).Should().Be(data.Result);
        }

        public class MatrixSimilarData
        {
            public MatrixData<int, bool> Data { get; set; }

            public int K { get; set; }
        }
        private static IEnumerable<MatrixSimilarData> GetAreSimilar_2946()
        {
            yield return new MatrixSimilarData { Data = new MatrixData<int, bool> { Input = [[1, 2, 3], [4, 5, 6], [7, 8, 9]], Result = false }, K = 4 };
            yield return new MatrixSimilarData { Data = new MatrixData<int, bool> { Input = [[1, 2, 1, 2], [5, 5, 5, 5], [6, 3, 6, 3]], Result = true }, K = 2 };
            yield return new MatrixSimilarData { Data = new MatrixData<int, bool> { Input = [[2, 2], [2, 2]], Result = true }, K = 3 };
        }


        [TestMethod]
        [DynamicData(nameof(GetAreSimilar_2946))]
        public void AreSimilar_2946(MatrixSimilarData data)
        {
            var sut = new MatrixAlgorithm();
            sut.AreSimilar(data.Data.Input, data.K).Should().Be(data.Data.Result);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 3, 1, 4, 1, 3, 2 }, new int[] { 0, 3, 5 }, new int[] { 2, -1, 3 })]
        public void SolveQueries_3488(int[] nums, int[] queries, int[] expectedMinDistances)
        {
            var sut = new ArrayAlgorithm();
            sut.SolveQueries(nums, queries).ToArray().Should().Equal(expectedMinDistances);
        }

        [TestMethod]
        [DataRow(new int[] { 55, 30, 5, 4, 2 }, new int[] { 100, 20, 10, 10, 5 }, 2)]
        [DataRow(new int[] { 2, 2, 2 }, new int[] { 10, 10, 1 }, 1)]
        [DataRow(new int[] { 30, 29, 19, 5 }, new int[] { 25, 25, 25, 25, 25 }, 2)]
        [DataRow(new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 }, 2)]
        public void MaxDistance_1855(int[] nums1, int[] nums2, int expected)
        {
            var reverseComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            //var index = Array.BinarySearch(nums2, 10, reverseComparer);
            //var t = ~index;
            var sut = new ArrayAlgorithm();
            sut.MaxDistance(nums1, nums2).Should().Be(expected);
        }

        private static IEnumerable<MatrixData<int, bool>> GetHasValidPath_1391()
        {
            yield return new MatrixData<int, bool> { Input = [[2, 4, 3], [6, 5, 2]], Result = true };
            yield return new MatrixData<int, bool> { Input = [[1, 2, 1], [1, 2, 1]], Result = false };
            yield return new MatrixData<int, bool> { Input = [[1, 1, 1, 1, 1, 1, 3]], Result = true };
        }

        [TestMethod]
        [DynamicData(nameof(GetHasValidPath_1391))]
        public void HasValidPath_1391(MatrixData<int, bool> data)
        {
            var sut = new Solution_1391();
            sut.HasValidPath(data.Input).Should().Be(data.Result);
        }

        public class MinOperationsData_2033
        {
            public MatrixData<int, int> Data { get; set; }

            public int X { get; set; }
        }

        private static IEnumerable<MinOperationsData_2033> GetMinOperationsData_2033()
        {
            yield return new MinOperationsData_2033 { Data = new MatrixData<int, int> { Input = [[2, 4], [6, 8]], Result = 4 }, X = 2 };
            yield return new MinOperationsData_2033 { Data = new MatrixData<int, int> { Input = [[1, 5], [2, 3]], Result = 5 }, X = 1 };
            yield return new MinOperationsData_2033 { Data = new MatrixData<int, int> { Input = [[1, 2], [3, 4]], Result = -1 }, X = 2 };
        }

        [TestMethod]
        [DynamicData(nameof(GetMinOperationsData_2033))]
        public void MinOperations_2033(MinOperationsData_2033 data)
        {
            var sut = new ArrayAlgorithm();
            sut.MinOperations_2033(data.Data.Input, data.X).Should().Be(data.Data.Result);
        }

        public class MatrixIntResultIntParam<TArrayType, TResult, TParam>
            where TArrayType : struct
            where TResult : struct
            where TParam : struct
        {
            public MatrixData<TArrayType, TResult> Data { get; set; }

            public TParam P { get; set; }
        }

        private static IEnumerable<MatrixIntResultIntParam<int, int, int>> GetMaxPathScore_3742()
        {
            yield return new MatrixIntResultIntParam<int, int, int> { Data = new MatrixData<int, int> { Input = [[0, 1], [2, 0]], Result = 2 }, P = 1 };
            yield return new MatrixIntResultIntParam<int, int, int> { Data = new MatrixData<int, int> { Input = [[0, 1], [1, 2]], Result = -1 },P = 1 };
        }

        [TestMethod]
        [DynamicData(nameof(GetMaxPathScore_3742))]
        public void MaxPathScore_3742(MatrixIntResultIntParam<int, int, int> testCase)
        {
            var sut = new GridAlgorithm();
            sut.MaxPathScore_3742(testCase.Data.Input, testCase.P).Should().Be(testCase.Data.Result);
        }
    }
}
