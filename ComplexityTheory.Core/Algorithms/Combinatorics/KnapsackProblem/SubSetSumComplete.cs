namespace ComplexityTheory.Core.Algorithms.Combinatorics.KnapsackProblem
{
    using System.Collections.Generic;

    /// <summary>
    /// I call it "Complete" to make the distinction between this one, which grabs any subset 
    /// even if the elements are not sequential, and the ones that need the subset to be sequential.
    /// </summary>
    public static class SubSetSumComplete
    {
        public static bool SubsetSum(List<int> nums, int target)
        {
            var left = new List<int> { 0 };
            var right = new List<int> { 0 };
            foreach (var n in nums)
            {
                if (left.Count < right.Count) left = Insert(n, left);
                else right = Insert(n, right);
            }
            int lefti = 0, righti = right.Count - 1;
            while (lefti < left.Count && righti >= 0)
            {
                int s = left[lefti] + right[righti];
                if (s < target) lefti++;
                else if (s > target) righti--;
                else return true;
            }
            return false;
        }

        public static List<int> Insert(int num, List<int> nums)
        {
            var result = new List<int>();
            int lefti = 0, left = nums[0] + num;
            for (var righti = 0; righti < nums.Count; righti++)
            {

                int right = nums[righti];
                while (left < right)
                {
                    result.Add(left);
                    left = nums[++lefti] + num;
                }
                if (right != left) result.Add(right);
            }
            while (lefti < nums.Count) result.Add(nums[lefti++] + num);
            return result;
        }
    }
}
