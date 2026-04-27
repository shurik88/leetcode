using System.Text;

namespace AlgorithmProblems.Quests.Algorithms
{
    public class String
    {
        /// <summary>
        ///     Q1. Detect Capital
        /// </summary>
        /// <see cref="https://leetcode.com/problems/detect-capital/?envType=problem-list-v2&envId=dsa-sequence-valley-string"/>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DetectCapitalUse(string word)
        {
            if (word.Length < 2)
                return true;
            var firstIsUpper = char.IsUpper(word[0]);
            for (var i = 1; i < word.Length; ++i)
            {
                if (i == 1)
                {
                    if (!char.IsUpper(word[0]) && char.IsUpper(word[1]))
                        return false;
                }
                else
                {
                    if (char.IsUpper(word[i]) != char.IsUpper(word[i - 1]))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        ///     Q2. License Key Formatting
        /// </summary>
        /// <see cref="https://leetcode.com/problems/license-key-formatting/?envType=problem-list-v2&envId=dsa-sequence-valley-string"/>

        public string LicenseKeyFormatting(string s, int k)
        {
            var sb = new StringBuilder();
            var curr = 0;
            for(var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '-')
                    continue;

                if (curr == k)
                {
                    sb.Append('-');
                    curr = 0;
                }
                sb.Append(char.ToUpper(s[i]));
                curr++;
            }
            var sbTarget = new StringBuilder();
            for(var i  = sb.Length - 1; i >= 0; i--)
            {
                sbTarget.Append(sb[i]);
            }
            return sbTarget.ToString();
        }
    }
}
