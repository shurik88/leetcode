using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.Structures.Heap
{
    public class Heap<TKey, TValue>
        where TKey : IComparable
    {
        public Heap(HeapType type, int size)
        {
            if (size < 1)
                throw new ArgumentException("Size < 1");

            _type = type;
            _heap = new HeapElem<TKey, TValue>[size];
        }

        public Heap(HeapType type, HeapElem<TKey, TValue>[] elems): this(type, elems.Length)
        {
            for (var i = 0; i < elems.Length; ++i)
                _heap[i] = elems[i];

            if (type == HeapType.NonDecreasing)
                BuildMaxHeap(_heap);
            else if (type == HeapType.NonIncreasing)
                BuildMinHeap(_heap);
            else
                throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown value");
        }

        private static void BuildMaxHeap(HeapElem<TKey, TValue>[] arr)
        {
            var lastParent = (arr.Length - 1) / 2;
            for (var i = lastParent; i >= 0; i--)
            {
                MaxHeapify(arr, i);
            }
        }

        private static void BuildMinHeap(HeapElem<TKey, TValue>[]arr)
        {
            var lastParent = (arr.Length - 1) / 2;
            for (var i = lastParent; i >= 0; i--)
            {
                MinHeapify(arr, i);
            }
        }

        private static int GetLeft(int root)
        {
            return 2 * root + 1;
        }

        private static int GetRight(int root)
        {
            return 2 * root + 2;
        }

        private static bool IsMaxHeap(HeapElem<TKey,TValue>[] arr)
        {
            var lastParent = (arr.Length - 1) / 2;
            for (var i = 0; i <= lastParent; ++i)
            {
                var left = (2 * i + 1) >= arr.Length ? arr[i] : arr[2 * i + 1];
                var right = (2 * i + 2) >= arr.Length ? arr[i] : arr[2 * i + 2]; ;
                if (arr[i].Key.CompareTo(left.Key) < 0 || arr[i].Key.CompareTo(right.Key) < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsMinHeap(HeapElem<TKey, TValue>[] arr)
        {
            var lastParent = (arr.Length - 1) / 2;
            for (var i = 0; i <= lastParent; ++i)
            {
                var left = (2 * i + 1) >= arr.Length ? arr[i] : arr[2 * i + 1];
                var right = (2 * i + 2) >= arr.Length ? arr[i] : arr[2 * i + 2]; ;
                if (arr[i].Key.CompareTo(left.Key) > 0 || arr[i].Key.CompareTo(right.Key) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void MinHeapify(HeapElem<TKey, TValue>[] arr, int i, int? heapSize = null)
        {
            var length = heapSize ?? arr.Length;
            var left = GetLeft(i);
            var right = GetRight(i);
            var smallest = i;
            if (left < length && arr[smallest].Key.CompareTo(arr[left].Key) > 0)
                smallest = left;
            if (right < length && arr[smallest].Key.CompareTo(arr[right].Key) > 0)
                smallest = right;

            if (smallest != i)
            {
                var temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;
                MinHeapify(arr, smallest, heapSize);
            }
        }

        private static void MaxHeapify(HeapElem<TKey, TValue>[] arr, int i, int? heapSize = null)
        {
            var length = heapSize ?? arr.Length;
            var left = GetLeft(i);
            var right = GetRight(i);
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
                MaxHeapify(arr, largest, heapSize);
            }
        }



        private readonly HeapElem<TKey, TValue>[] _heap;

        private readonly HeapType _type;
        
        public HeapElem<TKey, TValue> Root { get { return _heap[0]; } }

        public void Add(HeapElem<TKey, TValue> elem)
        {
            throw new NotImplementedException();
        }
    }
}
