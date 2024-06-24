using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tema13
{
    public class Solutii
    {
        Functii functii = new Functii();

        /*Given a string licensePlate and an array of strings words, find the shortest completing word in words.

A completing word is a word that contains all the letters in licensePlate. Ignore numbers and spaces in licensePlate, and treat letters as case insensitive. If a letter appears more than once in licensePlate, then it must appear in the word the same number of times or more.

For example, if licensePlate = "aBc 12c", then it contains letters 'a', 'b' (ignoring case), and 'c' twice. Possible completing words are "abccdef", "caaacab", and "cbca".

Return the shortest completing word in words. It is guaranteed an answer exists. If there are multiple shortest completing words, return the first one that occurs in words.



Example 1:

Input: licensePlate = "1s3 PSt", words = ["step","steps","stripe","stepple"]
Output: "steps"
Explanation: licensePlate contains letters 's', 'p', 's' (ignoring case), and 't'.
"step" contains 't' and 'p', but only contains 1 's'.
"steps" contains 't', 'p', and both 's' characters.
"stripe" is missing an 's'.
"stepple" is missing an 's'.
Since "steps" is the only word containing all the letters, that is the answer.
Example 2:

Input: licensePlate = "1s3 456", words = ["looks","pest","stew","show"]
Output: "pest"
Explanation: licensePlate only contains the letter 's'. All the words contain 's', but among these "pest", "stew", and "show" are shortest. The answer is "pest" because it is the word that appears earliest of the 3.
*/
        public void solutia1()
        {

            string licensePlate1 = "1s3 PSt";
            string[] words1 = { "step", "steps", "stripe", "stepple" };
            Console.WriteLine(functii.FindShortestCompletingWord(licensePlate1, words1));
        }

        /*Given two integers left and right, return the count of numbers in the inclusive range [left, right] having a prime number of set bits in their binary representation.

Recall that the number of set bits an integer has is the number of 1's present when written in binary.

For example, 21 written in binary is 10101, which has 3 set bits.


Example 1:

Input: left = 6, right = 10
Output: 4
Explanation:
6  -> 110 (2 set bits, 2 is prime)
7  -> 111 (3 set bits, 3 is prime)
8  -> 1000 (1 set bit, 1 is not prime)
9  -> 1001 (2 set bits, 2 is prime)
10 -> 1010 (2 set bits, 2 is prime)
4 numbers have a prime number of set bits.
Example 2:

Input: left = 10, right = 15
Output: 5
Explanation:
10 -> 1010 (2 set bits, 2 is prime)
11 -> 1011 (3 set bits, 3 is prime)
12 -> 1100 (2 set bits, 2 is prime)
13 -> 1101 (3 set bits, 3 is prime)
14 -> 1110 (3 set bits, 3 is prime)
15 -> 1111 (4 set bits, 4 is not prime)
5 numbers have a prime number of set bits.
*/
        public void solutia2()
        {

            int left1 = 6, right1 = 10;
            Console.WriteLine(functii.CountPrimeSetBits(left1, right1));
        }

        /*Given a n-ary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).



Example 1:



Input: root = [1,null,3,2,4,null,5,6]
Output: 3
Example 2:



Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: 5
*/
        public void solutia3()
        {
            Node root1 = new Node(1, new List<Node>
            {
                new Node(3, new List<Node> { new Node(5), new Node(6) }),
                new Node(2),
                new Node(4)
            });
            Console.WriteLine(functii.MaxDepth(root1));
        }

        /*Given the root of an n-ary tree, return the preorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)



Example 1:



Input: root = [1,null,3,2,4,null,5,6]
Output: [1,3,5,6,2,4]
Example 2:



Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [1,2,3,6,7,11,14,4,8,12,5,9,13,10]*/
        public void solutia4()
        {

            Node root1 = new Node(1, new List<Node> {
            null,
            new Node(3, new List<Node> {
                new Node(5),
                new Node(6)
            }),
            new Node(2),
            new Node(4)
        });
            List<int> result1 = functii.Preorder(root1);
            Console.WriteLine(string.Join(", ", result1));
        }

        /*Given the root of an n-ary tree, return the postorder traversal of its nodes' values.

Nary-Tree input serialization is represented in their level order traversal. Each group of children is separated by the null value (See examples)



Example 1:


Input: root = [1,null,3,2,4,null,5,6]
Output: [5,6,3,2,4,1]
Example 2:


Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]*/
        public void solutia5()
        {

            Node root1 = new Node(1, new List<Node> {
            null,
            new Node(3, new List<Node> {
                new Node(5),
                new Node(6)
            }),
            new Node(2),
            new Node(4)
        });

            List<int> result1 = functii.Postorder(root1);
            Console.WriteLine(string.Join(", ", result1));
        }

        /* Given an m x n matrix, return true if the matrix is Toeplitz.Otherwise, return false.

A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same elements.



Example 1:


Input: matrix = [[1, 2, 3, 4],[5, 1, 2, 3],[9, 5, 1, 2]]
Output: true
Explanation:
In the above grid, the diagonals are:
"[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]".
In each diagonal all elements are the same, so the answer is True.
Example 2:


Input: matrix = [[1, 2],[2, 2]]
Output: false
Explanation:
The diagonal "[1, 2]" has different elements.*/
        public void solutia6()
        {

            int[][] matrix1 = new int[][] {
            new int[] {1, 2, 3, 4},
            new int[] {5, 1, 2, 3},
            new int[] {9, 5, 1, 2}
        };
            Console.WriteLine(functii.IsToeplitzMatrix(matrix1));
        }

        /*You are given the root of a binary search tree (BST) and an integer val.

Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.



Example 1:


Input: root = [4,2,7,1,3], val = 2
Output: [2,1,3]
Example 2:


Input: root = [4,2,7,1,3], val = 5
Output: []*/
        public void solutia7()
        {
            TreeNode root1 = new TreeNode(4,
                    new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                    new TreeNode(7));
            int val1 = 2;
            TreeNode result1 = functii.SearchBST(root1, val1);
            PrintTree(result1);
        }
        static void PrintTree(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("[]");
                return;
            }
            Console.Write("[");
            PrintInorder(root);
            Console.WriteLine("]");
        }
        static void PrintInorder(TreeNode node)
        {
            if (node == null) return;
            PrintInorder(node.left);
            Console.Write(node.val + " ");
            PrintInorder(node.right);
        }

        /*Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

Implement KthLargest class:

KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.


Example 1:

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
Output
[null, 4, 5, 5, 8, 8]

Explanation
KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
kthLargest.add(3);   // return 4
kthLargest.add(5);   // return 5
kthLargest.add(10);  // return 5
kthLargest.add(9);   // return 8
kthLargest.add(4);   // return 8*/
        public void solutia8()
        {
            KthLargest kthLargest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
            Console.WriteLine(kthLargest.Add(3));  
            Console.WriteLine(kthLargest.Add(5)); 
            Console.WriteLine(kthLargest.Add(10)); 
            Console.WriteLine(kthLargest.Add(9));  
            Console.WriteLine(kthLargest.Add(4));
        }

        /*Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.



Example 1:

Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
Example 2:

Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
*/
        public void solutia9()
        {

            int[] nums1 = { -1, 0, 3, 5, 9, 12 };
            int target1 = 9;
            int index1 = functii.Search(nums1, target1);
            Console.WriteLine(string.Join(",", nums1)+","+target1);
            Console.WriteLine(index1);
        }

        /*Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.



Example 1:


Input: root = [4,2,6,1,3]
Output: 1
Example 2:


Input: root = [1,0,48,null,null,12,49]
Output: 1
*/
        public void solutia10()
        {

            TreeNode root1 = new TreeNode(4,
                                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                                new TreeNode(6));
            int minDiff1 = functii.MinDiffInBST(root1);
            Console.WriteLine(minDiff1);
        }









    }
}
