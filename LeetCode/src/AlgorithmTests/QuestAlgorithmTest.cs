using AlgorithmProblems.LinkedList;
using FluentAssertions;
using AlgorithmProblems.Quests.Algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTests
{
    [TestClass]
    public class QuestAlgorithmTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 1, 0, 0 }, new int[] { 0, 1, 0, 1 }, 0)]
        [DataRow(new int[] { 1, 1, 1, 0, 0, 1 }, new int[] { 1, 0, 0, 0, 1, 1 }, 3)]
        public void CountStudents(int[] students, int[] sandwiches, int count)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.Queue();
            sut.CountStudents(students, sandwiches).Should().Be(count);
        }

        [TestMethod]
        [DataRow(new int[] { 9, 3, 5 }, true)]
        [DataRow(new int[] { 1, 1, 1, 2 }, false)]
        [DataRow(new int[] { 8, 5 }, true)]
        [DataRow(new int[] { 2, 900000001 }, true)]
        public void IsPossible(int[] target, bool res)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.Heap();
            sut.IsPossible(target).Should().Be(res);
        }

        [TestMethod]
        [DataRow("5F3Z-2e-9-w", 4, "5F3Z-2E9W")]
        [DataRow("2-5g-3-J", 2, "2-5G-3J")]
        public void LicenseKeyFormatting(string input, int k, string res)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.String();
            sut.LicenseKeyFormatting(input, k).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3 })]
        public void DeleteDuplicates(int[] nums, int[] expected)
        {
            var head = ListNode.Create(nums);
            var sut = new AlgorithmProblems.Quests.Algorithms.LinkedList();
            var newHead = sut.DeleteDuplicates(head);
            var values = newHead.GetNumbers();
            values.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 3, 5, 2, 4 })]
        [DataRow(new int[] { 2, 1, 3, 5, 6, 4, 7 }, new int[] { 2, 3, 6, 7, 1, 5, 4 })]
        public void OddEvenList(int[] nums, int[] expected)
        {
            var head = ListNode.Create(nums);
            var sut = new AlgorithmProblems.Quests.Algorithms.LinkedList();
            var newHead = sut.OddEvenList(head);
            var values = newHead.GetNumbers();
            values.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1})]
        public void ReverseList(int[] nums, int[] expected)
        {
            var head = ListNode.Create(nums);
            var sut = new AlgorithmProblems.Quests.Algorithms.LinkedList();
            var newHead = sut.ReverseList(head);
            var values = newHead.GetNumbers();
            values.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 7, 13, 11, 10, 1}, new int[] { -1, 0, 4, 2, 0 })]
        public void CopyRandomList(int[] arr, int[] links)
        {
            var sut = new AlgorithmProblems.Quests.Algorithms.HashSet();
            var head = AlgorithmProblems.Quests.Algorithms.HashSet.Node.Create(arr, links);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 4, 2 }, 6, 1)]
        [DataRow(new int[] { 6, 3, 5, 2 }, 9, 2)]
        [DataRow(new int[] { 1, 2, 3 }, 3, 0)]
        public void MinSubarray(int[] arr, int p, int res)
        {
            var sut = new PrefixSum();
            sut.MinSubarray(arr, p).Should().Be(res);
        }

        [TestMethod]
        [DataRow(new int[] { 2, 1, 6, 4 }, 1)]
        public void WaysToMakeFair(int[] nums, int expected)
        {
            var sut = new PrefixSum();
            sut.WaysToMakeFair(nums).Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 2, 1, 5, 6, 4 }, true, new int[] { 1, 2, 3, 4, 5, 6})]
        [DataRow(new int[] { 3, 2, 1, 5, 6, 4 }, false, new int[] { 6, 5, 4, 3, 2, 1 })]
        public void QuickSort(int[] arr, bool asc, int[] expected)
        {
            var sut = new SpecificSort();
            sut.QuickSort(arr,asc ? new AscendingOrder() : new DecendingOrder()).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 2, 1, 5, 6, 4 }, 1, 6)]
        [DataRow(new int[] { 3, 2, 1, 5, 6, 4 }, 6, 1)]
        [DataRow(new int[] { 3, 2, 1, 5, 6, 4 }, 3, 4)]
        public void FindKLargest(int[] arr, int k, int expected)
        {
            var sut = new SpecificSort();
            sut.FindKthLargest(arr, k).Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 4,7,2,1,6,3}, new int[] { 1,2,3,4,6,7})]
        public void InsertionSortList(int[] arr, int[] expected)
        {
            var sut = new SpecificSort();
            var res = sut.InsertionSortList(ListNode.Create(arr));
            var resNumbers = res.GetNumbers();
            resNumbers.Should().BeEquivalentTo(expected);
        }


    }
}
