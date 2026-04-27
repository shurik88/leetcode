using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Quests.SystemDesign
{
    /// <summary>
    /// Q3. All O`one Data Structure
    /// <see cref="https://leetcode.com/problems/all-oone-data-structure/description/?envType=problem-list-v2&envId=ssd-ssd3-data-structure-design"/>
    /// </summary>
    public class AllOne
    {
        private class Node
        {
            //public int Counter { get; set; }

            public HashSet<string> Keys { get; set; }
        }
        private readonly LinkedList<Node> _list = new LinkedList<Node>();
        private readonly IDictionary<string, int> _counters = new Dictionary<string, int>();
        private readonly IDictionary<int, LinkedListNode<Node>> _groupings = new Dictionary<int, LinkedListNode<Node>>();
        public AllOne()
        {

        }


        private void ChangeValue(string key, int incValue)
        {

            var counter = _counters.ContainsKey(key) ? _counters[key] + incValue : incValue;
            var prevCounter = counter - incValue;
            if (counter == 0) // remove
            {
                _counters.Remove(key);
                var setToDeleteItemNode = _groupings[1];
                setToDeleteItemNode.Value.Keys.Remove(key);
                if (setToDeleteItemNode.Value.Keys.Count == 0)
                {
                    _list.Remove(setToDeleteItemNode);
                    _groupings.Remove(1);
                }
            }
            else
            {
                _counters[key] = counter;
                //add to new
                if (_groupings.TryGetValue(counter, out var setToAddItemNode))
                {
                    setToAddItemNode.Value.Keys.Add(key);
                }
                else
                {

                    var newSet = new HashSet<string>();
                    newSet.Add(key);
                    var nodeValue = new Node { Keys = newSet };
                    LinkedListNode<Node> node;
                    if (prevCounter == 0)
                        node = _list.AddFirst(nodeValue);
                    else if (prevCounter < counter)
                    {
                        node = _list.AddAfter(_groupings[prevCounter], nodeValue);
                    }
                    else
                    {
                        node = _list.AddBefore(_groupings[prevCounter], nodeValue);
                    }
                    _groupings[counter] = node;
                   
                }

                //remove from prev
                if (prevCounter == 0)//new element
                {

                }
                else
                {
                    var setToDeleteItemNode = _groupings[prevCounter];
                    setToDeleteItemNode.Value.Keys.Remove(key);
                    if (setToDeleteItemNode.Value.Keys.Count == 0)
                    {
                        _list.Remove(setToDeleteItemNode);
                        _groupings.Remove(prevCounter);
                    }
                }
                
            }
        }

        public void Inc(string key)
        {
            ChangeValue(key, 1);
        }

        public void Dec(string key)
        {
            ChangeValue(key, -1);
        }

        public string GetMaxKey()
        {
            return _list.Count == 0 ? string.Empty : _list.Last.Value.Keys.First();
        }

        public string GetMinKey()
        {
            return _list.Count == 0 ? string.Empty : _list.First.Value.Keys.First();
        }
    }
    /*
     * Design a data structure to store the strings' count with the ability to return the strings with minimum and maximum counts.
Implement the AllOne class:
AllOne() Initializes the object of the data structure.
inc(String key) Increments the count of the string key by 1. If key does not exist in the data structure, insert it with count 1.
dec(String key) Decrements the count of the string key by 1. If the count of key is 0 after the decrement, remove it from the data structure. 
    It is guaranteed that key exists in the data structure before the decrement.
getMaxKey() Returns one of the keys with the maximal count. If no element exists, return an empty string "".
getMinKey() Returns one of the keys with the minimum count. If no element exists, return an empty string "".
Note that each function must run in O(1) average time complexity.
     */
}
