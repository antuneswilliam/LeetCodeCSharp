var solution = new Solution();

Console.WriteLine(solution.Fibonacci(2)); // Expected = 1
Console.WriteLine(solution.Fibonacci(3)); // Expected = 2
Console.WriteLine(solution.Fibonacci(4)); // Expected = 3

Console.WriteLine(solution.Fibonacci(20)); // Expected = 6765

public class Solution
{
    public int Fibonacci(int n)
    {
        if (n == 0)
            return 0;

        var prev = 0;
        var next = 1;

        for (var i = 1; i < n; i++)
        {
            var sum = prev + next;
            prev = next;
            next = sum;
        }

        return next;
    }
}