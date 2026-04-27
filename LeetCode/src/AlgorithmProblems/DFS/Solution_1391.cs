using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.DFS
{
    /// <summary>
    /// 1391. Check if There is a Valid Path in a Grid
    /// <see cref="https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/description/?envType=daily-question&envId=2026-04-27"/>
    /// </summary>
    public class Solution_1391
    {
        public bool HasValidPath(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var visited = new bool[rows, cols];

            var avaialbleMoves = new Dictionary<int, Move[]>
            {
                [1] = [
                    new Move { StepCol = 1, StepRow = 0, AvalaibeStreets = [3, 5, 1] },
                    new Move { StepCol = -1, StepRow = 0, AvalaibeStreets = [4,6, 1]  }
                    ],
                [2] = [
                    new Move { StepCol = 0, StepRow = -1, AvalaibeStreets = [3, 4, 2] },
                    new Move { StepCol = 0, StepRow = 1, AvalaibeStreets = [5,6, 2]  }
                    ],
                [3] = [
                    new Move { StepCol = 0, StepRow = 1, AvalaibeStreets = [2, 5, 6] },
                    new Move { StepCol = -1, StepRow = 0, AvalaibeStreets = [1, 4,6]  }
                    ],
                [4] = [
                    new Move { StepCol = 1, StepRow = 0, AvalaibeStreets = [1, 3, 5] },
                    new Move { StepCol = 0, StepRow = 1, AvalaibeStreets = [2, 5, 6]  }
                    ],
                [5] = [
                    new Move { StepCol = 0, StepRow = -1, AvalaibeStreets = [2, 3, 4] },
                    new Move { StepCol = -1, StepRow = 0, AvalaibeStreets = [1, 4,6]  }
                    ],
                [6] = [
                    new Move { StepCol = 0, StepRow = -1, AvalaibeStreets = [2, 3, 4] },
                    new Move { StepCol = 1, StepRow = 0, AvalaibeStreets = [1, 3, 5]  }
                    ],
            };

            return DFS(avaialbleMoves, grid, 0, 0, visited, rows - 1, cols - 1);
        }

        private class Move
        {
            public int StepRow { get; set; }

            public int StepCol { get; set; }

            public int[] AvalaibeStreets { get; set; }
        }

        private bool DFS(Dictionary<int, Move[]> availableMoves, int[][] grid, int row, int col, bool[,] visited, int targetRow, int targetCol)
        {
            visited[row, col] = true;
            if (row == targetRow && col == targetCol)
                return true;

            var availableMovesForCell = availableMoves[grid[row][col]];

            for(var i = 0; i < availableMovesForCell.Length; i++)
            {
                var move = availableMovesForCell[i];
                var newRow = row + move.StepRow;
                var newCol = col + move.StepCol;
                //check bounds
                if (newRow < 0 || newRow >= grid.Length || newCol < 0 || newCol >= grid[0].Length)
                    continue;
                
                if (visited[newRow, newCol])
                    continue;

                var newStreet = grid[newRow][newCol];
                //check newstreet
                if (!move.AvalaibeStreets.Contains(newStreet))
                    continue;

                if (DFS(availableMoves, grid, newRow, newCol, visited, targetRow, targetCol))
                    return true;
            }
            return false;
        }
    }
}
