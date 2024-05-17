using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema10
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Functii
    {

        /*Given an array of strings words, return the words that can be typed using letters of the alphabet on only one row of American keyboard like the image below.

In the American keyboard:

the first row consists of the characters "qwertyuiop",
the second row consists of the characters "asdfghjkl", and
the third row consists of the characters "zxcvbnm".

 

Example 1:

Input: words = ["Hello","Alaska","Dad","Peace"]
Output: ["Alaska","Dad"]
Example 2:

Input: words = ["omk"]
Output: []
Example 3:

Input: words = ["adsdf","sfd"]
Output: ["adsdf","sfd"]
 */
        public string[] FindWords(string[] words)
        {
            HashSet<char> r1 = new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            HashSet<char> r2 = new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            HashSet<char> r3 = new HashSet<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

            List<string> res = new List<string>();

            foreach (string w in words)
            {
                bool b = true;
                HashSet<char> r = r1.Contains(char.ToLower(w[0])) ? r1 :
                                  r2.Contains(char.ToLower(w[0])) ? r2 : r3;

                foreach (char c in w.ToLower())
                {
                    if (!r.Contains(c))
                    {
                        b = false;
                        break;
                    }
                }

                if (b)
                {
                    res.Add(w);
                }
            }

            return res.ToArray();
        }

        /*Given the root of a binary search tree (BST) with duplicates, return all the mode(s) (i.e., the most frequently occurred element) in it.

If the tree has more than one mode, return them in any order.

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than or equal to the node's key.
The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:


Input: root = [1,null,2,2]
Output: [2]
Example 2:

Input: root = [0]
Output: [0]
 */
        
        private Dictionary<int, int> fm = new Dictionary<int, int>();
        private int maxF = 0;
        public int[] FindMode(TreeNode root)
        {
            Traverse(root);

            List<int> m = new List<int>();
            foreach (var kvp in fm)
            {
                if (kvp.Value == maxF)
                {
                    m.Add(kvp.Key);
                }
            }

            return m.ToArray();
        }
        private void Traverse(TreeNode n)
        {
            if (n == null) return;

            Traverse(n.left);

            fm[n.val] = fm.GetValueOrDefault(n.val, 0) + 1;
            maxF = Math.Max(maxF, fm[n.val]);

            Traverse(n.right);
        }

        /*Given an integer num, return a string of its base 7 representation.

 

Example 1:

Input: num = 100
Output: "202"
Example 2:

Input: num = -7
Output: "-10"*/
        public string ConvertToBase7(int num)
        {
            if (num == 0) return "0";

            bool isNegative = num < 0;
            num = Math.Abs(num);

            string result = "";

            while (num > 0)
            {
                int digit = num % 7;
                result = digit + result;
                num /= 7;
            }

            return isNegative ? "-" + result : result;
        }

        /*You are given an integer array score of size n, where score[i] is the score of the ith athlete in a competition. All the scores are guaranteed to be unique.

The athletes are placed based on their scores, where the 1st place athlete has the highest score, the 2nd place athlete has the 2nd highest score, and so on. The placement of each athlete determines their rank:

The 1st place athlete's rank is "Gold Medal".
The 2nd place athlete's rank is "Silver Medal".
The 3rd place athlete's rank is "Bronze Medal".
For the 4th place to the nth place athlete, their rank is their placement number (i.e., the xth place athlete's rank is "x").
Return an array answer of size n where answer[i] is the rank of the ith athlete.

 

Example 1:

Input: score = [5,4,3,2,1]
Output: ["Gold Medal","Silver Medal","Bronze Medal","4","5"]
Explanation: The placements are [1st, 2nd, 3rd, 4th, 5th].
Example 2:

Input: score = [10,3,8,9,4]
Output: ["Gold Medal","5","Bronze Medal","Silver Medal","4"]
Explanation: The placements are [1st, 5th, 3rd, 2nd, 4th].
*/
        public string[] FindRelativeRanks(int[] score)
        {
            Dictionary<int, int> scoreToIndex = new Dictionary<int, int>();
            for (int i = 0; i < score.Length; i++)
            {
                scoreToIndex[score[i]] = i;
            }

            Array.Sort(score, (a, b) => b.CompareTo(a));

            string[] result = new string[score.Length];
            for (int i = 0; i < score.Length; i++)
            {
                int rank = i + 1;
                switch (rank)
                {
                    case 1:
                        result[scoreToIndex[score[i]]] = "Gold Medal";
                        break;
                    case 2:
                        result[scoreToIndex[score[i]]] = "Silver Medal";
                        break;
                    case 3:
                        result[scoreToIndex[score[i]]] = "Bronze Medal";
                        break;
                    default:
                        result[scoreToIndex[score[i]]] = rank.ToString();
                        break;
                }
            }

            return result;
        }

        /*A perfect number is a positive integer that is equal to the sum of its positive divisors, excluding the number itself. A divisor of an integer x is an integer that can divide x evenly.

Given an integer n, return true if n is a perfect number, otherwise return false.

 

Example 1:

Input: num = 28
Output: true
Explanation: 28 = 1 + 2 + 4 + 7 + 14
1, 2, 4, 7, and 14 are all divisors of 28.
Example 2:

Input: num = 7
Output: false
 */
        public bool CheckPerfectNumber(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            int sum = 1;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (i != num / i)
                    {
                        sum += num / i;
                    }
                }
            }

            return sum == num;
        }

        /*We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital, like "Google".
Given a string word, return true if the usage of capitals in it is right.

 

Example 1:

Input: word = "USA"
Output: true
Example 2:

Input: word = "FlaG"
Output: false*/
        public bool DetectCapitalUse(string word)
        {
            bool allCaps = true, allLower = true;

            foreach (char c in word)
            {
                if (!char.IsUpper(c))
                {
                    allCaps = false;
                }
                if (!char.IsLower(c))
                {
                    allLower = false;
                }
            }

            bool firstCap = char.IsUpper(word[0]) && word.Substring(1).All(char.IsLower);

            return allCaps || allLower || firstCap;
        }

        /*Given two strings a and b, return the length of the longest uncommon subsequence between a and b. If no such uncommon subsequence exists, return -1.

An uncommon subsequence between two strings is a string that is a 
subsequence
 of exactly one of them.

 

Example 1:

Input: a = "aba", b = "cdc"
Output: 3
Explanation: One longest uncommon subsequence is "aba" because "aba" is a subsequence of "aba" but not "cdc".
Note that "cdc" is also a longest uncommon subsequence.
Example 2:

Input: a = "aaa", b = "bbb"
Output: 3
Explanation: The longest uncommon subsequences are "aaa" and "bbb".
Example 3:

Input: a = "aaa", b = "aaa"
Output: -1
Explanation: Every subsequence of string a is also a subsequence of string b. Similarly, every subsequence of string b is also a subsequence of string a. So the answer would be -1.*/
        public int FindLUSlength(string a, string b)
        {
            if (a == b)
            {
                return -1;
            }
            else
            {
                return Math.Max(a.Length, b.Length);
            }
        }

        /*Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

 

Example 1:


Input: root = [4,2,6,1,3]
Output: 1
Example 2:


Input: root = [1,0,48,null,null,12,49]
Output: 1
 */
        private int minDiff = int.MaxValue;
        private TreeNode prev;
        public int GetMinimumDifference(TreeNode root)
        {
            InOrderTraversal(root);
            return minDiff;
        }
        private void InOrderTraversal(TreeNode node)
        {
            if (node == null) return;

            InOrderTraversal(node.left);

            if (prev != null)
            {
                minDiff = Math.Min(minDiff, Math.Abs(node.val - prev.val));
            }
            prev = node;

            InOrderTraversal(node.right);
        }

        /*Given a string s and an integer k, reverse the first k characters for every 2k characters counting from the start of the string.

If there are fewer than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and leave the other as original.

 

Example 1:

Input: s = "abcdefg", k = 2
Output: "bacdfeg"
Example 2:

Input: s = "abcd", k = 2
Output: "bacd"*/
        public string ReverseStr(string s, int k)
        {
            StringBuilder result = new StringBuilder();
            int n = s.Length;

            for (int i = 0; i < n; i += 2 * k)
            {
                int start = i;
                int end = Math.Min(i + k, n);

                for (int j = end - 1; j >= start; j--)
                {
                    result.Append(s[j]);
                }
                
                for (int j = end; j < Math.Min(i + 2 * k, n); j++)
                {
                    result.Append(s[j]);
                }
            }

            return result.ToString();
        }

        /*You are given a string s representing an attendance record for a student where each character signifies whether the student was absent, late, or present on that day. The record only contains the following three characters:

'A': Absent.
'L': Late.
'P': Present.
The student is eligible for an attendance award if they meet both of the following criteria:

The student was absent ('A') for strictly fewer than 2 days total.
The student was never late ('L') for 3 or more consecutive days.
Return true if the student is eligible for an attendance award, or false otherwise.

 

Example 1:

Input: s = "PPALLP"
Output: true
Explanation: The student has fewer than 2 absences and was never late 3 or more consecutive days.
Example 2:

Input: s = "PPALLL"
Output: false
Explanation: The student was late 3 consecutive days in the last 3 days, so is not eligible for the award.*/
        public bool CheckRecord(string s)
        {
            int absentCount = 0;
            int lateStreak = 0;

            foreach (char c in s)
            {
                if (c == 'A')
                {
                    absentCount++;
                    lateStreak = 0;
                }
                else if (c == 'L')
                {
                    lateStreak++;
                }
                else
                {
                    lateStreak = 0;
                }

                if (absentCount >= 2 || lateStreak >= 3)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
