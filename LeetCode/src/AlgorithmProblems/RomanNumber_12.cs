using System.Collections.Generic;
using System.Linq;

namespace AlgorithmProblems
{
    public class RomanNumber_12
    {
        public string IntToRoman(int num)
        {
            var numbers = new RomanNumber[7]
            {
                new RomanNumber("I", 1), new RomanNumber("V", 5), new RomanNumber("X", 10), new RomanNumber("L", 50),
                new RomanNumber("C", 100), new RomanNumber("D", 500), new RomanNumber("M", 1000)
            };
            var list = new List<string>();
            var n = num;
            var currIndex = 2;
            while (n != 0)
            {
                var curr = numbers[currIndex];
                var prev = numbers[currIndex - 1];
                var prev2 = numbers[currIndex - 2];

                var del = curr.Number;
                var rem = n % del;
                if (rem == 0)
                {

                }
                else if (rem <= prev2.Number * 3)
                    list.Add(string.Concat(Enumerable.Repeat(prev2.Roman, rem / prev2.Number)));
                else if (rem < prev.Number)
                    list.Add(string.Concat(prev2.Roman, prev.Roman));
                else if (rem == prev.Number)
                    list.Add(prev.Roman);
                else if (rem <= prev.Number + prev2.Number * 3)
                {
                    var s = string.Concat(Enumerable.Repeat(prev2.Roman, (rem - prev.Number) / prev2.Number));
                    list.Add(string.Concat(prev.Roman, s));
                }
                else
                    list.Add(string.Concat(prev2.Roman, curr.Roman));

                n -= rem;
                currIndex += 2;

                if (currIndex <= numbers.Length || n == 0)
                    continue;
                curr = numbers[numbers.Length - 1];
                list.Add(string.Concat(Enumerable.Repeat(curr.Roman, n / curr.Number)));
                n = 0;
            }
            list.Reverse();
            return string.Concat(list);
        }

        private struct RomanNumber
        {
            public RomanNumber(string roman, int number)
            {
                Roman = roman;
                Number = number;
            }
            public readonly string Roman;

            public readonly int Number;
        }
    }
}
