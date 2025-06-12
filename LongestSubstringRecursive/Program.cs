var solution = new Solution();

Console.WriteLine(solution.LongestSubstring("aaabb", 3)); // Expected = 3
Console.WriteLine(solution.LongestSubstring("ababbc", 2)); // Expected = 5
Console.WriteLine(solution.LongestSubstring("aaaaabaaaaaacaabbedd", 2)); // Expected = 5

public class Solution
{
    public int LongestSubstring(string s, int k)
    {
        // Base case: If the string is empty or its length is less than k,
        // it's impossible to form a valid substring.
        if (string.IsNullOrEmpty(s) || s.Length < k)
        {
            return 0;
        }

        // Count character frequencies
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCounts.ContainsKey(c))
            {
                charCounts[c]++;
            }
            else
            {
                charCounts.Add(c, 1);
            }
        }

        // Find the first character that appears less than k times
        foreach (char c in charCounts.Keys)
        {
            if (charCounts[c] < k)
            {
                int maxLen = 0; // Initialize maxLen to 0
                string[] parts = s.Split(c);
                foreach (string part in parts)
                {
                    int currentPartLength = LongestSubstring(part, k);
                    if (currentPartLength > maxLen) // If the current part's length is greater
                    {
                        maxLen = currentPartLength; // Update maxLen
                    }
                }
                return maxLen;
            }
        }

        // If we reach here, it means all characters in the current string
        // appear at least k times. So, this entire string is a valid answer.
        return s.Length;
    }
}