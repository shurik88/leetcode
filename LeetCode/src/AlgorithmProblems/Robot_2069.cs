namespace AlgorithmProblems
{
    /// <summary>
    /// 2069. Walking Robot Simulation II
    /// </summary>
    /// <see cref="https://leetcode.com/problems/walking-robot-simulation-ii/?envType=daily-question&envId=2026-04-07"/>
    public class Robot_2069
    {
        private int[] pos = new int[2] { 0, 0 };
        private string[] directions = new string[4] { "East", "North", "West", "South" };
        private int direction = 0;
        private readonly int width;
        private readonly int height;
        private readonly int roundSteps;
        public Robot_2069(int width, int height)
        {
            this.width = width;
            this.height = height;
            roundSteps = (width - 1) * 2 + (height - 1) * 2;
        }

        private int unusedSteps = 0;
        public void Step(int num)
        {
            unusedSteps = (unusedSteps + num % roundSteps) %  roundSteps;
        }

        private void DoSteps()
        {
            if (unusedSteps == 0)
                return;

            var num = unusedSteps % roundSteps;
            while (num != 0)
            {
                switch (directions[direction])
                {
                    case "East":
                        var diffEast = (width - 1) - pos[0];
                        if (diffEast < num)
                        {
                            pos[0] = width - 1;
                            direction = (direction + 1) % 4;
                            num -= diffEast;
                        }
                        else
                        {
                            pos[0] += num;
                            num = 0;
                        }
                        break;
                    case "North":
                        var diffNorth = (height - 1) - pos[1];
                        if (diffNorth < num)
                        {
                            pos[1] = height - 1;
                            direction = (direction + 1) % 4;
                            num -= diffNorth;
                        }
                        else
                        {
                            pos[1] += num;
                            num = 0;
                        }
                        break;
                    case "West":
                        var diffWest = pos[0];
                        if (diffWest < num)
                        {
                            pos[0] = 0;
                            direction = (direction + 1) % 4;
                            num -= diffWest;
                        }
                        else
                        {
                            pos[0] -= num;
                            num = 0;
                        }
                        break;
                    case "South":
                        var diffSouth = pos[1];
                        if (diffSouth < num)
                        {
                            pos[1] = 0;
                            direction = (direction + 1) % 4;
                            num -= diffSouth;
                        }
                        else
                        {
                            pos[1] -= num;
                            num = 0;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(direction));
                }
            }
            unusedSteps = 0;
        }

        public int[] GetPos()
        {
            DoSteps();
            return pos;
        }

        public string GetDir()
        {
            DoSteps();
            return directions[direction];
        }
    }
}
