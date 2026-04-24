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

        /// <summary>
        /// 3296. Minimum Number of Seconds to Make Mountain Height Zero
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-number-of-seconds-to-make-mountain-height-zero/description/"/>
        /// <param name="mountainHeight"></param>
        /// <param name="workerTimes"></param>
        /// <returns></returns>
        public long MinNumberOfSeconds_3296(int mountainHeight, int[] workerTimes)
        {
            var heap = new PriorityQueue<int, long>(workerTimes.Length);//index in workerTimes, curr workerWeight(init value of workerTimes)
            var times = new long[workerTimes.Length];
            var attempts = new int[workerTimes.Length];
            for (var  i = 0; i < workerTimes.Length; ++i)
            {
                heap.Enqueue(i, workerTimes[i]);
            }
            long maxSeconds = 0;
            var remain = mountainHeight;
            while (remain > 0)
            {
                var item = heap.Dequeue();
                remain -= 1;
                attempts[item]++;
                times[item] += (long)workerTimes[item] * attempts[item];
                if (maxSeconds < times[item])
                    maxSeconds = times[item];
                heap.Enqueue(item, times[item] + (attempts[item] + 1) * (long)workerTimes[item]);
            }
            return maxSeconds;
        }

        private struct Element3296
        {
            public int Count { get; set; }

            public int Index { get; set; }

            public int Weight { get; set; }
        }


        /// <summary>
        ///     2751 Robot Colissions
        /// </summary>
        /// <see cref="https://leetcode.com/problems/robot-collisions/?envType=daily-question&envId=2026-04-01"/>
        /// <param name="positions"></param>
        /// <param name="healths"></param>
        /// <param name="directions"></param>
        /// <returns></returns>
        public IList<int> SurvivedRobotsHealths_2751(int[] positions, int[] healths, string directions)
        {
            var count = positions.Length;
            int[] indices = [.. Enumerable.Range(0, count)];
            Array.Sort(positions, indices);
            var elimanated = 0;
            if (elimanated == count)
                return [];

            //int? currIndex = null;
            var stack = new Stack<int>();
            for(var i = 0; i < count; i++)
            {
                var itemIndex = indices[i];
                var itemDirection = directions[itemIndex];
                if(stack.Count == 0)
                {
                    if(itemDirection == 'L')
                    {
                        continue;
                    }
                    else
                    {
                        stack.Push(itemIndex);
                    }
                }
                else
                {
                    if(itemDirection == 'L')
                    {
                        while(stack.Count != 0)
                        {
                            var lastRightIndex = stack.Peek();
                            var lastRightHealth = healths[lastRightIndex];
                            if (lastRightHealth <= healths[itemIndex])
                            {
                                stack.Pop();
                                healths[lastRightIndex] = 0;
                                if (lastRightHealth == healths[itemIndex])
                                {
                                    healths[itemIndex] = 0;
                                    break;
                                }
                                else
                                {
                                    healths[itemIndex]--;
                                }
                                
                                
                                
                            }
                            else
                            {
                                healths[itemIndex] = 0;
                                healths[lastRightIndex]--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        stack.Push(itemIndex);
                    }
                }
            }

            var res = new List<int>(count - elimanated);
            for (var i = 0; i < count; i++)
                if (healths[i] != 0)
                    res.Add(healths[i]);

            return res;

        }


        /// <summary>
        ///     874. Walking Robot Simulation
        /// </summary>
        /// <see cref="https://leetcode.com/problems/walking-robot-simulation/?envType=daily-question&envId=2026-04-06"/>
        /// <param name="commands"></param>
        /// <param name="obstacles"></param>
        /// <returns></returns>
        public int RobotSim(int[] commands, int[][] obstacles)
        {
            var obstaclesLength = obstacles.Length;
            var obstaclesHash = new HashSet<(int, int)>();
            for(var i = 0; i < obstaclesLength;i++)
            {
                obstaclesHash.Add((obstacles[i][0], obstacles[i][1]));
            }

            var maxDistance = 0;
            var xStep = 0;
            var yStep = 1;
            var currX = 0;
            var currY = 0;
            foreach(var com in commands)
            {
                if (com == -2)
                {
                    if (xStep == 0)
                        (xStep, yStep) = (-1 * yStep, 0);
                    else
                        (xStep, yStep) = (0, 1 * xStep);
                }
                else if (com == -1)
                {
                    if(xStep == 0)
                        (xStep, yStep) = (yStep, 0);
                    else
                        (xStep, yStep) = (0, -1 * xStep);

                }
                else
                {
                    var curr = 0;
                    var tempX = currX;
                    var tempY = currY;
                    while(curr < com)
                    {
                        tempX += xStep;
                        tempY += yStep;
                        curr++;
                        if (obstaclesHash.Contains((tempX, tempY)))
                            break;
                        else
                        {
                            currX = tempX;
                            currY = tempY;
                        }
                    }
                    var distance = currX * currX + currY * currY;
                    if(distance > maxDistance)
                    {
                        maxDistance = distance;
                    }

                }
            }

            return maxDistance;
        }


        /// <summary>
        ///     2078. Two Furthest Houses With Different Colors
        /// </summary>
        /// <see cref="https://leetcode.com/problems/two-furthest-houses-with-different-colors/?envType=daily-question&envId=2026-04-20"/>
        /// <param name="colors"></param>
        /// <returns></returns>
        public int MaxDistance(int[] colors)
        {
            var len = colors.Length;
            var i = 0;
            var j = len - 1;
            while (i != len && colors[i] == colors[len - 1])
                i++;
            while (j > 0 && colors[j] == colors[0])
                j--;
            return Math.Max(len - i - 1, j);

        }

        /// <summary>
        /// 2833. Furthest Point From Origin
        /// </summary>
        /// <see cref="https://leetcode.com/problems/furthest-point-from-origin/?envType=daily-question&envId=2026-04-24"/>
        /// <param name="moves"></param>
        /// <returns></returns>
        public int FurthestDistanceFromOrigin(string moves)
        {
            var left = 0;
            var right = 0;
            var underscore = 0;
            for (var i = 0; i < moves.Length; ++i)
            {
                if (moves[i] == 'L')
                    left++;
                else if (moves[i] == 'R')
                    right++;
                else
                    underscore++;
            }
            return Math.Abs(left - right) + underscore;
        }
    }
}
