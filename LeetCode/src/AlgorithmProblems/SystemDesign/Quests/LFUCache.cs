using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    public class LFUCache
    {
        private readonly IDictionary<int, LinkedListNode<Item>> _cache;
        private int _minUsed = 0;
        private readonly IDictionary<int, LinkedList<Item>> _used;
        private readonly int _capacity;
        public LFUCache(int capacity)
        {
            _cache = new Dictionary<int, LinkedListNode<Item>>(capacity);
            _used = new Dictionary<int, LinkedList<Item>>(capacity);
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.TryGetValue(key, out LinkedListNode<Item> item))
                return -1;

            UpdateListUsed(item);


            return item.Value.Value;
        }

        private void UpdateListUsed(LinkedListNode<Item> item)
        {
            var list = _used[item.Value.Count];
            list.Remove(item);
            if (list.Count == 0)
            {
                _used.Remove(item.Value.Count);
                if(item.Value.Count == _minUsed)
                    _minUsed++;
            }
            item.Value.Count++;
            if (!_used.TryGetValue(item.Value.Count, out var toList))
            {
                toList = new LinkedList<Item>();
                _used[item.Value.Count] = toList;

            }
            toList.AddFirst(item);

            
        }

        public void Put(int key, int value)
        {
            if(_cache.TryGetValue(key, out var node))
            {
                node.Value.Value = value;
                UpdateListUsed(node);
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    //delete old
                    var list = _used[_minUsed];
                    var itemtoDelete = list.Last;
                    list.RemoveLast();
                    _cache.Remove(itemtoDelete.Value.Key);
                    if (list.Count == 0)
                        _used.Remove(_minUsed);
                }
                _minUsed = 1;
                if (!_used.TryGetValue(_minUsed, out var listToAdd))
                {
                    listToAdd = new LinkedList<Item>();
                    _used[_minUsed] = listToAdd;
                }
                var nodeToAdd = listToAdd.AddFirst(new Item { Count = 1, Key = key, Value = value });
                _cache[key] = nodeToAdd;
            }
            
        }

        private class Item
        {
            public int Key { get; set; }

            public int Value { get; set; }

            public int Count { get; set; }
        }
    }
}
