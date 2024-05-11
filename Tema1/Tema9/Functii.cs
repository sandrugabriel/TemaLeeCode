using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema9
{
    public class Functii
    {

        /*Assume you are an awesome parent and want to give your children some cookies. But, you should give each child at most one cookie.

Each child i has a greed factor g[i], which is the minimum size of a cookie that the child will be content with; and each cookie j has a size s[j]. If s[j] >= g[i], we can assign the cookie j to the child i, and the child i will be content. Your goal is to maximize the number of your content children and output the maximum number.

 

Example 1:

Input: g = [1,2,3], s = [1,1]
Output: 1
Explanation: You have 3 children and 2 cookies. The greed factors of 3 children are 1, 2, 3. 
And even though you have 2 cookies, since their size is both 1, you could only make the child whose greed factor is 1 content.
You need to output 1.
Example 2:

Input: g = [1,2], s = [1,2,3]
Output: 2
Explanation: You have 2 children and 3 cookies. The greed factors of 2 children are 1, 2. 
You have 3 cookies and their sizes are big enough to gratify all of the children, 
You need to output 2.
 */
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int contentChildren = 0;
            int i = 0;
            int j = 0;

            while (i < g.Length && j < s.Length)
            {
                if (s[j] >= g[i])
                {
                    contentChildren++;
                    i++;
                }
                j++;
            }

            return contentChildren;
        }

        /*Given a string s, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.



Example 1:

Input: s = "abab"
Output: true
Explanation: It is the substring "ab" twice.
Example 2:

Input: s = "aba"
Output: false
Example 3:

Input: s = "abcabcabcabc"
Output: true
Explanation: It is the substring "abc" four times or the substring "abcabc" twice.
*/
        public bool RepeatedSubstringPattern(string s)
        {
            int n = s.Length;

            for (int len = 1; len <= n / 2; len++)
            {
                if (n % len == 0)
                {
                    string substr = s.Substring(0, len);
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < n / len; i++)
                    {
                        sb.Append(substr);
                    }


                    if (sb.ToString() == s)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /*The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

Given two integers x and y, return the Hamming distance between them.

 

Example 1:

Input: x = 1, y = 4
Output: 2
Explanation:
1   (0 0 0 1)
4   (0 1 0 0)
       ↑   ↑
The above arrows point to positions where the corresponding bits are different.
Example 2:

Input: x = 3, y = 1
Output: 1
 */
        public int HammingDistance(int x, int y)
        {
            int xorResult = x ^ y;
            int distance = 0;

            while (xorResult != 0)
            {
                distance += xorResult & 1;
                xorResult >>= 1;
            }

            return distance;
        }

        /*You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.

Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island. One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.

 

Example 1:


Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
Output: 16
Explanation: The perimeter is the 16 yellow stripes in the image above.
Example 2:

Input: grid = [[1]]
Output: 4
Example 3:

Input: grid = [[1,0]]
Output: 4*/
        public int IslandPerimeter(int[][] grid)
        {
            int perimeter = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        perimeter += 4;

                        if (i > 0 && grid[i - 1][j] == 1)
                            perimeter -= 2;
                        if (j > 0 && grid[i][j - 1] == 1)
                            perimeter -= 2;
                    }
                }
            }

            return perimeter;
        }

        /*The complement of an integer is the integer you get when you flip all the 0's to 1's and all the 1's to 0's in its binary representation.

For example, The integer 5 is "101" in binary and its complement is "010" which is the integer 2.
Given an integer num, return its complement.

 

Example 1:

Input: num = 5
Output: 2
Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
Example 2:

Input: num = 1
Output: 0
Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
 */
        public int FindComplement(int num)
        {
            int mask = 0;

            while ((num & mask) != 0)
            {
                mask <<= 1;
            }

            return num ^ (mask >> 1);
        }

        /*You are given a license key represented as a string s that consists of only alphanumeric characters and dashes. The string is separated into n + 1 groups by n dashes. You are also given an integer k.

We want to reformat the string s such that each group contains exactly k characters, except for the first group, which could be shorter than k but still must contain at least one character. Furthermore, there must be a dash inserted between two groups, and you should convert all lowercase letters to uppercase.

Return the reformatted license key.

 

Example 1:

Input: s = "5F3Z-2e-9-w", k = 4
Output: "5F3Z-2E9W"
Explanation: The string s has been split into two parts, each part has 4 characters.
Note that the two extra dashes are not needed and can be removed.
Example 2:

Input: s = "2-5g-3-J", k = 2
Output: "2-5G-3J"
Explanation: The string s has been split into three parts, each part has 2 characters except the first part as it could be shorter as mentioned above.
 */
        public string LicenseKeyFormatting(string s, int k)
        {
            s = s.Replace("-", "").ToUpper();

            int n = s.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = n - 1; i >= 0; i--)
            {
                sb.Insert(0, s[i]);

                if ((n - i) % k == 0 && i != 0)
                {
                    sb.Insert(0, '-');
                }
            }

            return sb.ToString();
        }

        /*Given a binary array nums, return the maximum number of consecutive 1's in the array.

 

Example 1:

Input: nums = [1,1,0,1,1,1]
Output: 3
Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
Example 2:

Input: nums = [1,0,1,1,0,1]
Output: 2*/
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxCount = 0;
            int count = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    count++;
                }
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 0;
                }
            }


            return Math.Max(maxCount, count);
        }

        /*A web developer needs to know how to design a web page's size. So, given a specific rectangular web page’s area, your job by now is to design a rectangular web page, whose length L and width W satisfy the following requirements:

The area of the rectangular web page you designed must equal to the given target area.
The width W should not be larger than the length L, which means L >= W.
The difference between length L and width W should be as small as possible.
Return an array [L, W] where L and W are the length and width of the web page you designed in sequence.

 

Example 1:

Input: area = 4
Output: [2,2]
Explanation: The target area is 4, and all the possible ways to construct it are [1,4], [2,2], [4,1]. 
But according to requirement 2, [1,4] is illegal; according to requirement 3,  [4,1] is not optimal compared to [2,2]. So the length L is 2, and the width W is 2.
Example 2:

Input: area = 37
Output: [37,1]
Example 3:

Input: area = 122122
Output: [427,286]*/
        public int[] ConstructRectangle(int area)
        {
            int[] result = new int[2];

            int sqrt = (int)Math.Sqrt(area);

            for (int i = sqrt; i >= 1; i--)
            {
                if (area % i == 0)
                {
                    result[0] = area / i;
                    result[1] = i;
                    break;
                }
            }

            return result;
        }

        /*Our hero Teemo is attacking an enemy Ashe with poison attacks! When Teemo attacks Ashe, Ashe gets poisoned for a exactly duration seconds. More formally, an attack at second t will mean Ashe is poisoned during the inclusive time interval [t, t + duration - 1]. If Teemo attacks again before the poison effect ends, the timer for it is reset, and the poison effect will end duration seconds after the new attack.

You are given a non-decreasing integer array timeSeries, where timeSeries[i] denotes that Teemo attacks Ashe at second timeSeries[i], and an integer duration.

Return the total number of seconds that Ashe is poisoned.

 

Example 1:

Input: timeSeries = [1,4], duration = 2
Output: 4
Explanation: Teemo's attacks on Ashe go as follows:
- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
- At second 4, Teemo attacks, and Ashe is poisoned for seconds 4 and 5.
Ashe is poisoned for seconds 1, 2, 4, and 5, which is 4 seconds in total.
Example 2:

Input: timeSeries = [1,2], duration = 2
Output: 3
Explanation: Teemo's attacks on Ashe go as follows:
- At second 1, Teemo attacks, and Ashe is poisoned for seconds 1 and 2.
- At second 2 however, Teemo attacks again and resets the poison timer. Ashe is poisoned for seconds 2 and 3.
Ashe is poisoned for seconds 1, 2, and 3, which is 3 seconds in total.
 */
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries == null || timeSeries.Length == 0 || duration == 0)
            {
                return 0;
            }

            int totalDuration = 0;
            int previousAttackTime = timeSeries[0];

            foreach (int attackTime in timeSeries)
            {
                totalDuration += Math.Min(duration, attackTime - previousAttackTime);
                previousAttackTime = attackTime;
            }

            return totalDuration + duration;
        }

        /*The next greater element of some element x in an array is the first greater element that is to the right of x in the same array.

You are given two distinct 0-indexed integer arrays nums1 and nums2, where nums1 is a subset of nums2.

For each 0 <= i < nums1.length, find the index j such that nums1[i] == nums2[j] and determine the next greater element of nums2[j] in nums2. If there is no next greater element, then the answer for this query is -1.

Return an array ans of length nums1.length such that ans[i] is the next greater element as described above.

 

Example 1:

Input: nums1 = [4,1,2], nums2 = [1,3,4,2]
Output: [-1,3,-1]
Explanation: The next greater element for each value of nums1 is as follows:
- 4 is underlined in nums2 = [1,3,4,2]. There is no next greater element, so the answer is -1.
- 1 is underlined in nums2 = [1,3,4,2]. The next greater element is 3.
- 2 is underlined in nums2 = [1,3,4,2]. There is no next greater element, so the answer is -1.
Example 2:

Input: nums1 = [2,4], nums2 = [1,2,3,4]
Output: [3,-1]
Explanation: The next greater element for each value of nums1 is as follows:
- 2 is underlined in nums2 = [1,2,3,4]. The next greater element is 3.
- 4 is underlined in nums2 = [1,2,3,4]. There is no next greater element, so the answer is -1.*/
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> nextGreater = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();

            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= nums2[i])
                {
                    stack.Pop();
                }
                nextGreater[nums2[i]] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(nums2[i]);
            }

            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = nextGreater[nums1[i]];
            }

            return result;
        }

    }
}
