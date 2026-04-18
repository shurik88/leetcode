namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    /// Q2. Range Frequency Queries
    /// </summary>
    /// <see cref="https://leetcode.com/problems/range-frequency-queries/?envType=problem-list-v2&envId=ssd-ssd5-comprehensive-data-operations-simulation"/>
    public class RangeFreqQuery
    {
        private readonly IDictionary<int, List<int>> _grouped = new Dictionary<int, List<int>>();
        public RangeFreqQuery(int[] arr)
        {
            _grouped = new Dictionary<int, List<int>>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (!_grouped.TryGetValue(arr[i], out var list))
                    _grouped[arr[i]] = new List<int> { i };
                else
                {
                    list.Add(i);
                }
            }
            //_grouped = arr.Select((value, index) => (value, index)).GroupBy(x => x.value).ToDictionary(x => x.Key, x => x.Select(y => y.index).ToList());
        }

        public int Query(int left, int right, int value)
        {
            if(!_grouped.TryGetValue(value, out var indexes))
                return 0;

            var leftIndex = indexes.BinarySearch(left);
            var rightIndex = indexes.BinarySearch(right);
            if (leftIndex < 0)
                leftIndex = ~leftIndex;
            if (rightIndex < 0)
                rightIndex = ~rightIndex;

            if (leftIndex == indexes.Count)
                return 0;

            if (rightIndex == 0 && indexes[rightIndex] > right)
                return 0;

            return rightIndex - leftIndex + (rightIndex != indexes.Count && indexes[rightIndex] == right ? 1 : 0);
        }
    }
}
