using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Functii
    {
        public bool IsPalindrome(int x)
        {

            for (int i = 0; i < x.ToString().Length; i++)
            {
                if (x.ToString()[i] != x.ToString()[x.ToString().Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool UniqueOccurrences(int[] arr)
        {
            int[] f = new int[2002];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= -1)
                {
                    f[arr[i] + 2001]++;
                }
                else
                    f[arr[i]]++;
            }

            for (int i = 0; i <= 2001; i++)
            {
                if (f[i] != 0)
                {
                    for (int j = 0; j <= 2001; j++)
                    {
                        if (f[j] != 0 && i != j)
                        {
                            if (f[i] == f[j]) return false;
                        }
                    }
                }
            }

            return true;
        }

        public string MergeAlternately(string word1, string word2)
        {
            int dim = word1.Length;
            if (word1.Length < word2.Length)
            {
                dim = word2.Length;
            }

            string text = "";
            for (int i = 0; i < dim; i++)
            {
                if (word1.Length > i)
                    text += word1[i];
                if (word2.Length > i)
                    text += word2[i];
            }
            return text;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            string prefix = "";

            strs.OrderDescending();
            for (int i = 0; i < strs[0].Length; i++)
            {
                int ok = 0;
                for (int k = 0; k < strs.Length; k++)
                {
                    if (strs[k].Length - 1 < i)
                    {
                        return prefix;
                    }
                    else if (strs[k][i] != strs[0][i]) return prefix;
                    else
                    {
                        ok = 1;

                    }
                }

                if (ok == 1) prefix += strs[0][i];
            }


            return prefix;
        }

        public bool IsValid(string s)
        {

            if (s.Length % 2 == 1) return false;

            while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            {
                s = s.Replace("()", "");
                s = s.Replace("[]", "");
                s = s.Replace("{}", "");
            }


            if (s.Length == 0)
                return true;
            return false;
        }

        public int BuyChoco(int[] prices, int money)
        {

            var sort = prices.ToList();

            sort.Sort();

            prices = sort.ToArray();

            if ((prices[0] + prices[1]) > money) return money;
            else return money - (prices[0] + prices[1]);
    }

        public string FrequencySort(string s)
        {

            int[] frecv = new int[120];

            for (int i = 0; i < s.Length; i++)
            {
                frecv[s[i] - 48]++;
            }

            string final = "";

            while (final.Length != s.Length)
            {

                int valoareMaxima = frecv.Max();

                int indexMaxim = Array.IndexOf(frecv, valoareMaxima);

                while (valoareMaxima != 0)
                {
                    final += ((char)(indexMaxim + 48));
                    valoareMaxima--;
                }

                frecv[indexMaxim] = 0;

            }

            return final;
        }

        public int HammingWeight(uint n)
        {

            int ct = 0;
            while (n != 0)
            {
                ct++;

                n &= (n - 1);
            }

            return ct;
        }

        public int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return null;
        }

        public int[] PlusOne(int[] digits)
        {

            int carry = 1;
            int n = digits.Length;

            for (int i = n - 1; i >= 0; i--)
            {
                int sum = digits[i] + carry;
                digits[i] = sum % 10;
                carry = sum / 10;
            }

            if (carry > 0)
            {
                int[] result = new int[n + 1];
                result[0] = carry;
                Array.Copy(digits, 0, result, 1, n);
                return result;
            }
            else
            {
                return digits;
            }
        }

        public int[] BuildArray(int[] nums)
        {

            int[] ans = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }

            return ans;
        }

        public int[] GetConcatenation(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n * 2];

            for (int i = 0; i < n; i++)
            {
                ans[i] = nums[i];
                ans[i + n] = nums[i];
            }

            return ans;
        }

        public int FinalValueAfterOperations(string[] operations)
        {

            int x = 0;

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "X++" || operations[i] == "++X") { x++; }
                else if (operations[i] == "X--" || operations[i] == "--X") { x--; }
            }

            return x;
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<int>();

            Array.Sort(nums);
            int n = nums.Length;

            int[] dp = new int[n];
            int[] parent = new int[n];

            int max_length = 1, max_index = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                parent[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        parent[i] = j;

                        if (dp[i] > max_length)
                        {
                            max_length = dp[i];
                            max_index = i;
                        }
                    }
                }
            }

            List<int> result = new List<int>();
            while (max_index != -1)
            {
                result.Add(nums[max_index]);
                max_index = parent[max_index];
            }

            result.Reverse();
            return result;
        }

        public int CountSubstrings(string s)
        {
            int count = 0;

            for (int i = 0; i < 2 * s.Length - 1; i++)
            {
                int left = i / 2;
                int right = left + i % 2;

                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }

            return count;
        }


    }
}
