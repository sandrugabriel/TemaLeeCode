using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema16
{

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

    public class Functii
    {

        /*Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree, and every node has no left child and only one right child.

 

Example 1:


Input: root = [5,3,6,2,4,null,8,1,null,null,null,7,9]
Output: [1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
Example 2:


Input: root = [5,1,7]
Output: [1,null,5,null,7]
 */
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode newRoot = null;
            TreeNode current = null;

            void InOrder(TreeNode node)
            {
                if (node == null) return;
                InOrder(node.left);
                if (newRoot == null)
                {
                    newRoot = new TreeNode(node.val);
                    current = newRoot;
                }
                else
                {
                    current.right = new TreeNode(node.val);
                    current = current.right;
                }
                InOrder(node.right);
            }

            InOrder(root);
            return newRoot;
        }

        /*Given an integer array nums, move all the even integers at the beginning of the array followed by all the odd integers.

Return any array that satisfies this condition.

 

Example 1:

Input: nums = [3,1,2,4]
Output: [2,4,3,1]
Explanation: The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
Example 2:

Input: nums = [0]
Output: [0]*/
        public int[] SortArrayByParity(int[] nums)
        {

            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            foreach (int num in nums)
            {
                if (num % 2 == 0) evens.Add(num);
                else odds.Add(num);
            }

            evens.AddRange(odds);
            return evens.ToArray();

        }

        /*You are given an integer array nums and an integer k.

In one operation, you can choose any index i where 0 <= i < nums.length and change nums[i] to nums[i] + x where x is an integer from the range [-k, k]. You can apply this operation at most once for each index i.

The score of nums is the difference between the maximum and minimum elements in nums.

Return the minimum score of nums after applying the mentioned operation at most once for each index in it.

 

Example 1:

Input: nums = [1], k = 0
Output: 0
Explanation: The score is max(nums) - min(nums) = 1 - 1 = 0.
Example 2:

Input: nums = [0,10], k = 2
Output: 6
Explanation: Change nums to be [2, 8]. The score is max(nums) - min(nums) = 8 - 2 = 6.
Example 3:

Input: nums = [1,3,6], k = 3
Output: 0
Explanation: Change nums to be [4, 4, 4]. The score is max(nums) - min(nums) = 4 - 4 = 0.*/
        public int SmallestRangeI(int[] nums, int k)
        {

            int min_val = int.MaxValue;
            int max_val = int.MinValue;

            foreach (int num in nums)
            {
                if (num < min_val) min_val = num;
                if (num > max_val) max_val = num;
            }

            int newMin = min_val + k;
            int newMax = max_val - k;
            int minScore = Math.Max(0, newMax - newMin);

            return minScore;
        }

        /*You are given an integer array deck where deck[i] represents the number written on the ith card.

Partition the cards into one or more groups such that:

Each group has exactly x cards where x > 1, and
All the cards in one group have the same integer written on them.
Return true if such partition is possible, or false otherwise.

 

Example 1:

Input: deck = [1,2,3,4,4,3,2,1]
Output: true
Explanation: Possible partition [1,1],[2,2],[3,3],[4,4].
Example 2:

Input: deck = [1,1,1,2,2,2,3,3]
Output: false
Explanation: No possible partition.
 */
        public bool HasGroupsSizeX(int[] deck)
        {
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            foreach (int card in deck)
            {
                if (countMap.ContainsKey(card))
                {
                    countMap[card]++;
                }
                else
                {
                    countMap[card] = 1;
                }
            }

            int[] counts = countMap.Values.ToArray();

            int gcd = counts[0];
            for (int i = 1; i < counts.Length; i++)
            {
                gcd = GCD(gcd, counts[i]);
            }

            return gcd > 1;
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /*Given a string s, reverse the string according to the following rules:

All the characters that are not English letters remain in the same position.
All the English letters (lowercase or uppercase) should be reversed.
Return s after reversing it.

 

Example 1:

Input: s = "ab-cd"
Output: "dc-ba"
Example 2:

Input: s = "a-bC-dEf-ghIj"
Output: "j-Ih-gfE-dCba"
Example 3:

Input: s = "Test1ng-Leet=code-Q!"
Output: "Qedo1ct-eeLg=ntse-T!"
 */
        public string ReverseOnlyLetters(string s)
        {
            List<char> letters = new List<char>();
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    letters.Add(c);
                }
            }
            letters.Reverse();

            StringBuilder result = new StringBuilder();
            int letterIndex = 0;

            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    result.Append(letters[letterIndex++]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /*Given an array of integers nums, half of the integers in nums are odd, and the other half are even.

Sort the array so that whenever nums[i] is odd, i is odd, and whenever nums[i] is even, i is even.

Return any answer array that satisfies this condition.

 

Example 1:

Input: nums = [4,2,5,7]
Output: [4,5,2,7]
Explanation: [4,7,2,5], [2,5,4,7], [2,7,4,5] would also have been accepted.
Example 2:

Input: nums = [2,3]
Output: [2,3]*/
        public int[] SortArrayByParityII(int[] nums)
        {
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();

            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    evens.Add(num);
                }
                else
                {
                    odds.Add(num);
                }
            }

            int[] result = new int[nums.Length];

            int evenIndex = 0;
            int oddIndex = 1;

            foreach (int even in evens)
            {
                result[evenIndex] = even;
                evenIndex += 2;
            }

            foreach (int odd in odds)
            {
                result[oddIndex] = odd;
                oddIndex += 2;
            }

            return result;
        }

        /*Your friend is typing his name into a keyboard. Sometimes, when typing a character c, the key might get long pressed, and the character will be typed 1 or more times.

You examine the typed characters of the keyboard. Return True if it is possible that it was your friends name, with some characters (possibly none) being long pressed.

 

Example 1:

Input: name = "alex", typed = "aaleex"
Output: true
Explanation: 'a' and 'e' in 'alex' were long pressed.
Example 2:

Input: name = "saeed", typed = "ssaaedd"
Output: false
Explanation: 'e' must have been pressed twice, but it was not in the typed output.*/
        public bool IsLongPressedName(string name, string typed)
        {
            int i = 0, j = 0;

            while (i < name.Length && j < typed.Length)
            {
                if (name[i] == typed[j])
                {
                    i++;
                    j++;
                }
                else if (i > 0 && name[i - 1] == typed[j])
                {
                    j++;
                }
                else
                {

                    return false;
                }
            }

            while (j < typed.Length)
            {
                if (typed[j] != name[i - 1])
                {
                    return false;
                }
                j++;
            }

            return i == name.Length;
        }

        /*Every valid email consists of a local name and a domain name, separated by the '@' sign. Besides lowercase letters, the email may contain one or more '.' or '+'.

For example, in "alice@leetcode.com", "alice" is the local name, and "leetcode.com" is the domain name.
If you add periods '.' between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name. Note that this rule does not apply to domain names.

For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.
If you add a plus '+' in the local name, everything after the first plus sign will be ignored. This allows certain emails to be filtered. Note that this rule does not apply to domain names.

For example, "m.y+name@email.com" will be forwarded to "my@email.com".
It is possible to use both of these rules at the same time.

Given an array of strings emails where we send one email to each emails[i], return the number of different addresses that actually receive mails.

 

Example 1:

Input: emails = ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
Output: 2
Explanation: "testemail@leetcode.com" and "testemail@lee.tcode.com" actually receive mails.
Example 2:

Input: emails = ["a@leetcode.com","b@leetcode.com","c@leetcode.com"]
Output: 3*/
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> uniqueEmails = new HashSet<string>();

            foreach (string email in emails)
            {
                string[] parts = email.Split('@');
                string local = parts[0];
                string domain = parts[1];

                int plusIndex = local.IndexOf('+');
                if (plusIndex != -1)
                {
                    local = local.Substring(0, plusIndex);
                }
                local = local.Replace(".", "");

                string normalizedEmail = local + "@" + domain;
                uniqueEmails.Add(normalizedEmail);
            }

            return uniqueEmails.Count;
        }

        /*Given the root node of a binary search tree and two integers low and high, return the sum of values of all nodes with a value in the inclusive range [low, high].

 

Example 1:


Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
Output: 32
Explanation: Nodes 7, 10, and 15 are in the range [7, 15]. 7 + 10 + 15 = 32.
Example 2:


Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
Output: 23
Explanation: Nodes 6, 7, and 10 are in the range [6, 10]. 6 + 7 + 10 = 23.
 */
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            return RangeSum(root, low, high);
        }
        private int RangeSum(TreeNode node, int low, int high)
        {
            if (node == null)
            {
                return 0;
            }

            int sum = 0;

            if (node.val >= low && node.val <= high)
            {
                sum += node.val;
            }

            if (node.val > low)
            {
                sum += RangeSum(node.left, low, high);
            }

            if (node.val < high)
            {
                sum += RangeSum(node.right, low, high);
            }

            return sum;
        }


    }

    /*You have a RecentCounter class which counts the number of recent requests within a certain time frame.

Implement the RecentCounter class:

RecentCounter() Initializes the counter with zero recent requests.
int ping(int t) Adds a new request at time t, where t represents some time in milliseconds, and returns the number of requests that has happened in the past 3000 milliseconds (including the new request). Specifically, return the number of requests that have happened in the inclusive range [t - 3000, t].
It is guaranteed that every call to ping uses a strictly larger value of t than the previous call.



Example 1:

Input
["RecentCounter", "ping", "ping", "ping", "ping"]
[[], [1], [100], [3001], [3002]]
Output
[null, 1, 2, 3, 3]

Explanation
RecentCounter recentCounter = new RecentCounter();
recentCounter.ping(1);     // requests = [1], range is [-2999,1], return 1
recentCounter.ping(100);   // requests = [1, 100], range is [-2900,100], return 2
recentCounter.ping(3001);  // requests = [1, 100, 3001], range is [1,3001], return 3
recentCounter.ping(3002);  // requests = [1, 100, 3001, 3002], range is [2,3002], return 3
*/
    public class RecentCounter
    {
        private Queue<int> queue;

        public RecentCounter()
        {
            queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            queue.Enqueue(t);

            while (queue.Peek() < t - 3000)
            {
                queue.Dequeue();
            }

            return queue.Count;
        }
    }
}
