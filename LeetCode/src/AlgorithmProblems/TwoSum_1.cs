using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProblems
{
    public class TwoSum_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var set = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                var remain = target - nums[i];
                if (set.ContainsKey(remain))
                {
                    return (new int[2] {i, set[remain]}).OrderBy(x => x).ToArray();
                }
                if(!set.ContainsKey(nums[i]))
                    set.Add(nums[i], i);
            }
            throw new Exception("Numbers not found");
        }
    }
}
