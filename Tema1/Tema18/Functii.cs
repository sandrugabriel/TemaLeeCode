using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tema18
{
    public class Functii
    {

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
        public int FindJudge(int n, int[][] trust)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            if (trust.Length == 0 & n > 1) return -1;

            for (int i = 0; i < trust.Length; i++)
            {
                if (map.ContainsKey(trust[i][0]))
                    map[trust[i][0]].Add(trust[i][1]);
                else map.Add(trust[i][0], new List<int>() { trust[i][1] });
            }

            /*  for (int i = 1; i <= n; i++)
              {
                  for (int k = 1; k <= n; k++)
                  {
                      if(k!=i)
                      if (map.ContainsKey(i))
                      {
                          if (map[i] == k)
                          {
                                  if(map.ContainsKey(k) && map[k] == i)
                                  {
                                      map.Remove(i);
                                      map.Remove((int)k);
                                  }
                          }
                      }
                  }
              }*/

            for (int i = 1; i <= n; i++)
            {
                if (!map.ContainsKey(i))
                {
                    if(verificationJudge(map,i,n))
                    return i;
                }
              
            }

            return -1;

        }
        private bool verificationJudge(Dictionary<int, List<int>> map, int judge, int n)
        {

            for(int i = 1; i <= n; i++)
            {
                if(map.ContainsKey(i) && i !=judge && !map[i].Contains(judge))
                {
                    return false;
                }
                else if(!map.ContainsKey(i) && i!=judge)
                {
                    return false;
                }
            }

            return true;
        }

        /*  private void allmapstovalue(Dictionary<int,int> map, int value)
          {

              var keyremove = map.Where(val => val.Value == value).Select(val => val.Key).ToList();

              foreach (var key in keyremove) { 

                  map.Remove(key);

              }

          }*/


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
        public int NumRookCaptures(char[][] board)
        {
            int pioniCapturati = 0;


            var tura = board
                      .SelectMany((row, rowIndex) => row
                          .Select((value, colIndex) => new { value, rowIndex, colIndex }))
                      .Where(x => x.value == 'R')
                      .FirstOrDefault();

            var pionii = board
                      .SelectMany((row, rowIndex) => row
                          .Select((value, colIndex) => new { value, rowIndex, colIndex }))
                      .Where(x => x.value == 'p')
                      .ToList();

            var nebuni = board
                      .SelectMany((row, rowIndex) => row
                          .Select((value, colIndex) => new { value, rowIndex, colIndex }))
                      .Where(x => x.value == 'B')
                      .ToList();

            var pion = pionii.LastOrDefault(p => p.rowIndex == tura.rowIndex && p.colIndex < tura.colIndex);
            if (pion != null)
            {
                if (nebuni.FirstOrDefault(n => n.rowIndex == tura.rowIndex && n.colIndex < tura.colIndex && n.colIndex > pion.colIndex) == null)
                {
                    pioniCapturati++;
                }
            }

            pion = pionii.FirstOrDefault(p => p.rowIndex == tura.rowIndex && p.colIndex > tura.colIndex);
            if (pion != null)
            {
                if (nebuni.FirstOrDefault(n => n.rowIndex == tura.rowIndex && (n.colIndex > tura.colIndex && n.colIndex < pion.colIndex)) == null)
                {
                    pioniCapturati++;
                }
            }

            pion = pionii.FirstOrDefault(p => p.rowIndex > tura.rowIndex && p.colIndex == tura.colIndex);
            if (pion != null)
            {
                if (nebuni.FirstOrDefault(n => (n.rowIndex > tura.rowIndex && n.rowIndex < pion.rowIndex) && n.colIndex == tura.colIndex) == null)
                {
                    pioniCapturati++;
                }
            }

            pion = pionii.FirstOrDefault(p => p.rowIndex < tura.rowIndex && p.colIndex == tura.colIndex);
            if (pion != null)
            {
                if (nebuni.FirstOrDefault(n => (n.rowIndex < tura.rowIndex && n.rowIndex > pion.rowIndex) && n.colIndex == tura.colIndex) == null)
                {
                    pioniCapturati++;
                }
            }

            return pioniCapturati;
        }

        /*Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). You may return the answer in any order.

 

Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]
Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]
 */
        public IList<string> CommonChars(string[] words)
        {
            List<Dictionary<char,int>> maps = new List<Dictionary<char,int>>();

            foreach (string word in words)
            {
                Dictionary<char,int> map = new Dictionary<char,int>();
                foreach (char c in word)
                {
                    if (map.ContainsKey(c))
                    {
                        map[c]++;
                    }
                    else map.Add(c, 1);

                }
                maps.Add(map);
            }

            List<string> result = new List<string>();

            List<char> chars = new List<char>();
            foreach (char c in words[0])
            {
                if (!chars.Contains(c))
                {
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (maps[i].ContainsKey(c))
                        {
                            if (i == words.Length - 1)
                            {
                                int min = GetMinValuesForKeys(maps, c);
                                for (int k = 0; k < min; k++)
                                {
                                    result.Add(c.ToString());
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    chars.Add(c);
                }

            }

            return result;
        }
        private int GetMinValuesForKeys(List<Dictionary<char, int>> maps, char c)
        {
            int min = int.MaxValue;

            for(int i=0;i< maps.Count; i++)
            {
                if (maps[i][c] < min)
                {
                    min = maps[i][c];
                }
            }

            return min;
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
        public int LargestSumAfterKNegations(int[] nums, int k)
        {

            for (int i = 0; i < k; i++)
            {
                Array.Sort(nums);
                    nums[0] = -nums[0];
             
            }
            return nums.Sum();
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
        public int BitwiseComplement(int n)
        {
            string binary = ConvertToBinary(n);

            string flip="";

            for(int i = 0; i < binary.Length; i++)
            {
                if(binary[i] == '0')
                {
                    flip += "1";
                }else flip += "0";
            }

            return ConvertBinaryToDecimal(flip);

        }
        public string ConvertToBinary(int number)
        {
            if (number == 0)
                return "0";

            string binary = "";
            while (number > 0)
            {
                binary = (number % 2) + binary;
                number /= 2;
            }

            return binary;
        }
        public int ConvertBinaryToDecimal(string binaryString)
        {
            int decimalValue = 0;
            int baseValue = 1;

            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] == '1')
                {
                    decimalValue += baseValue;
                }
                baseValue *= 2;
            }

            return decimalValue;
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
        public double TrimMean(int[] arr)
        {
            double media = 0.00000;

            Array.Sort(arr);

            int ct = (int)(arr.Length * 0.05);

            int[] nums = arr.Skip(ct).Take(arr.Length -  ct).ToArray();

            nums = nums.SkipLast(ct).Take(arr.Length-ct).ToArray();

            media = nums.Average();

            return media;
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
         private int Gcd(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }
        public string GcdOfStrings(string str1, string str2)
        {
            int gcdLength = Gcd(str1.Length, str2.Length);

            string candidate = str1.Substring(0, gcdLength);

            if (IsDivisible(str1, candidate) && IsDivisible(str2, candidate))
            {
                return candidate;
            }
            else
            {
                return "";
            }
        }
        private static bool IsDivisible(string str, string sub)
        {
            int len = sub.Length;
            int n = str.Length;
            if (n % len != 0)
            {
                return false;
            }

            string repeatedSub = new String(' ', n);
            for (int i = 0; i < n; i += len)
            {
                if (!str.Substring(i, len).Equals(sub))
                {
                    return false;
                }
            }

            return true;
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
        public string RemoveDuplicates(string s)
        {
            int semn = 0;
            do
            {
                semn = 0;
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] == s[i + 1])
                    {
                       s = s.Remove(i,2);
                        semn = 1;
                    }
                }
            } while (semn!=0);



            return s;
        }

        /*Given an array points where points[i] = [xi, yi] represents a point on the X-Y plane, return true if these points are a boomerang.

A boomerang is a set of three points that are all distinct and not in a straight line.

 

Example 1:

Input: points = [[1,1],[2,3],[3,2]]
Output: true
Example 2:

Input: points = [[1,1],[2,2],[3,3]]
Output: false*/
        public bool IsBoomerang(int[][] points)
        {
            if ((points[0][0] == points[1][0] && points[0][1] == points[1][1]) ||
                (points[0][0] == points[2][0] && points[0][1] == points[2][1]) ||
                (points[1][0] == points[2][0] && points[1][1] == points[2][1]))
            {
                return false;
            }

            int x1 = points[0][0], y1 = points[0][1];
            int x2 = points[1][0], y2 = points[1][1];
            int x3 = points[2][0], y3 = points[2][1];

            int area = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);

            return area != 0;
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
        public void DuplicateZeros(int[] arr)
        {
            int n = arr.Length;
            List<int> nou = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                {
                    nou.Add(arr[i]);
                    nou.Add(arr[i]);
                    n --;
                }
                else
                {
                    nou.Add(arr[i]);
                }
            }
            Array.Clear(arr);
            for(int i=0;i< arr.Length; i++)
            {
                arr[i] = nou[i];
            }
        }

    }
}
