using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    /// Q2. Insert Delete GetRandom O(1) - Duplicates allowed
    /// <see cref="https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/description/?envType=problem-list-v2&envId=ssd-ssd3-data-structure-design"/>
    /// </summary>
    public class RandomizedCollection
    {
        private readonly Random _rand = new Random();
        private readonly List<int> _items = new List<int>();
        private readonly IDictionary<int, HashSet<int>> _locations = new Dictionary<int, HashSet<int>>();
        public RandomizedCollection()
        {

        }

        public bool Insert(int val)
        {
            _items.Add(val);
            if (_locations.TryGetValue(val, out var list))
            {
                list.Add(_items.Count - 1);
                return false;
            }
            else
            {
                list = new HashSet<int>();
                list.Add(_items.Count - 1);
                _locations[val] = list;
                return true;
            }
        }

        public bool Remove(int val)
        {
            if (!_locations.TryGetValue(val, out var list))
                return false;

            var indexToRemove = list.First();

            if (list.Count == 1)
            {
                _locations.Remove(val);
            }
            else
            {
                list.Remove(indexToRemove);
            }

            //if last item in _items
            if (indexToRemove == _items.Count - 1)
            {
                _items.RemoveAt(indexToRemove);
            }
            else
            {
                var lastVal = _items[_items.Count - 1];
                _items[indexToRemove] = lastVal;
                var newList = _locations[lastVal];
                newList.Remove(_items.Count - 1);
                newList.Add(indexToRemove);

                _items.RemoveAt(_items.Count - 1);
            }




            return true;
        }

        public int GetRandom()
        {
            var next = _rand.Next(0, _items.Count);
            return _items[next];
        }
    }
    /*
     * RandomizedCollection is a data structure that contains a collection of numbers, possibly duplicates (i.e., a multiset). 
     * It should support inserting and removing specific elements and also reporting a random element.

Implement the RandomizedCollection class:

RandomizedCollection() Initializes the empty RandomizedCollection object.
bool insert(int val) Inserts an item val into the multiset, even if the item is already present. 
    Returns true if the item is not present, false otherwise.
bool remove(int val) Removes an item val from the multiset if present. 
    Returns true if the item is present, false otherwise. Note that if val has multiple occurrences in the multiset, we only remove one of them.
int getRandom() Returns a random element from the current multiset of elements. 
    The probability of each element being returned is linearly related to the number of the same values the multiset contains.
You must implement the functions of the class such that each function works on average O(1) time complexity.

Note: The test cases are generated such that getRandom will only be called if there is at least one item in the RandomizedCollection.
     */
}
