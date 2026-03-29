using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    ///     q2 stream of characters
    /// </summary>
    /// <see cref="https://leetcode.com/problems/kth-largest-element-in-a-stream/description/?envType=problem-list-v2&envId=ssd-ssd2-data-stream-processing"/>
    public class StreamChecker
    {
        private readonly Trie _trie = new Trie();
        private int _maxLength = 0;
        private readonly LinkedList<char> _letters = new LinkedList<char>();
        public StreamChecker(string[] words)
        {
            foreach(var word in words)
            {
                _maxLength = Math.Max(_maxLength, word.Length);
                var sb = new StringBuilder(word.Length);
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sb.Append(word[i]);
                }
                _trie.Insert(sb.ToString());
            }
            _letters = new LinkedList<char>();
        }

        public bool Query(char letter)
        {
            _letters.AddFirst(letter);
            if (_letters.Count > _maxLength)
                _letters.RemoveLast();

            var currLetterNode = _letters.First;
            var treeNode = _trie.Root;
            while(currLetterNode != null)
            {
                if (!treeNode.Children.TryGetValue(currLetterNode.Value, out var existNode))
                    return false;
                if (existNode.IsEndOfWord)
                    return true;

                treeNode = existNode;
                currLetterNode = currLetterNode.Next;
            }
            return false;
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
            public bool IsEndOfWord { get; set; } = false;
        }

        private class Trie
        {
            private readonly TrieNode root = new TrieNode();

            public TrieNode Root => root;

            public void Insert(string word)
            {
                TrieNode current = root;
                foreach (char c in word)
                {
                    if (!current.Children.ContainsKey(c))
                    {
                        current.Children[c] = new TrieNode();
                    }
                    current = current.Children[c];
                }
                current.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                TrieNode node = SearchPrefix(word);
                return node != null && node.IsEndOfWord;
            }
            public bool StartsWith(string prefix)
            {
                return SearchPrefix(prefix) != null;
            }

            private TrieNode SearchPrefix(string prefix)
            {
                TrieNode current = root;
                foreach (char c in prefix)
                {
                    if (!current.Children.ContainsKey(c))
                    {
                        return null;
                    }
                    current = current.Children[c];
                }
                return current;
            }
        }
    }

    /*
     * Design an algorithm that accepts a stream of characters and checks 
     * if a suffix of these characters is a string of a given array of strings words.
    For example, if words = ["abc", "xyz"] and the stream added the four characters (one by one) 'a', 'x', 'y', and 'z',
    your algorithm should detect that the suffix "xyz" of the characters "axyz" matches "xyz" from words.
Implement the StreamChecker class:
StreamChecker(String[] words) Initializes the object with the strings array words.
boolean query(char letter) Accepts a new character from the stream and returns true 
    if any non-empty suffix from the stream forms a word that is in words.
     */
}
