/*
 * 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
 * how many times each of them occurs. 
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class NumberOccurancesInSequence
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string SequenceWithEvenOccurancesStr = "{0} occurs in the sequence {1} times";

        static void Main(string[] args)
        {
            IList<int> inputNumbers = new List<int>();
            IDictionary<int, int> sequenceWithEvenOccurances;
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

            sequenceWithEvenOccurances = inputNumbers.Distinct().ToDictionary<int, int>(x => x);

            foreach (var pair in sequenceWithEvenOccurances)
            {
                int occurances = inputNumbers.Count(x => x == pair.Key);
                Console.WriteLine(SequenceWithEvenOccurancesStr, pair.Key, occurances);
            }
        }
    }
}
