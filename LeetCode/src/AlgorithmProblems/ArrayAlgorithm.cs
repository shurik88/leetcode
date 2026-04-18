using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class ArrayAlgorithm
    {
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
    }
}
