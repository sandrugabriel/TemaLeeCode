using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema18
{
    public class Solutii
    {

        Functii functii = new Functii();

        /*In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge.

If the town judge exists, then:

The town judge trusts nobody.
Everybody (except for the town judge) trusts the town judge.
There is exactly one person that satisfies properties 1 and 2.
You are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi. If a trust relationship does not exist in trust array, then such a trust relationship does not exist.

Return the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.



Example 1:

Input: n = 2, trust = [[1,2]]
Output: 2
Example 2:

Input: n = 3, trust = [[1,3],[2,3]]
Output: 3
Example 3:

Input: n = 3, trust = [[1,3],[2,3],[3,1]]
Output: -1*/
        public void solutia1()
        {
            int n = 2;
            int[][] trust = [];

            Console.WriteLine(functii.FindJudge(n,trust));

        }

        /*You are given an 8 x 8 matrix representing a chessboard. There is exactly one white rook represented by 'R', some number of white bishops 'B', and some number of black pawns 'p'. Empty squares are represented by '.'.

A rook can move any number of squares horizontally or vertically (up, down, left, right) until it reaches another piece or the edge of the board. A rook is attacking a pawn if it can move to the pawn's square in one move.

Note: A rook cannot move through other pieces, such as bishops or pawns. This means a rook cannot attack a pawn if there is another piece blocking the path.

Return the number of pawns the white rook is attacking.



Example 1:


Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","R",".",".",".","p"],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 3

Explanation:

In this example, the rook is attacking all the pawns.

Example 2:


Input: board = [[".",".",".",".",".",".","."],[".","p","p","p","p","p",".","."],[".","p","p","B","p","p",".","."],[".","p","B","R","B","p",".","."],[".","p","p","B","p","p",".","."],[".","p","p","p","p","p",".","."],[".",".",".",".",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 0

Explanation:

The bishops are blocking the rook from attacking any of the pawns.

Example 3:


Input: board = [[".",".",".",".",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".","p",".",".",".","."],["p","p",".","R",".","p","B","."],[".",".",".",".",".",".",".","."],[".",".",".","B",".",".",".","."],[".",".",".","p",".",".",".","."],[".",".",".",".",".",".",".","."]]

Output: 3*/
        public void solutia2()
        {
            char[][] board = new char[][]
{
    new char[] { '.', '.', '.', '.', '.', '.', '.', '.' },
    new char[] { '.', '.', 'B', 'B', 'B', 'B', 'B', '.' },
    new char[] { '.', 'p', 'B', 'p', 'p', 'p', 'B', 'p' },
    new char[] { '.', 'p', 'B', 'p', 'R', 'p', 'B', 'p' },
    new char[] { '.', 'p', 'B', 'p', 'p', 'p', 'B', 'p' },
    new char[] { '.', '.', 'B', 'B', 'B', 'B', 'B', '.' },
    new char[] { '.', '.', '.', 'p', 'p', 'p', '.', '.' },
    new char[] { '.', '.', '.', '.', '.', '.', '.', '.' }
};

            Console.WriteLine(functii.NumRookCaptures(board));

        }

        /*Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). You may return the answer in any order.



Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]
Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]
*/
        public void solutia3()
        {
            string[] words = ["bella", "label", "roller"];

            Console.WriteLine(string.Join(",",functii.CommonChars(words)));
        }

        /*Given an integer array nums and an integer k, modify the array in the following way:

choose an index i and replace nums[i] with -nums[i].
You should apply this process exactly k times. You may choose the same index i multiple times.

Return the largest possible sum of the array after modifying it in this way.



Example 1:

Input: nums = [4,2,3], k = 1
Output: 5
Explanation: Choose index 1 and nums becomes [4,-2,3].
Example 2:

Input: nums = [3,-1,0,2], k = 3
Output: 6
Explanation: Choose indices (1, 2, 2) and nums becomes [3,1,0,2].
Example 3:

Input: nums = [2,-3,-1,5,-4], k = 2
Output: 13
Explanation: Choose indices (1, 4) and nums becomes [2,3,-1,5,4].*/
        public void solutia4()
        {
            int[] nums = [-2, 5, 0, 2, -2];
            int k = 3;

            Console.WriteLine(functii.LargestSumAfterKNegations(nums,k));
        }
     
        /*The complement of an integer is the integer you get when you flip all the 0's to 1's and all the 1's to 0's in its binary representation.

For example, The integer 5 is "101" in binary and its complement is "010" which is the integer 2.
Given an integer n, return its complement.



Example 1:

Input: n = 5
Output: 2
Explanation: 5 is "101" in binary, with complement "010" in binary, which is 2 in base-10.
Example 2:

Input: n = 7
Output: 0
Explanation: 7 is "111" in binary, with complement "000" in binary, which is 0 in base-10.
Example 3:

Input: n = 10
Output: 5
Explanation: 10 is "1010" in binary, with complement "0101" in binary, which is 5 in base-10.*/
        public void solutia5()
        {
            int n = 5;

            Console.WriteLine(functii.BitwiseComplement(n));
        }

        /*Având în vedere un tablou întreg arr, returnați media numerelor întregi rămase după eliminarea celui mai mic 5%și cel mai mare 5%dintre elemente.

Răspunsurile din cadrul răspunsului real vor fi considerate acceptate.10-5

 

Exemplul 1:

Intrare: arr = [1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3]
 Ieșire: 2,00000
 Explicație: După ștergerea valorilor minime și maxime ale acestei matrice, toate elementele sunt egale cu 2, deci media este 2.
Exemplul 2:

Intrare: arr = [6,2,7,5,1,2,0,3,10,2,5,0,5,5,0,8,7,6,8,0]
 Ieșire: 4,00000
Exemplul 3:

Intrare: arr = [6,0,7,0,7,5,7,8,3,4,0,7,8,1,6,8,1,1,2,4,8,1,9 ,5,4,3,8,5,10,8,6,6,1,0,6,10,8,2,3,4]
 Ieșire: 4,77778*/
        public void solutia6()
        {
            int[] numbs = [6,2,7,5,1,2,0,3,10,2,5,0,5,5,0,8,7,6,8,0];

            Console.WriteLine(functii.TrimMean(numbs));
        }

        /*For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more times).

Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.



Example 1:

Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"
Example 2:

Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"
Example 3:

Input: str1 = "LEET", str2 = "CODE"
Output: ""*/
        public void solutia7()
        {

            string str1 = "ABCABC";
            string str2 = "ABC";
            Console.WriteLine(functii.GcdOfStrings(str1, str2));
        }

        /*You are given a string s consisting of lowercase English letters. A duplicate removal consists of choosing two adjacent and equal letters and removing them.

We repeatedly make duplicate removals on s until we no longer can.

Return the final string after all such duplicate removals have been made. It can be proven that the answer is unique.



Example 1:

Input: s = "abbaca"
Output: "ca"
Explanation: 
For example, in "abbaca" we could remove "bb" since the letters are adjacent and equal, and this is the only possible move.  The result of this move is that the string is "aaca", of which only "aa" is possible, so the final string is "ca".
Example 2:

Input: s = "azxxzy"
Output: "ay"*/
        public void solutia8()
        {
            string s = "abbaca";
            Console.WriteLine(functii.RemoveDuplicates(s));
        }

        /*Given an array points where points[i] = [xi, yi] represents a point on the X-Y plane, return true if these points are a boomerang.

A boomerang is a set of three points that are all distinct and not in a straight line.



Example 1:

Input: points = [[1,1],[2,3],[3,2]]
Output: true
Example 2:

Input: points = [[1,1],[2,2],[3,3]]
Output: false*/
        public void solutia9()
        {
            int[][] points = [[1, 1], [2, 3], [3, 2]];

            Console.WriteLine(functii.IsBoomerang(points));

        }

        /*Având în vedere un tablou întreg de lungime fixă arr, duplicați fiecare apariție a lui zero, deplasând elementele rămase la dreapta.

Rețineți că elementele dincolo de lungimea matricei originale nu sunt scrise. Faceți modificările de mai sus la matricea de intrare și nu returnați nimic.

 

Exemplul 1:

Intrare: arr = [1,0,2,3,0,4,5,0]
 Ieșire: [1,0,0,2,3,0,0,4]
 Explicație: După apelarea funcției, matricea de intrare este modificat în: [1,0,0,2,3,0,0,4]
Exemplul 2:

Intrare: arr = [1,2,3]
 Ieșire: [1,2,3]
 Explicație: După apelarea funcției, matricea de intrare este modificată la: [1,2,3]*/
        public void solutia10()
        {
            int[] arr = [1, 0, 2, 3, 0, 4, 5, 0];
            functii.DuplicateZeros(arr);
            for(int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]+" ");

        }

    }
}
