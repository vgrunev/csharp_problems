public class Solution
{
    private int[,] dp = new int[101, 101];

    public int PalindromePartition(string s, int k)
    {
        for (int i = 0; i < 101; i++)
        {
            for (int j = 0; j < 101; j++)
            {
                dp[i, j] = int.MaxValue;
            }
        }

        return FindSolution(s, k);
    }

    public int FindSolution(string s, int k)
    {
        if (k == 1) return MakePalindrome(s);
        var n = s.Length;
        if (dp[k, n] != int.MaxValue) return dp[k, n];
        var result = int.MaxValue;

        for (int i = 1; i <= n - k + 1; i++)
        {
            var c = FindSolution(s.Substring(0, i), 1);
            var sp = FindSolution(s.Substring(i, n - i), k - 1);
            result = Math.Min(result, c + sp);
        }

        dp[k, n] = result;

        return result;
    }


    public int MakePalindrome(string s)
    {
        var c = 0;
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1]) c++;
        }

        return c;
    }
}
