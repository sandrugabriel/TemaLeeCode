using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tema3
{
    public class Functii
    {

        /*Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

 

Example 1:


Input: p = [1,2,3], q = [1,2,3]
Output: true
Example 2:


Input: p = [1,2], q = [1,null,2]
Output: false
Example 3:


Input: p = [1,2,1], q = [1,1,2]
Output: false*/
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (p == null && q == null)
                    return true;

                if (p == null || q == null)
                    return false;

                if (p.val != q.val)
                    return false;

                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

        /*Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

 

Example 1:


Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false*/
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return IsMirror(root.left, root.right);
        }
        private bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;
            return (t1.val == t2.val) && IsMirror(t1.left, t2.right) && IsMirror(t1.right, t2.left);
        }

        /*Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 3
Example 2:

Input: root = [1,null,2]
Output: 2
 */
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        /*Given an integer array nums where the elements are sorted in ascending order, convert it to a 
height-balanced
 binary search tree.

 

Example 1:


Input: nums = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: [0,-10,5,null,-3,null,9] is also accepted:

Example 2:


Input: nums = [1,3]
Output: [3,1]
Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.*/
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return ConstructBST(nums, 0, nums.Length - 1);
        }
        private TreeNode ConstructBST(int[] nums, int left, int right)
        {
            if (left > right)
                return null;

            int mid = left + (right - left) / 2;
            TreeNode root = new TreeNode(nums[mid]);

            root.left = ConstructBST(nums, left, mid - 1);
            root.right = ConstructBST(nums, mid + 1, right);

            return root;
        }

        /*Given a binary tree, determine if it is 
height-balanced
.

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: true
Example 2:


Input: root = [1,2,2,3,3,null,null,4,4]
Output: false
Example 3:

Input: root = []
Output: true*/
        public bool IsBalanced(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }
        private int CheckHeight(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = CheckHeight(node.left);
            int rightHeight = CheckHeight(node.right);

            if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /*Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

Note: A leaf is a node with no children.



Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 2
Example 2:

Input: root = [2,null,3,null,4,null,5,null,6]
Output: 5*/
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 1;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left == null && node.right == null)
                        return depth;

                    if (node.left != null)
                        queue.Enqueue(node.left);

                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                depth++;
            }

            return depth;
        }

        /*Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.

A leaf is a node with no children.

 

Example 1:


Input: root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
Output: true
Explanation: The root-to-leaf path with the target sum is shown.
Example 2:


Input: root = [1,2,3], targetSum = 5
Output: false
Explanation: There two root-to-leaf paths in the tree:
(1 --> 2): The sum is 3.
(1 --> 3): The sum is 4.
There is no root-to-leaf path with sum = 5.
Example 3:

Input: root = [], targetSum = 0
Output: false
Explanation: Since the tree is empty, there are no root-to-leaf paths.*/
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;

            return HasPathSumHelper(root, 0, targetSum);
        }
        private bool HasPathSumHelper(TreeNode node, int currentSum, int targetSum)
        {
            currentSum += node.val;

            if (node.left == null && node.right == null)
            {
                return currentSum == targetSum;
            }

            bool leftResult = node.left != null ? HasPathSumHelper(node.left, currentSum, targetSum) : false;
            bool rightResult = node.right != null ? HasPathSumHelper(node.right, currentSum, targetSum) : false;

            return leftResult || rightResult;
        }

        /*A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.*/
        public bool IsPalindrome(string s)
        {
            string cleanedString = Regex.Replace(s.ToLower(), "[^a-z0-9]", "");

            int left = 0;
            int right = cleanedString.Length - 1;

            while (left < right)
            {
                if (cleanedString[left] != cleanedString[right])
                    return false;
                left++;
                right--;
            }

            return true;
        }

        /*Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

You must implement a solution with a linear runtime complexity and use only constant extra space.



Example 1:

Input: nums = [2,2,1]
Output: 1
Example 2:

Input: nums = [4,1,2,1,2]
Output: 4
Example 3:

Input: nums = [1]
Output: 1
*/
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (int num in nums)
            {
                result ^= num;
            }
            return result;
        }

        /*Write an algorithm to determine if a number n is happy.

A happy number is a number defined by the following process:

Starting with any positive integer, replace the number by the sum of the squares of its digits.
Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
Those numbers for which this process ends in 1 are happy.
Return true if n is a happy number, and false if not.

 

Example 1:

Input: n = 19
Output: true
Explanation:
12 + 92 = 82
82 + 22 = 68
62 + 82 = 100
12 + 02 + 02 = 1
Example 2:

Input: n = 2
Output: false*/
        public bool IsHappy(int n)
        {
            HashSet<int> seen = new HashSet<int>();

            while (n != 1 && !seen.Contains(n))
            {
                seen.Add(n);
                n = GetNextSumOfSquares(n);
            }

            return n == 1;
        }
        private int GetNextSumOfSquares(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return sum;
        }


    }
}
