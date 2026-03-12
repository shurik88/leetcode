using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class LongestPalindromicSubstring_5
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length == 0)
                return "";
            if (s.Length == 1)
                return s;

            //var max = "";
            var bl = 0;
            var br = 0;
            for(var  i = 0; i < s.Length; i++)
            {

                for(var c = 0; c < 2; ++c )
                {
                    var left = i;
                    var right = i + c;
                    while (left >= 0 && right < s.Length && s[left] == s[right])
                    {
                        if ((br - bl + 1) < (right - left + 1))
                        {
                            bl = left;
                            br = right;
                            //max = s[left..(right + 1)];
                        }
                        left--;
                        right++;
                    }
                }

                //foreach( (int l, int r) in new List<(int l, int r)> { (i, i), (i, i + 1) })
                //{
                //    var left = l;
                //    var right = r;
                //    while (left >= 0 && right < s.Length && s[left] == s[right])
                //    {
                //        if ((br-bl + 1) < (right - left + 1))
                //        {
                //            bl = left;
                //            br = right;
                //            //max = s[left..(right + 1)];
                //        }
                //        left--;
                //        right++;
                //    }
                //}     
            }
            return s[bl..(br + 1)];
        }
    }
}
