using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProblems
{
    public class TwoSum_1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            QuickSort(nums, 0, nums.Length - 1);
            int rightIndex = nums.Length - 1;
            int leftIndex = 0;
            while (true)
            {
                var sum = nums[leftIndex] + nums[rightIndex];
                if (sum == target)
                    return new int[2] { leftIndex, rightIndex };
                else if (sum > target)
                    rightIndex--;
                else
                    leftIndex++;
            }
        }

        static readonly Random Rand = new Random();

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left == right)
                return;
            var x = arr[Rand.Next(left, right)];
            var i = left;
            var j = right;
            while (i <= j)
            {
                while (arr[i] < x)
                    i++;
                while (arr[j] > x)
                    j--;
                if (i <= j)
                {
                    Swap(arr, i, j);
                    i++;
                    j--;
                }
            }

            if (i < right)
                QuickSort(arr, i, right);
            if (left < j)
                QuickSort(arr, left, j);
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
