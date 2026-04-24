using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint.InterviewInstance1
{
    /// <summary>
    /// Q2 Merge Intervals
    /// <see cref="https://leetcode.com/problems/merge-intervals/description/?envType=problem-list-v2&envId=interview-instance-i"/>
    /// </summary>
    public class Q2
    {
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
