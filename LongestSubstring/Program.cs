var solution = new Solution();

Console.WriteLine(solution.LongestSubstring("aaabb", 3)); // Expected = 3
Console.WriteLine(solution.LongestSubstring("ababbc", 2)); // Expected = 5
Console.WriteLine(solution.LongestSubstring("ababacb", 3)); // Expected = 0

public class Solution
{
    public int LongestSubstring(string s, int k)
    {
        if (string.IsNullOrEmpty(s) || s.Length < k)
        {
            return 0;
        }

        // Count character frequencies
        var dic = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (dic.ContainsKey(c))
                dic[c]++;
            else
                dic.Add(c, 1);
        }

        // Register bad characters, characters that appear less than k times
        var badChars = new List<char>();

        foreach (var key in dic.Keys)
        {
            if (dic[key] < k)
            {
                badChars.Add(key);
            }
        }

        // if no bad characters, return the length of the string
        if (badChars.Count == 0)
            return s.Length;

        // replace bad characters with a special character
        foreach (var c in badChars)
        {
            s = s.Replace(c, ';');
        }

        // split the string by the special character
        var results = s.Split(";");

        var maxLength = 0;

        // find the longest substring for each segment
        foreach (var result in results)
        {
            // recursively find the longest substring for each segment
            var currentSegmentMax = LongestSubstring(result, k);

            // determine the maximum length of the substring
            maxLength = Math.Max(maxLength, currentSegmentMax);
        }

        return maxLength;
    }
}