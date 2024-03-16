using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema2.Functii;

namespace Tema2
{
    public class Solutii
    {

        private Functii functii = new Functii();

        /*You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.



Example 1:


Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]*/
        public void solutia1()
        {
            ListNode list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(4);

            ListNode list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);

            ListNode mergedList = functii.MergeTwoLists(list1, list2);

            Console.WriteLine("Merged List:");
            while (mergedList != null)
            {
                Console.Write(mergedList.val + " ");
                mergedList = mergedList.next;
            }
        }

        /*Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
Return k.
Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int[] expectedNums = [...]; // The expected answer with correct length

int k = removeDuplicates(nums); // Calls your implementation

assert k == expectedNums.length;
for (int i = 0; i < k; i++) {
    assert nums[i] == expectedNums[i];
}
If all assertions pass, then your solution will be accepted.

 

Example 1:

Input: nums = [1,1,2]
Output: 2, nums = [1,2,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).
Example 2:

Input: nums = [0,0,1,1,1,2,2,3,3,4]
Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
It does not matter what you leave beyond the returned k (hence they are underscores).*/
        public void solutia2()
        {

            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int[] expectedNums = { 0, 1, 2, 3, 4 };
            
            int k = functii.RemoveDuplicates(nums);

            Console.WriteLine(k);
            Console.WriteLine("vector:");
            for (int i = 0; i < k; i++)
            {
                Console.Write(nums[i] + " ");
            }

        }

        /*Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.

Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:

Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
Return k.
Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int val = ...; // Value to remove
int[] expectedNums = [...]; // The expected answer with correct length.
                    // It is sorted with no values equaling val.

int k = removeElement(nums, val); // Calls your implementation

assert k == expectedNums.length;
sort(nums, 0, k); // Sort the first k elements of nums
for (int i = 0; i < actualLength; i++) {
assert nums[i] == expectedNums[i];
}
If all assertions pass, then your solution will be accepted.



Example 1:

Input: nums = [3,2,2,3], val = 3
Output: 2, nums = [2,2,_,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 2.
It does not matter what you leave beyond the returned k (hence they are underscores).
Example 2:

Input: nums = [0,1,2,2,3,0,4,2], val = 2
Output: 5, nums = [0,1,4,0,3,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
Note that the five elements can be returned in any order.
It does not matter what you leave beyond the returned k (hence they are underscores).
*/
        public void solutia3()
        {
            int[] nums1 = { 3, 2, 2, 3 };
            int val1 = 3;
            int[] expectedNums1 = { 2, 2 };

            int[] nums2 = { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val2 = 2;
            int[] expectedNums2 = { 0, 1, 4, 0, 3 };

            int k1 = functii.RemoveElement(nums1, val1);
            Console.WriteLine(k1);
            Console.WriteLine("array:");
            for (int i = 0; i < k1; i++)
            {
                Console.Write(nums1[i] + " ");
            }
        }

        /*Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.



Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.*/
        public void solutia4()
        {
            string haystack1 = "sadbutsad";
            string needle1 = "sad";
            string haystack2 = "leetcode";
            string needle2 = "leeto";

            int index1 = functii.StrStr(haystack1, needle1);
            Console.WriteLine(index1);

        }

        /*Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.



Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2
Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1
Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4
*/
        public void solutia5()
        {
            int[] nums1 = { 1, 3, 5, 6 };
            int target1 = 5;
            int[] nums2 = { 1, 3, 5, 6 };
            int target2 = 2;
            int[] nums3 = { 1, 3, 5, 6 };
            int target3 = 7;

            int index1 = functii.SearchInsert(nums1, target1);
            Console.WriteLine(index1);
        }

        /*Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal 
substring
consisting of non-space characters only.



Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.*/
        public void solutia6()
        {
            string s1 = "Hello World";
            string s2 = "   fly me   to   the moon  ";
            string s3 = "luffy is still joyboy";

            int length1 = functii.LengthOfLastWord(s1);
            Console.WriteLine(length1);
        }

        /*Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.

You must not use any built-in exponent function or operator.

For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.


Example 1:

Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.
Example 2:

Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
*/
        public void solutia7()
        {
            int x1 = 4;
            int x2 = 8;

            int sqrt1 = functii.MySqrt(x1);
            Console.WriteLine(x1 + ": " + sqrt1);

        }

        /*Given the head of a sorted linked list, delete all duplicates such that each element appears only once. Return the linked list sorted as well.



Example 1:


Input: head = [1,1,2]
Output: [1,2]
Example 2:


Input: head = [1,1,2,3,3]
Output: [1,2,3]*/
        public void solutia8()
        {
            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(1);
            head1.next.next = new ListNode(2);

            ListNode head2 = new ListNode(1);
            head2.next = new ListNode(1);
            head2.next.next = new ListNode(2);
            head2.next.next.next = new ListNode(3);
            head2.next.next.next.next = new ListNode(3);

            ListNode result1 = functii.DeleteDuplicates(head1);
            while (result1 != null)
            {
                Console.Write(result1.val + " ");
                result1 = result1.next;
            }
            Console.WriteLine();
        }

        /*You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

Merge nums1 and nums2 into a single array sorted in non-decreasing order.

The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.



Example 1:

Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]
Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
Example 2:

Input: nums1 = [1], m = 1, nums2 = [], n = 0
Output: [1]
Explanation: The arrays we are merging are [1] and [].
The result of the merge is [1].
Example 3:

Input: nums1 = [0], m = 0, nums2 = [1], n = 1
Output: [1]
Explanation: The arrays we are merging are [] and [1].
The result of the merge is [1].
Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.*/
        public void solutia9()
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = new int[] { 2, 5, 6 };
            int n = 3;

            functii.Merge(nums1, m, nums2, n);

            foreach (var num in nums1)
            {
                Console.Write(num + " ");
            }
        }

        /*Given the root of a binary tree, return the inorder traversal of its nodes' values.



Example 1:


Input: root = [1,null,2,3]
Output: [1,3,2]
Example 2:

Input: root = []
Output: []
Example 3:

Input: root = [1]
Output: [1]*/
        public void solutia10()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);

            IList<int> inorderTraversal = functii.InorderTraversal(root);

            Console.WriteLine(string.Join(", ", inorderTraversal));
        }



    }
}
