using System;

namespace AlgorithmProblems
{
    public class Atoi_8
    {
        public int MyAtoi(string str)
        {
            var temp = str.ToString().Trim();
            if (temp.Length == 0)
                return 0;
            var first = temp[0];
            var code = (int)first;
            if (code != 43 && code != 45 && !(code >= 48 && code <= 57))
                return 0;

            var neg = first == '-';
            long num = 0;
            if (code >= 48 && code <= 57)
                num += (code - 48);
            for (var i = 1; i < temp.Length; ++i)
            {
                code = (int)temp[i];
                if (code < 48 || code > 57)
                    break;
                num = num * 10 + (code - 48);
                if (!neg && num > Int32.MaxValue)
                    return Int32.MaxValue;
                else if (neg && num * (-1) < Int32.MinValue)
                    return Int32.MinValue;
            }

            num = neg ? num * -1 : num;

            return (int)num;
        }
    }
}
