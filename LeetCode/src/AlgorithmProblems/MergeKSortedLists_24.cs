using AlgorithmProblems.Structures.Heap;
using System;
using System.Collections.Generic;

namespace AlgorithmProblems
{
    public class MergeKSortedLists_24
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            var heapList = new List<HeapElem<int, ListNode>>();

            for (var i = 0; i < lists.Length; ++i)
            {
                if(lists[i] != null)
                    heapList.Add(new HeapElem<int, ListNode> { Key = lists[i].val, Value = lists[i] });
            }
            if (heapList.Count == 0)
                return null;

            //var heapArray = heapList.ToArray();
            BuildMinHeap(heapList);

            var root = new ListNode(0);
            var currNode = root;
            var currIndex = 0;
            while(currIndex != heapList.Count)
            {
                var elem = heapList[currIndex];
                currNode.next = new ListNode(elem.Key);
                currNode = currNode.next;
                if (elem.Value.next == null)
                {
                    currIndex++;
                    BuildMinHeap(heapList, currIndex);
                }
                else
                {
                    heapList[currIndex] = new HeapElem<int, ListNode>() { Key = elem.Value.next.val, Value = elem.Value.next };
                    MinHeapify(heapList, currIndex, currIndex);

                }
                
            }

            return root.next;
        }

        private static void BuildMinHeap(List<HeapElem<int, ListNode>> arr, int startIndex = 0)
        {
            var lastParent = (arr.Count - 1- startIndex) / 2;
            for (var i = lastParent + startIndex; i >= startIndex; i--)
            {
                MinHeapify(arr, i, startIndex);
            }
        }

        private static void MinHeapify(List<HeapElem<int, ListNode>> arr, int i, int rootIndex = 0)
        {
            var length = arr.Count - rootIndex;
            var left = GetLeft(i, rootIndex);
            var right = GetRight(i, rootIndex);
            var smallest = i;
            if (left < arr.Count && arr[smallest].Key.CompareTo(arr[left].Key) > 0)
                smallest = left;
            if (right < arr.Count && arr[smallest].Key.CompareTo(arr[right].Key) > 0)
                smallest = right;

            if (smallest != i)
            {
                var temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;
                MinHeapify(arr, smallest, rootIndex);
            }
        }

        private static int GetLeft(int elemIndex, int rootIndex = 0)
        {
            return 2 * (elemIndex - rootIndex) + 1 + rootIndex;
        }

        private static int GetRight(int elemIndex, int rootIndex = 0)
        {
            return 2 * (elemIndex - rootIndex) + 2 + rootIndex;
        }

        private static void BuildMaxHeap(HeapElem<int, ListNode>[] arr)
        {
            var lastParent = (arr.Length - 1) / 2;
            for (var i = lastParent; i >= 0; i--)
            {
                MaxHeapify(arr, i);
            }
        }

        private static void MaxHeapify(HeapElem<int, ListNode>[] arr, int i, int rootIndex = 0)
        {
            var length = arr.Length - rootIndex;
            var left = GetLeft(i, rootIndex);
            var right = GetRight(i, rootIndex);
            var largest = i;
            if (left < length && arr[largest].Key.CompareTo(arr[left].Key) < 0)
                largest = left;
            if (right < length && arr[largest].Key.CompareTo(arr[right].Key) < 0)
                largest = right;

            if (largest != i)
            {
                var temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;
                MaxHeapify(arr, largest, rootIndex);
            }
        }
    }

    public class ListNode
    {
      public int val;

      public ListNode next;

      public ListNode(int x) { val = x; }
    }
}
