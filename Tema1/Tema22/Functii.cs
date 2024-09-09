using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema22
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Functii
    {

        /*You are given a 0-indexed string array words, where words[i] consists of lowercase English letters.

In one operation, select any index i such that 0 < i < words.length and words[i - 1] and words[i] are anagrams, and delete words[i] from words. Keep performing this operation as long as you can select an index that satisfies the conditions.

Return words after performing all operations. It can be shown that selecting the indices for each operation in any arbitrary order will lead to the same result.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase using all the original letters exactly once. For example, "dacb" is an anagram of "abdc".

 

Example 1:

Input: words = ["abba","baba","bbaa","cd","cd"]
Output: ["abba","cd"]
Explanation:
One of the ways we can obtain the resultant array is by using the following operations:
- Since words[2] = "bbaa" and words[1] = "baba" are anagrams, we choose index 2 and delete words[2].
  Now words = ["abba","baba","cd","cd"].
- Since words[1] = "baba" and words[0] = "abba" are anagrams, we choose index 1 and delete words[1].
  Now words = ["abba","cd","cd"].
- Since words[2] = "cd" and words[1] = "cd" are anagrams, we choose index 2 and delete words[2].
  Now words = ["abba","cd"].
We can no longer perform any operations, so ["abba","cd"] is the final answer.
Example 2:

Input: words = ["a","b","c","d","e"]
Output: ["a","b","c","d","e"]
Explanation:
No two adjacent strings in words are anagrams of each other, so no operations are performed.*/
        public IList<string> RemoveAnagrams(string[] words)
        {
            List<string> result = new List<string>(words);
            int i = 1;

            while (i < result.Count)
            {
                if (AreAnagrams(result[i], result[i - 1]))
                {
                    result.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            return result;
        }
        private bool AreAnagrams(string word1, string word2)
        {
            return String.Concat(word1.OrderBy(c => c)) == String.Concat(word2.OrderBy(c => c));
        }

        /*Given a string of English letters s, return the greatest English letter which occurs as both a lowercase and uppercase letter in s. The returned letter should be in uppercase. If no such letter exists, return an empty string.

An English letter b is greater than another letter a if b appears after a in the English alphabet.

 

Example 1:

Input: s = "lEeTcOdE"
Output: "E"
Explanation:
The letter 'E' is the only letter to appear in both lower and upper case.
Example 2:

Input: s = "arRAzFif"
Output: "R"
Explanation:
The letter 'R' is the greatest letter to appear in both lower and upper case.
Note that 'A' and 'F' also appear in both lower and upper case, but 'R' is greater than 'F' or 'A'.
Example 3:

Input: s = "AbCdEfGhIjK"
Output: ""
Explanation:
There is no letter that appears in both lower and upper case.*/
        public string GreatestLetter(string s)
        {
            HashSet<char> lowerSet = new HashSet<char>();
            HashSet<char> upperSet = new HashSet<char>();

            foreach (char c in s)
            {
                if (char.IsLower(c))
                    lowerSet.Add(c);
                if (char.IsUpper(c))
                    upperSet.Add(c);
            }

            char greatestLetter = '\0';

            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (upperSet.Contains(c) && lowerSet.Contains(char.ToLower(c)))
                {
                    if (greatestLetter == '\0' || c > greatestLetter)
                    {
                        greatestLetter = c;
                    }
                }
            }

            return greatestLetter == '\0' ? "" : greatestLetter.ToString();
        }

        /*There is an m x n matrix that is initialized to all 0's. There is also a 2D array indices where each indices[i] = [ri, ci] represents a 0-indexed location to perform some increment operations on the matrix.

For each location indices[i], do both of the following:

Increment all the cells on row ri.
Increment all the cells on column ci.
Given m, n, and indices, return the number of odd-valued cells in the matrix after applying the increment to all locations in indices.

 

Example 1:


Input: m = 2, n = 3, indices = [[0,1],[1,1]]
Output: 6
Explanation: Initial matrix = [[0,0,0],[0,0,0]].
After applying first increment it becomes [[1,2,1],[0,1,0]].
The final matrix is [[1,3,1],[1,3,1]], which contains 6 odd numbers.
Example 2:


Input: m = 2, n = 2, indices = [[1,1],[0,0]]
Output: 0
Explanation: Final matrix = [[2,2],[2,2]]. There are no odd numbers in the final matrix.*/
        public int OddCells(int m, int n, int[][] indices)
        {
            int[] rowIncrements = new int[m];
            int[] colIncrements = new int[n];

            foreach (var index in indices)
            {
                int ri = index[0];
                int ci = index[1];

                rowIncrements[ri]++;
                colIncrements[ci]++;
            }

            int oddCount = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((rowIncrements[i] + colIncrements[j]) % 2 != 0)
                    {
                        oddCount++;
                    }
                }
            }

            return oddCount;
        }

        /*You are given a 0-indexed 2D integer array brackets where brackets[i] = [upperi, percenti] means that the ith tax bracket has an upper bound of upperi and is taxed at a rate of percenti. The brackets are sorted by upper bound (i.e. upperi-1 < upperi for 0 < i < brackets.length).

Tax is calculated as follows:

The first upper0 dollars earned are taxed at a rate of percent0.
The next upper1 - upper0 dollars earned are taxed at a rate of percent1.
The next upper2 - upper1 dollars earned are taxed at a rate of percent2.
And so on.
You are given an integer income representing the amount of money you earned. Return the amount of money that you have to pay in taxes. Answers within 10-5 of the actual answer will be accepted.

 

Example 1:

Input: brackets = [[3,50],[7,10],[12,25]], income = 10
Output: 2.65000
Explanation:
Based on your income, you have 3 dollars in the 1st tax bracket, 4 dollars in the 2nd tax bracket, and 3 dollars in the 3rd tax bracket.
The tax rate for the three tax brackets is 50%, 10%, and 25%, respectively.
In total, you pay $3 * 50% + $4 * 10% + $3 * 25% = $2.65 in taxes.
Example 2:

Input: brackets = [[1,0],[4,25],[5,50]], income = 2
Output: 0.25000
Explanation:
Based on your income, you have 1 dollar in the 1st tax bracket and 1 dollar in the 2nd tax bracket.
The tax rate for the two tax brackets is 0% and 25%, respectively.
In total, you pay $1 * 0% + $1 * 25% = $0.25 in taxes.
Example 3:

Input: brackets = [[2,50]], income = 0
Output: 0.00000
Explanation:
You have no income to tax, so you have to pay a total of $0 in taxes.*/
        public double CalculateTax(int[][] brackets, int income)
        {
            double totalTax = 0;
            int previousUpper = 0;

            foreach (var bracket in brackets)
            {
                int upper = bracket[0];
                int percent = bracket[1];

                int taxableIncome = Math.Min(income, upper) - previousUpper;

                if (taxableIncome <= 0)
                    break;

                totalTax += taxableIncome * (percent / 100.0);

                previousUpper = upper;

                if (income <= upper)
                    break;
            }

            return totalTax;
        }

        /*Given a 2D grid of size m x n and an integer k. You need to shift the grid k times.

In one shift operation:

Element at grid[i][j] moves to grid[i][j + 1].
Element at grid[i][n - 1] moves to grid[i + 1][0].
Element at grid[m - 1][n - 1] moves to grid[0][0].
Return the 2D grid after applying shift operation k times.

 

Example 1:


Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 1
Output: [[9,1,2],[3,4,5],[6,7,8]]
Example 2:


Input: grid = [[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]], k = 4
Output: [[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]
Example 3:

Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 9
Output: [[1,2,3],[4,5,6],[7,8,9]]
 */
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int total = m * n;

            k = k % total;

            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int oldPos = i * n + j;
                    int newPos = (oldPos + k) % total;

                    int newRow = newPos / n;
                    int newCol = newPos % n;

                    result[newRow][newCol] = grid[i][j];
                }
            }

            IList<IList<int>> shiftedGrid = new List<IList<int>>();
            foreach (var row in result)
            {
                shiftedGrid.Add(new List<int>(row));
            }

            return shiftedGrid;
        }

        /*Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:

answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
Note that the integers in the lists may be returned in any order.



Example 1:

Input: nums1 = [1,2,3], nums2 = [2,4,6]
Output: [[1,3],[4,6]]
Explanation:
For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1 and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4 and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].
Example 2:

Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
Output: [[3],[]]
Explanation:
For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] == nums1[3], their value is only included once and answer[0] = [3].
Every integer in nums2 is present in nums1. Therefore, answer[1] = [].*/
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);

            List<int> distinctInNums1 = new List<int>();
            foreach (int num in set1)
            {
                if (!set2.Contains(num))
                {
                    distinctInNums1.Add(num);
                }
            }

            List<int> distinctInNums2 = new List<int>();
            foreach (int num in set2)
            {
                if (!set1.Contains(num))
                {
                    distinctInNums2.Add(num);
                }
            }

            return new List<IList<int>> { distinctInNums1, distinctInNums2 };
        }

        /*On a 2D plane, there are n points with integer coordinates points[i] = [xi, yi]. Return the minimum time in seconds to visit all the points in the order given by points.

You can move according to these rules:

In 1 second, you can either:
move vertically by one unit,
move horizontally by one unit, or
move diagonally sqrt(2) units (in other words, move one unit vertically then one unit horizontally in 1 second).
You have to visit the points in the same order as they appear in the array.
You are allowed to pass through points that appear later in the order, but these do not count as visits.
 

Example 1:


Input: points = [[1,1],[3,4],[-1,0]]
Output: 7
Explanation: One optimal path is [1,1] -> [2,2] -> [3,3] -> [3,4] -> [2,3] -> [1,2] -> [0,1] -> [-1,0]   
Time from [1,1] to [3,4] = 3 seconds 
Time from [3,4] to [-1,0] = 4 seconds
Total time = 7 seconds
Example 2:

Input: points = [[3,2],[-2,2]]
Output: 5*/
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int totalTime = 0;

            for (int i = 1; i < points.Length; i++)
            {
                int x1 = points[i - 1][0], y1 = points[i - 1][1];
                int x2 = points[i][0], y2 = points[i][1];

                int horizontalDist = Math.Abs(x2 - x1);
                int verticalDist = Math.Abs(y2 - y1);

                totalTime += Math.Max(horizontalDist, verticalDist);
            }

            return totalTime;
        }

        /*Tic-tac-toe is played by two players A and B on a 3 x 3 grid. The rules of Tic-Tac-Toe are:

Players take turns placing characters into empty squares ' '.
The first player A always places 'X' characters, while the second player B always places 'O' characters.
'X' and 'O' characters are always placed into empty squares, never on filled ones.
The game ends when there are three of the same (non-empty) character filling any row, column, or diagonal.
The game also ends if all squares are non-empty.
No more moves can be played if the game is over.
Given a 2D integer array moves where moves[i] = [rowi, coli] indicates that the ith move will be played on grid[rowi][coli]. return the winner of the game if it exists (A or B). In case the game ends in a draw return "Draw". If there are still movements to play return "Pending".

You can assume that moves is valid (i.e., it follows the rules of Tic-Tac-Toe), the grid is initially empty, and A will play first.

 

Example 1:


Input: moves = [[0,0],[2,0],[1,1],[2,1],[2,2]]
Output: "A"
Explanation: A wins, they always play first.
Example 2:


Input: moves = [[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
Output: "B"
Explanation: B wins.
Example 3:


Input: moves = [[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
Output: "Draw"
Explanation: The game ends in a draw since there are no moves to make.
 */
        public string Tictactoe(int[][] moves)
        {
            char[,] grid = new char[3, 3];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    grid[i, j] = ' ';

            for (int i = 0; i < moves.Length; i++)
            {
                int row = moves[i][0];
                int col = moves[i][1];

                if (i % 2 == 0)
                    grid[row, col] = 'X';
                else
                    grid[row, col] = 'O';
            }

            if (CheckWinner(grid, 'X'))
                return "A";
            if (CheckWinner(grid, 'O'))
                return "B";

            if (moves.Length == 9)
                return "Draw";
            else
                return "Pending";
        }
        private bool CheckWinner(char[,] grid, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (grid[i, 0] == player && grid[i, 1] == player && grid[i, 2] == player)
                    return true;

                if (grid[0, i] == player && grid[1, i] == player && grid[2, i] == player)
                    return true;
            }

            if (grid[0, 0] == player && grid[1, 1] == player && grid[2, 2] == player)
                return true;

            if (grid[0, 2] == player && grid[1, 1] == player && grid[2, 0] == player)
                return true;

            return false;
        }

        /*Given an integer number n, return the difference between the product of its digits and the sum of its digits.
 

Example 1:

Input: n = 234
Output: 15 
Explanation: 
Product of digits = 2 * 3 * 4 = 24 
Sum of digits = 2 + 3 + 4 = 9 
Result = 24 - 9 = 15
Example 2:

Input: n = 4421
Output: 21
Explanation: 
Product of digits = 4 * 4 * 2 * 1 = 32 
Sum of digits = 4 + 4 + 2 + 1 = 11 
Result = 32 - 11 = 21
 */
        public int SubtractProductAndSum(int n)
        {
            int product = 1;
            int sum = 0;

            while (n > 0)
            {
                int digit = n % 10;
                product *= digit;
                sum += digit;
                n /= 10;
            }

            return product - sum;
        }

        /*Given head which is a reference node to a singly-linked list. The value of each node in the linked list is either 0 or 1. The linked list holds the binary representation of a number.

Return the decimal value of the number in the linked list.

The most significant bit is at the head of the linked list.

 

Example 1:


Input: head = [1,0,1]
Output: 5
Explanation: (101) in base 2 = (5) in base 10
Example 2:

Input: head = [0]
Output: 0*/
        public int GetDecimalValue(ListNode head)
        {
            int result = 0;

            while (head != null)
            {
                result = result * 2 + head.val;

                head = head.next;
            }

            return result;
        }

    }
}
