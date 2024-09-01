using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema21
{
    public class Functii
    {

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

        /*A bus has n stops numbered from 0 to n - 1 that form a circle. We know the distance between all pairs of neighboring stops where distance[i] is the distance between the stops number i and (i + 1) % n.

The bus goes along both directions i.e. clockwise and counterclockwise.

Return the shortest distance between the given start and destination stops.



Example 1:



Input: distance = [1,2,3,4], start = 0, destination = 1
Output: 1
Explanation: Distance between 0 and 1 is 1 or 9, minimum is 1.


Example 2:



Input: distance = [1,2,3,4], start = 0, destination = 2
Output: 3
Explanation: Distance between 0 and 2 is 3 or 7, minimum is 3.


Example 3:



Input: distance = [1,2,3,4], start = 0, destination = 3
Output: 4
Explanation: Distance between 0 and 3 is 6 or 4, minimum is 4.
*/
        public int DistanceBetweenBusStops(int[] dist, int start, int dest)
        {
            if (start > dest)
            {
                int temp = start;
                start = dest;
                dest = temp;
            }

            int distClockwise = 0;
            for (int i = start; i < dest; i++)
            {
                distClockwise += dist[i];
            }

            int distCounterClockwise = 0;
            for (int i = dest; i < dist.Length; i++)
            {
                distCounterClockwise += dist[i];
            }
            for (int i = 0; i < start; i++)
            {
                distCounterClockwise += dist[i];
            }

            return Math.Min(distClockwise, distCounterClockwise);
        }

        /*Given a date, return the corresponding day of the week for that date.

The input is given as three integers representing the day, month and year respectively.

Return the answer as one of the following values {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}.

 

Example 1:

Input: day = 31, month = 8, year = 2019
Output: "Saturday"
Example 2:

Input: day = 18, month = 7, year = 1999
Output: "Sunday"
Example 3:

Input: day = 15, month = 8, year = 1993
Output: "Sunday"*/
        public string DayOfTheWeek(int zi, int luna, int an)
        {
            if (luna < 3)
            {
                luna += 12;
                an--;
            }

            int k = an % 100;
            int j = an / 100;

            int f = zi + 13 * (luna + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            int ziSaptamana = f % 7;

            string[] zile = { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            return zile[ziSaptamana];
        }

        /*Given an integer array arr, return true if there are three consecutive odd numbers in the array. Otherwise, return false.
 

Example 1:

Input: arr = [2,6,4,1]
Output: false
Explanation: There are no three consecutive odds.
Example 2:

Input: arr = [1,2,34,3,4,5,7,23,12]
Output: true
Explanation: [5,7,23] are three consecutive odds.*/
        public bool HasThreeConsecutiveOdds(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count++;
                    if (count == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        /*Given a string text, you want to use the characters of text to form as many instances of the word "balloon" as possible.

You can use each character in text at most once. Return the maximum number of instances that can be formed.

 

Example 1:



Input: text = "nlaebolko"
Output: 1
Example 2:



Input: text = "loonbalxballpoon"
Output: 2
Example 3:

Input: text = "leetcode"
Output: 0*/
        public int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>
        {
            {'b', 0},
            {'a', 0},
            {'l', 0},
            {'o', 0},
            {'n', 0}
        };

            foreach (char c in text)
            {
                if (freq.ContainsKey(c))
                {
                    freq[c]++;
                }
            }

            freq['l'] /= 2;
            freq['o'] /= 2;

            int min = int.MaxValue;
            foreach (var count in freq.Values)
            {
                if (count < min)
                {
                    min = count;
                }
            }

            return min;
        }

        /*A fancy string is a string where no three consecutive characters are equal.

Given a string s, delete the minimum possible number of characters from s to make it fancy.

Return the final string after the deletion. It can be shown that the answer will always be unique.

 

Example 1:

Input: s = "leeetcode"
Output: "leetcode"
Explanation:
Remove an 'e' from the first group of 'e's to create "leetcode".
No three consecutive characters are equal, so return "leetcode".
Example 2:

Input: s = "aaabaaaa"
Output: "aabaa"
Explanation:
Remove an 'a' from the first group of 'a's to create "aabaaaa".
Remove two 'a's from the second group of 'a's to create "aabaa".
No three consecutive characters are equal, so return "aabaa".
Example 3:

Input: s = "aab"
Output: "aab"
Explanation: No three consecutive characters are equal, so return "aab".*/
        public string MakeFancyString(string s)
        {
            char[] result = new char[s.Length];
            int j = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (j < 2 || s[i] != result[j - 1] || s[i] != result[j - 2])
                {
                    result[j] = s[i];
                    j++;
                }
            }

            return new string(result, 0, j);
        }

        /*Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any two elements.

Return a list of pairs in ascending order(with respect to pairs), each pair [a, b] follows

a, b are from arr
a < b
b - a equals to the minimum absolute difference of any two elements in arr
 

Example 1:

Input: arr = [4,2,1,3]
Output: [[1,2],[2,3],[3,4]]
Explanation: The minimum absolute difference is 1. List all pairs with difference equal to 1 in ascending order.
Example 2:

Input: arr = [1,3,6,10,15]
Output: [[1,3]]
Example 3:

Input: arr = [3,8,-10,23,19,-4,-14,27]
Output: [[-14,-10],[19,23],[23,27]]*/
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);

            List<IList<int>> result = new List<IList<int>>();
            int minDiff = int.MaxValue;

            for (int i = 1; i < arr.Length; i++)
            {
                int diff = arr[i] - arr[i - 1];
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result.Clear();
                }
                if (diff == minDiff)
                {
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
            }

            return result;
        }

        /*We have n chips, where the position of the ith chip is position[i].

We need to move all the chips to the same position. In one step, we can change the position of the ith chip from position[i] to:

position[i] + 2 or position[i] - 2 with cost = 0.
position[i] + 1 or position[i] - 1 with cost = 1.
Return the minimum cost needed to move all the chips to the same position.

 

Example 1:


Input: position = [1,2,3]
Output: 1
Explanation: First step: Move the chip at position 3 to position 1 with cost = 0.
Second step: Move the chip at position 2 to position 1 with cost = 1.
Total cost is 1.
Example 2:


Input: position = [2,2,2,3,3]
Output: 2
Explanation: We can move the two chips at position  3 to position 2. Each move has cost = 1. The total cost = 2.
Example 3:

Input: position = [1,1000000000]
Output: 1
 */
        public int MinCostToMoveChips(int[] position)
        {
            int evenCount = 0;
            int oddCount = 0;

            foreach (int pos in position)
            {
                if (pos % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            return Math.Min(evenCount, oddCount);
        }

        /*Balanced strings are those that have an equal quantity of 'L' and 'R' characters.

Given a balanced string s, split it into some number of substrings such that:

Each substring is balanced.
Return the maximum number of balanced strings you can obtain.

 

Example 1:

Input: s = "RLRRLLRLRL"
Output: 4
Explanation: s can be split into "RL", "RRLL", "RL", "RL", each substring contains same number of 'L' and 'R'.
Example 2:

Input: s = "RLRRRLLRLL"
Output: 2
Explanation: s can be split into "RL", "RRRLLRLL", each substring contains same number of 'L' and 'R'.
Note that s cannot be split into "RL", "RR", "RL", "LR", "LL", because the 2nd and 5th substrings are not balanced.
Example 3:

Input: s = "LLLLRRRR"
Output: 1
Explanation: s can be split into "LLLLRRRR".*/
        public int BalancedStringSplit(string s)
        {
            int count = 0;
            int balance = 0;

            foreach (char c in s)
            {
                if (c == 'L')
                {
                    balance++;
                }
                else if (c == 'R')
                {
                    balance--;
                }

                if (balance == 0)
                {
                    count++;
                }
            }

            return count;
        }

        /*You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. Check if these points make a straight line in the XY plane.

 

 

Example 1:



Input: coordinates = [[1,2],[2,3],[3,4],[4,5],[5,6],[6,7]]
Output: true
Example 2:



Input: coordinates = [[1,1],[2,2],[3,4],[4,5],[5,6],[7,7]]
Output: false
 */
        public bool CheckStraightLine(int[][] coordinates)
        {
            int x0 = coordinates[0][0], y0 = coordinates[0][1];
            int x1 = coordinates[1][0], y1 = coordinates[1][1];

            int dx = x1 - x0;
            int dy = y1 - y0;

            for (int i = 2; i < coordinates.Length; i++)
            {
                int x = coordinates[i][0], y = coordinates[i][1];

                if ((y - y1) * dx != (x - x1) * dy)
                {
                    return false;
                }
            }

            return true;
        }






























































































    }
}
