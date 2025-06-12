var solution = new Solution();

Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // 1. Build Adjacency List (Graph Representation)
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u); // Assuming an undirected graph
        }

        // 2. Handle Edge Cases
        if (source == destination)
        {
            return true;
        }

        // 3. DFS Implementation (Iterative with Stack)
        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[n];

        stack.Push(source);
        visited[source] = true;

        while (stack.Count > 0)
        {
            int current = stack.Pop(); // Get the top element

            // If we reached the destination, a path exists
            if (current == destination)
            {
                return true;
            }

            // Explore neighbors
            foreach (int neighbor in graph[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    stack.Push(neighbor); // Push unvisited neighbor onto the stack
                }
            }
        }

        // If the stack becomes empty and destination was not reached, no path exists
        return false;
    }
}