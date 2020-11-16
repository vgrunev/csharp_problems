public class Solution
{
    public int ConstrainedSubsetSum(int[] nums, int k)
    {
        var n = nums.Length;
        var dp = new long?[n];

        long Solve(int[] nums, int i, int k)
        {
            if (i == nums.Length) return 0;
            if (dp[i].HasValue) return dp[i].Value;

            long bestSolution = 0;
            for (int j = i + 1; j < Math.Min(n, i + k + 1); j++)
            {
                bestSolution = Math.Max(Solve(nums, j, k), bestSolution);
                if (nums[j] >= 0)
                {
                    break;
                }
            }

            dp[i] = nums[i] + bestSolution;
            return dp[i].Value;
        }

        var result = Solve(nums, 0, k);
        for (int i = 1; i < n; i++)
        {
            result = Math.Max(Solve(nums, i, k), result);
        }

        return (int) result;
    }
}
