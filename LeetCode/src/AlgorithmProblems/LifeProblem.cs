using System;
using System.Collections.Generic;
using System.Dynamic;
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

        /// <summary>
        ///     1665. Minimum Initial Energy to Finish Tasks
        /// </summary>
        /// <see cref="https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks/?envType=daily-question&envId=2026-05-12"/>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int MinimumEffort_1665(int[][] tasks)
        {
            var curr = 0;
            var total = 0;
            var sorted = tasks.OrderByDescending(x => x[1] - x[0]).ToArray();
            for (var i = 0; i < sorted.Length; ++i)
            {
                var required = sorted[i][1] - curr;
                if (required >= 0)
                {
                    total += required;
                    curr = 0;
                }
                else
                    curr -= sorted[i][1];

                curr += (sorted[i][1] - sorted[i][0]);
            }
            return total;
        }

        public bool AsteroidsDestroyed(int mass, int[] asteroids)
        {
            Array.Sort(asteroids);
            long curr = mass;
            for (var i = 0; i < asteroids.Length; ++i)
            {
                if (asteroids[i] > curr)
                    return false;

                curr += asteroids[i];
            }
            return true;
        }

        /// <summary>
        /// 3633. Earliest Finish Time for Land and Water Rides I
        /// </summary>
        /// <see cref="https://leetcode.com/problems/earliest-finish-time-for-land-and-water-rides-i/description/?envType=daily-question&envId=2026-06-02"/>
        /// <param name="landStartTime"></param>
        /// <param name="landDuration"></param>
        /// <param name="waterStartTime"></param>
        /// <param name="waterDuration"></param>
        /// <returns></returns>
        public int EarliestFinishTime_3633(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
        {
            var min = int.MaxValue;
            var minLandEnd = int.MaxValue;
            for (var i = 0; i < landStartTime.Length; ++i)
            {
                var end = landStartTime[i] + landDuration[i];
                if (end < minLandEnd)
                    minLandEnd = end;
            }
            for (var j = 0; j < waterStartTime.Length; ++j)
            {
                min = Math.Min(min, Math.Max(minLandEnd, waterStartTime[j]) + waterDuration[j]);
            }

            var minWaterEnd = int.MaxValue;
            for (var j = 0; j < waterStartTime.Length; ++j)
            {
                var end = waterStartTime[j] + waterDuration[j];
                if (end < minWaterEnd)
                    minWaterEnd = end;
            }
            for (var i = 0; i < landStartTime.Length; ++i)
            {
                min = Math.Min(min, Math.Max(minWaterEnd, landStartTime[i]) + landDuration[i]);
            }
            //for (var i = 0; i < landStartTime.Length; ++i)
            //{
            //    for (var j = 0; j < waterStartTime.Length; ++j)
            //    {
            //        var firstS = landStartTime[i];
            //        var firstD = landDuration[i];
            //        var secondS = waterStartTime[j];
            //        var secondD = waterDuration[j];

            //        if (secondS < firstS)
            //        {
            //            (firstS, secondS) = (secondS, firstS);
            //            (firstD, secondD) = (secondD, firstD);
            //        }
            //        var finish = firstS + firstD;
            //        finish = finish >= secondS ? finish + secondD : secondS + secondD;
            //        if (finish < min)
            //            min = finish;
            //    }
            //}
            return min;
        }

        /// <summary>
        /// 3751. Total Waviness of Numbers in Range I
        /// </summary>
        /// <see cref="https://leetcode.com/problems/total-waviness-of-numbers-in-range-i/description/?envType=daily-question&envId=2026-06-04"/>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int TotalWaviness_3751(int num1, int num2)
        {
            var count = num2 - num1 + 1;
            var total = 0;

            //for(var num = num1; num <= num2; ++num)
            //{
            //    var digits = GetDigits(num);
            //    total += GetWaviness(digits);
            //}

            var digits = GetDigits(num1);

            for (var i = 0; i < count; ++i)
            {
                total += GetWaviness(digits);

                var pos = 0;
                while(true)
                {
                    digits[pos]++;
                    if (digits[pos] != 10)
                        break;

                    digits[pos] = 0;
                    pos++;
                    if(pos == digits.Count)
                    {
                        digits.Add(1);
                        break;
                    }
                }

            }

            return total;

        }

        private static int GetWaviness(List<int> numbers)
        {
            if (numbers.Count < 3)
                return 0;

            var total = 0;

            for(var i = 1; i < numbers.Count - 1; ++i)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]
                    || numbers[i] < numbers[i - 1] && numbers[i] < numbers[i + 1])
                    total++;
            }

            return total;
        }

        private static List<int> GetDigits(int num)
        {
            var digits = new List<int>(6);
            while(num > 0)
            {
                digits.Add(num % 10);
                num /=10;
            }
            return digits;
        }
        /// <summary>
        ///     3753. Total Waviness of Numbers in Range II
        /// </summary>
        /// <see cref="https://leetcode.com/problems/total-waviness-of-numbers-in-range-ii/description/?envType=daily-question&envId=2026-06-05"/>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public long TotalWaviness_3753(long num1, long num2)
        {
            var count = num2 - num1 + 1;
            var total = 0;

            //for(var num = num1; num <= num2; ++num)
            //{
            //    var digits = GetDigits(num);
            //    total += GetWaviness(digits);
            //}

            var digits = GetDigits(num1);

            for (var i = 0; i < count; ++i)
            {
                total += GetWaviness(digits);

                var pos = 0;
                while (true)
                {
                    digits[pos]++;
                    if (digits[pos] != 10)
                        break;

                    digits[pos] = 0;
                    pos++;
                    if (pos == digits.Count)
                    {
                        digits.Add(1);
                        break;
                    }
                }

            }

            return total;
        }

        private static List<int> GetDigits(long num)
        {
            var digits = new List<int>(6);
            while (num > 0)
            {
                digits.Add((int)(num % 10));
                num /= 10;
            }
            return digits;
        }

        /// <summary>
        /// 1732. Find the Highest Altitude
        /// </summary>
        /// <see cref="https://leetcode.com/problems/find-the-highest-altitude/description/?envType=daily-question&envId=2026-06-19"/>
        /// <param name="gain"></param>
        /// <returns></returns>
        public int LargestAltitude(int[] gain)
        {
            var max = 0;
            var curr = 0;
            for (var i = 0; i < gain.Length; ++i)
            {
                curr += gain[i];
                if (curr > max)
                    max = curr;
            }
            return max;
        }

        /// <summary>
        /// 1344. Angle Between Hands of a Clock
        /// </summary>
        /// <see cref="https://leetcode.com/problems/angle-between-hands-of-a-clock/description/?envType=daily-question&envId=2026-06-19"/>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public double AngleClock(int hour, int minutes)
        {
            var minuteAngle = minutes * 6;
            var hourAngle = (hour % 12) * 30 + minutes * 0.5;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return angle > 180.0 ? 360.0 - angle : angle;
        }
    }
}
