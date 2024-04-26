using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema8
{
    public class Solutii
    {
        Functii functii = new Functii();

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
        public void solutia1()
        {
            int turnedOn1 = 1;
            IList<string> result1 = functii.ReadBinaryWatch(turnedOn1);
            foreach (string time in result1)
            {
                Console.WriteLine(time);
            }
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
        public void solutia2()
        {

            TreeNode root1 = new TreeNode(3);
            root1.left = new TreeNode(9);
            root1.right = new TreeNode(20);
            root1.right.left = new TreeNode(15);
            root1.right.right = new TreeNode(7);
            int sum1 = functii.SumOfLeftLeaves(root1);
            Console.WriteLine(sum1);
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
        public void solutia3()
        {
            int num1 = 26;
            string hex1 = functii.ToHex(num1);
            Console.WriteLine(hex1);
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
        public void solutia4()
        {
            string s1 = "abccccdd";
            int longestPalindrome1 = functii.LongestPalindrome(s1);
            Console.WriteLine(longestPalindrome1);
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
        public void solutia5()
        {
            int n1 = 3;
            IList<string> result1 = functii.FizzBuzz(n1);
            Console.WriteLine("[" + string.Join(",", result1) + "]");
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
        public void solutia6()
        {
            int[] nums1 = { 3, 2, 1 };
            Console.WriteLine(functii.ThirdMax(nums1));
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
        public void solutia7()
        {
            string num1_1 = "11";
            string num2_1 = "123";
            Console.WriteLine(functii.AddStrings(num1_1, num2_1));
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
        public void solutia8()
        {
            string s1 = "Hello, my name is John";
            Console.WriteLine(functii.CountSegments(s1));
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
        public void solutia9()
        {
            int n1 = 5;
            Console.WriteLine(functii.ArrangeCoins(n1));
        }

        /*Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.



Example 1:

Input: nums = [4,3,2,7,8,2,3,1]
Output: [5,6]
Example 2:

Input: nums = [1,1]
Output: [2]*/
        public void solutia10()
        {
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> result1 = functii.FindDisappearedNumbers(nums1);
            Console.WriteLine("[" + string.Join(",", result1) + "]");
        }
        
    }
}
