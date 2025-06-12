var solution = new Solution();

Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));

public class Solution
{ 
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // 1. Build Adjacency List (Graph Representation)
        // This makes it easy to find neighbors of a node.
        List<List<int>> graph = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
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
            return true; // Path exists if source and destination are the same
        }

        // 3. BFS Implementation
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[n]; // To keep track of visited nodes and avoid cycles

        queue.Enqueue(source);
        visited[source] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

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
                    queue.Enqueue(neighbor);
                }
            }
        }

        // If the queue becomes empty and destination was not reached, no path exists
        return false;
    }
}