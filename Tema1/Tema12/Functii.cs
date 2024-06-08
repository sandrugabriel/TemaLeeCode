using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema12
{
    public class Functii
    {

        /*Given a string s, return true if the s can be palindrome after deleting at most one character from it.

 

Example 1:

Input: s = "aba"
Output: true
Example 2:

Input: s = "abca"
Output: true
Explanation: You could delete the character 'c'.
Example 3:

Input: s = "abc"
Output: false*/
       public bool CanBePalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
                }
                left++;
                right--;
            }

            return true;
        }
       public bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        /*You are keeping the scores for a baseball game with strange rules. At the beginning of the game, you start with an empty record.

You are given a list of strings operations, where operations[i] is the ith operation you must apply to the record and is one of the following:

An integer x.
Record a new score of x.
'+'.
Record a new score that is the sum of the previous two scores.
'D'.
Record a new score that is the double of the previous score.
'C'.
Invalidate the previous score, removing it from the record.
Return the sum of all the scores on the record after applying all the operations.

The test cases are generated such that the answer and all intermediate calculations fit in a 32-bit integer and that all operations are valid.

 

Example 1:

Input: ops = ["5","2","C","D","+"]
Output: 30
Explanation:
"5" - Add 5 to the record, record is now [5].
"2" - Add 2 to the record, record is now [5, 2].
"C" - Invalidate and remove the previous score, record is now [5].
"D" - Add 2 * 5 = 10 to the record, record is now [5, 10].
"+" - Add 5 + 10 = 15 to the record, record is now [5, 10, 15].
The total sum is 5 + 10 + 15 = 30.
Example 2:

Input: ops = ["5","-2","4","C","D","9","+","+"]
Output: 27
Explanation:
"5" - Add 5 to the record, record is now [5].
"-2" - Add -2 to the record, record is now [5, -2].
"4" - Add 4 to the record, record is now [5, -2, 4].
"C" - Invalidate and remove the previous score, record is now [5, -2].
"D" - Add 2 * -2 = -4 to the record, record is now [5, -2, -4].
"9" - Add 9 to the record, record is now [5, -2, -4, 9].
"+" - Add -4 + 9 = 5 to the record, record is now [5, -2, -4, 9, 5].
"+" - Add 9 + 5 = 14 to the record, record is now [5, -2, -4, 9, 5, 14].
The total sum is 5 + -2 + -4 + 9 + 5 + 14 = 27.
Example 3:

Input: ops = ["1","C"]
Output: 0
Explanation:
"1" - Add 1 to the record, record is now [1].
"C" - Invalidate and remove the previous score, record is now [].
Since the record is empty, the total sum is 0.
 */
        public int CalPoints(string[] ops)
        {
            Stack<int> stack = new Stack<int>();

            foreach (string op in ops)
            {
                if (op == "C")
                {
                    stack.Pop();
                }
                else if (op == "D")
                {
                    int prevScore = stack.Peek();
                    stack.Push(prevScore * 2);
                }
                else if (op == "+")
                {
                    int lastScore = stack.Pop();
                    int secondLastScore = stack.Peek();
                    stack.Push(lastScore);
                    stack.Push(lastScore + secondLastScore);
                }
                else
                {
                    stack.Push(int.Parse(op));
                }
            }

            int totalSum = 0;
            while (stack.Count > 0)
            {
                totalSum += stack.Pop();
            }

            return totalSum;
        }

        /*Given a positive integer, check whether it has alternating bits: namely, if two adjacent bits will always have different values.

 

Example 1:

Input: n = 5
Output: true
Explanation: The binary representation of 5 is: 101
Example 2:

Input: n = 7
Output: false
Explanation: The binary representation of 7 is: 111.
Example 3:

Input: n = 11
Output: false
Explanation: The binary representation of 11 is: 1011.
 */
        public bool HasAlternatingBits(int n)
        {
            int prevBit = n & 1;
            n >>= 1;

            while (n > 0)
            {
                int currentBit = n & 1;
                if (currentBit == prevBit)
                {
                    return false;
                }
                prevBit = currentBit;
                n >>= 1;
            }

            return true;
        }

        /*Given a binary string s, return the number of non-empty substrings that have the same number of 0's and 1's, and all the 0's and all the 1's in these substrings are grouped consecutively.

Substrings that occur multiple times are counted the number of times they occur.

 

Example 1:

Input: s = "00110011"
Output: 6
Explanation: There are 6 substrings that have equal number of consecutive 1's and 0's: "0011", "01", "1100", "10", "0011", and "01".
Notice that some of these substrings repeat and are counted the number of times they occur.
Also, "00110011" is not a valid substring because all the 0's (and 1's) are not grouped together.
Example 2:

Input: s = "10101"
Output: 4
Explanation: There are 4 substrings: "10", "01", "10", "01" that have equal number of consecutive 1's and 0's.
 */
        public int CountBinarySubstrings(string s)
        {
            int count = 0;
            int prevCount = 0;
            int currentCount = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    currentCount++;
                }
                else
                {
                    count += Math.Min(prevCount, currentCount);
                    prevCount = currentCount;
                    currentCount = 1;
                }
            }

            return count + Math.Min(prevCount, currentCount);
        }

        /*Given a non-empty array of non-negative integers nums, the degree of this array is defined as the maximum frequency of any one of its elements.

Your task is to find the smallest possible length of a (contiguous) subarray of nums, that has the same degree as nums.

 

Example 1:

Input: nums = [1,2,2,3,1]
Output: 2
Explanation: 
The input array has a degree of 2 because both elements 1 and 2 appear twice.
Of the subarrays that have the same degree:
[1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
The shortest length is 2. So return 2.
Example 2:

Input: nums = [1,2,2,3,1,4,2]
Output: 6
Explanation: 
The degree is 3 because the element 2 is repeated 3 times.
So [2,2,3,1,4,2] is the shortest subarray, therefore returning 6.
 */
        public int FindShortestSubarray(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            var indices = new Dictionary<int, int[]>();

            int maxFreq = 0;

            foreach (int num in nums)
            {
                if (!freq.ContainsKey(num))
                    freq[num] = 0;
                freq[num]++;
                maxFreq = Math.Max(maxFreq, freq[num]);

                if (!indices.ContainsKey(num))
                    indices[num] = new int[] { int.MaxValue, int.MinValue };
                indices[num][1] = Math.Max(indices[num][1], freq[num]);
                if (indices[num][0] == int.MaxValue)
                    indices[num][0] = freq[num];
            }

            int minLength = nums.Length;

            foreach (var kvp in freq)
            {
                if (kvp.Value == maxFreq)
                {
                    int[] index = indices[kvp.Key];
                    minLength = Math.Min(minLength, index[1] - index[0] + 1);
                }
            }

            return minLength;
        }

        /*Given an array of integers nums, calculate the pivot index of this array.

The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.

If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.

Return the leftmost pivot index. If no such index exists, return -1.

 

Example 1:

Input: nums = [1,7,3,6,5,6]
Output: 3
Explanation:
The pivot index is 3.
Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
Right sum = nums[4] + nums[5] = 5 + 6 = 11
Example 2:

Input: nums = [1,2,3]
Output: -1
Explanation:
There is no index that satisfies the conditions in the problem statement.
Example 3:

Input: nums = [2,1,-1]
Output: 0
Explanation:
The pivot index is 0.
Left sum = 0 (no elements to the left of index 0)
Right sum = nums[1] + nums[2] = 1 + -1 = 0*/
        public int PivotIndex(int[] nums)
        {
            int totalSum = 0;
            foreach (int num in nums)
            {
                totalSum += num;
            }

            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (leftSum == totalSum - leftSum - nums[i])
                {
                    return i;
                }
                leftSum += nums[i];
            }

            return -1;
        }

        /*A self-dividing number is a number that is divisible by every digit it contains.

For example, 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0, and 128 % 8 == 0.
A self-dividing number is not allowed to contain the digit zero.

Given two integers left and right, return a list of all the self-dividing numbers in the range [left, right].

 

Example 1:

Input: left = 1, right = 22
Output: [1,2,3,4,5,6,7,8,9,11,12,15,22]
Example 2:

Input: left = 47, right = 85
Output: [48,55,66,77]
 */
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> result = new List<int>();

            for (int num = left; num <= right; num++)
            {
                if (IsSelfDividing(num))
                {
                    result.Add(num);
                }
            }

            return result;
        }
        private bool IsSelfDividing(int num)
        {
            int originalNum = num;
            while (num > 0)
            {
                int digit = num % 10;
                if (digit == 0 || originalNum % digit != 0)
                {
                    return false;
                }
                num /= 10;
            }
            return true;
        }

        /*An image is represented by an m x n integer grid image where image[i][j] represents the pixel value of the image.

You are also given three integers sr, sc, and color. You should perform a flood fill on the image starting from the pixel image[sr][sc].

To perform a flood fill, consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color), and so on. Replace the color of all of the aforementioned pixels with color.

Return the modified image after performing the flood fill.

 

Example 1:


Input: image = [[1,1,1],[1,1,0],[1,0,1]], sr = 1, sc = 1, color = 2
Output: [[2,2,2],[2,2,0],[2,0,1]]
Explanation: From the center of the image with position (sr, sc) = (1, 1) (i.e., the red pixel), all pixels connected by a path of the same color as the starting pixel (i.e., the blue pixels) are colored with the new color.
Note the bottom corner is not colored 2, because it is not 4-directionally connected to the starting pixel.
Example 2:

Input: image = [[0,0,0],[0,0,0]], sr = 0, sc = 0, color = 0
Output: [[0,0,0],[0,0,0]]
Explanation: The starting pixel is already colored 0, so no changes are made to the image.*/
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int originalColor = image[sr][sc];
            if (originalColor != newColor)
            {
                DFS(image, sr, sc, originalColor, newColor);
            }
            return image;
        }
        private void DFS(int[][] image, int sr, int sc, int originalColor, int newColor)
        {
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != originalColor)
            {
                return;
            }

            image[sr][sc] = newColor;

            DFS(image, sr + 1, sc, originalColor, newColor);
            DFS(image, sr - 1, sc, originalColor, newColor);
            DFS(image, sr, sc + 1, originalColor, newColor);
            DFS(image, sr, sc - 1, originalColor, newColor);
        }

        /*You are given an array of characters letters that is sorted in non-decreasing order, and a character target. There are at least two different characters in letters.

Return the smallest character in letters that is lexicographically greater than target. If such a character does not exist, return the first character in letters.

 

Example 1:

Input: letters = ["c","f","j"], target = "a"
Output: "c"
Explanation: The smallest character that is lexicographically greater than 'a' in letters is 'c'.
Example 2:

Input: letters = ["c","f","j"], target = "c"
Output: "f"
Explanation: The smallest character that is lexicographically greater than 'c' in letters is 'f'.
Example 3:

Input: letters = ["x","x","y","y"], target = "z"
Output: "x"
Explanation: There are no characters in letters that is lexicographically greater than 'z' so we return letters[0].
 */
        public char NextGreatestLetter(char[] letters, char target)
        {
            int left = 0;
            int right = letters.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (letters[mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left < letters.Length ? letters[left] : letters[0];
        }

        /*You are given an integer array nums where the largest integer is unique.

Determine whether the largest element in the array is at least twice as much as every other number in the array. If it is, return the index of the largest element, or return -1 otherwise.

 

Example 1:

Input: nums = [3,6,1,0]
Output: 1
Explanation: 6 is the largest integer.
For every other number in the array x, 6 is at least twice as big as x.
The index of value 6 is 1, so we return 1.
Example 2:

Input: nums = [1,2,3,4]
Output: -1
Explanation: 4 is less than twice the value of 3, so we return -1.
 */
        public int DominantIndex(int[] nums)
        {
            int maxIndex = -1;
            int maxNum = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxNum)
                {
                    maxNum = nums[i];
                    maxIndex = i;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != maxIndex && nums[i] * 2 > maxNum)
                {
                    return -1;
                }
            }

            return maxIndex;
        }

    }
}
