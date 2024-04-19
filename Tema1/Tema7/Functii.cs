using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema7
{
    public class Functii
    {

        /*Given an integer n, return true if it is a power of three. Otherwise, return false.

An integer n is a power of three, if there exists an integer x such that n == 3x.



Example 1:

Input: n = 27
Output: true
Explanation: 27 = 33
Example 2:

Input: n = 0
Output: false
Explanation: There is no x where 3x = 0.
Example 3:

Input: n = -1
Output: false
Explanation: There is no x where 3x = (-1).
*/
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0) return false;

            while (n % 3 == 0)
            {
                n /= 3;
            }

            return n == 1;
        }

        /*Given an integer n, return true if it is a power of four. Otherwise, return false.

An integer n is a power of four, if there exists an integer x such that n == 4x.

 

Example 1:

Input: n = 16
Output: true
Example 2:

Input: n = 5
Output: false
Example 3:

Input: n = 1
Output: true*/
        public bool IsPowerOfFour(int n)
        {
            if (n <= 0) return false;

            while (n % 4 == 0)
            {
                n /= 4;
            }

            return n == 1;
        }

        /*Write a function that reverses a string. The input string is given as an array of characters s.

You must do this by modifying the input array in-place with O(1) extra memory.

 

Example 1:

Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]
Example 2:

Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
 */
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        /*Given a string s, reverse only all the vowels in the string and return it.

The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

 

Example 1:

Input: s = "hello"
Output: "holle"
Example 2:

Input: s = "leetcode"
Output: "leotcede"
 */
        public string ReverseVowels(string s)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] charArray = s.ToCharArray();

            int left = 0;
            int right = charArray.Length - 1;

            while (left < right)
            {
                if (Array.IndexOf(vowels, charArray[left]) != -1 && Array.IndexOf(vowels, charArray[right]) != -1)
                {
                    char temp = charArray[left];
                    charArray[left] = charArray[right];
                    charArray[right] = temp;
                    left++;
                    right--;
                }
                else if (Array.IndexOf(vowels, charArray[left]) != -1)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return new string(charArray);
        }

        /*Given two integer arrays nums1 and nums2, return an array of their 
intersection
. Each element in the result must be unique and you may return the result in any order.

 

Example 1:

Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2]
Example 2:

Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [9,4]
Explanation: [4,9] is also accepted.
 */
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>(nums1);
            HashSet<int> intersection = new HashSet<int>();

            foreach (int num in nums2)
            {
                if (set.Contains(num))
                {
                    intersection.Add(num);
                }
            }

            return intersection.ToArray();
        }

        /*Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.

 

Example 1:

Input: nums1 = [1,2,2,1], nums2 = [2,2]
Output: [2,2]
Example 2:

Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
Output: [4,9]
Explanation: [9,4] is also accepted.
 */
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            List<int> intersection = new List<int>();

            foreach (int num in nums1)
            {
                if (!frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num] = 1;
                }
                else
                {
                    frequencyMap[num]++;
                }
            }

            foreach (int num in nums2)
            {
                if (frequencyMap.ContainsKey(num) && frequencyMap[num] > 0)
                {
                    intersection.Add(num);
                    frequencyMap[num]--;
                }
            }

            return intersection.ToArray();
        }

        /*Given a positive integer num, return true if num is a perfect square or false otherwise.

A perfect square is an integer that is the square of an integer. In other words, it is the product of some integer with itself.

You must not use any built-in library function, such as sqrt.

 

Example 1:

Input: num = 16
Output: true
Explanation: We return true because 4 * 4 = 16 and 4 is an integer.
Example 2:

Input: num = 14
Output: false
Explanation: We return false because 3.742 * 3.742 = 14 and 3.742 is not an integer.*/
        public bool IsPerfectSquare(int num)
        {
            long left = 1;
            long right = num;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long square = mid * mid;

                if (square == num)
                {
                    return true;
                }
                else if (square < num)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        /*We are playing the Guess Game. The game is as follows:

I pick a number from 1 to n. You have to guess which number I picked.

Every time you guess wrong, I will tell you whether the number I picked is higher or lower than your guess.

You call a pre-defined API int guess(int num), which returns three possible results:

-1: Your guess is higher than the number I picked (i.e. num > pick).
1: Your guess is lower than the number I picked (i.e. num < pick).
0: your guess is equal to the number I picked (i.e. num == pick).
Return the number that I picked.

 

Example 1:

Input: n = 10, pick = 6
Output: 6
Example 2:

Input: n = 1, pick = 1
Output: 1
Example 3:

Input: n = 2, pick = 1
Output: 1
 */
        private int Guess(int num)
        {
            int pickedNumber = 6; 

            if (num < pickedNumber)
            {
                return 1; 
            }
            else if (num > pickedNumber)
            {
                return -1; 
            }
            else
            {
                return 0; 
            }
        }
        public int GuessNumber(int n)
        {
            int left = 1;
            int right = n;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int result = Guess(mid);

                if (result == 0)
                {
                    return mid;
                }
                else if (result == 1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }


            return -1;
        }

        /*Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

 

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true*/
        public bool CanConstruct(string ransomNote, string magazine)
        {

            Dictionary<char, int> magazineFreq = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (!magazineFreq.ContainsKey(c))
                {
                    magazineFreq[c] = 1;
                }
                else
                {
                    magazineFreq[c]++;
                }
            }


            foreach (char c in ransomNote)
            {
                if (!magazineFreq.ContainsKey(c) || magazineFreq[c] == 0)
                {
                    return false;
                }
                else
                {
                    magazineFreq[c]--;
                }
            }

            return true;
        }

        /*You are given two strings s and t.

String t is generated by random shuffling string s and then add one more letter at a random position.

Return the letter that was added to t.

 

Example 1:

Input: s = "abcd", t = "abcde"
Output: "e"
Explanation: 'e' is the letter that was added.
Example 2:

Input: s = "", t = "y"
Output: "y"
 */
        public char FindTheDifference(string s, string t)
        {
            int[] charCount = new int[26];

            foreach (char c in s)
            {
                charCount[c - 'a']++;
            }

            foreach (char c in t)
            {
                charCount[c - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (charCount[i] < 0)
                {
                    return (char)('a' + i);
                }
            }

            return ' ';
        }
  
    }
}
