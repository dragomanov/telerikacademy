/* 
 * 3. Write a program that reads a sequence of integers (List<int>) 
 * ending with an empty line and sorts them in an increasing order.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class SortIntegerList
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string SortedStr = "Numbers in sorted order: {0}";

        static void Main(string[] args)
        {
            IList<int> inputNumbers = new List<int>();
            List<int> sortedNumbers;
            string inputStr;
            int number;

            Console.WriteLine(IntroStr);

            while (true)
            {
                inputStr = Console.ReadLine();

                try
                {
                    number = Int32.Parse(inputStr);
                    inputNumbers.Add(number);
                }
                catch (FormatException e)
                {
                    if (String.IsNullOrEmpty(inputStr))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(InvalidFormat);
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(InvalidNumber);
                }
            }

            sortedNumbers = new List<int>(inputNumbers);
            sortedNumbers.Sort();

            Console.WriteLine(SortedStr, String.Join(", ", sortedNumbers));
        }
    }
}
