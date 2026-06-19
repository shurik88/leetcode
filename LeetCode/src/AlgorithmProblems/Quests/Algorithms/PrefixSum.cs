using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class PrefixSum
    {
        /// <summary>
        /// Q1. Find the Highest Altitude
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-the-highest-altitude/description/?envType=problem-list-v2&envId=dsa-association-slope-prefix-sum"/>
        /// <param name="gain"></param>
        /// <returns></returns>
        public int LargestAltitude(int[] gain)
        {
            var max = 0;
            var curr = 0;
            for (var i = 0; i < gain.Length; ++i)
            {
                curr += gain[i];
                if (curr > max)
                    max = curr;
            }
            return max;
        }

        /// <summary>
        ///     Q2. Make Sum Divisible by P
        /// </summary>
        /// <see cref="https://leetcode.com/problems/make-sum-divisible-by-p/description/?envType=problem-list-v2&envId=dsa-association-slope-prefix-sum"/>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinSubarray(int[] nums, int p)
        {
            //var prefixSum = new long[nums.Length + 1];
            //prefixSum[0] = 0;
            //for (var i = 0; i < nums.Length; ++i)
            //{
            //    prefixSum[i + 1] = prefixSum[i] + nums[i];
            //}
            //var totalSum = prefixSum[nums.Length];
            //if (totalSum % p == 0)
            //    return 0;

            //var min = nums.Length - 1;
            //for (var i = 1; i < prefixSum.Length; ++i)
            //{
            //    for (var j = i; j < prefixSum.Length; ++j)
            //    {
            //        var subArraySum = prefixSum[j] - prefixSum[i - 1];
            //        var elemsCount = j - i + 1;
            //        if ((totalSum - subArraySum) % p == 0 && elemsCount < min)
            //        {
            //            min = elemsCount;
            //            if (min == 1)
            //                return 1;
            //        }

            //    }
            //}

            //return min == nums.Length - 1 ? -1 : min;
            // Step 1: Compute the total remainder needed to be removed
            int totalRemainder = 0;
            foreach (int num in nums)
            {
                totalRemainder = (totalRemainder + num) % p;
            }

            // If the total sum is already divisible by p, no need to remove anything
            if (totalRemainder == 0) return 0;

            // Map to store the latest index of each prefix remainder encountered
            Dictionary<int, int> prefixIndices = new Dictionary<int, int>();
            prefixIndices[0] = -1; // Base case: an empty prefix has a remainder of 0 at index -1

            int currentPrefixRemainder = 0;
            int minLength = nums.Length;

            // Step 2: Iterate through the array to find the shortest sub-array matching the target
            for (int i = 0; i < nums.Length; i++)
            {
                currentPrefixRemainder = (currentPrefixRemainder + nums[i]) % p;

                // Target remainder we need to find to isolate the totalRemainder
                int targetRemainder = (currentPrefixRemainder - totalRemainder + p) % p;

                if (prefixIndices.ContainsKey(targetRemainder))
                {
                    minLength = Math.Min(minLength, i - prefixIndices[targetRemainder]);
                }

                // Always update to the most recent index for the shortest sub-array length
                prefixIndices[currentPrefixRemainder] = i;
            }

            // It is not allowed to remove the whole array, so if minLength equals nums.Length, return -1
            return minLength == nums.Length ? -1 : minLength;
        }

        /// <summary>
        /// Q3. Ways to Make a Fair Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToMakeFair(int[] nums)
        {
            var n = nums.Length;
            if (n < 3)
                return 0;

            var even = new int[nums.Length / 2 + (n % 2 == 0 ? 0 : 1)];
            even[0] = nums[0];
            var odd = new int[n / 2];
            odd[0] = nums[1];
            for(var i = 2; i < n; ++i)
            {
                var ind = i / 2;
                if (i % 2 == 0)
                    even[ind] = even[ind - 1] + nums[i];
                else
                    odd[ind] = odd[ind - 1] + nums[i]; 
            }
            var count = 0;
            for(var i = 0; i < n; ++i)
            {
                var elemToDelete = nums[i];
                var deleteFromEven = i % 2 == 0;
                var ind = i / 2;
                var remainEven = i % 2 != 0 ? even[ind] : ind != 0 ? even[ind - 1] : 0;
                var remainOdd = i < 2 ? 0 : odd[ind - 1]; 
                (var sumEven, var sumOdd) = (remainEven + odd[odd.Length - 1] - remainOdd - (deleteFromEven ? 0 : elemToDelete), remainOdd + even[even.Length - 1] - remainEven - (deleteFromEven ? elemToDelete : 0));
                if (sumEven == sumOdd)
                    count++;
            }
            return count;
        }
    }
}
