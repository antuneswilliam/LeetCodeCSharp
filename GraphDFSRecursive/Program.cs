var solution = new Solution();

Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));


public class Solution
{
    // Adjacency list will be shared across recursive calls
    private List<int>[] graph;
    // Visited array will be shared across recursive calls
    private bool[] visited;
    // Destination node will be checked in recursive calls
    private int destinationNode;

    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // 1. Build Adjacency List (Graph Representation)
        graph = new List<int>[n];
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

        // Initialize visited array and destination node for recursive calls
        visited = new bool[n];
        destinationNode = destination;

        // 3. DFS Implementation (Recursive)
        return DfsRecursive(source);
    }

    private bool DfsRecursive(int current)
    {
        // If we've already visited this node, or if we reached the destination
        // (the latter check is typically done before the recursive call in the main loop,
        // but can also be placed here for early exit).
        if (visited[current])
        {
            return false; // Already processed this path
        }

        visited[current] = true; // Mark current node as visited

        if (current == destinationNode)
        {
            return true; // Found the destination!
        }

        // Explore neighbors
        foreach (int neighbor in graph[current])
        {
            if (!visited[neighbor])
            {
                // If the recursive call finds the destination, propagate true back up
                if (DfsRecursive(neighbor))
                {
                    return true;
                }
            }
        }

        // If no path was found through this branch
        return false;
    }
}