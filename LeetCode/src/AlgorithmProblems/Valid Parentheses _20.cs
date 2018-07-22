using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProblems
{
    public class Valid_Parentheses__20
    {
        public bool IsValid(string s)
        {
            var openBraces = new Stack<char>();
            for(var i = 0; i < s.Length; ++i)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    openBraces.Push(s[i]);
                else if(!openBraces.Any())
                    return false;
                else
                {
                    switch(s[i])
                    {
                        case ')':
                            if (openBraces.Pop() != '(')
                                return false;
                            break;
                        case ']':
                            if (openBraces.Pop() != '[')
                                return false;
                            break;
                        case '}':
                            if (openBraces.Pop() != '{')
                                return false;
                            break;
                        default:
                            throw new Exception(string.Format("Unknown character: {0}", s[i]));
                    }
                }                
            }
            return !openBraces.Any();
        }
    }
}
