using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Program
    {
        private static int n;
        private static uint x;
        private static IEnumerable<uint> inputNumbers;
        private static SortedDictionary<uint, List<uint>> sortedNumbers = new SortedDictionary<uint, List<uint>>();

        static void Main()
        {
            Console.SetIn(new StreamReader("../../input.txt"));
            Console.SetOut(new StreamWriter("../../out.txt"));
            ReadInput();
            SortNumbers();
            PrintSortedNumbers();
        }

        private static void PrintSortedNumbers()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var numbersWithRemainder in sortedNumbers)
            {
                foreach (var number in numbersWithRemainder.Value)
                {
                    sb.Append(number)
                      .Append(" ");

                    if (i % 1000 == 0)
                    {
                        Console.Write(sb);
                        sb.Clear();
                    }
                    i++;
                }
            }
            Console.Write(sb);
        }

        private static void SortNumbers()
        {
            foreach (var inputNumber in inputNumbers)
            {
                uint remainder = inputNumber % x;

                if (!sortedNumbers.ContainsKey(remainder))
                {
                    sortedNumbers[remainder] = new List<uint>();
                }

                sortedNumbers[remainder].Add(inputNumber);
            }

            foreach (var numbersWithRemainder in sortedNumbers)
            {
                numbersWithRemainder.Value.Sort();
            }
        }

        private static void ReadInput()
        {
            var delimiter = new char[] { ' ' };
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            x = uint.Parse(input[1]);
            inputNumbers = new uint[n];
            input = Console.ReadLine().Split(delimiter);
            inputNumbers = input.Select(num => uint.Parse(num));
        }
    }
}
