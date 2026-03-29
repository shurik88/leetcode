using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AlgorithmProblems
{
    public class MatrixAlgorithm
    {
        /// <summary>
        ///   Minimum swaps to arrange a binary grid      
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid/?envType=daily-question&envId=2026-03-02"/>
        /// <param name="grid">matix</param>
        /// <returns>Swaps count or -1 if impossible</returns>
        public int MinSwaps_1536(int[][] grid)
        {
            var res = 0;
            var arr = new int[grid.Length];
            for (var  i = 0; i < grid.Length; ++i)
            {
                for(var j = grid[i].Length - 1; j >= 0; --j)
                {
                    //find first right 1
                    if (grid[i][j] == 1)
                    {
                        arr[i] = j;
                        //arrSort[i] = j;
                        break;
                    }
                }
            }
            ////check posibillity
            //var arrSort = new int[grid.Length];
            //arr.CopyTo(arrSort);
            //arrSort.Sort();
            //for (var i = 0; i < arrSort.Length; ++i)
            //{
            //    if (arrSort[i] > i)
            //        return -1;
            //}
            var requiredShift = true;
            while(requiredShift)
            {
                requiredShift = false;
                var shiftUsed = false;
                for(var i = 0; i < arr.Length; ++i)
                {
                    if (arr[i] > i)
                    {
                        requiredShift = true;
                        var prev = arr[i];
                        for(var j = i + 1; j < arr.Length; ++j)
                        {
                            //(arr[j], arr[j-1]) = (arr[i], arr[i + 1]);
                            if (arr[j] <= i)
                            {
                                shiftUsed = true;
                                res += j - i;
                                arr[i] = arr[j];
                                arr[j] = prev;
                                break; 
                            }
                            else
                            {
                                (prev, arr[j]) = (arr[j], prev);
                                //prev = arr[j];
                                //arr[j] = arr[j - 1];
                            }
                        }
                        if (shiftUsed)
                            break;
                    }
                    if (requiredShift && !shiftUsed)
                        return -1;

                }
                //for(var i =0; i < arr.Length - 1; ++i)
                //{
                //    if (arr[i] > i)
                //    {
                //        requiredShift = true;
                //    }
                //    if (requiredShift && arr[i] > arr[i + 1])
                //    {
                //        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                //        shiftUsed = true;
                //        res++;
                //        break;
                //    }
                //}
                //if (requiredShift && !shiftUsed)
                //    return -1;
            }
            //var requireSort = true;
            //while(requireSort)
            //{
            //    requireSort = false;
            //    for (var i = 0; i < arr.Length - 1; ++i)
            //    {
            //        if (arr[i] > arr[i + 1])
            //        {
            //            (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
            //            res++;
            //            requireSort = true;
            //            break;

            //        }
            //    }
            //}

            return res;
        }

        /// <summary>
        ///     1727. Largest Submatrix With Rearrangements
        /// </summary>
        /// <see cref="https://leetcode.com/problems/largest-submatrix-with-rearrangements/?envType=daily-question&envId=2026-03-17"/>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LargestSubmatrix(int[][] matrix)
        {
            var res = 0;
            var rows = matrix.Length;
            var columns = matrix[0].Length;
            for(var c = 0; c < columns; ++c)
            {
                //var cum = 0;
                for(var r = 1; r < rows; ++r)
                {
                    if (matrix[r][c] != 0)
                        matrix[r][c] += matrix[r - 1][c];
                }
            }

            for(var r = 0; r < rows; ++r)
            {
                //counting sort
                int[] counts = new int[rows + 1];
                for(var c =0; c < columns; ++c)
                {
                    counts[matrix[r][c]]++;
                }
                var index = 0;
                for (int j = rows; j >= 0; j--)
                {
                    if (counts[j] > 0)
                    {
                        for (int k = 0; k < counts[j]; k++)
                        {
                            matrix[r][index] = j;
                            index++;
                        }
                    }
                }
            }

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    int curr_area = (c + 1) * matrix[r][c];
                    res = Math.Max(res, curr_area);
                }
            }


            return res;
        }

        public int GetSpecialPostionsInBinaryMatrix_1582(int[][] mat)
        {
            var res = 0;
            var rows = new int[mat.Length];
            var cols = new int[mat[0].Length];

            for(var i = 0; i < mat.Length; ++i)
            {
                for(var j = 0; j < mat[i].Length; ++j)
                {
                    if(mat[i][j] == 1)
                    {
                        rows[i]++;
                        cols[j]++;
                    }
                }
            }

            for (var i = 0; i < mat.Length; ++i)
            {
                for (var j = 0; j < mat[i].Length; ++j)
                {
                    if (mat[i][j] == 1 && rows[i] == 1 && cols[j] == 1)
                        res++;
                }
            }

            return res;
        }

        /// <summary>
        ///     3070. Count Submatrices with Top-Left Element and Sum Less Than k
        /// </summary>
        /// <see cref="https://leetcode.com/problems/count-submatrices-with-top-left-element-and-sum-less-than-k/?envType=daily-question&envId=2026-03-18"/>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubmatrices(int[][] grid, int k)
        {
            //var total = 0;
            //var rows = grid.Length;
            //var columns = grid[0].Length;
            //int[,] sub = new int[rows + 1, columns + 1];
            //for (var r = 1; r <= rows; ++r)
            //{
            //    for(var c = 1; c <= columns; ++c)
            //    {
            //        sub[r, c] = sub[r - 1, c] + sub[r, c - 1] - sub[r - 1, c - 1] + grid[r - 1][c - 1];
            //        if (sub[r, c] <= k) 
            //            ++total;
            //    }
            //}
            //return total;

            var total = 0;
            var rows = grid.Length;
            var columns = grid[0].Length;
            var columnsStop = columns;
            for (var r = 0; r < rows; ++r)
            {
                for (var c = 0; c < columnsStop; ++c)
                {
                    grid[r][c] = (r == 0 ? 0 : grid[r - 1][c]) + (c == 0 ? 0 : grid[r][c - 1]) - (r == 0 || c == 0  ? 0 : grid[r - 1][c - 1]) + grid[r][c];
                    if (grid[r][c] <= k)
                        ++total;
                    else
                    {
                        columnsStop = c;
                        if (c == 0)
                            return total;
                        break;
                    }
                }
            }
            return total;
        }

        /// <summary>
        ///     3212. Count Submatrices With Equal Frequency of X and Y
        ///     'X', 'Y', or '.'
        /// </summary>
        /// <see cref="https://leetcode.com/problems/count-submatrices-with-equal-frequency-of-x-and-y/?envType=daily-question&envId=2026-03-19"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumberOfSubmatrices(char[][] grid)
        {
            var rows = grid.Length;
            var columns = grid[0].Length;
            var sum = new int[rows,columns];
            var xexists = new bool[rows, columns];
            var total = 0;
            for(var r = 0; r < rows; ++r)
            {
                for(var c = 0; c < columns; ++c)
                {
                    var sym = grid[r][c];
                    var isX = sym == 'X';
                    var value = isX ? 1 : sym == 'Y' ? -1 : 0;
                    sum[r, c] = (r == 0 ? 0 : sum[r - 1, c]) + (c == 0 ? 0 : sum[r, c - 1]) - (r == 0 || c == 0 ? 0 : sum[r - 1, c - 1]) + value;
                    xexists[r, c] = isX || (r == 0 ? false : xexists[r - 1, c]) || (c == 0 ? false : xexists[r, c - 1]);
                    if (sum[r, c] == 0 && xexists[r, c])
                        total++;
                }
            }
            return total;
        }

        /// <summary>
        ///     3567. Minimum Absolute Difference in Sliding Submatrix
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-absolute-difference-in-sliding-submatrix/?envType=daily-question&envId=2026-03-20"/>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] MinAbsDiff(int[][] grid, int k)
        {
            var rows = grid.Length;
            var columns = grid[0].Length;
            var res = new int[rows - k + 1][];
            for(var r = 0; r <= rows - k; ++r)
            {
                res[r] = new int[columns - k + 1];
                for(var c = 0; c <= columns - k; ++c)
                {
                    var list = new List<int>(k * k);
                    for (int x = r; x < r + k; ++x)
                    {
                        for (int y = c; y < c + k; ++y)
                        {
                            list.Add(grid[x][y]);
                        }
                    }
                    list.Sort();
                    var min = int.MaxValue;
                    for (int t = 1; t < list.Count; ++t)
                    {
                        if (list[t] != list[t - 1])
                        {
                            min = Math.Min(min, Math.Abs(list[t] - list[t - 1]));
                        }
                    }

                    res[r][c] = min == int.MaxValue ? 0 : min;
                }
            }
            return res;
        }

        /// <summary>
        /// 3643. Flip Square Submatrix Vertically
        /// </summary>
        /// <see cref="https://leetcode.com/problems/flip-square-submatrix-vertically/description/?envType=daily-question&envId=2026-03-21"/>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
        {
            var rows  = grid.Length;
            var columns = grid[0].Length;
            for(var r = 0; r < k / 2; ++r)
            {
                for(var c = y; c < y + k; ++c)
                {
                    (grid[x + r][c], grid[x + k - r - 1][c]) = (grid[x + k - r - 1][c], grid[x + r][c]);
                }
            }
            return grid;
        }

        /// <summary>
        /// 1886. Determine Whether Matrix Can Be Obtained By Rotation    
        /// Можно ли из текущей матрицы(квадратная) получить целевую путем поворота
        /// </summary>
        /// <see cref="https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/?envType=daily-question&envId=2026-03-22"/>
        /// <param name="mat">Исходная матрица</param>
        /// <param name="target">Целевая матрица</param>
        /// <returns>Да/нет</returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            var len = mat.Length;
            //0:  r,c -> r,c
            //90: r, c -> c, len-r-1
            //180: c, len-r-1 -> len-r-1, len-c-1
            //270: len-r-1, len-c-1 -> len-c-1, r
            var rotate = 0;
            while (rotate <= 270)
            {
                var match = true;
                for (var r = 0; r < len; ++r)
                {
                    for (var c = 0; c < len; ++c)
                    {
                        var newR = rotate == 0 ? r : rotate == 90 ? c : rotate == 180 ? len - r - 1 : len - c - 1;
                        var newC = rotate == 0 ? c : rotate == 90 ? len - r - 1 : rotate == 180 ? len - c - 1 : r;
                        if (mat[r][c] != target[newR][newC])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (!match)
                        break;
                }
                if (match)
                    return true;
                rotate += 90;
            }
            return false;
        }

        /// <summary>
        ///     1594 maximum non negative product matrix
        /// </summary>
        /// <see cref="https://leetcode.com/problems/maximum-non-negative-product-in-a-matrix/?envType=daily-question&envId=2026-03-23"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxProductPath(int[][] grid)
        {
            const int mod = 1_000_000_007;
            int rows = grid.Length;
            int columns = grid[0].Length;
            long[,,] dp = new long[rows,columns,2];
            dp[0, 0, 0] = grid[0][0];
            dp[0, 0, 1] = grid[0][0];
            for(var c = 1; c < columns; ++c)
            {
                dp[0, c, 0] = dp[0, c - 1, 0] * grid[0][c];
                dp[0, c, 1] = dp[0, c - 1, 1] * grid[0][c];
            }
            for (var r = 1; r < rows; ++r)
            {
                dp[r, 0, 0] = dp[r-1, 0, 0] * grid[r][0];
                dp[r, 0, 1] = dp[r-1, 0, 1] * grid[r][0];
            }

            for(var r = 1; r < rows; ++r)
            {
                for(var c = 1; c < columns; ++c)
                {
                    var val = grid[r][c];
                    if(val >= 0)
                    {
                        dp[r, c, 0] = Math.Min(dp[r - 1, c, 0], dp[r, c - 1, 0]) * val;
                        dp[r, c, 1] = Math.Max(dp[r - 1, c, 1], dp[r, c- 1, 1]) * val;
                    }
                    else
                    {
                        dp[r, c, 0] = Math.Max(dp[r - 1, c, 1], dp[r, c - 1, 1]) * val;
                        dp[r, c, 1] = Math.Min(dp[r - 1, c, 0], dp[r, c - 1, 0]) * val;
                    }
                }
            }

            var res = dp[rows - 1, columns - 1, 1];
            return res < 0 ? - 1 : (int)(res % mod);
        }

        /// <summary>
        ///     2906 construct product matrix
        /// </summary>
        /// <see cref="https://leetcode.com/problems/construct-product-matrix/?envType=daily-question&envId=2026-03-24"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] ConstructProductMatrix(int[][] grid)
        {
            const int mod = 12345;
            var rows = grid.Length;
            var columns = grid[0].Length;
            int[][] p = new int[rows][];
            for (var r = 0; r < rows; r++)
            {
                p[r] = new int[columns];
            }

            long suf = 1;
            for(var r = rows - 1; r >= 0; r--)
            {
                for (var c = columns - 1; c >= 0; c--)
                {
                    p[r][c] = (int)(suf % mod);
                    suf = suf * grid[r][c] % mod;
                }
            }
            long pre = 1;
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    p[r][c] = (int)(p[r][c] * pre % mod);
                    pre = pre * grid[r][c] % mod;
                }
            }
            return p;
        }

        /// <summary>
        ///     2946. Matrix Similarity After Cyclic Shifts
        /// </summary>
        /// <see cref="https://leetcode.com/problems/matrix-similarity-after-cyclic-shifts/description/?envType=daily-question&envId=2026-03-27"/>
        /// <returns></returns>
        public bool AreSimilar(int[][] mat, int k)
        {
            var rows = mat.Length;
            var cols = mat[0].Length;
            var remain = k % cols;
            if (remain == 0)
                return true;

            for(var r = 0; r < rows; r++)
            {
                //var curr = new int[cols];
                for(var c = 0; c < cols; c++)
                {
                    var shiftIndex = r % 2 == 0
                        ? (cols - remain + c) % cols
                        : (c + remain) % cols;
                    if (mat[r][c] != mat[r][shiftIndex])
                        return false;
                    //if (r % 2 == 0)
                    //{
                    //    var shiftIndex = (cols - remain + c) % cols;
                    //}
                    //else
                    //{
                    //    var shiftIndex = (c + remain) % cols;
                    //    if (mat[r][c] != mat[r][shiftIndex])
                    //        return false;
                    //}
                }
            }
            return true;
        }

        /// <summary>
        /// 3546. Equal Sum Grid Partition I
        /// </summary>
        /// <see cref="https://leetcode.com/problems/equal-sum-grid-partition-i/description/?envType=daily-question&envId=2026-03-25"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CanPartitionGrid(int[][] grid)
        {
            var sum = 0L;
            var rows = grid.Length;
            var columns = grid[0].Length;

            for(var r = 0; r < rows; r++)
                for(var c=0; c < columns; c++)
                    sum+= grid[r][c];

            if (sum % 2 != 0)
                return false;

            var half = sum / 2;
            var sumTemp = 0L;
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    sumTemp += grid[r][c];
                }
                if (sumTemp == half)
                    return true;

                if (sumTemp > half)
                    break;
            }

            sumTemp = 0L;
            for(var c = 0; c < columns; ++c)
            {
                for(var r = 0; r < rows; r++)
                {
                    sumTemp+= grid[r][c];
                }
                if (sumTemp == half)
                    return true;

                if (sumTemp > half)
                    break;
            }

            return false;
            //return CanPartitionHorizontalGrid(grid) || CanPartitionVerticalGrid(grid);
        }

        private bool CanPartitionHorizontalGrid(int[][] grid)
        {
            if (grid.Length == 1)
                return false;
            
            var rows = grid.Length;
            var ind1 = 0;
            var ind2 = rows;
            var sum1 = 0;
            var sum2 = 0;
            while(ind1 != ind2)
            {
                if (sum1 <= sum2)
                {
                    ind1++;
                    for(var c = 0; c < grid[ind1].Length; c++)
                        sum1+= grid[ind1-1][c];
                }
                else
                {
                    ind2--;
                    for (var c = 0; c < grid[ind1].Length; c++)
                        sum2 += grid[ind2][c];
                }
            }
            return sum1 == sum2;
        }

        private bool CanPartitionVerticalGrid(int[][] grid)
        {
            if (grid[0].Length == 1)
                return false;

            var columns = grid[0].Length;
            var rows = grid.Length;
            var ind1 = 0;
            var ind2 = columns;
            var sum1 = 0;
            var sum2 = 0;
            while (ind1 != ind2)
            {
                if (sum1 <= sum2)
                {
                    ind1++;
                    for (var r = 0; r < rows; r++)
                        sum1 += grid[r][ind1-1];
                }
                else
                {
                    ind2--;
                    for (var r = 0; r < rows; r++)
                        sum2 += grid[r][ind2];
                }
            }
            return sum1 == sum2;
        }
    }
}
