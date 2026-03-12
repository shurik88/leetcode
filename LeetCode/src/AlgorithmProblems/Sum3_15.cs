using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class Sum3_15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return [];

            Array.Sort(nums);

            var res = new List<IList<int>>();
            for (var i = 0; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                var fixi = nums[i];
                var j = i + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    var fixj = nums[j];
                    var fixk = nums[k];
                    var sum = fixi + fixj + fixk;
                    if (sum == 0)
                    {
                        res.Add([fixi, fixj, fixk]);
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1])
                            j++;
                        while (j < k && nums[k] == nums[k + 1])
                            k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }
            return res;
        }

        public int ClosestSum(int[] nums, int target)
        {
            Array.Sort(nums);

            var minDiff = int.MaxValue;
            var bestSum = 0;
            for (var i = 0; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                var fixi = nums[i];
                var j = i + 1;
                var k = nums.Length - 1;
                while (j < k)
                {
                    var fixj = nums[j];
                    var fixk = nums[k];
                    var sum = fixi + fixj + fixk;
                    var diff = Math.Abs(target - sum);
                    if (diff == 0)
                    {
                        return target;
                    }
                    else if (sum < target)
                    {
                        j++;
                        if (minDiff >= diff)
                        {
                            minDiff = diff;
                            bestSum = sum;
                        }
                    }
                    else
                    {
                        k--;
                        if (minDiff >= diff)
                        {
                            minDiff = diff;
                            bestSum = sum;
                        }
                    }


                }
            }
            return bestSum;
        }
    }
}
