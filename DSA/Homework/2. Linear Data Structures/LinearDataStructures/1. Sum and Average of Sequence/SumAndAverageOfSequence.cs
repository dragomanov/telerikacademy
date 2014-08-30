/*
 * 1. Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. 
 * Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    class SumAndAverageOfSequence
    {
        private const string IntroStr = "Enter a sequence of positive integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the positive integer!";
        private const string InvalidNumber = "The number must be a positive integer!";
        private const string SumStr = "The sum of all the elements is {0}";
        private const string AverageStr = "The average of all the elements is {0}";

        static void Main(string[] args)
        {
            IList<int> sequence = new List<int>();
            string inputStr;
            int number;

            Console.WriteLine(IntroStr);

            while (true)
            {
                inputStr = Console.ReadLine();

                try
                {
                    number = Int32.Parse(inputStr);

                    if (number <= 0)
                    {
                        throw new OverflowException();
                    }

                    sequence.Add(number);
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

            Console.WriteLine(SumStr, sequence.Sum());
            Console.WriteLine(AverageStr, sequence.Average());
        }
    }
}
