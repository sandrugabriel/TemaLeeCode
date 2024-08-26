using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema20
{
    public class Functii
    {

        /*Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated to be equal to another domino.

Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].

 

Example 1:

Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
Output: 1
Example 2:

Input: dominoes = [[1,2],[1,2],[1,1],[1,2],[2,2]]
Output: 3*/
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            var map = new Dictionary<int, int>();
            int pairs = 0;

            foreach (var domino in dominoes)
            {
                int a = domino[0];
                int b = domino[1];
                int key = a < b ? a * 10 + b : b * 10 + a;

                if (map.ContainsKey(key))
                {
                    pairs += map[key];
                    map[key]++;
                }
                else
                {
                    map[key] = 1;
                }
            }

            return pairs;
        }

        /*Given an array arr, replace every element in that array with the greatest element among the elements to its right, and replace the last element with -1.

After doing so, return the array.

 

Example 1:

Input: arr = [17,18,5,4,6,1]
Output: [18,6,6,6,1,-1]
Explanation: 
- index 0 --> the greatest element to the right of index 0 is index 1 (18).
- index 1 --> the greatest element to the right of index 1 is index 4 (6).
- index 2 --> the greatest element to the right of index 2 is index 4 (6).
- index 3 --> the greatest element to the right of index 3 is index 4 (6).
- index 4 --> the greatest element to the right of index 4 is index 5 (1).
- index 5 --> there are no elements to the right of index 5, so we put -1*/
        public int[] ReplaceElements(int[] arr)
        {
            int n = arr.Length;
            int max = -1;

            for (int i = n - 1; i >= 0; i--)
            {
                int curr = arr[i];
                arr[i] = max;
                if (curr > max)
                {
                    max = curr;
                }
            }

            return arr;
        }

        /*We are given a list nums of integers representing a list compressed with run-length encoding.

Consider each adjacent pair of elements [freq, val] = [nums[2*i], nums[2*i+1]] (with i >= 0).  For each such pair, there are freq elements with value val concatenated in a sublist. Concatenate all the sublists from left to right to generate the decompressed list.

Return the decompressed list.

 

Example 1:

Input: nums = [1,2,3,4]
Output: [2,4,4,4]
Explanation: The first pair [1,2] means we have freq = 1 and val = 2 so we generate the array [2].
The second pair [3,4] means we have freq = 3 and val = 4 so we generate [4,4,4].
At the end the concatenation [2] + [4,4,4] is [2,4,4,4].
Example 2:

Input: nums = [1,1,2,3]
Output: [1,3,3]
 */
        public int[] DecompressRLElist(int[] nums)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Length; i += 2)
            {
                int freq = nums[i];
                int val = nums[i + 1];

                for (int j = 0; j < freq; j++)
                {
                    result.Add(val);
                }
            }

            return result.ToArray();
        }

        /*Given an array of integers arr, replace each element with its rank.

The rank represents how large the element is. The rank has the following rules:

Rank is an integer starting from 1.
The larger the element, the larger the rank. If two elements are equal, their rank must be the same.
Rank should be as small as possible.
 

Example 1:

Input: arr = [40,10,20,30]
Output: [4,1,2,3]
Explanation: 40 is the largest element. 10 is the smallest. 20 is the second smallest. 30 is the third smallest.
Example 2:

Input: arr = [100,100,100]
Output: [1,1,1]
Explanation: Same elements share the same rank.
Example 3:

Input: arr = [37,12,28,9,100,56,80,5,12]
Output: [5,3,4,2,8,6,7,1,3]
 */
        public int[] ArrayRankTransform(int[] arr)
        {
            int[] sortedArr = (int[])arr.Clone();
            Array.Sort(sortedArr);

            Dictionary<int, int> rankMap = new Dictionary<int, int>();
            int rank = 1;

            foreach (int num in sortedArr)
            {
                if (!rankMap.ContainsKey(num))
                {
                    rankMap[num] = rank;
                    rank++;
                }
            }

            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = rankMap[arr[i]];
            }

            return result;
        }

        /*Given a string date representing a Gregorian calendar date formatted as YYYY-MM-DD, return the day number of the year.

 

Example 1:

Input: date = "2019-01-09"
Output: 9
Explanation: Given date is the 9th day of the year in 2019.
Example 2:

Input: date = "2019-02-10"
Output: 41*/
        public int DayOfYear(string date)
        {
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] parts = date.Split('-');

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            if (IsLeapYear(year))
            {
                daysInMonth[1] = 29;
            }

            int dayOfYear = 0;
            for (int i = 0; i < month - 1; i++)
            {
                dayOfYear += daysInMonth[i];
            }
            dayOfYear += day;

            return dayOfYear;
        }
        private bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        /*There is a malfunctioning keyboard where some letter keys do not work. All other keys on the keyboard work properly.

Given a string text of words separated by a single space (no leading or trailing spaces) and a string brokenLetters of all distinct letter keys that are broken, return the number of words in text you can fully type using this keyboard.

 

Example 1:

Input: text = "hello world", brokenLetters = "ad"
Output: 1
Explanation: We cannot type "world" because the 'd' key is broken.
Example 2:

Input: text = "leet code", brokenLetters = "lt"
Output: 1
Explanation: We cannot type "leet" because the 'l' and 't' keys are broken.
Example 3:

Input: text = "leet code", brokenLetters = "e"
Output: 0
Explanation: We cannot type either word because the 'e' key is broken.*/
        public int CanBeTypedWords(string text, string brokenLetters)
        {
            string[] words = text.Split(' ');
            int count = 0;
            bool[] broken = new bool[26];

            foreach (char ch in brokenLetters)
            {
                broken[ch - 'a'] = true;
            }

            foreach (string word in words)
            {
                bool canType = true;
                foreach (char ch in word)
                {
                    if (broken[ch - 'a'])
                    {
                        canType = false;
                        break;
                    }
                }
                if (canType)
                {
                    count++;
                }
            }

            return count;
        }

        /*Write a program to count the number of days between two dates.

The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.

 

Example 1:

Input: date1 = "2019-06-29", date2 = "2019-06-30"
Output: 1
Example 2:

Input: date1 = "2020-01-15", date2 = "2019-12-31"
Output: 15*/
        public int DaysBetweenDates(string date1, string date2)
        {
            DateTime d1 = DateTime.Parse(date1);
            DateTime d2 = DateTime.Parse(date2);

            TimeSpan difference = d1.Subtract(d2);

            return Math.Abs(difference.Days);
        }

        /*Return the number of permutations of 1 to n so that prime numbers are at prime indices (1-indexed.)

(Recall that an integer is prime if and only if it is greater than 1, and cannot be written as a product of two positive integers both smaller than it.)

Since the answer may be large, return the answer modulo 10^9 + 7.

 

Example 1:

Input: n = 5
Output: 12
Explanation: For example [1,2,5,4,3] is a valid permutation, but [5,2,3,4,1] is not because the prime number 5 is at index 1.
Example 2:

Input: n = 100
Output: 682289015*/
        private const int MOD = 1000000007;
        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2 || num == 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;
            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0) return false;
            }
            return true;
        }
        public int NumPrimeArrangements(int n)
        {
            int primeCount = 0;

            for (int i = 1; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    primeCount++;
                }
            }

            int nonPrimeCount = n - primeCount;

            long result = 1;
            for (int i = 2; i <= primeCount; i++)
            {
                result = (result * i) % MOD;
            }
            for (int i = 2; i <= nonPrimeCount; i++)
            {
                result = (result * i) % MOD;
            }

            return (int)result;
        }

        /*Având în vedere o matrice de întregi sortate în ordine nedescrescătoare, există exact un număr întreg în matrice care apare mai mult de 25% din timp, returnează acel număr întreg.

 

Exemplul 1:

Intrare: arr = [1,2,2,6,6,6,6,7,10]
 Ieșire: 6
Exemplul 2:

Intrare: arr = [1,1]
 Ieșire: 1*/
        public int FindSpecialInteger(int[] arr)
        {
            int n = arr.Length;
            int threshold = n / 4;

            for (int i = 0; i < n; i++)
            {
                if (i + threshold < n && arr[i] == arr[i + threshold])
                {
                    return arr[i];
                }
            }

            return arr[0];
        }

        /*Given a date string in the form Day Month Year, where:

Day is in the set {"1st", "2nd", "3rd", "4th", ..., "30th", "31st"}.
Month is in the set {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}.
Year is in the range [1900, 2100].
Convert the date string to the format YYYY-MM-DD, where:

YYYY denotes the 4 digit year.
MM denotes the 2 digit month.
DD denotes the 2 digit day.
 */
        public string ReformatDate(string date)
        {
            string[] days = {
              "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th",
               "11th", "12th", "13th", "14th", "15th", "16th", "17th", "18th", "19th", "20th",
               "21st", "22nd", "23rd", "24th", "25th", "26th", "27th", "28th", "29th", "30th", "31st"
          };

            string[] month = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            int[] years = [1900, 2100];

            string[] prop = date.Split(' ');


            string final = prop[2] + "-";

            if ((Array.IndexOf(month, prop[1]) + 1) < 10)
            {
                final += "0" + (Array.IndexOf(month, prop[1]) + 1);
            }
            else
            {
                final +=(Array.IndexOf(month, prop[1]) + 1);
            }

            if((Array.IndexOf(days, prop[0]) + 1) < 10)
            {
                final += "-" + "0" + (Array.IndexOf(days, prop[0]) + 1);
            }
            else
            {
                final += "-" + (Array.IndexOf(days, prop[0]) + 1);

            }

            return final;
        }






    }
}
