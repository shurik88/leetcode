using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class MatrixAlgorithm
    {
        /// <summary>
        ///   Minimum swaps to arrange a binary grid      
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-swaps-to-arrange-a-binary-grid/?envType=daily-question&envId=2026-03-02"/>
        /// <param name="grid">matix</param>
        /// <returns>Swaps count or -1 if impossible</returns>
        public int MinSwaps_1536(int[][] grid)
        {
            var res = 0;
            var arr = new int[grid.Length];
            for (var  i = 0; i < grid.Length; ++i)
            {
                for(var j = grid[i].Length - 1; j >= 0; --j)
                {
                    //find first right 1
                    if (grid[i][j] == 1)
                    {
                        arr[i] = j;
                        //arrSort[i] = j;
                        break;
                    }
                }
            }
            ////check posibillity
            //var arrSort = new int[grid.Length];
            //arr.CopyTo(arrSort);
            //arrSort.Sort();
            //for (var i = 0; i < arrSort.Length; ++i)
            //{
            //    if (arrSort[i] > i)
            //        return -1;
            //}
            var requiredShift = true;
            while(requiredShift)
            {
                requiredShift = false;
                var shiftUsed = false;
                for(var i = 0; i < arr.Length; ++i)
                {
                    if (arr[i] > i)
                    {
                        requiredShift = true;
                        var prev = arr[i];
                        for(var j = i + 1; j < arr.Length; ++j)
                        {
                            //(arr[j], arr[j-1]) = (arr[i], arr[i + 1]);
                            if (arr[j] <= i)
                            {
                                shiftUsed = true;
                                res += j - i;
                                arr[i] = arr[j];
                                arr[j] = prev;
                                break; 
                            }
                            else
                            {
                                (prev, arr[j]) = (arr[j], prev);
                                //prev = arr[j];
                                //arr[j] = arr[j - 1];
                            }
                        }
                        if (shiftUsed)
                            break;
                    }
                    if (requiredShift && !shiftUsed)
                        return -1;

                }
                //for(var i =0; i < arr.Length - 1; ++i)
                //{
                //    if (arr[i] > i)
                //    {
                //        requiredShift = true;
                //    }
                //    if (requiredShift && arr[i] > arr[i + 1])
                //    {
                //        (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
                //        shiftUsed = true;
                //        res++;
                //        break;
                //    }
                //}
                //if (requiredShift && !shiftUsed)
                //    return -1;
            }
            //var requireSort = true;
            //while(requireSort)
            //{
            //    requireSort = false;
            //    for (var i = 0; i < arr.Length - 1; ++i)
            //    {
            //        if (arr[i] > arr[i + 1])
            //        {
            //            (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
            //            res++;
            //            requireSort = true;
            //            break;

            //        }
            //    }
            //}

            return res;
        }

        public int GetSpecialPostionsInBinaryMatrix_1582(int[][] mat)
        {
            var res = 0;
            var rows = new int[mat.Length];
            var cols = new int[mat[0].Length];

            for(var i = 0; i < mat.Length; ++i)
            {
                for(var j = 0; j < mat[i].Length; ++j)
                {
                    if(mat[i][j] == 1)
                    {
                        rows[i]++;
                        cols[j]++;
                    }
                }
            }

            for (var i = 0; i < mat.Length; ++i)
            {
                for (var j = 0; j < mat[i].Length; ++j)
                {
                    if (mat[i][j] == 1 && rows[i] == 1 && cols[j] == 1)
                        res++;
                }
            }

            return res;
        }
    }
}
