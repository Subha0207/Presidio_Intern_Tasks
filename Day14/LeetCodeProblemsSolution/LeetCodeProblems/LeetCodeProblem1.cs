using System.Reflection.Emit;

namespace LeetCodeProblemApplication
{

    public class LeetCodeProblem1
    {
        public async Task<int> MinimumDepth(TreeNode root)
        {
            // If the root is null, the minimum depth is 0.
            if (root == null)
                return 0;

            // If both left and right child nodes are null, the minimum depth is 1.
            if (root.left == null && root.right == null)
                return 1;

            // If the left child node is null, recursively find the minimum depth on the right subtree.
            if (root.left == null)
                return 1 + await MinimumDepth(root.right);

            // If the right child node is null, recursively find the minimum depth on the left subtree.
            if (root.right == null)
                return 1 + await MinimumDepth(root.left);

            // If both left and right child nodes exist, recursively find the minimum depth on both subtrees and take the minimum.
            return 1 + Math.Min(await MinimumDepth(root.left), await MinimumDepth(root.right));
        }

        public async Task GetTreeMinDepthValuesAsync()
        {
            int[] values = { 3, 9, 20, -1, -1, 15, 7 };
            TreeBuilder builder = new TreeBuilder();
            TreeNode root = builder.BuildTree(values);
            Console.WriteLine("The Minimum depth of the given Tree is : " + await MinimumDepth(root));
        }
        public static void Main(string[] args)
        {
            LeetCodeProblem1 program = new LeetCodeProblem1();
            program.GetTreeMinDepthValuesAsync();
        }
    }
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
    public class TreeBuilder
    {
        public TreeNode BuildTree(int[] values)
        {
            if (values == null || values.Length == 0)
            {
                return null;
            }

            var queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(values[0]);
            queue.Enqueue(root);

            int i = 1;
            while (queue.Count > 0 && i < values.Length)
            {
                var current = queue.Dequeue();

                // Check for null values in the input array
                if (values[i] != -1)
                {
                    current.left = new TreeNode(values[i]);
                    queue.Enqueue(current.left);
                }
                i++;

                if (i < values.Length && values[i] != -1)
                {
                    current.right = new TreeNode(values[i]);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }
    }
}
