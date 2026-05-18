using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.DFS
{
    public class Solution_1345
    {
        /// <summary>
        /// 1345. Jump Game IV
        /// </summary>
        /// <see cref="https://leetcode.com/problems/jump-game-iv/description/?envType=daily-question&envId=2026-05-18"/>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MinJumps(int[] arr)
        {
            if (arr.Length < 1)
                return 0;
            
            var graph = new Dictionary<int, List<int>>();
            for(var i = 0; i < arr.Length; ++i)
            {
                if (!graph.ContainsKey(arr[i]))
                    graph[arr[i]] = new List<int>();
                graph[arr[i]].Add(i);
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);

            var visited = new bool[arr.Length];
            visited[0] = true;
            var count = 0;
            while (queue.Count > 0)
            {
                int currQueueSize = queue.Count;
                for (var i = 0; i < currQueueSize; ++i)
                {
                    var curr = queue.Dequeue();
                    if (curr == arr.Length - 1)
                        return count;

                    if (curr + 1 < arr.Length && !visited[curr+1])
                    {
                        visited[curr + 1] = true;
                        queue.Enqueue(curr + 1);
                    }
                    if (curr - 1 >= 0 && !visited[curr - 1])
                    {
                        visited[curr - 1] = true;
                        queue.Enqueue(curr - 1);
                    }
                    if (graph.ContainsKey(arr[curr]))
                    {
                        foreach (var item in graph[arr[curr]])
                            if (!visited[item])
                            {
                                visited[item] = true;
                                queue.Enqueue(item);
                            }
                        graph.Remove(arr[curr]);
                    }

                }
                count++;
            }


            return count;
        }
    }
}
