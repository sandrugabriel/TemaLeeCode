using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema20
{
    public class Solutii
    {

        Functii functii = new Functii();

        /*Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated to be equal to another domino.

Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].



Example 1:

Input: dominoes = [[1,2],[2,1],[3,4],[5,6]]
Output: 1
Example 2:

Input: dominoes = [[1,2],[1,2],[1,1],[1,2],[2,2]]
Output: 3*/
        public void solutia1()
        {

            int[][] dominoes1 = new int[][] {
            new int[] {1, 2},
            new int[] {2, 1},
            new int[] {3, 4},
            new int[] {5, 6}
        };

            int result1 = functii.NumEquivDominoPairs(dominoes1);
            Console.WriteLine(result1);
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
        public void solutia2()
        {

            int[] arr1 = { 17, 18, 5, 4, 6, 1 };
            int[] res1 = functii.ReplaceElements(arr1);
            Console.WriteLine(string.Join(",", res1));
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
        public void solutia3()
        {

            int[] nums1 = { 1, 2, 3, 4 };
            int[] res1 = functii.DecompressRLElist(nums1);
            Console.WriteLine(string.Join(",", res1));
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
        public void solutia4()
        {

            int[] arr1 = { 40, 10, 20, 30 };
            int[] res1 = functii.ArrayRankTransform(arr1);
            Console.WriteLine(string.Join(",", res1));
        }

        /*Given a string date representing a Gregorian calendar date formatted as YYYY-MM-DD, return the day number of the year.



Example 1:

Input: date = "2019-01-09"
Output: 9
Explanation: Given date is the 9th day of the year in 2019.
Example 2:

Input: date = "2019-02-10"
Output: 41*/
        public void solutia5()
        {

            string date1 = "2019-01-09";
            int result1 = functii.DayOfYear(date1);
            Console.WriteLine( result1);
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
        public void solutia6()
        {
            string text1 = "hello world";
            string brokenLetters1 = "ad";
            Console.WriteLine(functii.CanBeTypedWords(text1, brokenLetters1));
        }

        /*Write a program to count the number of days between two dates.

The two dates are given as strings, their format is YYYY-MM-DD as shown in the examples.



Example 1:

Input: date1 = "2019-06-29", date2 = "2019-06-30"
Output: 1
Example 2:

Input: date1 = "2020-01-15", date2 = "2019-12-31"
Output: 15*/
        public void solutia7()
        {

            string date1a = "2019-06-29";
            string date2a = "2019-06-30";
            Console.WriteLine( functii.DaysBetweenDates(date1a, date2a));
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
        public void solutia8()
        {

            int n1 = 5;
            Console.WriteLine(functii.NumPrimeArrangements(n1));
        }

        /*Având în vedere o matrice de întregi sortate în ordine nedescrescătoare, există exact un număr întreg în matrice care apare mai mult de 25% din timp, returnează acel număr întreg.



Exemplul 1:

Intrare: arr = [1,2,2,6,6,6,6,7,10]
Ieșire: 6
Exemplul 2:

Intrare: arr = [1,1]
Ieșire: 1*/
        public void solutia9()
        {
            int[] arr = [1, 2, 2, 6, 6, 6, 6, 7, 10];
            Console.WriteLine(functii.FindSpecialInteger(arr));
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
        public void solutia10()
        {
            string date = "20th Oct 2052";

            Console.WriteLine(functii.ReformatDate(date));
        }



    }
}
