/*
 * 6. Write a program that removes from given sequence all numbers that occur odd number of times. 
 * Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class RemoveOddOccurances
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string SequenceWithEvenOccurancesStr = "Sequence with numbers occuring even times: {0}";

        static void Main(string[] args)
        {
            IList<int> inputNumbers = new List<int>();
            IList<int> sequenceWithEvenOccurances;
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

            sequenceWithEvenOccurances = inputNumbers.Where(x => inputNumbers.Count(y => x == y) % 2 == 0).ToList<int>();

            Console.WriteLine(SequenceWithEvenOccurancesStr, String.Join(", ", sequenceWithEvenOccurances));
        }
    }
}
