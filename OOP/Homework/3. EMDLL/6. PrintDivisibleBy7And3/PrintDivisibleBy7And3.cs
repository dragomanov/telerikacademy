using System;
using System.Linq;

namespace _6.PrintDivisibleBy7And3
{
    class PrintDivisibleBy7And3
    {
        public static void PrintWithLambda(int[] nums)
        {
            foreach (int num in nums.Where(x => x % 21 == 0))
            {
                Console.WriteLine(num);
            }
        }

        public static void PrintWithLINQ(int[] nums)
        {
            var divisible = from div in nums
                              where div % 21 == 0
                              select div;
            foreach (int num in divisible)
            {
                Console.WriteLine(num);
            }
        }

        static void Main()
        {
            int[] nums = { 1, 3, 5, 7, 19, 21, 42, 49, 63, 70, 90 };

            PrintWithLambda(nums);
            Console.WriteLine();
            PrintWithLINQ(nums);
        }
    }
}
