using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SpringSprint
{
    public class Practice2
    {
        /// <summary>
        ///     Q1. Number of islands
        /// </summary>
        /// <see cref="https://leetcode.com/problems/number-of-islands/?envType=problem-list-v2&envId=Practice-II"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            var rows = grid.Length;
            var columns = grid[0].Length;
            var count = 0;

            static void DfsDrawIsland(char[][] grid, int r, int c)
            {
                if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length || grid[r][c] == '0')
                    return;

                grid[r][c] = '0';

                DfsDrawIsland(grid, r + 1, c);
                DfsDrawIsland(grid, r, c + 1);
                DfsDrawIsland(grid, r - 1, c);
                DfsDrawIsland(grid, r, c - 1);
            }

            for (var r = 0; r < rows; r++)
            {
                for(var c = 0; c < columns; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        count++;
                        DfsDrawIsland(grid, r, c);
                    }
                }
            }
            return count;

            
        }


        /// <summary>
        ///     Q2. Rotting oranges
        /// </summary>
        /// <see cref="https://leetcode.com/problems/rotting-oranges/?envType=problem-list-v2&envId=Practice-II"/>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            var freshOranges = 0;
            var rotten = new Queue<(int, int)>();
            for(var r = 0; r < grid.Length; r++)
            {
                for(var c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 1)
                        freshOranges++;
                    else if (grid[r][c] == 2)
                        rotten.Enqueue((r, c));
                }
            }
            if (freshOranges == 0)
                return 0;
            var min = 0;
            int[][] directions = [
                new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}
            ];
            while (rotten.Count > 0 && freshOranges > 0)
            {
                var currRotten = rotten.Count;
                min++;
                for(var  i = 0; i < currRotten; i++)
                {
                    (var r, var c) = rotten.Dequeue();
                    for(var j = 0; j < directions.Length; ++j)
                    {
                        (var newR, var newC) = (r + directions[j][0], c + directions[j][1]);
                        if (newR < 0 || newR >= grid.Length || newC < 0 || newC >= grid[0].Length || grid[newR][newC] != 1)
                            continue;

                        rotten.Enqueue((newR, newC));
                        grid[newR][newC] = 2;
                        freshOranges--;
                    }
                }
            }
            return freshOranges == 0 ? min : -1;
        }


    }
}
