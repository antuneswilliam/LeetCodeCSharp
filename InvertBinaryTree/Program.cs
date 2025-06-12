using System.Text.Json;

var solution = new Solution();

var result = solution.InvertTree(
    new TreeNode(4,
        new TreeNode(2, new TreeNode(1), new TreeNode(3)),
        new TreeNode(7, new TreeNode(6), new TreeNode(9))));
Console.WriteLine(JsonSerializer.Serialize(result));
// Expected [4,7,2,9,6,3,1]

var result2 = solution.InvertTree(
    new TreeNode(2, new TreeNode(1), new TreeNode(3)));
Console.WriteLine(JsonSerializer.Serialize(result2));
// Expected [2,3,1]

var result3 = solution.InvertTree(new TreeNode());
Console.WriteLine(JsonSerializer.Serialize(result3));
// Expected []

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        // Base case: If the node is null, there's nothing to invert, so return null.
        if (root == null)
        {
            return null;
        }

        // Recursively invert the left and right subtrees.
        TreeNode leftInverted = InvertTree(root.left);
        TreeNode rightInverted = InvertTree(root.right);

        // Swap the left and right children of the current node.
        root.left = rightInverted;
        root.right = leftInverted;

        // Return the current node (which is now the root of the inverted subtree).
        return root;
    }
}