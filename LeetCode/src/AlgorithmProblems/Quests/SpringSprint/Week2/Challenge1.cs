using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.Week2
{
    public class Challenge1
    {
        /// <summary>
        ///     Q2. Product of Array Except Self
        /// </summary>
        /// <see cref="https://leetcode.com/problems/product-of-array-except-self/description/?envType=problem-list-v2&envId=Challenge-I"/>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            var length = nums.Length;
            var left = new int[length + 1];
            var right = new int[length + 1];
            Array.Fill(left, 1);
            Array.Fill(right, 1);
            for (var i = 1; i < nums.Length + 1; ++i)
                left[i] = left[i - 1] * nums[i - 1];
            for (var i = nums.Length - 1; i >= 0; --i)
                right[i] = right[i + 1] * nums[i];

            var res = new int[length];
            for (var i = 0; i < res.Length; ++i)
                res[i] = left[i] * right[i + 1];

            return res;
        }

        /// <summary>
        ///     Q3. Cinema Seat Allocation
        /// </summary>
        /// <see cref="https://leetcode.com/problems/cinema-seat-allocation/?envType=problem-list-v2&envId=Challenge-I"/>
        /// <param name="n"></param>
        /// <param name="reservedSeats"></param>
        /// <returns></returns>
        public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            var masks = new int[0b0111100000, 0b0000011110, 0b0001111000];
            //var res = new int[n];
            //Array.Fill(res, 2);
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < reservedSeats.Length; ++i)
            {
                var row = reservedSeats[i][0];
                var seat = reservedSeats[i][1];
                dict[row] = (dict.TryGetValue(row, out var value) ? value : 0) | (1 << (10 - seat));
            }
            var total = (n - dict.Count) << 1;
            foreach(var key in dict.Keys)
            {
                var value = dict[key];
                foreach(var mask in masks)
                {
                    if((value & mask) == 0)
                    {
                        value |= mask;
                        ++total;
                    }
                }
            }
            return total;
        //var groupedByRow = reservedSeats.GroupBy(x => x[0])
        //        .ToDictionary(x => x.Key, x => x.Select(y => y[1]).ToHashSet());
        //    var total = (n - groupedByRow.Count) << 1;
        //    for(var r = 1; r <= n; ++r)
        //    {
        //        if(!groupedByRow.TryGetValue(r, out var list))
        //        {
        //            total += 2;
        //            continue;
        //        }
        //        var first = true; // 2-5
        //        var second = true;// 6-9
        //        var third = true; // 4-7

        //        for(var i = 0; i < list.Length; ++i)
        //        {
        //            if (list[i] >= 2 && list[i] <= 5)
        //                first = false;
        //            else if (list[i] >= 6 && list[i] <= 9)
        //                second = false;

        //            if (list[i] >= 4 && list[i] <= 7)
        //                third = false;
        //        }
        //        if (first && second)
        //            total += 2;
        //        else if(first || second || third)
        //        {
        //            total += 1;
        //        }
        //    }
        //    return total;
        }
    }
}
