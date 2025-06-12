var solution = new Solution();

Console.WriteLine(string.Join(',', solution.TwoSum([2, 7, 11, 15], 9))); // Expected = [0, 1]
Console.WriteLine(string.Join(',', solution.TwoSum([3, 2, 4], 6))); // Expected = [1, 2]
Console.WriteLine(string.Join(',', solution.TwoSum([3, 3], 6))); // Expected = [0, 1]

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dic = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (dic.ContainsKey(diff))
            {
                return [dic[diff], i];
            }

            if (!dic.ContainsKey(nums[i]))
                dic.Add(nums[i], i);
        }

        return [];
    }
}