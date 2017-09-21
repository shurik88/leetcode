using System;

namespace AlgorithmProblems
{
    public class ReverseNumber_7
    {
        public int Reverse(int x)
        {
            long num = 0;
            var left = x;
            while (left != 0)
            {
                var rev = left % 10;
                num = num * 10 + rev;
                left = left / 10;
            }
            if (num > Int32.MaxValue || num < Int32.MinValue)
                return 0;
            return (int)num;
        }
    }
}
