using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema15
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Functii
    {

        /*At a lemonade stand, each lemonade costs $5. Customers are standing in a queue to buy from you and order one at a time (in the order specified by bills). Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill. You must provide the correct change to each customer so that the net transaction is that the customer pays $5.

Note that you do not have any change in hand at first.

Given an integer array bills where bills[i] is the bill the ith customer pays, return true if you can provide every customer with the correct change, or false otherwise.

 

Example 1:

Input: bills = [5,5,5,10,20]
Output: true
Explanation: 
From the first 3 customers, we collect three $5 bills in order.
From the fourth customer, we collect a $10 bill and give back a $5.
From the fifth customer, we give a $10 bill and a $5 bill.
Since all customers got correct change, we output true.
Example 2:

Input: bills = [5,5,10,10,20]
Output: false
Explanation: 
From the first two customers in order, we collect two $5 bills.
For the next two customers in order, we collect a $10 bill and give back a $5 bill.
For the last customer, we can not give the change of $15 back because we only have two $10 bills.
Since not every customer received the correct change, the answer is false.
 */
        public bool LemonadeChange(int[] bills)
        {
            int fiveDollarBills = 0;
            int tenDollarBills = 0;

            foreach (int bill in bills)
            {
                if (bill == 5)
                {
                    fiveDollarBills++;
                }
                else if (bill == 10)
                {
                    if (fiveDollarBills == 0)
                    {
                        return false;
                    }
                    fiveDollarBills--;
                    tenDollarBills++;
                }
                else if (bill == 20)
                {
                    if (tenDollarBills > 0 && fiveDollarBills > 0)
                    {
                        tenDollarBills--;
                        fiveDollarBills--;
                    }
                    else if (fiveDollarBills >= 3)
                    {
                        fiveDollarBills -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /*Given a 2D integer array matrix, return the transpose of matrix.

The transpose of a matrix is the matrix flipped over its main diagonal, switching the matrix's row and column indices.



 

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[1,4,7],[2,5,8],[3,6,9]]
Example 2:

Input: matrix = [[1,2,3],[4,5,6]]
Output: [[1,4],[2,5],[3,6]]*/
        public int[][] Transpose(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int[][] transposedMatrix = new int[cols][];
            for (int i = 0; i < cols; i++)
            {
                transposedMatrix[i] = new int[rows];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedMatrix[j][i] = matrix[i][j];
                }
            }

            return transposedMatrix;
        }

        /*Given a positive integer n, find and return the longest distance between any two adjacent 1's in the binary representation of n. If there are no two adjacent 1's, return 0.

Two 1's are adjacent if there are only 0's separating them (possibly no 0's). The distance between two 1's is the absolute difference between their bit positions. For example, the two 1's in "1001" have a distance of 3.

 

Example 1:

Input: n = 22
Output: 2
Explanation: 22 in binary is "10110".
The first adjacent pair of 1's is "10110" with a distance of 2.
The second adjacent pair of 1's is "10110" with a distance of 1.
The answer is the largest of these two distances, which is 2.
Note that "10110" is not a valid pair since there is a 1 separating the two 1's underlined.
Example 2:

Input: n = 8
Output: 0
Explanation: 8 in binary is "1000".
There are not any adjacent pairs of 1's in the binary representation of 8, so we return 0.
Example 3:

Input: n = 5
Output: 2
Explanation: 5 in binary is "101".
 */
        public int BinaryGap(int n)
        {
            string binaryString = Convert.ToString(n, 2);

            int maxDistance = 0;
            int prevOneIndex = -1;

            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] == '1')
                {
                    if (prevOneIndex != -1)
                    {
                        int currentDistance = i - prevOneIndex;
                        maxDistance = Math.Max(maxDistance, currentDistance);
                    }
                    prevOneIndex = i;
                }
            }

            return maxDistance;
        }

        /*Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.



For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).

Two binary trees are considered leaf-similar if their leaf value sequence is the same.

Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.

 

Example 1:


Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true
Example 2:


Input: root1 = [1,2,3], root2 = [1,3,2]
Output: false*/
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {

            List<int> leaves1 = new List<int>();
            List<int> leaves2 = new List<int>();

            void CollectLeaves(TreeNode node, List<int> leaves)
            {
                if (node == null) return;
                if (node.left == null && node.right == null)
                {
                    leaves.Add(node.val);
                    return;
                }
                CollectLeaves(node.left, leaves);
                CollectLeaves(node.right, leaves);
            }

            CollectLeaves(root1, leaves1);
            CollectLeaves(root2, leaves2);

            if (leaves1.Count != leaves2.Count)
            {
                return false;
            }

            for (int i = 0; i < leaves1.Count; i++)
            {
                if (leaves1[i] != leaves2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /*Given the head of a singly linked list, return the middle node of the linked list.

If there are two middle nodes, return the second middle node.

 

Example 1:


Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.
Example 2:


Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
 */
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        /*You are given an n x n grid where we place some 1 x 1 x 1 cubes that are axis-aligned with the x, y, and z axes.

Each value v = grid[i][j] represents a tower of v cubes placed on top of the cell (i, j).

We view the projection of these cubes onto the xy, yz, and zx planes.

A projection is like a shadow, that maps our 3-dimensional figure to a 2-dimensional plane. We are viewing the "shadow" when looking at the cubes from the top, the front, and the side.

Return the total area of all three projections.

 

Example 1:


Input: grid = [[1,2],[3,4]]
Output: 17
Explanation: Here are the three projections ("shadows") of the shape made with each axis-aligned plane.
Example 2:

Input: grid = [[2]]
Output: 5
Example 3:

Input: grid = [[1,0],[0,2]]
Output: 8
 */
        public int ProjectionArea(int[][] grid)
        {
            int n = grid.Length;
            int xy_area = 0;
            int[] max_in_column = new int[n];
            int zx_area = 0;

            for (int i = 0; i < n; i++)
            {
                int max_in_row = 0;
                for (int j = 0; j < n; j++)
                {
                    int height = grid[i][j];
                    if (height > 0) xy_area++;
                    max_in_row = Math.Max(max_in_row, height);
                    max_in_column[j] = Math.Max(max_in_column[j], height);
                }
                zx_area += max_in_row;
            }

            int yz_area = 0;
            foreach (int max_height in max_in_column)
            {
                yz_area += max_height;
            }

            return xy_area + yz_area + zx_area;
        }

        /*A sentence is a string of single-space separated words where each word consists only of lowercase letters.

A word is uncommon if it appears exactly once in one of the sentences, and does not appear in the other sentence.

Given two sentences s1 and s2, return a list of all the uncommon words. You may return the answer in any order.

 

Example 1:

Input: s1 = "this apple is sweet", s2 = "this apple is sour"
Output: ["sweet","sour"]
Example 2:

Input: s1 = "apple apple", s2 = "banana"
Output: ["banana"]
 */
        public string[] UncommonFromSentences(string s1, string s2)
        {
            string combined = s1 + " " + s2;

            string[] words = combined.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFreq = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFreq.ContainsKey(word))
                {
                    wordFreq[word]++;
                }
                else
                {
                    wordFreq[word] = 1;
                }
            }

            List<string> uncommonWords = new List<string>();

            foreach (var kvp in wordFreq)
            {
                if (kvp.Value == 1)
                {
                    uncommonWords.Add(kvp.Key);
                }
            }

            return uncommonWords.ToArray();
        }

        /*Alice and Bob have a different total number of candies. You are given two integer arrays aliceSizes and bobSizes where aliceSizes[i] is the number of candies of the ith box of candy that Alice has and bobSizes[j] is the number of candies of the jth box of candy that Bob has.

Since they are friends, they would like to exchange one candy box each so that after the exchange, they both have the same total amount of candy. The total amount of candy a person has is the sum of the number of candies in each box they have.

Return an integer array answer where answer[0] is the number of candies in the box that Alice must exchange, and answer[1] is the number of candies in the box that Bob must exchange. If there are multiple answers, you may return any one of them. It is guaranteed that at least one answer exists.

 

Example 1:

Input: aliceSizes = [1,1], bobSizes = [2,2]
Output: [1,2]
Example 2:

Input: aliceSizes = [1,2], bobSizes = [2,3]
Output: [1,2]
Example 3:

Input: aliceSizes = [2], bobSizes = [1,3]
Output: [2,3]
 */
        public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
        {

            int totalAlice = 0;
            foreach (int size in aliceSizes)
            {
                totalAlice += size;
            }

            int totalBob = 0;
            foreach (int size in bobSizes)
            {
                totalBob += size;
            }

            int target = (totalAlice + totalBob) / 2;

            foreach (int x in aliceSizes)
            {
                foreach (int y in bobSizes)
                {
                    if (totalAlice - x + y == target && totalBob - y + x == target)
                    {
                        return new int[] { x, y };
                    }
                }
            }

            return new int[0];
        }

        /*You are given an n x n grid where you have placed some 1 x 1 x 1 cubes. Each value v = grid[i][j] represents a tower of v cubes placed on top of cell (i, j).

After placing these cubes, you have decided to glue any directly adjacent cubes to each other, forming several irregular 3D shapes.

Return the total surface area of the resulting shapes.

Note: The bottom face of each shape counts toward its surface area.

 

Example 1:


Input: grid = [[1,2],[3,4]]
Output: 34
Example 2:


Input: grid = [[1,1,1],[1,0,1],[1,1,1]]
Output: 32
Example 3:


Input: grid = [[2,2,2],[2,1,2],[2,2,2]]
Output: 46
 */
        public int SurfaceArea(int[][] grid)
        {
            int n = grid.Length;
            int totalArea = 0;

            int[] di = { -1, 1, 0, 0 };
            int[] dj = { 0, 0, -1, 1 };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        totalArea += 4 * grid[i][j];

                        for (int d = 0; d < 4; d++)
                        {
                            int ni = i + di[d];
                            int nj = j + dj[d];

                            if (ni >= 0 && ni < n && nj >= 0 && nj < n)
                            {
                                totalArea -= Math.Min(grid[i][j], grid[ni][nj]);
                            }
                        }
                    }
                }
            }

            return totalArea;
        }

        /*An array is monotonic if it is either monotone increasing or monotone decreasing.

An array nums is monotone increasing if for all i <= j, nums[i] <= nums[j]. An array nums is monotone decreasing if for all i <= j, nums[i] >= nums[j].

Given an integer array nums, return true if the given array is monotonic, or false otherwise.

 

Example 1:

Input: nums = [1,2,2,3]
Output: true
Example 2:

Input: nums = [6,5,4,4]
Output: true
Example 3:

Input: nums = [1,3,2]
Output: false
 */
        public bool IsMonotonic(int[] nums)
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    increasing = false;
                }
                if (nums[i] > nums[i - 1])
                {
                    decreasing = false;
                }
            }

            return increasing || decreasing;
        }






































































    }
}
