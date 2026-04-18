using AlgorithmProblems;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmTests.AlgorithTest;

namespace AlgorithmTests
{
    [TestClass]
    public class LifeProblemTests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 4, 3, 2, 1 }, new int[] { 2, 17, 9, 15, 10 }, "RRRRR", new int[] { 2, 17, 9, 15, 10 })]
        [DataRow(new int[] { 3, 5, 2, 6 }, new int[] { 10, 10, 15, 12 }, "RLRL", new int[] { 14 })]
        [DataRow(new int[] { 1, 2, 5, 6 }, new int[] { 10, 10, 11, 11 }, "RLRL", new int[] {  })]
        public void SurvivedRobotsHealths_2751(int[] positions, int[] healths, string directions, int[] res)
        {
            var sut = new LifeProblem();
            sut.SurvivedRobotsHealths_2751(positions, healths, directions).ToArray().Should().BeEquivalentTo(res);
        }

        private static IEnumerable<MatrixData<int, int>> GetSpecialPostionsInBinaryMatrixData()
        {
            yield return new MatrixData<int, int> { Input = [[1, 0, 0], [0, 0, 1], [1, 0, 0]], Result = 1 };
            yield return new MatrixData<int, int> { Input = [[1, 0, 0], [0, 1, 0], [0, 0, 1]], Result = 3 };
        }

        public class RobotSlimInput
        {
            public int[][] Obstacles { get; set; }

            public int[] Commands { get; set; }

            public int Result { get; set; }
        }

        private static IEnumerable<RobotSlimInput> GetInputDataForRobotSlim()
        {
            yield return new RobotSlimInput { Commands = [4, -1, 4, -2, 4], Obstacles = [[2, 4]], Result = 65 };
        }

        [TestMethod]
        [DynamicData(nameof(GetInputDataForRobotSlim))]
        public void RobotSim(RobotSlimInput robotSlim)
        {
            var sut = new LifeProblem();
            sut.RobotSim(robotSlim.Commands, robotSlim.Obstacles).Should().Be(robotSlim.Result);
        }

        private static IEnumerable<Robot2069Case> GetRobotCases_2069()
        {
            yield return new Robot2069Case
            {
                Width = 20,
                Height = 13,
                Commands = ["step", "step", "getPos", "getDir", "step", "getPos", "getDir", "getPos", "getDir"],
                Args = [12, 21, 0, 0, 17, 0, 0, 0, 0],
                Results = [null, null, new Robot2069CaseResult([17, 12]), new Robot2069CaseResult("West"), null, new Robot2069CaseResult([0, 12]), new Robot2069CaseResult("West"), new Robot2069CaseResult([0, 12]), new Robot2069CaseResult("West")]
            };
        }

        public class Robot2069Case
        {
            public int Width { get; set; }

            public int Height { get; set; }

            public string[] Commands { get; set; }

            public int[] Args { get; set; }

            public Robot2069CaseResult[] Results { get; set; }

            
        }
        public class Robot2069CaseResult
        {
            public Robot2069CaseResult(string dir)
            {
                Direction = dir;
            }
            public Robot2069CaseResult(int[] c)
            {
                Coordinates = c;
            }
            public string Direction { get; private set; }

            public int[] Coordinates { get; private set; }
        }

        [TestMethod]
        [DynamicData(nameof(GetRobotCases_2069))]
        public void Robot_2069(Robot2069Case robotCase)
        {
            var sut = new Robot_2069(robotCase.Width, robotCase.Height);
            for (int i = 0; i < robotCase.Commands.Length; i++)
            {
                var com = robotCase.Commands[i];
                switch (com)
                {
                    case "step":
                        sut.Step(robotCase.Args[i]);
                        break;
                    case "getPos":
                        var expected = robotCase.Results[i].Coordinates;
                        sut.GetPos().Should().BeEquivalentTo(expected, $"get pos for command:{i}");
                        break;
                    case "getDir":
                        var dir = robotCase.Results[i].Direction;
                        sut.GetDir().Should().Be(dir, $"get direction for command:{i}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(com));
                }
            }
        }
    }
}
