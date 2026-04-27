using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlgorithmProblems.Quests.SystemDesign
{
    /// <summary>
    ///     1622. Fancy Sequence
    /// </summary>
    /// <see cref="https://leetcode.com/problems/fancy-sequence/description/?envType=daily-question&envId=2026-03-15"/>
    public class Fancy
    {
        const long Mod = 1_000_000_007;
        private class CumOp
        {
            public int LastElemIndex { get; set; }

            public long Mul { get; set; }

            public long Add { get; set; }

            public void Combine(CumOp op)
            {
                Mul = (Mul * op.Mul) % Mod;
                Add = (Add * op.Mul + op.Add) % Mod;
            }
        }

        private class CumOpComparer : IComparer<CumOp>
        {
            public int Compare(CumOp x, CumOp y)
            {
                return x.LastElemIndex.CompareTo(y.LastElemIndex);
            }
        }
        private readonly List<int> _numbers = [];
        private readonly List<CumOp> _ops = [];
        private readonly CumOpComparer _comparer = new CumOpComparer();
        public Fancy()
        {
            _ops.Add(new CumOp { Add = 0, Mul = 1, LastElemIndex = 0 });
        }

        public void Append(int val)
        {
            _numbers.Add(val);
        }

        public void AddAll(int inc)
        {
            AddOperation(new CumOp { Mul = 1, Add = inc, LastElemIndex = _numbers.Count - 1 });
        }

        private void AddOperation(CumOp op)
        {
            if (_numbers.Count == 0)
                return;
            // for(var i = 0; i < _ops.Count; ++i)
            // {
            //     _ops[i].Combine(op);
            // }
            // if (_ops[_ops.Count - 1].LastElemIndex != _numbers.Count - 1)
            //     _ops.Add(op);

            if (_ops[^1].LastElemIndex != _numbers.Count - 1)
                _ops.Add(op);
            else
                _ops[^1].Combine(op);
        }

        public void MultAll(int m)
        {
            AddOperation(new CumOp { Mul = m, Add = 0, LastElemIndex = _numbers.Count - 1 });
        }

        public int GetIndex(int idx)
        {
            //if (_numbers.Count <= idx)
            //    return -1;

            ////find first operation index greater than or equal than elem index
            //int index = _ops.BinarySearch(new CumOp { LastElemIndex = idx }, _comparer);
            //if ((index < 0))
            //    index = ~index;
            //CumOp op = index == _ops.Count ? new CumOp { Mul = 1, Add = 0 } : _ops[index];
            //return (int)((_numbers[idx] * op.Mul + op.Add) % Mod);

            if (_numbers.Count <= idx)
                return -1;

            //find first operation index greater than or equal than elem index
            int index = _ops.BinarySearch(new CumOp { LastElemIndex = idx }, _comparer);
            if (index < 0)
            {
                index = ~index;
            }
            long val = _numbers[idx];
            for (var j = index; j < _ops.Count; ++j)
            {
                val = (val * _ops[j].Mul + _ops[j].Add) % Mod;
            }
            return (int)val;

        }
    }
}
