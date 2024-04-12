using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema6
{
    public class Functii
    {

        /*Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false*/
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c))
                {
                    charCount[c] = 1;
                }
                else
                {
                    charCount[c]++;
                }
            }

            foreach (char c in t)
            {
                if (!charCount.ContainsKey(c))
                {
                    return false;
                }
                else
                {
                    charCount[c]--;
                    if (charCount[c] < 0)
                    {
                        return false;
                    }
                }
            }

            foreach (int count in charCount.Values)
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /*Given the root of a binary tree, return all root-to-leaf paths in any order.

A leaf is a node with no children.

 

Example 1:


Input: root = [1,2,3,null,5]
Output: ["1->2->5","1->3"]
Example 2:

Input: root = [1]
Output: ["1"]
 */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public IList<string> GetBinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            if (root == null)
            {
                return paths;
            }
            DFS(root, "", paths);
            return paths;
        }
        private void DFS(TreeNode node, string path, List<string> paths)
        {
            if (node == null)
            {
                return;
            }

            path += node.val.ToString();

            if (node.left == null && node.right == null)
            {
                paths.Add(path);
                return;
            }

            path += "->";
            DFS(node.left, path, paths);
            DFS(node.right, path, paths);
        }

        /*Given an integer num, repeatedly add all its digits until the result has only one digit, and return it.

 

Example 1:

Input: num = 38
Output: 2
Explanation: The process is
38 --> 3 + 8 --> 11
11 --> 1 + 1 --> 2 
Since 2 has only one digit, return it.
Example 2:

Input: num = 0
Output: 0*/
        public int AddDigits(int num)
        {
            while (num >= 10)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                num = sum;
            }
            return num;
        }

        /*An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.

Given an integer n, return true if n is an ugly number.

 

Example 1:

Input: n = 6
Output: true
Explanation: 6 = 2 × 3
Example 2:

Input: n = 1
Output: true
Explanation: 1 has no prime factors, therefore all of its prime factors are limited to 2, 3, and 5.
Example 3:

Input: n = 14
Output: false
Explanation: 14 is not ugly since it includes the prime factor 7.
 */
        public bool IsUgly(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            while (n % 2 == 0)
            {
                n /= 2;
            }

            while (n % 3 == 0)
            {
                n /= 3;
            }

            while (n % 5 == 0)
            {
                n /= 5;
            }

            return n == 1;
        }

        /*Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.

 

Example 1:

Input: nums = [3,0,1]
Output: 2
Explanation: n = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.
Example 2:

Input: nums = [0,1]
Output: 2
Explanation: n = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.
Example 3:

Input: nums = [9,6,4,2,3,5,7,0,1]
Output: 8
Explanation: n = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.*/
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int expectedSum = n * (n + 1) / 2;
            int actualSum = 0;

            foreach (int num in nums)
            {
                actualSum += num;
            }

            return expectedSum - actualSum;
        }

        /*You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.

 

Example 1:

Input: n = 5, bad = 4
Output: 4
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.
Example 2:

Input: n = 1, bad = 1
Output: 1*/
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (isBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
        private bool isBadVersion(int version)
        {
            return version >= 4;
        }

        /*Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Note that you must do this in-place without making a copy of the array.

 

Example 1:

Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]
Example 2:

Input: nums = [0]
Output: [0]
 */
        public void MoveZeroes(int[] nums)
        {
            int nonZeroPointer = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[nonZeroPointer++] = nums[i];
                }
            }

            for (int i = nonZeroPointer; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        /*Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

 

Example 1:

Input: pattern = "abba", s = "dog cat cat dog"
Output: true
Example 2:

Input: pattern = "abba", s = "dog cat cat fish"
Output: false
Example 3:

Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false*/
        public bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');

            if (pattern.Length != words.Length)
            {
                return false;
            }

            Dictionary<char, string> charToWord = new Dictionary<char, string>();
            Dictionary<string, char> wordToChar = new Dictionary<string, char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                string word = words[i];

                if (charToWord.ContainsKey(c))
                {
                    if (charToWord[c] != word)
                    {
                        return false;
                    }
                }
                else
                {
                    if (wordToChar.ContainsKey(word))
                    {
                        return false;
                    }

                    charToWord[c] = word;
                    wordToChar[word] = c;
                }
            }

            return true;
        }

        /*You are playing the following Nim Game with your friend:

Initially, there is a heap of stones on the table.
You and your friend will alternate taking turns, and you go first.
On each turn, the person whose turn it is will remove 1 to 3 stones from the heap.
The one who removes the last stone is the winner.
Given n, the number of stones in the heap, return true if you can win the game assuming both you and your friend play optimally, otherwise return false.

 

Example 1:

Input: n = 4
Output: false
Explanation: These are the possible outcomes:
1. You remove 1 stone. Your friend removes 3 stones, including the last stone. Your friend wins.
2. You remove 2 stones. Your friend removes 2 stones, including the last stone. Your friend wins.
3. You remove 3 stones. Your friend removes the last stone. Your friend wins.
In all outcomes, your friend wins.
Example 2:

Input: n = 1
Output: true
Example 3:

Input: n = 2
Output: true
 */
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

    }

    /*Given an integer array nums, handle multiple queries of the following type:

Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
Implement the NumArray class:

NumArray(int[] nums) Initializes the object with the integer array nums.
int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive (i.e. nums[left] + nums[left + 1] + ... + nums[right]).
 

Example 1:

Input
["NumArray", "sumRange", "sumRange", "sumRange"]
[[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
Output
[null, 1, -1, -3]

Explanation
NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
numArray.sumRange(0, 2); // return (-2) + 0 + 3 = 1
numArray.sumRange(2, 5); // return 3 + (-5) + 2 + (-1) = -1
numArray.sumRange(0, 5); // return (-2) + 0 + 3 + (-5) + 2 + (-1) = -3*/

    public class NumArray
    {
        private int[] prefixSum;

        public NumArray(int[] nums)
        {
            prefixSum = new int[nums.Length + 1];
            for (int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            }
        }

        public int SumRange(int left, int right)
        {
            return prefixSum[right + 1] - prefixSum[left];
        }
    }

}
