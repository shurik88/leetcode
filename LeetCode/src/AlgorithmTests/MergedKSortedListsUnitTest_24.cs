using System;
using AlgorithmProblems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmTests
{
    [TestClass]
    public class MergedKSortedListsUnitTest_24
    {
        [TestMethod]
        public void MergedKSortedLists()
        {
            //Case1();
            Case2();
            
        }

        private void Case(ListNode[] input, ListNode output)
        {
            var res = MergeKSortedLists_24.MergeKLists(input);
            var currIndex = 0;
            var actual = res;
            var expected = output;
            while(expected != null)
            {
                Assert.IsNotNull(actual, $"Expected {expected.val} at position: {currIndex} but actual is null");
                Assert.AreEqual(expected.val, actual.val, $"At position: {currIndex}");
                expected = expected.next;
                actual = actual.next;
                currIndex++;
            }
            if (actual != null)
                Assert.Fail($"Expected null at position: {currIndex} but actual:{actual.val}");
        }

        //[[-10,-9,-9,-3,-1,-1,0],[-5],[4],[-8],[],[-9,-6,-5,-4,-2,2,3],[-3,-3,-2,-1,0]]
        //[-10,-9,-9,-9,-8,-6,-5,-5,-4,-3,-3,-3,-2,-2,-1,-1,-1,0,0,2,3,4]


        private void Case2()
        {
            var list1 = GenerateListNode(new int[] { -10, -9, -9, -3, -1, -1, 0 });
            var list2 = GenerateListNode(new int[] { -5 });
            var list3 = GenerateListNode(new int[] { 4 });
            var list4 = GenerateListNode(new int[] { -8 });
            var list5 = GenerateListNode(new int[] { });
            var list6 = GenerateListNode(new int[] { -9, -6, -5, -4, -2, 2, 3 });
            var list7 = GenerateListNode(new int[] { -3, -3, -2, -1, 0 });
            Case(new ListNode[] { list1, list2, list3, list4, list5, list6, list7 }, GenerateListNode(new int[] { -10, -9, -9, -9, -8, -6, -5, -5, -4, -3, -3, -3, -2, -2, -1, -1, -1, 0, 0, 2, 3, 4 }));
        }

        private void Case1()
        {
            var list2 = GenerateListNode(new int[] { 1, 4, 5 });//GenerateListNode(1, 3, 3);
            var list1 = GenerateListNode(new int[] { 1, 3, 4 });//GenerateListNode(0, 2, 5);
            var list3 = GenerateListNode(new int[] { 2, 6 });//GenerateListNode(2, 1, 7);
            var res = MergeKSortedLists_24.MergeKLists(new ListNode[] { list1, list2, list3 });
        }

        private ListNode GenerateListNode(int[] arr)
        {
            var rootListNode = new ListNode(0);
            var currNode = rootListNode;
            for(var i = 0; i < arr.Length; ++i)
            {
                currNode.next = new ListNode(arr[i]);
                currNode = currNode.next;
            }
            return rootListNode.next;
        }

        private ListNode GenerateListNode(int start, int inc, int count)
        {
            var currValue = start;
            var rootListNode = new ListNode(0);
            var currNode = rootListNode;
            var i = 0;
            while(i < count)
            {
                currNode.next = new ListNode(currValue);
                currNode = currNode.next;
                currValue += inc;
                i++;
            }
            return rootListNode.next;
        }
    }
}
