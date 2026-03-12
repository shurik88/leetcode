using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class MinMovesToTarget_2139
    {
        public int MinMoves(int target, int maxDoubles)
        {
            var res = 0;

            var curr = target;
            while(curr != 1 && maxDoubles != 0)
            {
                maxDoubles--;
                if (curr % 2 == 0)
                    res++;
                else
                    res += 2;
                curr = curr / 2;
            }
            return curr == 1 ? res : res + curr - 1;
        }
        public int MinMovesBad(int target, int maxDoubles)
        {
            var res = int.MaxValue;
            MakeMoves(1, target, ref res, 0, maxDoubles);
            return res;
        }

        private void MakeMoves(int curr, int target, ref int currOpt, int currMoves, int remainDoubles)
        {
            if (currOpt < currMoves)
            {
                return;
            }
            if (target == curr)
            {
                if(currOpt > currMoves)
                    currOpt = currMoves;
                return;
            }
            
            if (remainDoubles != 0 && curr * 2 <= target)
            {
                MakeMoves(curr * 2, target, ref currOpt, currMoves + 1, remainDoubles - 1);
            }
            MakeMoves(curr + 1, target, ref currOpt, currMoves + 1, remainDoubles);
        }
    }
}
