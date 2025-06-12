var sol = new  Solution();

int[] nums1 = { 1, 2, 3, 4, 2, 3, 2, 1 };
int k1 = 3;
int[] result1 = sol.Slide(nums1, k1); // Expected: [3, 3, 5, 5, 6, 7]
Console.WriteLine($"[{string.Join(", ", result1)}]");

public class Solution
{
    public int[] Slide(int[] nums, int k)
    {
        // Handle edge cases: empty or null array, or invalid window size.
        if (nums == null || nums.Length == 0 || k <= 0)
        {
            return new int[0];
        }

        // The list to store the results for each window.
        List<int> results = new List<int>();

        // Loop through the array to create each sliding window.
        // The loop runs from index 0 up to nums.Length - k to ensure a full window of size k.
        for (int i = 0; i <= nums.Length - k; i++)
        {
            // Create a new array for the current window's elements.
            // This copies k elements from nums starting at index i.
            int[] currentWindow = new int[k];
            var size = k + i;
            currentWindow = nums[i..size];
            // Array.Copy(nums, i, currentWindow, 0, k);

            // --- Check for sequential numbers within the current window ---
            bool isSequential = true;

            // Iterate through the sorted window to verify if elements are consecutive.
            for (int j = 0; j < currentWindow.Length - 1; j++)
            {
                // If any two adjacent elements in the sorted window are not consecutive,
                // then the window does not contain sequential numbers.
                if (currentWindow[j] + 1 != currentWindow[j + 1])
                {
                    isSequential = false;
                    break; // No need to check further if non-sequential
                }
            }

            // --- Add to results based on sequential check ---
            if (isSequential)
            {
                // If the numbers are sequential, add the maximum value from the current window.
                results.Add(currentWindow.Max());
            }
            else
            {
                // If the numbers are not sequential, add 0 to the results.
                results.Add(0);
            }
        }

        // Convert the list of results to an array and return it.
        return results.ToArray();
    }
    
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k <= 0)
        {
            return [];
        }

        // Deque to store indices of elements in monotonically decreasing order of their values
        LinkedList<int> deque = new LinkedList<int>();
        // List to store the maximums of each window
        List<int> result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // 1. Remove elements from the front of the deque that are out of the current window
            // The element at deque.First.Value is out of bounds if its index is i - k
            if (deque.Count > 0 && deque.First.Value <= i - k)
            {
                deque.RemoveFirst();
            }

            // 2. Remove elements from the back of the deque that are smaller than or equal to the current element
            // These elements can no longer be the maximum in future windows because nums[i] is larger (or equal)
            // and comes after them.
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
            {
                deque.RemoveLast();
            }

            // 3. Add the current element's index to the back of the deque
            deque.AddLast(i);

            // 4. If the window has formed (i.e., we have processed at least k elements),
            // the maximum for the current window is at the front of the deque.
            if (i >= k - 1)
            {
                result.Add(nums[deque.First.Value]);
            }
        }

        return result.ToArray();
    }
}