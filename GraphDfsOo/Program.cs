var solution = new Solution();

Console.WriteLine(solution.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
Console.WriteLine(solution.ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));

class Node
{
    public List<int> Neighbors { get; } = [];
    public bool Visited { get; set; }
}

class Graph
{
    public List<Node> Nodes { get; } = [];

    public Graph(int size)
    {
        for (var i = 0; i < size; i++)
            Nodes.Add(new Node());
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
}

static class PathFinder
{
    public static bool FindPath(List<Node> nodes, int source, int destination)
    {
        Stack<int> stack = new();

        stack.Push(source);
        nodes[source].Visited = true;

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current == destination)
                return true;

            foreach (var neighbor in nodes[current].Neighbors)
            {
                if (nodes[neighbor].Visited)
                    continue;

                nodes[neighbor].Visited = true;
                stack.Push(neighbor);
            }
        }

        return false;
    }
}

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
            return true;

        var graph = new Graph(size: n);

        graph.MapEdges(edges);

        return PathFinder.FindPath(graph.Nodes, source, destination);
    }
}