var solution = new Solution();

Console.WriteLine(solution.LongestSubstring("aaabb", 3)); // Expected = 3
Console.WriteLine(solution.LongestSubstring("ababbc", 2)); // Expected = 5

class Text
{
    public Text(int start, int end)
    {
        Start = start;
        End = end;
    }

    public int Start { get; set; }
    public int End { get; set; }
}

public class Solution
{
    public int LongestSubstring(string s, int k)
    {
        if (string.IsNullOrEmpty(s) || s.Length < k)
        {
            return 0;
        }

        int maxLength = 0;
        Queue<Text> queue = new Queue<Text>();
        queue.Enqueue(new Text(0, s.Length - 1)); // Store (start, end) indices of substrings to process

        while (queue.Any())
        {
            Text currentRange = queue.Dequeue();
            int start = currentRange.Start;
            int end = currentRange.End;

            // If the current substring is too short, skip it
            if (end - start + 1 < k)
            {
                continue;
            }

            // Count character frequencies for the current substring
            int[] charCounts = new int[26]; // For lowercase English letters
            for (int i = start; i <= end; i++)
            {
                charCounts[s[i] - 'a']++;
            }

            // Find the first character that appears less than k times in this substring
            int splitIndex = -1;
            for (int i = start; i <= end; i++)
            {
                if (charCounts[s[i] - 'a'] < k)
                {
                    splitIndex = i;
                    break;
                }
            }

            if (splitIndex == -1)
            {
                // All characters in this substring appear at least k times
                maxLength = Math.Max(maxLength, end - start + 1);
            }
            else
            {
                // Found a splitting character, divide and add subproblems to the queue

                // Add the left part
                if (splitIndex - 1 >= start)
                {
                    queue.Enqueue(new Text(start, splitIndex - 1));
                }

                // Add the right part (skip consecutive splitting characters)
                int nextStart = splitIndex + 1;
                while (nextStart <= end && charCounts[s[nextStart] - 'a'] < k)
                {
                    nextStart++;
                }
                if (nextStart <= end)
                {
                    queue.Enqueue(new Text(nextStart, end));
                }
            }
        }

        return maxLength;
    }
}