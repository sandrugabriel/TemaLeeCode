using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{
    public class Functii
    {

        /*Given two binary strings a and b, return their sum as a binary string.

 

Example 1:

Input: a = "11", b = "1"
Output: "100"
Example 2:

Input: a = "1010", b = "1011"
Output: "10101"*/
        public string AddBinary(string a, string b)
        {
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            string result = "";

            while (i >= 0 || j >= 0 || carry == 1)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a[i] - '0';
                    i--;
                }

                if (j >= 0)
                {
                    sum += b[j] - '0';
                    j--;
                }

                result = (sum % 2) + result;
                carry = sum / 2;
            }

            return result;
        }

        /*A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 */
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                if (!IsAlphaNumeric(s[left]))
                {
                    left++;
                    continue;
                }
                if (!IsAlphaNumeric(s[right]))
                {
                    right--;
                    continue;
                }
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }

            return true;
        }
        private bool IsAlphaNumeric(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
        }

        /*Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.

 

Example 1:


Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
Example 2:


Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
Example 3:


Input: head = [1], pos = -1
Output: false
Explanation: There is no cycle in the linked list.*/
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                    return true;
                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }

        /*Given the root of a binary tree, return the preorder traversal of its nodes' values.

 

Example 1:


Input: root = [1,null,2,3]
Output: [1,2,3]
Example 2:

Input: root = []
Output: []
Example 3:

Input: root = [1]
Output: [1]
 */
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            PreorderTraversalHelper(root, result);
            return result;
        }
        private void PreorderTraversalHelper(TreeNode node, IList<int> result)
        {
            if (node == null)
                return;

            result.Add(node.val);
            PreorderTraversalHelper(node.left, result);
            PreorderTraversalHelper(node.right, result);
        }

        /*Given the root of a binary tree, return the postorder traversal of its nodes' values.

 

Example 1:


Input: root = [1,null,2,3]
Output: [3,2,1]
Example 2:

Input: root = []
Output: []
Example 3:

Input: root = [1]
Output: [1]*/
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            PostorderTraversalHelper(root, result);
            return result;
        }
        private void PostorderTraversalHelper(TreeNode node, IList<int> result)
        {
            if (node == null)
                return;

            PostorderTraversalHelper(node.left, result);
            PostorderTraversalHelper(node.right, result);
            result.Add(node.val);
        }

        /*Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect. If the two linked lists have no intersection at all, return null.

For example, the following two linked lists begin to intersect at node c1:


The test cases are generated such that there are no cycles anywhere in the entire linked structure.

Note that the linked lists must retain their original structure after the function returns.

Custom Judge:

The inputs to the judge are given as follows (your program is not given these inputs):

intersectVal - The value of the node where the intersection occurs. This is 0 if there is no intersected node.
listA - The first linked list.
listB - The second linked list.
skipA - The number of nodes to skip ahead in listA (starting from the head) to get to the intersected node.
skipB - The number of nodes to skip ahead in listB (starting from the head) to get to the intersected node.
The judge will then create the linked structure based on these inputs and pass the two heads, headA and headB to your program. If you correctly return the intersected node, then your solution will be accepted.

 

Example 1:


Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
Output: Intersected at '8'
Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
- Note that the intersected node's value is not 1 because the nodes with value 1 in A and B (2nd node in A and 3rd node in B) are different node references. In other words, they point to two different locations in memory, while the nodes with value 8 in A and B (3rd node in A and 4th node in B) point to the same location in memory.
Example 2:


Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
Output: Intersected at '2'
Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.
Example 3:


Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
Output: No intersection
Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
Explanation: The two lists do not intersect, so return null.
 */
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode pA = headA;
            ListNode pB = headB;

            while (pA != pB)
            {
                if (pA == null)
                    pA = headB;
                else
                    pA = pA.next;

                if (pB == null)
                    pB = headA;
                else
                    pB = pB.next;
            }

            return pA;
        }

        /*Given a string columnTitle that represents the column title as appears in an Excel sheet, return its corresponding column number.

For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28 
...
 

Example 1:

Input: columnTitle = "A"
Output: 1
Example 2:

Input: columnTitle = "AB"
Output: 28
Example 3:

Input: columnTitle = "ZY"
Output: 701*/
        public int TitleToNumber(string columnTitle)
        {
            int result = 0;

            foreach (char c in columnTitle)
            {
                result = result * 26 + (c - 'A' + 1);
            }

            return result;
        }

        /*Reverse bits of a given 32 bits unsigned integer.

Note:

Note that in some languages, such as Java, there is no unsigned integer type. In this case, both input and output will be given as a signed integer type. They should not affect your implementation, as the integer's internal binary representation is the same, whether it is signed or unsigned.
In Java, the compiler represents the signed integers using 2's complement notation. Therefore, in Example 2 above, the input represents the signed integer -3 and the output represents the signed integer -1073741825.
 

Example 1:

Input: n = 00000010100101000001111010011100
Output:    964176192 (00111001011110000010100101000000)
Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.
Example 2:

Input: n = 11111111111111111111111111111101
Output:   3221225471 (10111111111111111111111111111111)
Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.*/
        public uint reverseBits(uint n)
        {
            uint result = 0;

            for (int i = 0; i < 32; i++)
            {
                uint bit = n & 1;

                result = (result << 1) | bit;

                n >>= 1;
            }

            return result;
        }

        /*Given the head of a singly linked list, return true if it is a 
palindrome
 or false otherwise.

 

Example 1:


Input: head = [1,2,2,1]
Output: true
Example 2:


Input: head = [1,2]
Output: false
 */
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode secondHalf = ReverseLinkedList(slow.next);

            ListNode firstHalf = head;
            while (secondHalf != null)
            {
                if (firstHalf.val != secondHalf.val)
                    return false;
                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }

            return true;
        }
        private ListNode ReverseLinkedList(ListNode head)
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

    }
    /*Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).

Implement the MyQueue class:

void push(int x) Pushes element x to the back of the queue.
int pop() Removes the element from the front of the queue and returns it.
int peek() Returns the element at the front of the queue.
boolean empty() Returns true if the queue is empty, false otherwise.
Notes:

You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.
 

Example 1:

Input
["MyQueue", "push", "push", "peek", "pop", "empty"]
[[], [1], [2], [], [], []]
Output
[null, null, null, 1, 1, false]

Explanation
MyQueue myQueue = new MyQueue();
myQueue.push(1); // queue is: [1]
myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
myQueue.peek(); // return 1
myQueue.pop(); // return 1, queue is [2]
myQueue.empty(); // return false
 */
    public class MyQueue
    {
        private Stack<int> inputStack;
        private Stack<int> outputStack;

        public MyQueue()
        {
            inputStack = new Stack<int>();
            outputStack = new Stack<int>();
        }

        public void Push(int x)
        {
            inputStack.Push(x);
        }

        public int Pop()
        {
            if (outputStack.Count == 0)
            {
                while (inputStack.Count > 0)
                {
                    outputStack.Push(inputStack.Pop());
                }
            }

            return outputStack.Pop();
        }

        public int Peek()
        {
            if (outputStack.Count == 0)
            {
                while (inputStack.Count > 0)
                {
                    outputStack.Push(inputStack.Pop());
                }
            }

            return outputStack.Peek();
        }

        public bool Empty()
        {
            return inputStack.Count == 0 && outputStack.Count == 0;
        }


    }

}
