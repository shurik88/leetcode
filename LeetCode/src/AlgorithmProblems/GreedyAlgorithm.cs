using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class GreedyAlgorithm
    {
        public int Jump_45(int[] nums)
        {
            var curr = 0;
            var total = 0;
            while (curr < nums.Length - 1)
            {
                var elem = nums[curr];
                var bestI = curr + 1;
                var bestRes = 0;
                for (var i = curr + 1; i <= curr + elem; ++i)
                {
                    if (i >= nums.Length - 1)
                    {
                        bestI = i;
                        break;
                    }
                    if (nums[i] + i >= bestRes)
                    {
                        bestRes = nums[i] + i;
                        bestI = i;
                    }
                }
                curr = bestI;
                total++;
            }
            return total;
        }
    }
}
