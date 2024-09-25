using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema23
{
    public class Functii
    {


        /*Given an array nums of integers, return how many of them contain an even number of digits.

 

Example 1:

Input: nums = [12,345,2,6,7896]
Output: 2
Explanation: 
12 contains 2 digits (even number of digits). 
345 contains 3 digits (odd number of digits). 
2 contains 1 digit (odd number of digits). 
6 contains 1 digit (odd number of digits). 
7896 contains 4 digits (even number of digits). 
Therefore only 12 and 7896 contain an even number of digits.
Example 2:

Input: nums = [555,901,482,1771]
Output: 1 
Explanation: 
Only 1771 contains an even number of digits.*/
        public int FindNums(int[] arr)
        {
            int count = 0;
            foreach (int n in arr)
            {
                if (n.ToString().Length % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /*Given an integer n, return any array containing n unique integers such that they add up to 0.

 

Example 1:

Input: n = 5
Output: [-7,-1,1,3,4]
Explanation: These arrays also are accepted [-5,-1,1,2,3] , [-3,-1,2,-2,4].
Example 2:

Input: n = 3
Output: [-1,0,1]
Example 3:

Input: n = 1
Output: [0]*/
        public int[] SumZero(int n)
        {
            int[] res = new int[n];
            int idx = 0;

            for (int i = 1; i <= n / 2; i++)
            {
                res[idx++] = i;
                res[idx++] = -i;
            }

            if (n % 2 != 0)
            {
                res[idx] = 0;
            }

            return res;
        }

        /*The k-beauty of an integer num is defined as the number of substrings of num when it is read as a string that meet the following conditions:

It has a length of k.
It is a divisor of num.
Given integers num and k, return the k-beauty of num.

Note:

Leading zeros are allowed.
0 is not a divisor of any value.
A substring is a contiguous sequence of characters in a string.

 

Example 1:

Input: num = 240, k = 2
Output: 2
Explanation: The following are the substrings of num of length k:
- "24" from "240": 24 is a divisor of 240.
- "40" from "240": 40 is a divisor of 240.
Therefore, the k-beauty is 2.
Example 2:

Input: num = 430043, k = 2
Output: 2
Explanation: The following are the substrings of num of length k:
- "43" from "430043": 43 is a divisor of 430043.
- "30" from "430043": 30 is not a divisor of 430043.
- "00" from "430043": 0 is not a divisor of 430043.
- "04" from "430043": 4 is not a divisor of 430043.
- "43" from "430043": 43 is a divisor of 430043.
Therefore, the k-beauty is 2.*/
        public int DivisorSubstrings(int num, int k)
        {
            string s = num.ToString();
            int count = 0;

            for (int i = 0; i <= s.Length - k; i++)
            {
                string subStr = s.Substring(i, k);
                int subNum = int.Parse(subStr);

                if (subNum != 0 && num % subNum == 0)
                {
                    count++;
                }
            }

            return count;
        }

        /*You are given a string s formed by digits and '#'. We want to map s to English lowercase characters as follows:

Characters ('a' to 'i') are represented by ('1' to '9') respectively.
Characters ('j' to 'z') are represented by ('10#' to '26#') respectively.
Return the string formed after mapping.

The test cases are generated so that a unique mapping will always exist.

 

Example 1:

Input: s = "10#11#12"
Output: "jkab"
Explanation: "j" -> "10#" , "k" -> "11#" , "a" -> "1" , "b" -> "2".
Example 2:

Input: s = "1326#"
Output: "acz"
 */
        public string FreqAlphabets(string s)
        {
            string result = "";
            int i = 0;

            while (i < s.Length)
            {
                if (i + 2 < s.Length && s[i + 2] == '#')
                {
                    int num = int.Parse(s.Substring(i, 2));
                    result += (char)(num - 1 + 'a');
                    i += 3;
                }
                else
                {
                    int num = s[i] - '0';
                    result += (char)(num - 1 + 'a');
                    i++;
                }
            }

            return result;
        }

        /*No-Zero integer is a positive integer that does not contain any 0 in its decimal representation.

Given an integer n, return a list of two integers [a, b] where:

a and b are No-Zero integers.
a + b = n
The test cases are generated so that there is at least one valid solution. If there are many valid solutions, you can return any of them.

 

Example 1:

Input: n = 2
Output: [1,1]
Explanation: Let a = 1 and b = 1.
Both a and b are no-zero integers, and a + b = 2 = n.
Example 2:

Input: n = 11
Output: [2,9]
Explanation: Let a = 2 and b = 9.
Both a and b are no-zero integers, and a + b = 9 = n.
Note that there are other valid answers as [8, 3] that can be accepted.*/
        public int[] GetNoZeroIntegers(int n)
        {
            for (int a = 1; a < n; a++)
            {
                int b = n - a;
                if (IsNoZero(a) && IsNoZero(b))
                {
                    return new int[] { a, b };
                }
            }
            return new int[] { 0, 0 };
        }
        private bool IsNoZero(int num)
        {
            while (num > 0)
            {
                if (num % 10 == 0) return false;
                num /= 10;
            }
            return true;
        }

        /*Given an integer num, return the number of steps to reduce it to zero.

In one step, if the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.

 

Example 1:

Input: num = 14
Output: 6
Explanation: 
Step 1) 14 is even; divide by 2 and obtain 7. 
Step 2) 7 is odd; subtract 1 and obtain 6.
Step 3) 6 is even; divide by 2 and obtain 3. 
Step 4) 3 is odd; subtract 1 and obtain 2. 
Step 5) 2 is even; divide by 2 and obtain 1. 
Step 6) 1 is odd; subtract 1 and obtain 0.
Example 2:

Input: num = 8
Output: 4
Explanation: 
Step 1) 8 is even; divide by 2 and obtain 4. 
Step 2) 4 is even; divide by 2 and obtain 2. 
Step 3) 2 is even; divide by 2 and obtain 1. 
Step 4) 1 is odd; subtract 1 and obtain 0.
Example 3:

Input: num = 123
Output: 12*/
        public int NumberOfSteps(int num)
        {
            int steps = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2; 
                }
                else
                {
                    num -= 1;  
                }
                steps++; 
            }

            return steps;
        }

        /*You are given a positive integer num consisting only of digits 6 and 9.

Return the maximum number you can get by changing at most one digit (6 becomes 9, and 9 becomes 6).

 

Example 1:

Input: num = 9669
Output: 9969
Explanation: 
Changing the first digit results in 6669.
Changing the second digit results in 9969.
Changing the third digit results in 9699.
Changing the fourth digit results in 9666.
The maximum number is 9969.
Example 2:

Input: num = 9996
Output: 9999
Explanation: Changing the last digit 6 to 9 results in the maximum number.
Example 3:

Input: num = 9999
Output: 9999
Explanation: It is better not to apply any change.*/
        public int Maximum69Number(int num)
        {
            char[] digits = num.ToString().ToCharArray();

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == '6')
                {
                    digits[i] = '9';
                    break;
                }
            }

            return int.Parse(new string(digits));
        }

        /*You are given a string s consisting only of letters 'a' and 'b'. In a single step you can remove one palindromic subsequence from s.

Return the minimum number of steps to make the given string empty.

A string is a subsequence of a given string if it is generated by deleting some characters of a given string without changing its order. Note that a subsequence does not necessarily need to be contiguous.

A string is called palindrome if is one that reads the same backward as well as forward.

 

Example 1:

Input: s = "ababa"
Output: 1
Explanation: s is already a palindrome, so its entirety can be removed in a single step.
Example 2:

Input: s = "abb"
Output: 2
Explanation: "abb" -> "bb" -> "". 
Remove palindromic subsequence "a" then "bb".
Example 3:

Input: s = "baabb"
Output: 2
Explanation: "baabb" -> "b" -> "". 
Remove palindromic subsequence "baab" then "b".*/
        public int RemovePalindromeSub(string s)
        {
            if (IsPalindrome(s))
            {
                return 1;
            }
            return 2;
        }
        private bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        /*You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in their binary representation and in case of two or more integers have the same number of 1's you have to sort them in ascending order.

Return the array after sorting it.

 

Example 1:

Input: arr = [0,1,2,3,4,5,6,7,8]
Output: [0,1,2,4,8,3,5,6,7]
Explantion: [0] is the only integer with 0 bits.
[1,2,4,8] all have 1 bit.
[3,5,6] have 2 bits.
[7] has 3 bits.
The sorted array by bits is [0,1,2,4,8,3,5,6,7]
Example 2:

Input: arr = [1024,512,256,128,64,32,16,8,4,2,1]
Output: [1,2,4,8,16,32,64,128,256,512,1024]
Explantion: All integers have 1 bit in the binary representation, you should just sort them in ascending order.
 */
        public int[] SortByBits(int[] arr)
        {
            return arr.OrderBy(x => CountOnes(x))
                      .ThenBy(x => x)
                      .ToArray();
        }
        private int CountOnes(int num)
        {
            return Convert.ToString(num, 2).Count(c => c == '1');
        }

        /*You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's (representing civilians). The soldiers are positioned in front of the civilians. That is, all the 1's will appear to the left of all the 0's in each row.

A row i is weaker than a row j if one of the following is true:

The number of soldiers in row i is less than the number of soldiers in row j.
Both rows have the same number of soldiers and i < j.
Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.

 

Example 1:

Input: mat = 
[[1,1,0,0,0],
 [1,1,1,1,0],
 [1,0,0,0,0],
 [1,1,0,0,0],
 [1,1,1,1,1]], 
k = 3
Output: [2,0,3]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 2 
- Row 1: 4 
- Row 2: 1 
- Row 3: 2 
- Row 4: 5 
The rows ordered from weakest to strongest are [2,0,3,1,4].
Example 2:

Input: mat = 
[[1,0,0,0],
 [1,1,1,1],
 [1,0,0,0],
 [1,0,0,0]], 
k = 2
Output: [0,2]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 1 
- Row 1: 4 
- Row 2: 1 
- Row 3: 1 
The rows ordered from weakest to strongest are [0,2,3,1].*/
        public int[] KWeakestRows(int[][] mat, int k)
        {
            var soldiers = new List<(int count, int index)>();

            for (int i = 0; i < mat.Length; i++)
            {
                int count = mat[i].Count(x => x == 1);
                soldiers.Add((count, i));
            }

            soldiers = soldiers.OrderBy(x => x.count).ThenBy(x => x.index).ToList();

            return soldiers.Take(k).Select(x => x.index).ToArray();
        }













































    }
}
