using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SystemDesign
{
    /// <summary>
    ///  Q3. Subrectangle Queries
    ///  <see cref="https://leetcode.com/problems/subrectangle-queries/description/?envType=problem-list-v2&envId=ssd-ssd5-comprehensive-data-operations-simulation"/>
    /// </summary>
    public class SubrectangleQueries
    {
        private readonly int[][] _rectangle;
        public SubrectangleQueries(int[][] rectangle)
        {
            _rectangle = rectangle;
        }

        //stack on objects

        //public record Operation(int Row1, int Col1, int Row2, int Col2, int Value);

        //private readonly Stack<Operation> _stack = new Stack<Operation>();

        //public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        //{
        //    _stack.Push(new Operation(row1, col1, row2, col2, newValue));
        //}

        //public int GetValue(int row, int col)
        //{
        //    var value = _rectangle[row][col];
        //    if (_stack.Count == 0)
        //        return value;

        //    var tempStack = new Stack<Operation>();
        //    while (_stack.Count != 0)
        //    {
        //        var lastOp = _stack.Pop();
        //        tempStack.Push(lastOp);
        //        if (row >= lastOp.Row1 && row <= lastOp.Row2 && col >= lastOp.Col1 && col <= lastOp.Col2)
        //        {
        //            value = lastOp.Value;
        //            break;
        //        }
        //    }
        //    while (tempStack.Count != 0)
        //    {
        //        _stack.Push(tempStack.Pop());
        //    }
        //    return value;
        //    //return _rectangle[row][col];
        //}
        //stack of structs

        private readonly Stack<(int Row1, int Col1, int Row2, int Col2, int Value)> _stack = new Stack<(int Row1, int Col1, int Row2, int Col2, int Value)>();

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            _stack.Push((row1, col1, row2, col2, newValue));
        }

        public int GetValue(int row, int col)
        {
            var value = _rectangle[row][col];
            if (_stack.Count == 0)
                return value;

            var tempStack = new Stack<(int Row1, int Col1, int Row2, int Col2, int Value)>();
            while (_stack.Count != 0)
            {
                var lastOp = _stack.Pop();
                tempStack.Push(lastOp);
                if (row >= lastOp.Row1 && row <= lastOp.Row2 && col >= lastOp.Col1 && col <= lastOp.Col2)
                {
                    value = lastOp.Value;
                    break;
                }
            }
            while (tempStack.Count != 0)
            {
                _stack.Push(tempStack.Pop());
            }
            return value;
            //return _rectangle[row][col];
        }
        //1 brute force every time update rectangle

        //public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        //{
        //    for(var i = row1; i <= row2; ++i)
        //    {
        //        for(var j = col1; j <= col2; ++j)
        //            _rectangle[i][j] = newValue;
        //    }
        //}

        //public int GetValue(int row, int col)
        //{
        //    return _rectangle[row][col];
        //}
    }
}
