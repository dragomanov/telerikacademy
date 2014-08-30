/*
 * 5. Write a program that removes from given sequence all negative numbers.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class RemoveNegativeNumbers
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string SequenceWithoutNegativeNumbersStr = "Sequence with negative numbers removed: {0}";

        static void Main(string[] args)
        {
            IList<int> inputNumbers = new List<int>();
            IList<int> nonNegativeSequence;
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

            nonNegativeSequence = inputNumbers.Where(x => x >= 0).ToList<int>();

            Console.WriteLine(SequenceWithoutNegativeNumbersStr, String.Join(", ", nonNegativeSequence));
        }
    }
}
