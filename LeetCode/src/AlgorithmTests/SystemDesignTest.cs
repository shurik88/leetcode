using AlgorithmProblems.SystemDesign;
using AlgorithmProblems.SystemDesign.Quests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using static AlgorithmTests.AlgorithTest;

namespace AlgorithmTests
{
    [TestClass]
    public class SystemDesignTest
    {
        [TestMethod]
        [DataRow(new string[] { "append", "append", "getIndex", "getIndex", "multAll", "append", "getIndex", "getIndex" },
            new int[] { 3, 2, 0, 0, 3, 2, 2, 2 },
            new int[] { -1, -1, 3, 3, -1, -1, 2, 2 }
            )]
        [DataRow(new string[] { "append", "addAll", "append", "multAll", "getIndex", "addAll", "append", "multAll", "getIndex", "getIndex", "getIndex" },
            new int[] { 2, 3, 7, 2, 0, 3, 10, 2, 0, 1, 2 },
            new int[] { -1, -1, -1, -1, 10, -1, -1, -1, 26, 34, 20 }
            )]
        //9, 11 , 2, 
        public void Fancy_1622(string[] ops, int[] args, int[] res)
        {
            ops.Length.Should().Be(args.Length, "ops and args should have one length");
            /*
             * ["Fancy", "append", "addAll", "append", "multAll", "getIndex", "addAll", "append", "multAll", "getIndex", "getIndex", "getIndex"]
                [[],    [2],        [3],       [7],     [2],        [0],        [3],    [10],       [2],      [0],          [1],        [2]]
            */
            var sut = new Fancy();
            for(var i = 0; i < ops.Length; i++)
            {
                var op = ops[i];
                op.Should().BeOneOf("append", "getIndex", "multAll", "addAll");
                switch(op)
                {
                    case "append":
                        sut.Append(args[i]);
                        break;
                    case "multAll":
                        sut.MultAll(args[i]);
                        break;
                    case "addAll":
                        sut.AddAll(args[i]);
                        break;
                    default:
                        var item = sut.GetIndex(args[i]);
                        item.Should().Be(res[i], $"for operation at index i:{i}");
                        break;

                        //item.Should().Be(args[i]);

                }
            }
            
            //sut.Append(2);
            //sut.AddAll(3);
            //sut.Append(7);
            //sut.MultAll(2);
            //var item = sut.GetIndex(0);
            //item.Should().Be(10);
            //sut.AddAll(3);
            //sut.Append(10);
            //sut.MultAll(2);
            //item = sut.GetIndex(0);
            //item.Should().Be(26);
            //item = sut.GetIndex(1);
            //item.Should().Be(34);
            //item = sut.GetIndex(2);
            //item.Should().Be(20);

        }

        [TestMethod]
        public void KthLargest_Q1()
        {
            var sut = new KthLargest(3, [4, 5, 8, 2]);
            var kth = sut.Add(3);
            kth = sut.Add(5);
            kth = sut.Add(10);
            kth = sut.Add(9);
            kth = sut.Add(4);
        }

        [TestMethod]
        public void RandomizedSet_Q1()
        {
            var sut = new RandomizedSet();
            var opRes = sut.Insert(1);
            opRes = sut.Remove(2);
            opRes = sut.Insert(2);
            var valRes = sut.GetRandom();
            opRes = sut.Remove(1);
            opRes = sut.Insert(2);
            valRes = sut.GetRandom();
        }

        [TestMethod]
        public void RandomizedCollection_Q2()
        {
            var sut = new RandomizedCollection();
            var opRes = sut.Insert(4);
            opRes = sut.Insert(3);
            opRes = sut.Insert(4);
            opRes = sut.Insert(2);
            opRes = sut.Insert(4);
            opRes = sut.Remove(4);
            opRes = sut.Remove(3);
            opRes = sut.Remove(4);
            opRes = sut.Remove(4);
        }

        //private static IEnumerable<(string, string)[]> GetAllOneTestCases()
        //{
        //    yield return [("inc","hello"), ("inc", "hello"), ("getMaxKey", "hello"), ("getMinKey", "hello"), ("inc", "leet"), ("getMaxKey", "hello"), ("getMinKey", "leet")];
        //}
        private static IEnumerable<AllOneQ3TestCase> GetAllOneTestCases()
        {
            
            //yield return new AllOneQ3TestCase
            //{
            //    Commands = ["inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "dec", "dec", "dec", "dec", "dec", "dec", "inc", "inc", "inc", "inc", "getMaxKey", "getMinKey", "inc", "inc", "getMaxKey", "getMinKey", "inc", "dec", "getMaxKey", "getMinKey"],
            //    Args = [["a"], ["b"], ["c"], ["d"], ["e"], ["f"], ["g"], ["h"], ["i"], ["j"], ["k"], ["l"], ["a"], ["b"], ["c"], ["d"], ["e"], ["f"], ["g"], ["h"], ["i"], ["j"], [], [], ["k"], ["l"], [], [], ["a"], ["j"], [], []],
            //    Results = [null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "i", "k", null, null, "g", "g", null, null, "g", "a"]
            //};
            //yield return new AllOneQ3TestCase
            //{
            //    Commands = ["inc", "inc", "inc", "inc", "inc", "inc", "dec", "dec", "getMinKey", "dec", "getMaxKey", "getMinKey"],
            //    Args = [["a"], ["b"], ["b"], ["c"], ["c"], ["c"], ["b"], ["b"], [], ["a"], [], []],
            //    Results = [null, null, null, null, null, null, null, null, "a", null, "c", "c"]
            //};
            //yield return new AllOneQ3TestCase
            //{
            //    Commands = ["inc", "inc", "getMaxKey", "getMinKey", "inc", "getMaxKey", "getMinKey"],
            //    Args = [["hello"], ["hello"], [], [], ["leet"], [], []],
            //    Results = [null, null, "hello", "hello", null, "hello", "leet"]
            //};
            yield return new AllOneQ3TestCase
            {
                Commands = ["inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "inc", "getMaxKey", "getMinKey", "inc", "dec", "getMaxKey", "getMinKey"],
                Args = [["a"], ["b"], ["b"], ["b"], ["c"], ["c"], ["c"], ["c"], ["c"], ["c"], ["d"], ["d"], ["d"], ["d"], ["d"], ["d"], ["d"], ["d"], [], [], ["b"], ["d"], [], []],
                Results = [null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,"", "", null, null, "", ""]
            };
        }

        [TestMethod]
        [DynamicData(nameof(GetAllOneTestCases))]
        public void AllOne_Q3(AllOneQ3TestCase caseItem)
        {
            var sut = new AllOne();
            for (var i = 0; i < caseItem.Commands.Length; i++)
            {
                switch (caseItem.Commands[i])
                {
                    case "inc":
                        sut.Inc(caseItem.Args[i][0]);
                        break;
                    case "dec":
                        sut.Dec(caseItem.Args[i][0]);
                        break;
                    case "getMaxKey":
                        //sut.GetMaxKey().Should().Be(caseItem.Results[i], $"for command max: {i}");
                        break;
                    case "getMinKey":
                        //sut.GetMinKey().Should().Be(caseItem.Results[i], $"for command min: {i}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
            //sut.Inc("hello");
            //sut.Inc("hello");
            //var maxKey = sut.GetMaxKey();
            //var minKey = sut.GetMinKey();
            //sut.Inc("leet");
            //maxKey = sut.GetMaxKey();
            //minKey = sut.GetMinKey();
        }

        public class AllOneQ3TestCase
        {
            public string[] Commands { get; set; }

            public string[][] Args { get; set; }

            public string[] Results { get; set; }
        }

        private class AllOneQ3Commands
        {
            public const string Inc = "inc";
            public const string Dec = "dec";
        }

        [TestMethod]
        public void Twitter_Q2()
        {
            var sut = new Twitter();
            sut.PostTweet(1, 5);
            var feed = sut.GetNewsFeed(1);
            sut.Follow(1, 2);
            sut.PostTweet(2, 6);
            feed = sut.GetNewsFeed(1);
            sut.Unfollow(1, 2);
            feed = sut.GetNewsFeed(1);
            /*
             "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]
[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
             */
        }

        [TestMethod]
        public void RangeModule_Q1()
        {
            var sut = new RangeModule();
            sut.AddRange(10, 14);
            sut.AddRange(5, 9);
            //var query = sut.QueryRange(12, 13);
            //query = sut.QueryRange(3, 8);
            //query = sut.QueryRange(15, 17);
            //query = sut.QueryRange(9, 16);
            //query = sut.QueryRange(8, 11);
            sut.AddRange(18, 20);
            sut.AddRange(11, 21);
        }

        [TestMethod]
        [DataRow(new int[] { 12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56 }, 1, 2, 4, 1)]
        [DataRow(new int[] { 12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56 }, 0, 11, 33, 2)]
        public void RangeFreqQuery_Q2(int[] arr, int left, int right, int value, int expectedCount)
        {
            var sut = new RangeFreqQuery(arr);
            sut.Query(left, right, value).Should().Be(expectedCount);
        }
    }
}
