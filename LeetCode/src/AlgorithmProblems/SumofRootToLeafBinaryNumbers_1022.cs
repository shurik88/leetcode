using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems
{
    public class SumofRootToLeafBinaryNumbers_1022
    {
        public int SumRootToLeaf(TreeNode root)
        {
            return Sum(root, 0);
        }

        private static int Sum(TreeNode node, int val)
        {
            if (node == null)
                return 0;

            val = val * 2 + node.val;
            if (node.left == null && node.right == null)
                return val;

            return Sum(node.left, val) + Sum(node.right, val);

        }

        public class TreeNode {
             public int val;
             public TreeNode left;
             public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
 
    }
}
