using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema8
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

        /*A binary watch has 4 LEDs on the top to represent the hours (0-11), and 6 LEDs on the bottom to represent the minutes (0-59). Each LED represents a zero or one, with the least significant bit on the right.

For example, the below binary watch reads "4:51".


Given an integer turnedOn which represents the number of LEDs that are currently on (ignoring the PM), return all possible times the watch could represent. You may return the answer in any order.

The hour must not contain a leading zero.

For example, "01:00" is not valid. It should be "1:00".
The minute must consist of two digits and may contain a leading zero.

For example, "10:2" is not valid. It should be "10:02".
 

Example 1:

Input: turnedOn = 1
Output: ["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]
Example 2:

Input: turnedOn = 9
Output: []
 */
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            IList<string> result = new List<string>();

            for (int h = 0; h < 12; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    if (CountBits(h) + CountBits(m) == turnedOn)
                    {
                        result.Add($"{h}:{m:D2}");
                    }
                }
            }

            return result;
        }
        private int CountBits(int num)
        {
            int count = 0;
            while (num > 0)
            {
                count += num & 1;
                num >>= 1;
            }
            return count;
        }

        /*Given the root of a binary tree, return the sum of all left leaves.

A leaf is a node with no children. A left leaf is a leaf that is the left child of another node.

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 24
Explanation: There are two left leaves in the binary tree, with values 9 and 15 respectively.
Example 2:

Input: root = [1]
Output: 0*/
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;

            int sum = 0;

            if (root.left != null && root.left.left == null && root.left.right == null)
            {
                sum += root.left.val;
            }

            sum += SumOfLeftLeaves(root.left);
            sum += SumOfLeftLeaves(root.right);

            return sum;
        }

        /*Given an integer num, return a string representing its hexadecimal representation. For negative integers, two’s complement method is used.

All the letters in the answer string should be lowercase characters, and there should not be any leading zeros in the answer except for the zero itself.

Note: You are not allowed to use any built-in library method to directly solve this problem.

 

Example 1:

Input: num = 26
Output: "1a"
Example 2:

Input: num = -1
Output: "ffffffff"*/
        public string ToHex(int num)
        {
            if (num == 0) return "0";

            StringBuilder sb = new StringBuilder();
            while (num != 0)
            {
                int remainder = num & 15;
                sb.Insert(0, GetHexDigit(remainder));
                num >>= 4; 
        }

            return sb.ToString();
        }
        private char GetHexDigit(int num)
        {
            if (num < 10) return (char)('0' + num);
            else return (char)('a' + num - 10);
        }

        /*Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.

Letters are case sensitive, for example, "Aa" is not considered a palindrome here.

 

Example 1:

Input: s = "abccccdd"
Output: 7
Explanation: One longest palindrome that can be built is "dccaccd", whose length is 7.
Example 2:

Input: s = "a"
Output: 1
Explanation: The longest palindrome that can be built is "a", whose length is 1.*/
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charFreq.ContainsKey(c))
                {
                    charFreq[c] = 0;
                }
                charFreq[c]++;
            }

            int palindromeLength = 0;
            bool hasOddFreq = false;

            foreach (int freq in charFreq.Values)
            {
                palindromeLength += freq / 2 * 2;
                if (freq % 2 != 0) hasOddFreq = true; 
            }

            if (hasOddFreq) palindromeLength++;

            return palindromeLength;
        }

        /*Given an integer n, return a string array answer (1-indexed) where:

answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
answer[i] == "Fizz" if i is divisible by 3.
answer[i] == "Buzz" if i is divisible by 5.
answer[i] == i (as a string) if none of the above conditions are true.
 

Example 1:

Input: n = 3
Output: ["1","2","Fizz"]
Example 2:

Input: n = 5
Output: ["1","2","Fizz","4","Buzz"]
Example 3:

Input: n = 15
Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]*/
        public IList<string> FizzBuzz(int n)
        {
            IList<string> result = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        /*Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

 

Example 1:

Input: nums = [3,2,1]
Output: 1
Explanation:
The first distinct maximum is 3.
The second distinct maximum is 2.
The third distinct maximum is 1.
Example 2:

Input: nums = [1,2]
Output: 2
Explanation:
The first distinct maximum is 2.
The second distinct maximum is 1.
The third distinct maximum does not exist, so the maximum (2) is returned instead.
Example 3:

Input: nums = [2,2,3,1]
Output: 1
Explanation:
The first distinct maximum is 3.
The second distinct maximum is 2 (both 2's are counted together since they have the same value).
The third distinct maximum is 1.*/
        public int ThirdMax(int[] nums)
        {

            Array.Sort(nums);
            Array.Reverse(nums);

            int distinctMax = 0;
            int? thirdMax = null;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    distinctMax++;
                    if (distinctMax == 3)
                    {
                        thirdMax = nums[i];
                        break;
                    }
                }
            }

            return thirdMax ?? nums[0];
        }

        /*Given two non-negative integers, num1 and num2 represented as string, return the sum of num1 and num2 as a string.

You must solve the problem without using any built-in library for handling large integers (such as BigInteger). You must also not convert the inputs to integers directly.

 

Example 1:

Input: num1 = "11", num2 = "123"
Output: "134"
Example 2:

Input: num1 = "456", num2 = "77"
Output: "533"
Example 3:

Input: num1 = "0", num2 = "0"
Output: "0"
 */
        public string AddStrings(string num1, string num2)
        {
            StringBuilder result = new StringBuilder();

            int carry = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int digit1 = i >= 0 ? num1[i] - '0' : 0;
                int digit2 = j >= 0 ? num2[j] - '0' : 0;

                int sum = digit1 + digit2 + carry;
                result.Insert(0, sum % 10);
                carry = sum / 10;

                i--;
                j--;
            }

            return result.ToString();
        }

        /*Given a string s, return the number of segments in the string.

A segment is defined to be a contiguous sequence of non-space characters.

 

Example 1:

Input: s = "Hello, my name is John"
Output: 5
Explanation: The five segments are ["Hello,", "my", "name", "is", "John"]
Example 2:

Input: s = "Hello"
Output: 1*/
        public int CountSegments(string s)
        {
            string[] segments = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return segments.Length;
        }

        /*You have n coins and you want to build a staircase with these coins. The staircase consists of k rows where the ith row has exactly i coins. The last row of the staircase may be incomplete.

Given the integer n, return the number of complete rows of the staircase you will build.

 

Example 1:


Input: n = 5
Output: 2
Explanation: Because the 3rd row is incomplete, we return 2.
Example 2:


Input: n = 8
Output: 3
Explanation: Because the 4th row is incomplete, we return 3.
*/
        public int ArrangeCoins(int n)
        {
            long left = 0;
            long right = n;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long total = mid * (mid + 1) / 2;

                if (total == n)
                {
                    return (int)mid;
                }
                else if (total < n)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return (int)right;
        }

        /*Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

 

Example 1:

Input: nums = [4,3,2,7,8,2,3,1]
Output: [5,6]
Example 2:

Input: nums = [1,1]
Output: [2]*/
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>();

            foreach (int num in nums)
            {
                numSet.Add(num);
            }

            IList<int> result = new List<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                if (!numSet.Contains(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

    }
}
