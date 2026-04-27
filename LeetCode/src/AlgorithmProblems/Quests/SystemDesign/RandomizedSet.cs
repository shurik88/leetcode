using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SystemDesign
{
    /// <summary>
    ///     Q1. Insert Delete GetRandom O(1)
    /// </summary>
    /// <see cref="https://leetcode.com/problems/insert-delete-getrandom-o1/description/?envType=problem-list-v2&envId=ssd-ssd3-data-structure-design"/>
    public class RandomizedSet
    {
        private readonly Random _rand = new Random();
        private readonly List<int> _items = new List<int>();
        private readonly IDictionary<int, int> _locations = new Dictionary<int, int>();
        public RandomizedSet()
        {

        }

        public bool Insert(int val)
        {
            if (_locations.ContainsKey(val))
                return false;

            _items.Add(val);
            _locations[val] = _items.Count - 1;

            return true;
        }

        public bool Remove(int val)
        {
            if (!_locations.TryGetValue(val, out int itemIndex))
                return false;

            //if last item in _items
            if(itemIndex == _items.Count - 1)
            {
                _items.RemoveAt(itemIndex);
            }
            else
            {
                var lastVal = _items[_items.Count - 1];
                _items[itemIndex] = lastVal;
                _locations[lastVal] = itemIndex;
                _items.RemoveAt(_items.Count - 1);
            }
            _locations.Remove(val);

            return true;
        }

        public int GetRandom()
        {
            var next = _rand.Next(0, _items.Count);
            return _items[next];
        }
    }
    /*
     * Implement the RandomizedSet class:

RandomizedSet() Initializes the RandomizedSet object.
bool insert(int val) Inserts an item val into the set if not present. 
    Returns true if the item was not present, false otherwise.
bool remove(int val) Removes an item val from the set if present. 
    Returns true if the item was present, false otherwise.
int getRandom() Returns a random element from the current set of elements
    (it's guaranteed that at least one element exists when this method is called). Each element must have the same probability of being returned.
You must implement the functions of the class such that each function works in average O(1) time complexity.

 
     */
}
