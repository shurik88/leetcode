using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class GridAlgorithm
    {
        /// <summary>
        ///    3742. Maximum Path Score in a Grid 
        /// </summary>
        /// <see cref="https://leetcode.com/problems/maximum-path-score-in-a-grid/?envType=daily-question&envId=2026-04-30"/>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxPathScore_3742(int[][] grid, int k)
        {
            var res = DfsScore(grid, grid[0][0], k - grid[0][0] == 0 ? 0 : 1, 0, 0);
            return res;

        }


        private static int DfsScore(int[][] grid, int score, int k, int r, int c)
        {
            if (r == grid.Length - 1 && c == grid[0].Length - 1)
                return score;

            //var availables moves (+1,0) ,(0,+1)
            var maxScore = -1;
            for(var i = 0; i < 2; ++i)
            {
                (var newR, var newC) = i == 0 ? (r + 1, c) : (r, c + 1);
                if (newR >= grid[0].Length || newC >= grid[0].Length)
                    continue;

                var cost = grid[newR][newC] == 0 ? 0 : 1;
                if (k - cost < 0)
                    continue;

                var addScore = grid[newR][newC];
                var pathScore = DfsScore(grid, score + addScore, k - cost, newR, newC);
                maxScore = Math.Max(maxScore, pathScore);
            }
            return maxScore;
        }
    }
}
