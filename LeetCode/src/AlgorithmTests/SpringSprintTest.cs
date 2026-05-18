using AlgorithmProblems.LinkedList;
using AlgorithmProblems.Quests.SpringSprint;
using AlgorithmProblems.Quests.SpringSprint.Week2;
using AlgorithmProblems.Quests.SpringSprint.Week3;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using spring = AlgorithmProblems.Quests.SpringSprint;

namespace AlgorithmTests
{
    [TestClass]
    public class SpringSprintTest
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 1 }, 4)]
        [DataRow(new int[] { 2, 7, 9, 3, 1 }, 12)]
        [DataRow(new int[] { 1, 3, 1, 3, 100 }, 103)]
        public void InterviewInstance1_Q3(int[] input, int res)
        {
            var sut = new spring.InterviewInstance1.Q3();
            sut.Rob(input).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { 10, 6, 8, 5, 11, 9 }, new int[] { 3, 1, 2, 1, 1, 0 })]
        [DataRow(new int[] { 5, 1, 2, 3, 10 }, new int[] { 4, 1, 1, 1, 0 })]
        public void CanSeePersonsCount(int[] heights, int[] res)
        {
            var sut = new Practice3();
            sut.CanSeePersonsCount(heights).Should().BeEquivalentTo(res);
        }

        [TestMethod]
        //[DataRow(new int[] { 1, 1, 1 }, 2, 2)]
        [DataRow(new int[] { 1, 2, 3 }, 3, 2)]
        [DataRow(new int[] { 1, 1, 1 }, 2, 2)]
        public void SubarraySum(int[] nums, int k, int res)
        {
            var sut = new Challenge2();
            sut.SubarraySum(nums, k).Should().Be(res);
        }

        [TestMethod]
        public void MergeKLists()
        {
            var vals = new List<int[]> { new int[] { 1, 4, 5 }, new int[] { 1, 3, 4 }, new int[] { 2, 6 } };
            var sut = new Challenge2();
            var lists = vals.Select(
                x =>
                {
                    var head = new ListNode(x[0]);
                    var curr = head;
                    for(int i = 1; i < x.Length; ++i)
                    {
                        curr.next = new ListNode(x[i]);
                        curr = curr.next;
                    }
                    return head;
                }).ToArray();
            var res = sut.MergeKLists(lists);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 3}, new int[] { 2}, 2)]
        public void FindMedianSortedArrays(int[] nums1, int[] nums2, double med)
        {
            var sut = new Ascension1();
            sut.FindMedianSortedArrays(nums1, nums2).Should().Be(med);

        }

        [TestMethod]
        public void GroupAnagrams()
        {
            var sut = new Ascension1();
            var res = sut.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
        [DataRow(new int[] { 0, 1, 1 }, 0, 2)]
        public void LongestOnes(int[] nums, int k, int res)
        {
            var sut = new Ascension2();
            sut.LongestOnes(nums, k).Should().Be(res);
        }

    }
}
