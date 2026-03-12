using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class LifeProblem
    {
        public int[] AvoidFlood_1488(int[] rains)
        {
            var dry = new int[rains.Length];
            //var lastRains = new int[1000000000];
            var lastRains = new Dictionary<int, int>();
            var dryB = -1;
            var dryE = -1;
            for(var i = 0; i < rains.Length; ++i)
            {
                var val = rains[i];
                if(val != 0) //rain
                {
                    if (!lastRains.ContainsKey(val))
                        lastRains.Add(val, i + 1);
                    //var lastRain = lastRains[val - 1];
                    //if (lastRain == 0)
                    //    lastRains[val - 1] = i + 1;
                    else //try to find dry day and dry lake
                    {
                        var lastRain = lastRains[val];
                        if (dryB == dryE) //empty
                            return [];
                        else
                        {
                            //find first correct dry index ()
                            var dryIndex = -1;
                            for(var k = dryB; k < dryE; ++k)
                            {
                                var rainIndex = dry[k];
                                if(rainIndex >= lastRain)
                                {
                                    dryIndex = k;
                                    break;
                                }    
                                //if(rainIndex)
                            }
                            if (dryIndex == -1)
                                return [];

                            rains[dry[dryIndex]] = val;
                            dry[dryIndex] = 0;

                            for(var j = dryIndex; j > dryB; --j)
                            {
                                dry[j] = dry[j - 1];
                            }
                            dry[dryB] = 0;

                            dryB++;

                            //rains[dry[dryB]] = val;
                            //dry[dryB] = 0;
                            //dryB++;
                        }
                        lastRains[val]= i + 1;
                    }
                    rains[i] = -1;
                }
                else
                {
                    if(dryB == dryE) // empty
                    {
                        dry[0] = i;
                        dryB = 0;
                        dryE = 1;
                    }
                    else
                    {
                        dry[dryE] = i;
                        dryE++;
                    }    
                }
            }
            if(dryB != dryE)
            {
                for(var i = dryB; i < dryE; ++i)
                {
                    if (dry[i] != -1)
                    {
                        rains[dry[i]] = 1;
                    }
                    
                }
            }
            return rains;
        }
    }
}
