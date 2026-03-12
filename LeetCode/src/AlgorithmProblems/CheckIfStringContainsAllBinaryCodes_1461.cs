using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class CheckIfStringContainsAllBinaryCodes_1461
    {
        public bool HasAllCodes(string s, int k)
        {
            if (s.Length < k)
                return false;

            var set = new HashSet<string>();
            var codesCount = 1 << k; // 2**k
            for (var i = 0; i < s.Length - k + 1; ++i)
            {
                var str = s[i..(i + k)];
                if (!set.Contains(str))
                {
                    set.Add(str);
                }
                if (codesCount == set.Count)
                    return true;
            }


            
            return codesCount == set.Count;
        }
    }
}
