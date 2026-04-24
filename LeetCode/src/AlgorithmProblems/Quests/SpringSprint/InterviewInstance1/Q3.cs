namespace AlgorithmProblems.Quests.SpringSprint.InterviewInstance1
{
    /// <summary>
    ///    Q3 House robber 
    /// <see cref="https://leetcode.com/problems/house-robber/?envType=problem-list-v2&envId=interview-instance-i"/>
    /// </summary>
    public class Q3
    {
        public int Rob(int[] nums)
        {
            var sum1 = 0;
            var sum2 = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                var temp = Math.Max(sum1 , sum2 + nums[i]);
                sum2 = sum1;
                sum1 = temp;
            } 
            return Math.Max(sum1, sum2);
        }
    }
}
