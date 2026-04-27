using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmProblems.Quests.SystemDesign
{
    /// <summary>
    ///     Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
    ///     Implement the LRUCache class:
    ///     LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    ///     int get(int key) Return the value of the key if the key exists, otherwise return -1.
    ///     void put(int key, int value) Update the value of the key if the key exists.Otherwise, add the key-value pair to the cache.If the number of keys exceeds the capacity from this operation, evict the least recently used key.
    ///     The functions get and put must each run in O(1) average time complexity.
    /// </summary>
    /// <remarks>Q1</remarks>
    /// <see cref="https://leetcode.com/problems/lru-cache/?envType=problem-list-v2&envId=ssd-ssd1-cache-system-design"/>
    public class LRUCache
    {
        private readonly IDictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
        private readonly LinkedList<KeyValuePair<int, int>> _lruList = new LinkedList<KeyValuePair<int, int>>();
        private readonly int _capacity;
        public LRUCache(int capacity)
        {
            _cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if(_cache.TryGetValue(key, out var node))
            {
                _lruList.Remove(node);
                _lruList.AddFirst(node);
                return node.Value.Value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if(!_cache.ContainsKey(key))
            {
                if (_cache.Count >= _capacity)
                {
                    // Evict the least recently used item (last in list)
                    LinkedListNode<KeyValuePair<int, int>> lruNode = _lruList.Last;
                    _cache.Remove(lruNode.Value.Key);
                    _lruList.RemoveLast();
                }
                var node = _lruList.AddFirst(new KeyValuePair<int, int>(key, value));
                _cache[key] = node;
            }
            else
            {
                var node = _cache[key];
                node.Value = new KeyValuePair<int, int>(key, value);
                _lruList.Remove(node);
                _lruList.AddFirst(node);
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
