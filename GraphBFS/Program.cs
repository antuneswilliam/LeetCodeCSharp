var solution = new Solution();

Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));

class Node
{
    public List<int> Neighbors { get; } = [];
}

class Graph
{
    private List<Node> Nodes { get; set; } = [];
    private Queue<int> Queue { get; set; } = new();
    private bool[] Visited { get; set; }

    public Graph(int size)
    {
        for (var i = 0; i < size; i++)
            Nodes.Add(new Node());

        Visited = new bool[size];
    }

    public void MapEdges(int[][] edges)
    {
        foreach (var edge in edges) {
            var u = edge[0];
            var v = edge[1];
            Nodes[u].Neighbors.Add(v);
            Nodes[v].Neighbors.Add(u);
        }
    }

    public bool FindPath(int source, int destination)
    {
        Queue.Enqueue(source);
        Visited[source] = true;

        while (Queue.Count > 0)
        {
            var current = Queue.Dequeue();

            // If we reached the destination, a path exists
            if (current == destination)
                return true;

            // Explore neighbors
            foreach (var neighbor in Nodes[current].Neighbors)
            {
                if (Visited[neighbor])
                    continue;

                Visited[neighbor] = true;
                Queue.Enqueue(neighbor);
            }
        }

        // If the queue becomes empty and destination was not reached, no path exists
        return false;
    }
}

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        // 2. Handle Edge Cases
        if (source == destination)
        {
            return true; // Path exists if source and destination are the same
        }

        var graph = new Graph(size: n);

        graph.MapEdges(edges);

        return graph.FindPath(source, destination);
    }

    public bool ValidPathBKP(int n, int[][] edges, int source, int destination)
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