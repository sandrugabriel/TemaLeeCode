using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema3.Functii;

namespace Tema3
{
    public class Solutii
    {

        Functii functii = new Functii();

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
        public void solutia1()
        {

            TreeNode p = new TreeNode(1);
            p.left = new TreeNode(2);
            p.right = new TreeNode(3);

            TreeNode q = new TreeNode(1);
            q.left = new TreeNode(2);
            q.right = new TreeNode(3);
            Console.WriteLine(functii.IsSameTree(p, q));
        }

        /*Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).



Example 1:


Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false*/
        public void solutia2()
        {

            TreeNode root2 = new TreeNode(1);
            root2.left = new TreeNode(2);
            root2.right = new TreeNode(2);
            root2.left.right = new TreeNode(3);
            root2.right.right = new TreeNode(3);

            Console.WriteLine(functii.IsSymmetric(root2)); 
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
        public void solutia3()
        {
            TreeNode root2 = new TreeNode(1);
            root2.right = new TreeNode(2);

            Console.WriteLine(functii.MaxDepth(root2));
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
        public void solutia4()
        {
            int[] nums1 = { -10, -3, 0, 5, 9 };

            TreeNode result1 = functii.SortedArrayToBST(nums1);

            PrintTree(result1); 
            Console.WriteLine();

        }
        static void PrintTree(TreeNode root)
        {
            if (root == null)
                return;

            Console.Write(root.val + " ");
            PrintTree(root.left);
            PrintTree(root.right);
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
        public void solutia5()
        {
            TreeNode root2 = new TreeNode(1);
            root2.left = new TreeNode(2);
            root2.right = new TreeNode(2);
            root2.left.left = new TreeNode(3);
            root2.left.right = new TreeNode(3);
            root2.left.left.left = new TreeNode(4);
            root2.left.left.right = new TreeNode(4);


            Console.WriteLine(functii.IsBalanced(root2));
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
        public void solutia6()
        {
            TreeNode root2 = new TreeNode(2);
            root2.right = new TreeNode(3);
            root2.right.right = new TreeNode(4);
            root2.right.right.right = new TreeNode(5);
            root2.right.right.right.right = new TreeNode(6);

            Console.WriteLine(functii.MinDepth(root2));
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
        public void solutia7()
        {
            TreeNode root2 = new TreeNode(1);
            root2.left = new TreeNode(2);
            root2.right = new TreeNode(3);

            Console.WriteLine(functii.HasPathSum(root2, 22));
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
        public void solutia8()
        {
            string s1 = "A man, a plan, a canal: Panama";

            Console.WriteLine(functii.IsPalindrome(s1));
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
        public void solutia9()
        {
            int[] nums1 = { 2, 2, 1 };

            Console.WriteLine(functii.SingleNumber(nums1));
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
        public void solutia10()
        {
            int n2 = 2;

            System.Console.WriteLine(functii.IsHappy(n2));
        }

    }
}
