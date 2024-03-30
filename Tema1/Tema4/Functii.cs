using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4
{
    public class Functii
    {

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
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            while (head != null && head.val == val)
                head = head.next;

            ListNode current = head;
            while (current != null && current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
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
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            Dictionary<char, char> mapping = new Dictionary<char, char>();
            HashSet<char> mappedChars = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char charS = s[i];
                char charT = t[i];

                if (mapping.ContainsKey(charS))
                {
                    if (mapping[charS] != charT)
                        return false;
                }
                else
                {
                    if (mappedChars.Contains(charT))
                        return false;

                    mapping[charS] = charT;
                    mappedChars.Add(charT);
                }
            }

            return true;
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
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode nextNode = current.next;
                current.next = prev;
                prev = current;
                current = nextNode;
            }

            return prev;
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
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
            {
                if (set.Contains(num))
                {
                    return true;
                }
                set.Add(num);
            }

            return false;
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
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numIndices.ContainsKey(nums[i]) && Math.Abs(i - numIndices[nums[i]]) <= k)
                {
                    return true;
                }
                numIndices[nums[i]] = i;
            }

            return false;
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
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = GetDepth(root.left);
            int rightDepth = GetDepth(root.right);

            if (leftDepth == rightDepth)
            {
                return (1 << leftDepth) + CountNodes(root.right);
            }
            else
            {
                return (1 << rightDepth) + CountNodes(root.left);
            }
        }
        private int GetDepth(TreeNode node)
        {
            int depth = 0;
            while (node != null)
            {
                depth++;
                node = node.left;
            }
            return depth;
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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);

            return root;
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
        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();

            if (nums == null || nums.Length == 0)
                return result;

            int start = nums[0];
            int end = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == end + 1)
                {
                    end = nums[i];
                }
                else
                {
                    result.Add(GetRangeString(start, end));
                    start = nums[i];
                    end = nums[i];
                }
            }

            result.Add(GetRangeString(start, end));

            return result;
        }
        private string GetRangeString(int start, int end)
        {
            return start == end ? start.ToString() : start + "->" + end;
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
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

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
    public class MyStack
    {
        private Queue<int> queue;
        private Queue<int> tempQueue;

        public MyStack()
        {
            queue = new Queue<int>();
            tempQueue = new Queue<int>();
        }

        public void Push(int x)
        {
            while (queue.Count > 0)
            {
                tempQueue.Enqueue(queue.Dequeue());
            }

            queue.Enqueue(x);

            while (tempQueue.Count > 0)
            {
                queue.Enqueue(tempQueue.Dequeue());
            }
        }

        public int Pop()
        {
            return queue.Dequeue();
        }

        public int Top()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }
    }
}
