using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class ArrayAlgorithm
    {
        /// <summary>
        /// 2144. Minimum Cost of Buying Candies With Discount
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount/description/?envType=daily-question&envId=2026-06-01"/>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinimumCost_2144(int[] cost)
        {
            Array.Sort(cost);
            var sum = 0;
            var step = 0;
            for (var i = cost.Length - 1; i >= 0; i--)
            {
                sum += cost[i];
                step++;
                if (step == 2 && i > 0)
                {
                    i--;
                    step = 0;
                }
            }
            return sum;
        }

        /// <summary>
        /// 3740. Minimum Distance Between Three Equal Elements I
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-distance-between-three-equal-elements-i/description/?envType=daily-question&envId=2026-04-10"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumDistance_3740(int[] nums)
        {
            var res = Int32.MaxValue;
            var temp = new int[101, 3];
            for (var i = 0; i <= 100; ++i)
            {
                temp[i, 0] = -1;
                temp[i, 1] = -1;
                temp[i, 2] = -1;
            }
            for (var i = 0; i < nums.Length; ++i)
            {
                var elem = nums[i];
                if (temp[elem, 0] == -1)
                {
                    temp[elem, 0] = i;
                    continue;
                }
                else if (temp[elem, 1] == -1)
                {
                    temp[elem, 1] = i;
                    continue;
                }
                else if (temp[elem, 2] == -1)
                {
                    temp[elem, 2] = i;
                }
                else
                {
                    (temp[elem, 0], temp[elem, 1], temp[elem, 2]) = (temp[elem, 1], temp[elem, 2], i);
                }
                res = Math.Min(res, 2 * (temp[elem, 2] - temp[elem, 0]));
            }
            return res == Int32.MaxValue ? -1 : res;
        }

        /// <summary>
        ///     3741. Minimum Distance Between Three Equal Elements II
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-distance-between-three-equal-elements-ii/?envType=daily-question&envId=2026-04-11"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumDistance_3741(int[] nums)
        {
            var res = Int32.MaxValue;
            var dict = new Dictionary<int, int[]>();
            // var temp = new int[100001, 3];
            // for (var i = 0; i <= 100000; ++i)
            // {
            //     temp[i, 0] = -1;
            //     temp[i, 1] = -1;
            //     temp[i, 2] = -1;
            // }
            for (var i = 0; i < nums.Length; ++i)
            {
                var elem = nums[i];
                if (!dict.ContainsKey(elem))
                {
                    dict.Add(elem, new int[3] { i, -1, -1 });
                    //temp[elem, 0] = i;
                    continue;
                }
                else if (dict[elem][1] == -1)
                {
                    dict[elem][1] = i;
                    continue;
                }
                else if (dict[elem][2] == -1)
                {
                    dict[elem][2] = i;
                }
                else
                {
                    var arr = dict[elem];
                    (arr[0], arr[1], arr[2]) = (arr[1], arr[2], i);
                }
                res = Math.Min(res, 2 * (dict[elem][2] - dict[elem][0]));
            }
            return res == Int32.MaxValue ? -1 : res;
        }

        /// <summary>
        /// 1848. Minimum Distance to the Target Element.
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-distance-to-the-target-element/?envType=daily-question&envId=2026-04-13"/>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int GetMinDistance(int[] nums, int target, int start)
        {
            var step = 0;
            while (start + step < nums.Length || start - step >= 0)
            {
                if (start + step < nums.Length && nums[start + step] == target)
                    return step;
                if (start - step >= 0 && nums[start - step] == target)
                    return step;
                step++;
            }
            return step;
        }

        /// <summary>
        ///     3488. Closest Equal Element Queries
        /// </summary>
        /// <see cref="https://leetcode.com/problems/closest-equal-element-queries/?envType=daily-question&envId=2026-04-16"/>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<int> SolveQueries(int[] nums, int[] queries)
        {
            var res = new List<int>(queries.Length);
            var grouped = new Dictionary<int, List<int>>();
            for(var i = 0; i < nums.Length; ++i)
            {
                if (!grouped.TryGetValue(nums[i], out var list))
                    grouped[nums[i]] = new List<int> { i };
                else
                {
                    list.Add(i);
                }
            }

            for (var i = 0; i < queries.Length; ++i)
            {
                var query = queries[i];
                if (query < 0 || query >= nums.Length)
                {
                    res.Add(-1);
                    continue;
                }
                var list = grouped[nums[query]];
                if (list.Count == 1)
                {
                    res.Add(-1);
                    continue;
                }

                var startIndex = list.BinarySearch(query);
                var leftIndex = (startIndex - 1 + list.Count) % list.Count;
                var rightIndex = (startIndex + 1) % list.Count;
                var leftDistance = Math.Abs(list[leftIndex] - list[startIndex]);
                var rightDistance = Math.Abs(list[rightIndex] - list[startIndex]);

                var min = Math.Min(Math.Min(leftDistance, nums.Length - leftDistance), Math.Min(rightDistance, nums.Length - rightDistance));
                
                res.Add(min);
            }

            return res;
        }

        /// <summary>
        /// 3761 minimum absolute distance between mirror pairs
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-absolute-distance-between-mirror-pairs/?envType=daily-question&envId=2026-04-17"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMirrorPairDistance(int[] nums)
        {
            var minDistance = nums.Length + 1;

            var dictReverse = new Dictionary<int, int>();
            for(var  i = 0; i < nums.Length; ++i)
            {
                if(dictReverse.TryGetValue(nums[i], out var result))
                {
                    minDistance = Math.Min(minDistance, i - result);
                }
                var reverse = Reverse(nums[i]);
                dictReverse[reverse] = i;
            }

            return minDistance == nums.Length + 1 ? -1 : minDistance;
        }

        private static int Reverse(int n)
        {
            long reverse = 0;
            while(n != 0)
            {
                reverse = reverse * 10 + (n % 10);
                n /= 10;
            }
            return (int)reverse;

        }

        /// <summary>
        ///     3783. Mirror Distance of an Integer
        /// </summary>
        /// <see cref="https://leetcode.com/problems/mirror-distance-of-an-integer/description/?envType=daily-question&envId=2026-04-18"/>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MirrorDistance(int n)
        {
            var reverse = Reverse(n);
            return Math.Abs(reverse - n);
        }

        /// <summary>
        ///     1855. Maximum Distance Between a Pair of Values
        /// </summary>
        /// <see cref="https://leetcode.com/problems/maximum-distance-between-a-pair-of-values/?envType=daily-question&envId=2026-04-19"/>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            var reverseComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            var max = 0;
            for(var i = 0; i < nums1.Length; ++i)
            {
                var index = Array.BinarySearch(nums2, nums1[i], reverseComparer);
                var exact = index >= 0;
                if(index >= 0)
                {
                    while (index + 1 < nums2.Length && nums2[index] == nums2[index + 1])
                        index++;
                }
                else
                {
                    index = ~index;
                }
                    
                if (index >= i)
                    max = Math.Max(max, index - i - (exact ? 0 : 1));
                //
            }
            return max;
        }

        /// <summary>
        ///     1855. Maximum Distance Between a Pair of Values
        /// </summary>
        /// <see cref="https://leetcode.com/problems/maximum-distance-between-a-pair-of-values/?envType=daily-question&envId=2026-04-19"/>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxDistance_2(int[] nums1, int[] nums2)
        {
            int maxDist = 0;
            int i = 0;
            int j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                // If the condition is met, update maxDist and try a larger j
                if (nums1[i] <= nums2[j])
                {
                    maxDist = Math.Max(maxDist, j - i);
                    j++;
                }
                else
                {
                    // If not met, increment i to find a smaller value in nums1
                    i++;
                }
            }

            return maxDist;
        }

        /// <summary>
        ///     2615 Sum of distances
        /// </summary>
        /// <see cref="https://leetcode.com/problems/sum-of-distances/?envType=daily-question&envId=2026-04-23"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long[] Distance(int[] nums)
        {
            var count = nums.Length;
            //int[] indices = [.. Enumerable.Range(0, count)];
            //Array.Sort(nums, indices);
            var dict = new Dictionary<int, List<int>>();
            for(var  i = 0; i < count; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = [];
                }
                dict[nums[i]].Add(i);
            }

            var res = new long[count];
            foreach (var group in dict.Values)
            {
                var groupCount = group.Count;
                if (groupCount == 1)
                    continue;
                long totalSum = 0;
                foreach (int index in group) 
                    totalSum += index;
                
                long leftSum = 0;
                for (int i = 0; i < groupCount; i++)
                {
                    long currentIdx = group[i];
                    // Formula: (currentIdx * count of elements to left - leftSum) + 
                    //          (rightSum - currentIdx * count of elements to right)
                    long rightSum = totalSum - leftSum - currentIdx;

                    long leftDist = (long)i * currentIdx - leftSum;
                    long rightDist = rightSum - (long)(groupCount - 1 - i) * currentIdx;

                    res[currentIdx] = leftDist + rightDist;
                    leftSum += currentIdx;
                }
            }
            //while()

            return res;
        }

        /// <summary>
        ///     2033. Minimum Operations to Make a Uni-Value Grid
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/?envType=daily-question&envId=2026-04-28"/>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MinOperations_2033(int[][] grid, int x)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var arr = new int[rows * cols];
            var remain = grid[0][0] % x;
            var opsCount = 0;
            for (var r = 0; r < rows; ++r)
            {
                for (var c = 0; c < cols; ++c)
                {
                    if (grid[r][c] % x != remain)
                        return -1;

                    arr[r * cols + c] = grid[r][c];
                }
            }
            Array.Sort(arr);
            var medI = arr.Length / 2;
            var med = arr[medI];
            for (var i = 0; i < arr.Length; ++i)
                opsCount += Math.Abs(arr[i] - med) / x;
            return opsCount;

        }


        /// <summary>
        ///     396 RotateFunction
        /// </summary>
        /// <see cref="https://leetcode.com/problems/rotate-function/?envType=daily-question&envId=2026-05-01"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxRotateFunction_396(int[] nums)
        {
            if (nums.Length < 2)
                return 0;

            var sumElem = 0;
            var f0 = 0;
            for (var i = 0; i < nums.Length; ++i)
            {
                sumElem += nums[i];
                f0 += (i * nums[i]);
            }
            var lastElemMul = (nums.Length - 1) * nums[nums.Length - 1];
            var max = f0;
            var prevF = f0;
            for (var k = 1; k < nums.Length; ++k)
            {
                var fk = prevF + sumElem - nums[nums.Length - k] - lastElemMul;
                lastElemMul = (nums.Length - 1) * nums[nums.Length - 1 - k];
                max = Math.Max(max, fk);
                prevF = fk;
            }

            return max;
        }


    }
}
