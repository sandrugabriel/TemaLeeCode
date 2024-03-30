using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tema4.Functii;

namespace Tema4
{
    public class Solutii
    {
        Functii functii = new Functii();

        /*Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.



Example 1:


Input: head = [1,2,6,3,4,5,6], val = 6
Output: [1,2,3,4,5]
Example 2:

Input: head = [], val = 1
Output: []
Example 3:

Input: head = [7,7,7,7], val = 7
Output: []
*/
        public void solutia1()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next.next = new ListNode(6);

            int val = 6;
            ListNode newHead = functii.RemoveElements(head, val);

            while (newHead != null)
            {
                Console.Write(newHead.val + " ");
                newHead = newHead.next;
            }
        }

        /*Given two strings s and t, determine if they are isomorphic.

Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.



Example 1:

Input: s = "egg", t = "add"
Output: true
Example 2:

Input: s = "foo", t = "bar"
Output: false
Example 3:

Input: s = "paper", t = "title"
Output: true
*/
        public void solutia2()
        {
            string s1 = "egg";
            string t1 = "add";
            Console.WriteLine(functii.IsIsomorphic(s1, t1));

        }

        /*Given the head of a singly linked list, reverse the list, and return the reversed list.



Example 1:


Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]
Example 2:


Input: head = [1,2]
Output: [2,1]
Example 3:

Input: head = []
Output: []
*/
        public void solutia3()
        {
            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(2);
            head1.next.next = new ListNode(3);
            head1.next.next.next = new ListNode(4);
            head1.next.next.next.next = new ListNode(5);

            ListNode reversedHead1 = functii.ReverseList(head1);
            PrintList(reversedHead1);
        }
        static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            Console.WriteLine();
        }

        /*Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.



Example 1:

Input: nums = [1,2,3,1]
Output: true
Example 2:

Input: nums = [1,2,3,4]
Output: false
Example 3:

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true
*/
        public void solutia4()
        {
            int[] nums1 = { 1, 2, 3, 1 };
            Console.WriteLine(functii.ContainsDuplicate(nums1));
        }

        /*Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.



Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true
Example 2:

Input: nums = [1,0,1,1], k = 1
Output: true
Example 3:

Input: nums = [1,2,3,1,2,3], k = 2
Output: false
*/
        public void solutia5()
        {
            int[] nums1 = { 1, 2, 3, 1 };
            int k1 = 3;
            Console.WriteLine(functii.ContainsNearbyDuplicate(nums1, k1));
        }

        /*Given the root of a complete binary tree, return the number of the nodes in the tree.

According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

Design an algorithm that runs in less than O(n) time complexity.

 

Example 1:


Input: root = [1,2,3,4,5,6]
Output: 6
Example 2:

Input: root = []
Output: 0
Example 3:

Input: root = [1]
Output: 1*/
        public void solutia6()
        {
            TreeNode root1 = new TreeNode(1);
            root1.left = new TreeNode(2);
            root1.right = new TreeNode(3);
            root1.left.left = new TreeNode(4);
            root1.left.right = new TreeNode(5);
            root1.right.left = new TreeNode(6);

            Console.WriteLine(functii.CountNodes(root1));
        }

        /*Implement a last-in-first-out (LIFO) stack using only two queues. The implemented stack should support all the functions of a normal stack (push, top, pop, and empty).

Implement the MyStack class:

void push(int x) Pushes element x to the top of the stack.
int pop() Removes the element on the top of the stack and returns it.
int top() Returns the element on the top of the stack.
boolean empty() Returns true if the stack is empty, false otherwise.
Notes:

You must use only standard operations of a queue, which means that only push to back, peek/pop from front, size and is empty operations are valid.
Depending on your language, the queue may not be supported natively. You may simulate a queue using a list or deque (double-ended queue) as long as you use only a queue's standard operations.


Example 1:

Input
["MyStack", "push", "push", "top", "pop", "empty"]
[[], [1], [2], [], [], []]
Output
[null, null, null, 2, 2, false]

Explanation
MyStack myStack = new MyStack();
myStack.push(1);
myStack.push(2);
myStack.top(); // return 2
myStack.pop(); // return 2
myStack.empty(); // return False*/
        public void solutia7()
        {
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            Console.WriteLine(myStack.Top());
        }

        /*Given the root of a binary tree, invert the tree, and return its root.



Example 1:


Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]
Example 2:


Input: root = [2,1,3]
Output: [2,3,1]
Example 3:

Input: root = []
Output: []*/
        public void solutia8()
        {
            TreeNode root1 = new TreeNode(4);
            root1.left = new TreeNode(2);
            root1.right = new TreeNode(7);
            root1.left.left = new TreeNode(1);
            root1.left.right = new TreeNode(3);
            root1.right.left = new TreeNode(6);
            root1.right.right = new TreeNode(9);

            TreeNode invertedRoot1 = functii.InvertTree(root1);
            PrintTree(invertedRoot1);
        }
        static void PrintTree(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("(empty)");
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write(node.val + " ");
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            Console.WriteLine();
        }

        /*You are given a sorted unique integer array nums.

A range [a,b] is the set of all integers from a to b (inclusive).

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

"a->b" if a != b
"a" if a == b


Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"
Example 2:

Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
*/
        public void solutia9()
        {
            int[] nums1 = { 0, 1, 2, 4, 5, 7 };
            IList<string> result1 = functii.SummaryRanges(nums1);
            PrintList(result1);
        }
        static void PrintList(IList<string> list)
        {
            Console.Write("[");
            foreach (var item in list)
            {
                Console.Write("\"" + item + "\", ");
            }
            Console.WriteLine("]");
        }

        /*Given an integer n, return true if it is a power of two. Otherwise, return false.

An integer n is a power of two, if there exists an integer x such that n == 2x.



Example 1:

Input: n = 1
Output: true
Explanation: 20 = 1
Example 2:

Input: n = 16
Output: true
Explanation: 24 = 16
Example 3:

Input: n = 3
Output: false
*/
        public void soluti10()
        {
            int n1 = 1;
            Console.WriteLine(functii.IsPowerOfTwo(n1));
        }

    }
}
