using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace AlgorithmProblems.DFS
{
    /// <summary>
    /// 1559. Detect Cycles in 2D Grid
    /// <see cref="https://leetcode.com/problems/detect-cycles-in-2d-grid/description/?envType=daily-question&envId=2026-04-26"/>
    /// </summary>
    public class Solution_1559
    {
        public bool ContainsCycle(char[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var visited = new bool[rows, cols];
            for(var i = 0; i < rows; ++i)
            {
                for(var j = 0; j < cols; ++j)
                {
                    if (visited[i, j])
                        continue;

                    if (DFS(grid, i, j, -1, -1, visited, grid[i][j]))
                        return true;
                }
            }
            return false;
        }

        private bool DFS(char[][] grid, int row, int col, int prevRow, int prevCol, bool[,] visited, char target)
        {
            visited[row, col] = true;
            int[] rowDirections = { 0, 0, 1, -1 };
            int[] columnDirections = { 1, -1, 0, 0 };
            for(var dir = 0; dir < 4; ++dir)
            {
                var rowDir = rowDirections[dir];
                var colDir = columnDirections[dir];

                var newRow = row + rowDir;
                var newCol = col + colDir;
                if (newRow < 0 || newRow >= grid.Length || newCol < 0 || newCol >= grid[0].Length || grid[newRow][newCol] != target)
                    continue;

                if (newRow == prevRow && newCol == prevCol)
                    continue;

                if (visited[newRow, newCol])
                    return true;

                if (DFS(grid, newRow, newCol, row, col, visited, target))
                    return true;
            }
            return false;
        }
    }
}
