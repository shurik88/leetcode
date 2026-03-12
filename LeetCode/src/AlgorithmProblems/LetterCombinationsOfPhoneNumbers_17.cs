using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class LetterCombinationsOfPhoneNumbers_17
    {
        public IList<string> LetterCombinations(string digits)
        {
            var mappings = new List<string>(10)
            {
                "", "","abc","def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" 
            };
            var res = new List<string>();
            var queue = new Queue<string>();
            queue.Enqueue("");
            while(queue.Count > 0)
            {
                var prefix = queue.Dequeue();
                if(prefix.Length == digits.Length)
                    res.Add(prefix);
                else
                {
                    var digit = digits[prefix.Length];
                    var n = digit - '0';
                    if (n < 2 || n > 9)
                        continue;

                    foreach (var c in mappings[n])
                        queue.Enqueue(prefix + c);
                }
            }
            return res;

        }
    }
}
