using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tema11
{

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
    public class Functii
    {

        /*You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

 

Example 1:

Input: flowerbed = [1,0,0,0,1], n = 1
Output: true
Example 2:

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false*/
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int len = flowerbed.Length;

            for (int i = 0; i < len && n > 0; i++)
            {
                if (flowerbed[i] == 0)
                {
                    bool prevEmpty = (i == 0) || (flowerbed[i - 1] == 0);
                    bool nextEmpty = (i == len - 1) || (flowerbed[i + 1] == 0);

                    if (prevEmpty && nextEmpty)
                    {
                        flowerbed[i] = 1;
                        n--;
                    }
                }
            }

            return n == 0;
        }

        /*In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one with a different size r x c keeping its original data.

You are given an m x n matrix mat and two integers r and c representing the number of rows and the number of columns of the wanted reshaped matrix.

The reshaped matrix should be filled with all the elements of the original matrix in the same row-traversing order as they were.

If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; Otherwise, output the original matrix.

 

Example 1:


Input: mat = [[1,2],[3,4]], r = 1, c = 4
Output: [[1,2,3,4]]
Example 2:


Input: mat = [[1,2],[3,4]], r = 2, c = 4
Output: [[1,2],[3,4]]
 */
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int m = mat.Length;
            int n = mat[0].Length;

            if (m * n != r * c)
            {
                return mat;
            }

            int[][] reshapedMat = new int[r][];
            for (int i = 0; i < r; i++)
            {
                reshapedMat[i] = new int[c];
            }

            for (int i = 0; i < m * n; i++)
            {
                reshapedMat[i / c][i % c] = mat[i / n][i % n];
            }

            return reshapedMat;
        }

        /*Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.

A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.

 

Example 1:


Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true
Example 2:


Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false*/
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
            {
                return false;
            }

            if (IsSameTree(root, subRoot))
            {
                return true;
            }

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }

            if (s == null || t == null || s.val != t.val)
            {
                return false;
            }

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }

        /*Alice has n candies, where the ith candy is of type candyType[i]. Alice noticed that she started to gain weight, so she visited a doctor.

The doctor advised Alice to only eat n / 2 of the candies she has (n is always even). Alice likes her candies very much, and she wants to eat the maximum number of different types of candies while still following the doctor's advice.

Given the integer array candyType of length n, return the maximum number of different types of candies she can eat if she only eats n / 2 of them.

 

Example 1:

Input: candyType = [1,1,2,2,3,3]
Output: 3
Explanation: Alice can only eat 6 / 2 = 3 candies. Since there are only 3 types, she can eat one of each type.
Example 2:

Input: candyType = [1,1,2,3]
Output: 2
Explanation: Alice can only eat 4 / 2 = 2 candies. Whether she eats types [1,2], [1,3], or [2,3], she still can only eat 2 different types.
Example 3:

Input: candyType = [6,6,6,6]
Output: 1
Explanation: Alice can only eat 4 / 2 = 2 candies. Even though she can eat 2 candies, she only has 1 type.*/
        public int DistributeCandies(int[] candyType)
        {
            HashSet<int> uniqueCandies = new HashSet<int>();

            foreach (int candy in candyType)
            {
                uniqueCandies.Add(candy);
            }

            return Math.Min(uniqueCandies.Count, candyType.Length / 2);
        }

        /*We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.

Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.

A subsequence of array is a sequence that can be derived from the array by deleting some or no elements without changing the order of the remaining elements.

 

Example 1:

Input: nums = [1,3,2,2,5,2,3,7]
Output: 5
Explanation: The longest harmonious subsequence is [3,2,2,2,3].
Example 2:

Input: nums = [1,2,3,4]
Output: 2
Example 3:

Input: nums = [1,1,1,1]
Output: 0
 */
        public int FindLHS(int[] nums)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (!frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num] = 0;
                }
                frequencyMap[num]++;
            }

            int maxSubsequenceLength = 0;

            foreach (var kvp in frequencyMap)
            {
                int num = kvp.Key;
                int frequency = kvp.Value;

                if (frequencyMap.ContainsKey(num + 1))
                {
                    int subsequenceLength = frequency + frequencyMap[num + 1];
                    maxSubsequenceLength = Math.Max(maxSubsequenceLength, subsequenceLength);
                }
            }

            return maxSubsequenceLength;
        }

        /*You are given an m x n matrix M initialized with all 0's and an array of operations ops, where ops[i] = [ai, bi] means M[x][y] should be incremented by one for all 0 <= x < ai and 0 <= y < bi.

Count and return the number of maximum integers in the matrix after performing all the operations.

 

Example 1:


Input: m = 3, n = 3, ops = [[2,2],[3,3]]
Output: 4
Explanation: The maximum integer in M is 2, and there are four of it in M. So return 4.
Example 2:

Input: m = 3, n = 3, ops = [[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3]]
Output: 4
Example 3:

Input: m = 3, n = 3, ops = []
Output: 9*/
        public int MaxCount(int m, int n, int[][] ops)
        {
            int minX = m;
            int minY = n;

            foreach (var op in ops)
            {
                minX = Math.Min(minX, op[0]);
                minY = Math.Min(minY, op[1]);
            }

            return minX * minY;
        }

        /*Given two arrays of strings list1 and list2, find the common strings with the least index sum.

A common string is a string that appeared in both list1 and list2.

A common string with the least index sum is a common string such that if it appeared at list1[i] and list2[j] then i + j should be the minimum value among all the other common strings.

Return all the common strings with the least index sum. Return the answer in any order.

 

Example 1:

Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["Piatti","The Grill at Torrey Pines","Hungry Hunter Steakhouse","Shogun"]
Output: ["Shogun"]
Explanation: The only common string is "Shogun".
Example 2:

Input: list1 = ["Shogun","Tapioca Express","Burger King","KFC"], list2 = ["KFC","Shogun","Burger King"]
Output: ["Shogun"]
Explanation: The common string with the least index sum is "Shogun" with index sum = (0 + 1) = 1.
Example 3:

Input: list1 = ["happy","sad","good"], list2 = ["sad","happy","good"]
Output: ["sad","happy"]
Explanation: There are three common strings:
"happy" with index sum = (0 + 1) = 1.
"sad" with index sum = (1 + 0) = 1.
"good" with index sum = (2 + 2) = 4.
The strings with the least index sum are "sad" and "happy".
 */
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, int> indexMap = new Dictionary<string, int>();
            List<string> result = new List<string>();
            int minIndexSum = int.MaxValue;

            for (int i = 0; i < list1.Length; i++)
            {
                indexMap[list1[i]] = i;
            }

            for (int j = 0; j < list2.Length; j++)
            {
                if (indexMap.ContainsKey(list2[j]))
                {
                    int indexSum = j + indexMap[list2[j]];

                    if (indexSum < minIndexSum)
                    {
                        result.Clear();
                        result.Add(list2[j]);
                        minIndexSum = indexSum;
                    }
                    else if (indexSum == minIndexSum)
                    {
                        result.Add(list2[j]);
                    }
                }
            }

            return result.ToArray();
        }

        /*Given a string s, reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

 

Example 1:

Input: s = "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Example 2:

Input: s = "Mr Ding"
Output: "rM gniD"*/
        public string ReverseWords(string s)
        {
            string[] prop = s.Split(' ');

            string final = "";

            for (int i = 0; i < prop.Length; i++)
            {
                for (int k = prop[i].Length - 1; k >= 0; k--)
                {
                    final += prop[i][k];
                }
                if(i< prop.Length-1)
                final += " ";
            }

            return final;
        }

        /*Given an integer array nums of 2n integers, group these integers into n pairs (a1, b1), (a2, b2), ..., (an, bn) such that the sum of min(ai, bi) for all i is maximized. Return the maximized sum.

 

Example 1:

Input: nums = [1,4,3,2]
Output: 4
Explanation: All possible pairings (ignoring the ordering of elements) are:
1. (1, 4), (2, 3) -> min(1, 4) + min(2, 3) = 1 + 2 = 3
2. (1, 3), (2, 4) -> min(1, 3) + min(2, 4) = 1 + 2 = 3
3. (1, 2), (3, 4) -> min(1, 2) + min(3, 4) = 1 + 3 = 4
So the maximum possible sum is 4.
Example 2:

Input: nums = [6,2,6,5,1,2]
Output: 9
Explanation: The optimal pairing is (2, 1), (2, 5), (6, 6). min(2, 1) + min(2, 5) + min(6, 6) = 1 + 2 + 6 = 9.
 */
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;

            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }

            return sum;
        }

        /*Given the root of a binary tree, return the sum of every tree node's tilt.

The tilt of a tree node is the absolute difference between the sum of all left subtree node values and all right subtree node values. If a node does not have a left child, then the sum of the left subtree node values is treated as 0. The rule is similar if the node does not have a right child.

 

Example 1:


Input: root = [1,2,3]
Output: 1
Explanation: 
Tilt of node 2 : |0-0| = 0 (no children)
Tilt of node 3 : |0-0| = 0 (no children)
Tilt of node 1 : |2-3| = 1 (left subtree is just left child, so sum is 2; right subtree is just right child, so sum is 3)
Sum of every tilt : 0 + 0 + 1 = 1
Example 2:


Input: root = [4,2,9,3,5,null,7]
Output: 15
Explanation: 
Tilt of node 3 : |0-0| = 0 (no children)
Tilt of node 5 : |0-0| = 0 (no children)
Tilt of node 7 : |0-0| = 0 (no children)
Tilt of node 2 : |3-5| = 2 (left subtree is just left child, so sum is 3; right subtree is just right child, so sum is 5)
Tilt of node 9 : |0-7| = 7 (no left child, so sum is 0; right subtree is just right child, so sum is 7)
Tilt of node 4 : |(3+5+2)-(9+7)| = |10-16| = 6 (left subtree values are 3, 5, and 2, which sums to 10; right subtree values are 9 and 7, which sums to 16)
Sum of every tilt : 0 + 0 + 0 + 2 + 7 + 6 = 15
Example 3:


Input: root = [21,7,14,1,1,2,2,3,3]
Output: 9
 */
        private int tiltSum = 0;
        public int FindTilt(TreeNode root)
        {
            CalculateSum(root);
            return tiltSum;
        }
        private int CalculateSum(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftSum = CalculateSum(node.left);
            int rightSum = CalculateSum(node.right);

            tiltSum += Math.Abs(leftSum - rightSum);

            return leftSum + rightSum + node.val;
        }

        /*You are given two binary trees root1 and root2.

Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. You need to merge the two trees into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of the new tree.

Return the merged tree.

Note: The merging process must start from the root nodes of both trees.

 

Example 1:


Input: root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
Output: [3,4,5,5,4,null,7]
Example 2:

Input: root1 = [1], root2 = [1,2]
Output: [2,2]*/
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
            {
                return root2;
            }
            if (root2 == null)
            {
                return root1;
            }

            TreeNode mergedNode = new TreeNode(root1.val + root2.val);
            mergedNode.left = MergeTrees(root1.left, root2.left);
            mergedNode.right = MergeTrees(root1.right, root2.right);

            return mergedNode;
        }

        /*Given an integer array nums, find three numbers whose product is maximum and return the maximum product.

 

Example 1:

Input: nums = [1,2,3]
Output: 6
Example 2:

Input: nums = [1,2,3,4]
Output: 24
Example 3:

Input: nums = [-1,-2,-3]
Output: -6
 */
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;

            int maxProduct1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

            int maxProduct2 = nums[0] * nums[1] * nums[n - 1];

            return Math.Max(maxProduct1, maxProduct2);
        }

        /*Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: [3.00000,14.50000,11.00000]
Explanation: The average value of nodes on level 0 is 3, on level 1 is 14.5, and on level 2 is 11.
Hence return [3, 14.5, 11].
Example 2:


Input: root = [3,9,20,15,7]
Output: [3.00000,14.50000,11.00000]*/
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> result = new List<double>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                double levelSum = 0;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelSum += node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(levelSum / levelSize);
            }

            return result;
        }

        /*You are given an integer array nums consisting of n elements, and an integer k.

Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.

 

Example 1:

Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
Example 2:

Input: nums = [5], k = 1
Output: 5.00000
 */
        public double FindMaxAverage(int[] nums, int k)
        {
            int n = nums.Length;
            int windowSum = 0;

            for (int i = 0; i < k; i++)
            {
                windowSum += nums[i];
            }

            double maxAverage = (double)windowSum / k;

            for (int right = k; right < n; right++)
            {
                windowSum += nums[right] - nums[right - k];
                maxAverage = Math.Max(maxAverage, (double)windowSum / k);
            }

            return maxAverage;
        }

        /*You have a set of integers s, which originally contains all the numbers from 1 to n. Unfortunately, due to some error, one of the numbers in s got duplicated to another number in the set, which results in repetition of one number and loss of another number.

You are given an integer array nums representing the data status of this set after the error.

Find the number that occurs twice and the number that is missing and return them in the form of an array.

 

Example 1:

Input: nums = [1,2,2,4]
Output: [2,3]
Example 2:

Input: nums = [1,1]
Output: [1,2]*/
        public int[] FindErrorNums(int[] nums)
        {
            int n = nums.Length;
            HashSet<int> seen = new HashSet<int>();
            int duplicate = -1;
            int missing = -1;

            foreach (int num in nums)
            {
                if (!seen.Add(num))
                {
                    duplicate = num;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (!seen.Contains(i))
                {
                    missing = i;
                    break;
                }
            }

            return new int[] { duplicate, missing };
        }

        /*Given the root of a binary search tree and an integer k, return true if there exist two elements in the BST such that their sum is equal to k, or false otherwise.

 

Example 1:


Input: root = [5,3,6,2,4,null,7], k = 9
Output: true
Example 2:


Input: root = [5,3,6,2,4,null,7], k = 28
Output: false
 */
        public bool FindTarget(TreeNode root, int k)
        {
            TreeNode left = root;
            TreeNode right = root;
            InitializeLeft(ref left);
            InitializeRight(ref right);

            while (left != right)
            {
                int sum = left.val + right.val;
                if (sum == k)
                {
                    return true;
                }
                else if (sum < k)
                {
                    left = MoveLeftNext(left,root);
                }
                else
                {
                    right = MoveRightNext(right, root);
                }
            }

            return false;
        }
        private void InitializeLeft(ref TreeNode node)
        {
            while (node != null)
            {
                node = node.left; 
            }
        }
        private void InitializeRight(ref TreeNode node)
        {
            while (node != null)
            {
                node = node.right; 
            }
        }
        private TreeNode MoveLeftNext(TreeNode node, TreeNode root)
        {
            if (node.right != null)
            {
                node = node.right;
                while (node.left != null)
                {
                    node = node.left;
                }
            }
            else
            {
                TreeNode parent = null;
                while (root != null && root != node)
                {
                    if (node.val < root.val)
                    {
                        parent = root;
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
                node = parent;
            }
            return node;
        }
        private TreeNode MoveRightNext(TreeNode node, TreeNode root)
        {
            if (node.left != null)
            {
                node = node.left;
                while (node.right != null)
                {
                    node = node.right;
                }
            }
            else
            {
                TreeNode parent = null;
                while (root != null && root != node)
                {
                    if (node.val > root.val)
                    {
                        parent = root;
                        root = root.right;
                    }
                    else
                    {
                        root = root.left;
                    }
                }
                node = parent;
            }
            return node;
        }

        /*There is a robot starting at the position (0, 0), the origin, on a 2D plane. Given a sequence of its moves, judge if this robot ends up at (0, 0) after it completes its moves.

You are given a string moves that represents the move sequence of the robot where moves[i] represents its ith move. Valid moves are 'R' (right), 'L' (left), 'U' (up), and 'D' (down).

Return true if the robot returns to the origin after it finishes all of its moves, or false otherwise.

Note: The way that the robot is "facing" is irrelevant. 'R' will always make the robot move to the right once, 'L' will always make it move left, etc. Also, assume that the magnitude of the robot's movement is the same for each move.

 

Example 1:

Input: moves = "UD"
Output: true
Explanation: The robot moves up once, and then down once. All moves have the same magnitude, so it ended up at the origin where it started. Therefore, we return true.
Example 2:

Input: moves = "LL"
Output: false
Explanation: The robot moves left twice. It ends up two "moves" to the left of the origin. We return false because it is not at the origin at the end of its moves.*/
        public bool JudgeCircle(string moves)
        {
            int x = 0, y = 0;

            foreach (char move in moves)
            {
                switch (move)
                {
                    case 'U':
                        y++;
                        break;
                    case 'D':
                        y--;
                        break;
                    case 'L':
                        x--;
                        break;
                    case 'R':
                        x++;
                        break;
                }
            }

            return x == 0 && y == 0;
        }

        /*An image smoother is a filter of the size 3 x 3 that can be applied to each cell of an image by rounding down the average of the cell and the eight surrounding cells (i.e., the average of the nine cells in the blue smoother). If one or more of the surrounding cells of a cell is not present, we do not consider it in the average (i.e., the average of the four cells in the red smoother).


Given an m x n integer matrix img representing the grayscale of an image, return the image after applying the smoother on each cell of it.



Example 1:


Input: img = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[0,0,0],[0,0,0],[0,0,0]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the points (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0
Example 2:


Input: img = [[100,200,100],[200,50,200],[100,200,100]]
Output: [[137,141,137],[141,138,141],[137,141,137]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137.5) = 137
For the points (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) = floor(141.666667) = 141
For the point (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.888889) = 138
*/
        public int[][] ImageSmoother(int[][] img)
        {
            int m = img.Length;
            int n = img[0].Length;
            int[][] result = new int[m][];

            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = CalculateAverage(img, i, j);
                }
            }

            return result;
        }
        private int CalculateAverage(int[][] img, int row, int col)
        {
            int sum = 0;
            int count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (IsValidCell(img, i, j))
                    {
                        sum += img[i][j];
                        count++;
                    }
                }
            }

            return sum / count;
        }
        private bool IsValidCell(int[][] img, int row, int col)
        {
            return row >= 0 && row < img.Length && col >= 0 && col < img[0].Length;
        }

        /*Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes. More formally, the property root.val = min(root.left.val, root.right.val) always holds.

Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.

If no such second minimum value exists, output -1 instead.





Example 1:


Input: root = [2,2,5,null,null,5,7]
Output: 5
Explanation: The smallest value is 2, the second smallest value is 5.
Example 2:


Input: root = [2,2,2]
Output: -1
Explanation: The smallest value is 2, but there isn't any second smallest value.
*/
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null) return -1;
            int minVal = root.val;
            int secondMinVal = int.MaxValue;
            FindSecondMinimumValueHelper(root, minVal, ref secondMinVal);
            return secondMinVal == int.MaxValue ? -1 : secondMinVal;
        }
        private void FindSecondMinimumValueHelper(TreeNode node, int minVal, ref int secondMinVal)
        {
            if (node == null) return;
            if (node.val > minVal && node.val < secondMinVal)
            {
                secondMinVal = node.val;
            }
            FindSecondMinimumValueHelper(node.left, minVal, ref secondMinVal);
            FindSecondMinimumValueHelper(node.right, minVal, ref secondMinVal);
        }

        /*Given an unsorted array of integers nums, return the length of the longest continuous increasing subsequence (i.e. subarray). The subsequence must be strictly increasing.

A continuous increasing subsequence is defined by two indices l and r (l < r) such that it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for each l <= i < r, nums[i] < nums[i + 1].



Example 1:

Input: nums = [1,3,5,4,7]
Output: 3
Explanation: The longest continuous increasing subsequence is [1,3,5] with length 3.
Even though [1,3,5,7] is an increasing subsequence, it is not continuous as elements 5 and 7 are separated by element
4.
Example 2:

Input: nums = [2,2,2,2,2]
Output: 1
Explanation: The longest continuous increasing subsequence is [2] with length 1. Note that it must be strictly
increasing.
*/
        public int FindLengthOfLCIS(int[] nums)
        {
            int index = 0, ct = 1;
            int maxi = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i-1] < nums[i])
                {
                    ct++;
                }
                else
                {
                    ct = 1;
                }

                if (ct > maxi)
                {
                    maxi = ct;
                }
            }

            return maxi;
        }

    }
}
