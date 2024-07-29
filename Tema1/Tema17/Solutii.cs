using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tema17
{
    public class Solutii
    {
        Functii functii = new Functii();

        /*Given an array of integers arr, return true if and only if it is a valid mountain array.

Recall that arr is a mountain array if and only if:

arr.length >= 3
There exists some i with 0 < i < arr.length - 1 such that:
arr[0] < arr[1] < ... < arr[i - 1] < arr[i] 
arr[i] > arr[i + 1] > ... > arr[arr.length - 1]



Example 1:

Input: arr = [2,1]
Output: false
Example 2:

Input: arr = [3,5,5]
Output: false
Example 3:

Input: arr = [0,3,2,1]
Output: true*/
        public void solutia1()
        {

            int[] arr1 = { 2, 1 };
            Console.WriteLine(functii.ValidMountainArray(arr1));
        }

        /*A permutation perm of n + 1 integers of all the integers in the range [0, n] can be represented as a string s of length n where:

s[i] == 'I' if perm[i] < perm[i + 1], and
s[i] == 'D' if perm[i] > perm[i + 1].
Given a string s, reconstruct the permutation perm and return it. If there are multiple valid permutations perm, return any of them.



Example 1:

Input: s = "IDID"
Output: [0,4,1,3,2]
Example 2:

Input: s = "III"
Output: [0,1,2,3]
Example 3:

Input: s = "DDI"
Output: [3,2,0,1]
*/
        public void solutia2()
        {
            string s1 = "IDID";
            Console.WriteLine(string.Join(",", functii.DiStringMatch(s1)));
        }

        /*You are given an array of n strings strs, all of the same length.

The strings can be arranged such that there is one on each line, making a grid.

For example, strs = ["abc", "bce", "cae"] can be arranged as follows:
abc
bce
cae
You want to delete the columns that are not sorted lexicographically. In the above example (0-indexed), columns 0 ('a', 'b', 'c') and 2 ('c', 'e', 'e') are sorted, while column 1 ('b', 'c', 'a') is not, so you would delete column 1.

Return the number of columns that you will delete.



Example 1:

Input: strs = ["cba","daf","ghi"]
Output: 1
Explanation: The grid looks as follows:
cba
daf
ghi
Columns 0 and 2 are sorted, but column 1 is not, so you only need to delete 1 column.
Example 2:

Input: strs = ["a","b"]
Output: 0
Explanation: The grid looks as follows:
a
b
Column 0 is the only column and is sorted, so you will not delete any columns.
Example 3:

Input: strs = ["zyx","wvu","tsr"]
Output: 3
Explanation: The grid looks as follows:
zyx
wvu
tsr
All 3 columns are not sorted, so you will delete all 3.
*/
        public void solutia3()
        {

            string[] strs1 = { "cba", "daf", "ghi" };
            Console.WriteLine(functii.MinDeletionSize(strs1));
        }

        /*In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.



Example 1:

Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
Example 2:

Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
Example 3:

Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false
Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).*/
        public void solutia4()
        {

            string[] words1 = { "hello", "leetcode" };
            string order1 = "hlabcdefgijkmnopqrstuvwxyz";
            Console.WriteLine(functii.IsAlienSorted(words1, order1));
        }

        /*You are given an integer array nums with the following properties:

nums.length == 2 * n.
nums contains n + 1 unique elements.
Exactly one element of nums is repeated n times.
Return the element that is repeated n times.



Example 1:

Input: nums = [1,2,3,3]
Output: 3
Example 2:

Input: nums = [2,1,2,5,3,2]
Output: 2
Example 3:

Input: nums = [5,1,5,2,5,3,5,4]
Output: 5*/
        public void solutia5()
        {

            int[] nums1 = { 1, 2, 3, 3 };
            Console.WriteLine(functii.RepeatedNTimes(nums1));
        }

        /*A binary tree is uni-valued if every node in the tree has the same value.

Given the root of a binary tree, return true if the given tree is uni-valued, or false otherwise.



Example 1:


Input: root = [1,1,1,1,1,null,1]
Output: true
Example 2:


Input: root = [2,2,2,5,2]
Output: false
*/
        public void solutia6()
        {

            TreeNode root1 = new TreeNode(1,
                new TreeNode(1, new TreeNode(1), new TreeNode(1)),
                new TreeNode(1, null, new TreeNode(1))
            );
            Console.WriteLine(functii.IsUnivalTree(root1));
        }

        /*Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.



Example 1:

Input: nums = [2,1,2]
Output: 5
Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
Example 2:

Input: nums = [1,2,1,10]
Output: 0
Explanation: 
You cannot use the side lengths 1, 1, and 2 to form a triangle.
You cannot use the side lengths 1, 1, and 10 to form a triangle.
You cannot use the side lengths 1, 2, and 10 to form a triangle.
As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.*/
        public void solutia7()
        {

            int[] nums1 = { 2, 1, 2 };
            Console.WriteLine(functii.LargestPerimeter(nums1));
        }

        /*Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.



Example 1:

Input: nums = [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Explanation: After squaring, the array becomes [16,1,0,9,100].
After sorting, it becomes [0,1,9,16,100].
Example 2:

Input: nums = [-7,-3,2,3,11]
Output: [4,9,9,49,121]*/
        public void solutia8()
        {

            int[] nums1 = { -4, -1, 0, 3, 10 };
            Console.WriteLine(string.Join(", ", functii.SortedSquares(nums1)));

        }
       
        /*The array-form of an integer num is an array representing its digits in left to right order.

For example, for num = 1321, the array form is [1,3,2,1].
Given num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.



Example 1:

Input: num = [1,2,0,0], k = 34
Output: [1,2,3,4]
Explanation: 1200 + 34 = 1234
Example 2:

Input: num = [2,7,4], k = 181
Output: [4,5,5]
Explanation: 274 + 181 = 455
Example 3:

Input: num = [2,1,5], k = 806
Output: [1,0,2,1]
Explanation: 215 + 806 = 1021*/
        public void solutia9()
        {

            int[] num1 = { 1, 2, 0, 0 };
            int k1 = 34;
            Console.WriteLine(string.Join(", ", functii.AddToArrayForm(num1, k1)));

        }

        /*Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y, return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.

Two nodes of a binary tree are cousins if they have the same depth with different parents.

Note that in a binary tree, the root node is at the depth 0, and children of each depth k node are at the depth k + 1.



Example 1:


Input: root = [1,2,3,4], x = 4, y = 3
Output: false
Example 2:


Input: root = [1,2,3,null,4,null,5], x = 5, y = 4
Output: true
Example 3:


Input: root = [1,2,3,null,4], x = 2, y = 3
Output: false*/
        public void solutia10()
        {

            TreeNode root1 = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    null
                ),
                new TreeNode(3)
            );
            Console.WriteLine(functii.IsCousins(root1, 4, 3));
        }





















































    }
}
