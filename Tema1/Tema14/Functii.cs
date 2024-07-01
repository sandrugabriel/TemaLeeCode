using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema14
{
    public class Functii
    {

        /*Given two strings s and goal, return true if and only if s can become goal after some number of shifts on s.

A shift on s consists of moving the leftmost character of s to the rightmost position.

For example, if s = "abcde", then it will be "bcdea" after one shift.
 

Example 1:

Input: s = "abcde", goal = "cdeab"
Output: true
Example 2:

Input: s = "abcde", goal = "abced"
Output: false*/
        public bool RotateString(string s, string goal)
        {
            int dim = s.Length;
            int ct = dim;
            while (ct != 0)
            {
                char[] aux = s.ToCharArray();
                char first = aux[0];
                char last = aux[dim-1];

                aux[0] = last;
                aux[dim-1] = first;

                s = aux.ToString();
                if (s.Equals(goal)) return true;

                ct--;
            }

            return false;
        }

        /*You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.

You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.

Return an array result of length 2 where:

result[0] is the total number of lines.
result[1] is the width of the last line in pixels.
 

Example 1:

Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
Output: [3,60]
Explanation: You can write s as follows:
abcdefghij  // 100 pixels wide
klmnopqrst  // 100 pixels wide
uvwxyz      // 60 pixels wide
There are a total of 3 lines, and the last line is 60 pixels wide.
Example 2:

Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "bbbcccdddaaa"
Output: [2,4]
Explanation: You can write s as follows:
bbbcccdddaa  // 98 pixels wide
a            // 4 pixels wide
There are a total of 2 lines, and the last line is 4 pixels wide.*/
        public int[] NumberOfLines(int[] widths, string s)
        {
            int maxW = 100;
            int curW = 0;
            int ln = 1;

            foreach (char c in s)
            {
                int width = widths[c - 'a'];
                if (curW + width > maxW)
                {
                    ln++;
                    curW = width;
                }
                else
                {
                    curW += width;
                }
            }

            return new int[] { ln, curW };
        }

        /*Given an array of points on the X-Y plane points where points[i] = [xi, yi], return the area of the largest triangle that can be formed by any three different points. Answers within 10-5 of the actual answer will be accepted.

 

Example 1:


Input: points = [[0,0],[0,1],[1,0],[0,2],[2,0]]
Output: 2.00000
Explanation: The five points are shown in the above figure. The red triangle is the largest.
Example 2:

Input: points = [[1,0],[0,0],[0,1]]
Output: 0.50000*/
        public double LargestTriangleArea(int[][] points)
        {
            int n = points.Length;
            double maxArea = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        maxArea = Math.Max(maxArea, CalculateArea(points[i], points[j], points[k]));
                    }
                }
            }

            return maxArea;
        }
        private double CalculateArea(int[] p1, int[] p2, int[] p3)
        {
            return 0.5 * Math.Abs(
                p1[0] * (p2[1] - p3[1]) +
                p2[0] * (p3[1] - p1[1]) +
                p3[0] * (p1[1] - p2[1])
            );
        }

        /*Given a string s and a character c that occurs in s, return an array of integers answer where answer.length == s.length and answer[i] is the distance from index i to the closest occurrence of character c in s.

The distance between two indices i and j is abs(i - j), where abs is the absolute value function.

 

Example 1:

Input: s = "loveleetcode", c = "e"
Output: [3,2,1,0,1,0,0,1,2,2,1,0]
Explanation: The character 'e' appears at indices 3, 5, 6, and 11 (0-indexed).
The closest occurrence of 'e' for index 0 is at index 3, so the distance is abs(0 - 3) = 3.
The closest occurrence of 'e' for index 1 is at index 3, so the distance is abs(1 - 3) = 2.
For index 4, there is a tie between the 'e' at index 3 and the 'e' at index 5, but the distance is still the same: abs(4 - 3) == abs(4 - 5) = 1.
The closest occurrence of 'e' for index 8 is at index 6, so the distance is abs(8 - 6) = 2.
Example 2:

Input: s = "aaab", c = "b"
Output: [3,2,1,0]
 */
        public int[] ShortestToChar(string s, char c)
        {
            int n = s.Length;
            int[] answer = new int[n];

            int prev = -n;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == c)
                {
                    prev = i;
                }
                answer[i] = i - prev;
            }

            prev = 2 * n;
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == c)
                {
                    prev = i;
                }
                answer[i] = Math.Min(answer[i], prev - i);
            }

            return answer;
        }

        /*You are given a string sentence that consist of words separated by spaces. Each word consists of lowercase and uppercase letters only.

We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.) The rules of Goat Latin are as follows:

If a word begins with a vowel ('a', 'e', 'i', 'o', or 'u'), append "ma" to the end of the word.
For example, the word "apple" becomes "applema".
If a word begins with a consonant (i.e., not a vowel), remove the first letter and append it to the end, then add "ma".
For example, the word "goat" becomes "oatgma".
Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
For example, the first word gets "a" added to the end, the second word gets "aa" added to the end, and so on.
Return the final sentence representing the conversion from sentence to Goat Latin.

 

Example 1:

Input: sentence = "I speak Goat Latin"
Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"
Example 2:

Input: sentence = "The quick brown fox jumped over the lazy dog"
Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"
 */
        public string ToGoatLatin(string sentence)
        {
            string[] words = sentence.Split(' ');
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            List<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (IsVowel(word[0], vowels))
                {
                    word += "ma";
                }
                else
                {
                    word = word.Substring(1) + word[0] + "ma";
                }

                word += new string('a', i + 1);

                result.Add(word);
            }

            return string.Join(' ', result);
        }
        private bool IsVowel(char c, char[] vowels)
        {
            foreach (char vowel in vowels)
            {
                if (c == vowel)
                {
                    return true;
                }
            }
            return false;
        }

        /*In a string s of lowercase letters, these letters form consecutive groups of the same character.

For example, a string like s = "abbxxxxzyy" has the groups "a", "bb", "xxxx", "z", and "yy".

A group is identified by an interval [start, end], where start and end denote the start and end indices (inclusive) of the group. In the above example, "xxxx" has the interval [3,6].

A group is considered large if it has 3 or more characters.

Return the intervals of every large group sorted in increasing order by start index.

 

Example 1:

Input: s = "abbxxxxzzy"
Output: [[3,6]]
Explanation: "xxxx" is the only large group with start index 3 and end index 6.
Example 2:

Input: s = "abc"
Output: []
Explanation: We have groups "a", "b", and "c", none of which are large groups.
Example 3:

Input: s = "abcdddeeeeaabbbcd"
Output: [[3,5],[6,9],[12,14]]
Explanation: The large groups are "ddd", "eeee", and "bbb".*/
        public IList<IList<int>> LargeGroupPositions(string s)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int n = s.Length;

            int start = 0;
            for (int end = 1; end < n; end++)
            {
                if (s[end] != s[end - 1])
                {
                    if (end - start >= 3)
                    {
                        result.Add(new List<int> { start, end - 1 });
                    }
                    start = end;
                }
            }

            if (n - start >= 3)
            {
                result.Add(new List<int> { start, n - 1 });
            }

            return result;
        }

        /*Given an n x n binary matrix image, flip the image horizontally, then invert it, and return the resulting image.

To flip an image horizontally means that each row of the image is reversed.

For example, flipping [1,1,0] horizontally results in [0,1,1].
To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0.

For example, inverting [0,1,1] results in [1,0,0].
 

Example 1:

Input: image = [[1,1,0],[1,0,1],[0,0,0]]
Output: [[1,0,0],[0,1,0],[1,1,1]]
Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].
Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]
Example 2:

Input: image = [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
Explanation: First reverse each row: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].
Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
 */
        public int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(image[i]);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    image[i][j] = image[i][j] == 0 ? 1 : 0;
                }
            }

            return image;
        }

        /*An axis-aligned rectangle is represented as a list [x1, y1, x2, y2], where (x1, y1) is the coordinate of its bottom-left corner, and (x2, y2) is the coordinate of its top-right corner. Its top and bottom edges are parallel to the X-axis, and its left and right edges are parallel to the Y-axis.

Two rectangles overlap if the area of their intersection is positive. To be clear, two rectangles that only touch at the corner or edges do not overlap.

Given two axis-aligned rectangles rec1 and rec2, return true if they overlap, otherwise return false.

 

Example 1:

Input: rec1 = [0,0,2,2], rec2 = [1,1,3,3]
Output: true
Example 2:

Input: rec1 = [0,0,1,1], rec2 = [1,0,2,1]
Output: false
Example 3:

Input: rec1 = [0,0,1,1], rec2 = [2,2,3,3]
Output: false
 */
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            int x1 = rec1[0], y1 = rec1[1], x2 = rec1[2], y2 = rec1[3];

            int a1 = rec2[0], b1 = rec2[1], a2 = rec2[2], b2 = rec2[3];

            if (x2 <= a1 || a2 <= x1 || y2 <= b1 || b2 <= y1)
            {
                return false;
            }

            return true;
        }

        /*Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

Note that after backspacing an empty text, the text will continue empty.

 

Example 1:

Input: s = "ab#c", t = "ad#c"
Output: true
Explanation: Both s and t become "ac".
Example 2:

Input: s = "ab##", t = "c#d#"
Output: true
Explanation: Both s and t become "".
Example 3:

Input: s = "a#c", t = "b"
Output: false
Explanation: s becomes "c" while t becomes "b".
 */
        public bool BackspaceCompare(string s, string t)
        {
            return ProcessString(s) == ProcessString(t);
        }
        private string ProcessString(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if (c != '#')
                {
                    stack.Push(c);
                }
                else if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            return new string(stack.ToArray());
        }

        /*Given two strings s and goal, return true if you can swap two letters in s so the result is equal to goal, otherwise, return false.

Swapping letters is defined as taking two indices i and j (0-indexed) such that i != j and swapping the characters at s[i] and s[j].

For example, swapping at indices 0 and 2 in "abcd" results in "cbad".
 

Example 1:

Input: s = "ab", goal = "ba"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'b' to get "ba", which is equal to goal.
Example 2:

Input: s = "ab", goal = "ab"
Output: false
Explanation: The only letters you can swap are s[0] = 'a' and s[1] = 'b', which results in "ba" != goal.
Example 3:

Input: s = "aa", goal = "aa"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'a' to get "aa", which is equal to goal.*/
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length) return false;

            if (s.Equals(goal))
            {
                int[] count = new int[26];
                foreach (char c in s)
                {
                    count[c - 'a']++;
                    if (count[c - 'a'] > 1)
                    {
                        return true;
                    }
                }
                return false;
            }

            List<int> mismatchPositions = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    mismatchPositions.Add(i);
                }
            }

            if (mismatchPositions.Count != 2)
            {
                return false;
            }

            int pos1 = mismatchPositions[0];
            int pos2 = mismatchPositions[1];
            return s[pos1] == goal[pos2] && s[pos2] == goal[pos1];
        }

    }
}
