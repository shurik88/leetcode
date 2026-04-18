using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    ///     A Range Module is a module that tracks ranges of numbers. Design a data structure to track the ranges represented as half-open intervals and query about them.
    /// </summary>
    /// <see cref="https://leetcode.com/problems/range-module/?envType=problem-list-v2&envId=ssd-ssd5-comprehensive-data-operations-simulation"/>
    public class RangeModule
    {
        //private readonly SortedDictionary<int, int> _intervals = new SortedDictionary<int, int>();
        private readonly SortedList<int, int> _intervals = new SortedList<int, int>();
        public RangeModule()
        {

        }

        public void AddRange(int left, int right)
        {
            //if (_intervals.Count == 0)
            //{
            //    _intervals.Add(left, right);
            //    return;
            //}

            //var indexToInsertLeft = _intervals.IndexOfKey(left);
            //var indexToInsertRight = _intervals.IndexOfValue(right);
            //if (indexToInsertLeft < 0)
            //    indexToInsertLeft = ~indexToInsertLeft;
            //if (indexToInsertRight < 0)
            //    indexToInsertRight = ~indexToInsertRight;



            //var newLeft = indexToInsertLeft == _intervals.Count ? left : Math.Min(left, _intervals.Keys[indexToInsertLeft]);
            //var newRight = indexToInsertRight == _intervals.Count ? right : Math.Max(right, _intervals.Values[indexToInsertRight]);
            //for(var j = indexToInsertRight; j  >= indexToInsertLeft; j--)
            //{
            //    _intervals.RemoveAt(j);
            //}
            //_intervals.Add(newLeft, newRight);

            //_intervals.Re


            (var newIntervalLeft, var newIntervalRight) = (left, right);

            var overlaps = _intervals.Where(i => i.Key <= right && i.Value >= left).ToList();

            foreach (var overlap in overlaps)
            {
                newIntervalLeft = Math.Min(newIntervalLeft, overlap.Key);
                newIntervalRight = Math.Max(newIntervalRight, overlap.Value);
                _intervals.Remove(overlap.Key);
            }

            _intervals.Add(newIntervalLeft, newIntervalRight);
        }

        public bool QueryRange(int left, int right)
        {
            var potential = _intervals.Where(r => r.Key <= left).OrderByDescending(r => r.Key).FirstOrDefault();
            return potential.Value >= right;
            //var newInterval = new Interval(left, right);
            //var view = _intervals.GetViewBetween(new Interval(left, left), new Interval(right, right));
            //var hasOverlaps = _intervals.Any(i => i.Start <= right && i.End >= left);
            //return view.Count == 0;

        }

        public void RemoveRange(int left, int right)
        {
            var overlapping = _intervals.Where(r => r.Key < right && r.Value > left).ToList();

            foreach (var interval in overlapping)
            {
                _intervals.Remove(interval.Key);
                // If the existing range extends before the removal range, keep the left part
                if (interval.Key < left)
                {
                    _intervals[interval.Key] = left;
                }
                // If the existing range extends after the removal range, keep the right part
                if (interval.Value > right)
                {
                    _intervals[right] = interval.Value;
                }
            }
            //var overlaps = _intervals.Where(i => i.Key <= right && i.Value >= left).ToList();
            //if (overlaps.Count == 0)
            //    return;
            //(int? left1, int? right1) = (null, null);
            //(int? left2, int? right2) = (null, null);
            //if (left1 == null)
            //    return;
            //if (left1 != null)
            //    _intervals.Add(left1.Value, right1.Value);
            //if (left2 != null)
            //    _intervals.Add(left2.Value, right2.Value);
        }

        public record Interval(int Start, int End) : IComparable<Interval>
        {
            public int CompareTo(Interval other) => Start.CompareTo(other.Start);
        }
    }
}
