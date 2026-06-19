namespace AlgorithmProblems.Quests.Algorithms
{
    public class Sorting
    {
        /// <summary>
        /// Q1. Minimum Absolute Difference
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-absolute-difference/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-sorting"/>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);
            var minDiff = arr[1] - arr[0];
            var res = new List<IList<int>> { new List<int> { arr[0], arr[1] } };
            for (var i = 1; i < arr.Length - 1; ++i)
            {
                var diff = arr[i + 1] - arr[i];
                if (diff > minDiff)
                    continue;

                if (diff < minDiff)
                {
                    res.Clear();
                    minDiff = diff;
                }

                res.Add(new List<int> { arr[i], arr[i + 1] });
                //minDiff = Math.Min(minDiff, arr[i+1] - arr[i]);
            }
            // var res = new List<IList<int>>();
            // for(var i = 0; i < arr.Length - 1; ++i)
            // {
            //     var diff = arr[i+1]-arr[i];
            //     if(diff == minDiff)
            //         res.Add(new List<int>{ arr[i], arr[i+1]});
            // }
            return res;
        }

        /// <summary>
        /// Q2. Reduction Operations to Make the Array Elements Equal
        /// </summary>
        /// <see cref="https://leetcode.com/problems/reduction-operations-to-make-the-array-elements-equal/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-sorting"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ReductionOperations(int[] nums)
        {
            if (nums.Length == 1)
                return 0;
            // Array.Sort(nums);
            // Array.Reverse(nums);
            Array.Sort(nums, (a, b) => b.CompareTo(a));

            var count = 0;
            var currSame = 1;
            var curr = nums[0];
            for (var i = 1; i < nums.Length; ++i)
            {
                if (nums[i] != curr)
                {
                    count += currSame;
                    curr = nums[i];
                }
                currSame++;
            }

            return count;
        }

        /// <summary>
        /// Q3. Merge Intervals
        /// </summary>
        /// <see cref="https://leetcode.com/problems/merge-intervals/description/?envType=problem-list-v2&envId=dsa-sorting-plateau-sorting"/>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1)
                return intervals;

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var merged = new List<int[]>();
            var curr = intervals[0];
            merged.Add(curr);
            foreach (var interval in intervals)
            {
                var currEnd = curr[1];
                var start = interval[0];
                var end = interval[1];
                if (start <= currEnd)
                {
                    curr[1] = Math.Max(currEnd, end);
                }
                else
                {
                    merged.Add(interval);
                    curr = interval;
                }
            }
            return merged.ToArray();
        }
    }
}
    