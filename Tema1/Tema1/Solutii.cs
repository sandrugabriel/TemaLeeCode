using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Solutii
    {

        private Functii functii = new Functii();

        public void solutia1()
        {
            Console.WriteLine(functii.IsPalindrome(121));
        }

        public void solutia2()
        {
            int[] arr = new int[]{ 1, 2, 2, 1, 1, 3 };
            Console.WriteLine(functii.UniqueOccurrences(arr));

        }

        public void solutia3()
        {
            Console.WriteLine(functii.MergeAlternately("abc", "pqr"));

        }

        public void solutia4()
        {
            string[] strs = new string[] {"abc","abcas","abcdsd","abdsf" };
            Console.WriteLine(functii.LongestCommonPrefix(strs));

        }

        public void solutia5()
        {
            Console.WriteLine(functii.IsValid("abcdeasd"));

        }

        public void solutia6()
        {
            int[] prices = new int[] { 1,2,4,6,6,8 };
            Console.WriteLine( functii.BuyChoco(prices,12));

        }

        public void solutia7()
        {
            Console.WriteLine(functii.FrequencySort("i went in the park"));

        }

        public void solutia8()
        {
            Console.WriteLine(functii.HammingWeight(00000001010100000));

        }

        public void solutia9()
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            int[] sum = functii.TwoSum(nums,9);

            foreach (var item in sum)
            {
                Console.WriteLine(item);
            }
        }

        public void solutia10()
        {

            int[] nums = new int[] { 1, 2, 3 };
            int[] sum = functii.PlusOne(nums);

            foreach (var item in sum)
            {
                Console.Write(item);
            }
        }

        public void solutia11()
        {
            int[] nums = new int[] { 0, 2, 1, 5, 3, 4 };
            int[] array = functii.BuildArray(nums);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void solutia12()
        {
            int[] nums = new int[] { 1, 2, 1 };
            int[] array = functii.GetConcatenation(nums);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void solutia13()
        {

            string[] oper = new string[] { "--X", "X++", "X++" };
                Console.WriteLine(functii.FinalValueAfterOperations(oper));
        }

        public void solutia14()
        {
            int[] nums = new int[] { 1, 2, 3 };
            IList<int> array = functii.LargestDivisibleSubset(nums);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void solutia15()
        {
            Console.WriteLine(functii.CountSubstrings("abc"));

        }

    }
}
