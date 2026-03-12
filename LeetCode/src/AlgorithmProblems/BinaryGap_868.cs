using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class BinaryGap_868
    {
        public int BinaryGap(int n)
        {
            var length = 0;
            var curr = n;
            var right = -1;
            var max = 0;
            while (curr != 0)
            {
                var mod = curr % 2;
                curr = curr / 2;
                if (mod == 1)
                {
                    if (right == -1)
                        right = length;
                    else
                    {
                        var diff = length - right;
                        max = max > diff ? max : diff;
                        right = length;
                    }
                }
                length++;
            }
            return max;
        }
    }
}
