using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema19
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

        /*Given an array of integers arr, return true if we can partition the array into three non-empty parts with equal sums.

Formally, we can partition the array if we can find indexes i + 1 < j with (arr[0] + arr[1] + ... + arr[i] == arr[i + 1] + arr[i + 2] + ... + arr[j - 1] == arr[j] + arr[j + 1] + ... + arr[arr.length - 1])

 

Example 1:

Input: arr = [0,2,1,-6,6,-7,9,1,2,0,1]
Output: true
Explanation: 0 + 2 + 1 = -6 + 6 - 7 + 9 + 1 = 2 + 0 + 1
Example 2:

Input: arr = [0,2,1,-6,6,7,9,-1,2,0,1]
Output: false
Example 3:

Input: arr = [3,3,6,5,-2,2,5,1,-9,4]
Output: true
Explanation: 3 + 3 = 6 = 5 - 2 + 2 + 5 + 1 - 9 + 4*/
        public bool CanThreePartsEqualSum(int[] arr)
        {
            int totalSum = 0;
            foreach (int num in arr)
            {
                totalSum += num;
            }

            if (totalSum % 3 != 0)
            {
                return false;
            }

            int targetSum = totalSum / 3;
            int currentSum = 0;
            int partitions = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];

                if (currentSum == targetSum)
                {
                    partitions++;
                    currentSum = 0;

                    if (partitions == 2 && i < arr.Length - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /*A valid parentheses string is either empty "", "(" + A + ")", or A + B, where A and B are valid parentheses strings, and + represents string concatenation.

For example, "", "()", "(())()", and "(()(()))" are all valid parentheses strings.
A valid parentheses string s is primitive if it is nonempty, and there does not exist a way to split it into s = A + B, with A and B nonempty valid parentheses strings.

Given a valid parentheses string s, consider its primitive decomposition: s = P1 + P2 + ... + Pk, where Pi are primitive valid parentheses strings.

Return s after removing the outermost parentheses of every primitive string in the primitive decomposition of s.

 

Example 1:

Input: s = "(()())(())"
Output: "()()()"
Explanation: 
The input string is "(()())(())", with primitive decomposition "(()())" + "(())".
After removing outer parentheses of each part, this is "()()" + "()" = "()()()".
Example 2:

Input: s = "(()())(())(()(()))"
Output: "()()()()(())"
Explanation: 
The input string is "(()())(())(()(()))", with primitive decomposition "(()())" + "(())" + "(()(()))".
After removing outer parentheses of each part, this is "()()" + "()" + "()(())" = "()()()()(())".
Example 3:

Input: s = "()()"
Output: ""
Explanation: 
The input string is "()()", with primitive decomposition "()" + "()".
After removing outer parentheses of each part, this is "" + "" = "".*/
        public string RemoveOuterParentheses(string s)
        {
            string result = "";
            int balance = 0;
            int start = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    balance++;
                }
                else if (s[i] == ')')
                {
                    balance--;
                }

                if (balance == 0)
                {
                    result += s.Substring(start + 1, i - start - 1);
                    start = i + 1;
                }
            }

            return result;
        }

        /*You are given the root of a binary tree where each node has a value 0 or 1. Each root-to-leaf path represents a binary number starting with the most significant bit.

For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
For all leaves in the tree, consider the numbers represented by the path from the root to that leaf. Return the sum of these numbers.

The test cases are generated so that the answer fits in a 32-bits integer.

 

Example 1:


Input: root = [1,0,1,0,1,0,1]
Output: 22
Explanation: (100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
Example 2:

Input: root = [0]
Output: 0*/
        public int SumRootToLeaf(TreeNode root)
        {
            return SumRootToLeafHelper(root, 0);
        }
        private int SumRootToLeafHelper(TreeNode node, int currentSum)
        {
            if (node == null)
            {
                return 0;
            }

            currentSum = (currentSum << 1) | node.val;

            if (node.left == null && node.right == null)
            {
                return currentSum;
            }

            return SumRootToLeafHelper(node.left, currentSum) + SumRootToLeafHelper(node.right, currentSum);
        }

        /*You are given four integers row, cols, rCenter, and cCenter. There is a rows x cols matrix and you are on the cell with the coordinates (rCenter, cCenter).

Return the coordinates of all cells in the matrix, sorted by their distance from (rCenter, cCenter) from the smallest distance to the largest distance. You may return the answer in any order that satisfies this condition.

The distance between two cells (r1, c1) and (r2, c2) is |r1 - r2| + |c1 - c2|.

 

Example 1:

Input: rows = 1, cols = 2, rCenter = 0, cCenter = 0
Output: [[0,0],[0,1]]
Explanation: The distances from (0, 0) to other cells are: [0,1]
Example 2:

Input: rows = 2, cols = 2, rCenter = 0, cCenter = 1
Output: [[0,1],[0,0],[1,1],[1,0]]
Explanation: The distances from (0, 1) to other cells are: [0,1,1,2]
The answer [[0,1],[1,1],[0,0],[1,0]] would also be accepted as correct.
Example 3:

Input: rows = 2, cols = 3, rCenter = 1, cCenter = 2
Output: [[1,2],[0,2],[1,1],[0,1],[1,0],[0,0]]
Explanation: The distances from (1, 2) to other cells are: [0,1,1,2,2,3]
There are other answers that would also be accepted as correct, such as [[1,2],[1,1],[0,2],[1,0],[0,1],[0,0]].*/
        public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            List<int[]> cells = new List<int[]>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    cells.Add(new int[] { r, c });
                }
            }

            cells.Sort((a, b) =>
            {
                int distA = Math.Abs(a[0] - rCenter) + Math.Abs(a[1] - cCenter);
                int distB = Math.Abs(b[0] - rCenter) + Math.Abs(b[1] - cCenter);
                return distA.CompareTo(distB);
            });

            return cells.ToArray();
        }

        /*You are given an array of strings words and a string chars.

A string is good if it can be formed by characters from chars (each character can only be used once).

Return the sum of lengths of all good strings in words.

 

Example 1:

Input: words = ["cat","bt","hat","tree"], chars = "atach"
Output: 6
Explanation: The strings that can be formed are "cat" and "hat" so the answer is 3 + 3 = 6.
Example 2:

Input: words = ["hello","world","leetcode"], chars = "welldonehoneyr"
Output: 10
Explanation: The strings that can be formed are "hello" and "world" so the answer is 5 + 5 = 10.
 */
        public int CountCharacters(string[] words, string chars)
        {
            int[] charCount = new int[26];
            int totalLength = 0;

            foreach (char c in chars)
            {
                charCount[c - 'a']++;
            }

            foreach (string word in words)
            {
                int[] wordCount = new int[26];
                bool canBeFormed = true;

                foreach (char c in word)
                {
                    wordCount[c - 'a']++;
                    if (wordCount[c - 'a'] > charCount[c - 'a'])
                    {
                        canBeFormed = false;
                        break;
                    }
                }

                if (canBeFormed)
                {
                    totalLength += word.Length;
                }
            }

            return totalLength;
        }

        /*You are given an array of integers stones where stones[i] is the weight of the ith stone.

We are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:

If x == y, both stones are destroyed, and
If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
At the end of the game, there is at most one stone left.

Return the weight of the last remaining stone. If there are no stones left, return 0.

 

Example 1:

Input: stones = [2,7,4,1,8,1]
Output: 1
Explanation: 
We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.
Example 2:

Input: stones = [1]
Output: 1*/
        public int LastStoneWeight(int[] stones)
        {
            List<int> stoneList = new List<int>(stones);

            while (stoneList.Count > 1)
            {
                stoneList.Sort();

                int stone1 = stoneList[stoneList.Count - 1];
                int stone2 = stoneList[stoneList.Count - 2];  

                stoneList.RemoveAt(stoneList.Count - 1);
                stoneList.RemoveAt(stoneList.Count - 1);

                if (stone1 != stone2)
                {
                    stoneList.Add(stone1 - stone2);
                }
            }

            return stoneList.Count == 0 ? 0 : stoneList[0];
        }

        /*A school is trying to take an annual photo of all the students. The students are asked to stand in a single file line in non-decreasing order by height. Let this ordering be represented by the integer array expected where expected[i] is the expected height of the ith student in line.

You are given an integer array heights representing the current order that the students are standing in. Each heights[i] is the height of the ith student in line (0-indexed).

Return the number of indices where heights[i] != expected[i].

 

Example 1:

Input: heights = [1,1,4,2,1,3]
Output: 3
Explanation: 
heights:  [1,1,4,2,1,3]
expected: [1,1,1,2,3,4]
Indices 2, 4, and 5 do not match.
Example 2:

Input: heights = [5,1,2,3,4]
Output: 5
Explanation:
heights:  [5,1,2,3,4]
expected: [1,2,3,4,5]
All indices do not match.
Example 3:

Input: heights = [1,2,3,4,5]
Output: 0
Explanation:
heights:  [1,2,3,4,5]
expected: [1,2,3,4,5]
All indices match.*/
        public int HeightChecker(int[] heights)
        {
            int[] expected = (int[])heights.Clone();
            Array.Sort(expected);

            int count = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != expected[i])
                {
                    count++;
                }
            }

            return count;
        }

        /*Given two strings first and second, consider occurrences in some text of the form "first second third", where second comes immediately after first, and third comes immediately after second.

Return an array of all the words third for each occurrence of "first second third".

 

Example 1:

Input: text = "alice is a good girl she is a good student", first = "a", second = "good"
Output: ["girl","student"]
Example 2:

Input: text = "we will we will rock you", first = "we", second = "will"
Output: ["we","rock"]
 */
        public string[] FindOcurrences(string text, string first, string second)
        {
            string[] words = text.Split(' ');
            List<string> result = new List<string>();

            for (int i = 0; i < words.Length - 2; i++)
            {
                if (words[i] == first && words[i + 1] == second)
                {
                    result.Add(words[i + 2]);
                }
            }

            return result.ToArray();
        }

        /*We distribute some number of candies, to a row of n = num_people people in the following way:

We then give 1 candy to the first person, 2 candies to the second person, and so on until we give n candies to the last person.

Then, we go back to the start of the row, giving n + 1 candies to the first person, n + 2 candies to the second person, and so on until we give 2 * n candies to the last person.

This process repeats (with us giving one more candy each time, and moving to the start of the row after we reach the end) until we run out of candies.  The last person will receive all of our remaining candies (not necessarily one more than the previous gift).

Return an array (of length num_people and sum candies) that represents the final distribution of candies.



Example 1:

Input: candies = 7, num_people = 4
Output: [1,2,3,1]
Explanation:
On the first turn, ans[0] += 1, and the array is [1,0,0,0].
On the second turn, ans[1] += 2, and the array is [1,2,0,0].
On the third turn, ans[2] += 3, and the array is [1,2,3,0].
On the fourth turn, ans[3] += 1 (because there is only one candy left), and the final array is [1,2,3,1].
Example 2:

Input: candies = 10, num_people = 3
Output: [5,2,3]
Explanation: 
On the first turn, ans[0] += 1, and the array is [1,0,0].
On the second turn, ans[1] += 2, and the array is [1,2,0].
On the third turn, ans[2] += 3, and the array is [1,2,3].
On the fourth turn, ans[0] += 4, and the final array is [5,2,3].
*/
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] result = new int[num_people];
            int current_candy = 1;

            while (candies > 0)
            {
                for (int i = 0; i < num_people; i++)
                {
                    if (candies >= current_candy)
                    {
                        result[i] += current_candy;
                        candies -= current_candy;
                    }
                    else
                    {
                        result[i] += candies;
                        candies = 0;
                        break;
                    }

                    current_candy++;
                }
            }

            return result;
        }

        /*Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1.

Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2. Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order.

 

Example 1:

Input: arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
Output: [2,2,2,1,4,3,3,9,6,7,19]
Example 2:

Input: arr1 = [28,6,22,8,44,17], arr2 = [22,28,8,6]
Output: [22,28,8,6,17,44]
 */
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {

                var orderDict = arr2
                    .Select((value, index) => new { value, index })
                    .ToDictionary(x => x.value, x => x.index);

                var inArr2 = arr1.Where(x => orderDict.ContainsKey(x)).ToList();
                var notInArr2 = arr1.Where(x => !orderDict.ContainsKey(x)).ToList();

                var sortedInArr2 = inArr2
                    .OrderBy(x => orderDict[x])
                    .ToList();

                var sortedNotInArr2 = notInArr2
                    .OrderBy(x => x)
                    .ToList();

                return sortedInArr2.Concat(sortedNotInArr2).ToArray();
            }

    }
}
