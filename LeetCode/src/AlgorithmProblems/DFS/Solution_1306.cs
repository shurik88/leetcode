using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.DFS
{
    public class Solution_1306
    {
        /// <summary>
        /// 1306. Jump Game III
        /// </summary>
        /// <see cref="https://leetcode.com/problems/jump-game-iii/?envType=daily-question&envId=2026-05-17"/>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public bool CanReach(int[] arr, int start)
        {
            var visited = new bool[arr.Length];

            const int targetValue = 0;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            while(queue.Count > 0)
            {
                var currIndex = queue.Dequeue();
                var currValue = arr[currIndex];
                if (currValue == targetValue)
                    return true;

                if (visited[currIndex])
                    continue;

                visited[currIndex] = true;

                var forwardStep = currIndex + currValue;
                if (forwardStep < arr.Length && forwardStep >= 0)
                    queue.Enqueue(forwardStep);
                var backwardStep = currIndex - currValue;
                if (backwardStep < arr.Length && backwardStep >= 0)
                    queue.Enqueue(backwardStep);
            }

            return false;
        }
    }
}
