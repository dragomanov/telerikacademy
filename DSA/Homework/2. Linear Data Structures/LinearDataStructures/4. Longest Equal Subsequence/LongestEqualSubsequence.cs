/*
 * 4. Write a method that finds the longest subsequence of equal numbers in given List<int> 
 * and returns the result as new List<int>. Write a program to test whether the method works correctly.
 */

using System;
using System.Collections.Generic;

namespace LinearDataStructures
{
    public class LongestEqualSubsequence
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string LongestSubsequenceStr = "Longest subsequence of equal numbers: {0}";

        static void Main(string[] args)
        {
            IList<int> inputNumbers = new List<int>();
            IList<int> longestSubsquence;
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

            longestSubsquence = GetLongestSubsequence(inputNumbers);

            Console.WriteLine(LongestSubsequenceStr, String.Join(", ", longestSubsquence));
        }

        public static IList<int> GetLongestSubsequence(IList<int> inputNumbers)
        {
            IList<int> longestSubsquence = new List<int>();
            IList<int> currentSequence = new List<int>();
            int sequenceNumber = inputNumbers.Count > 0 ? inputNumbers[0] : 0;

            for (int i = 0, len = inputNumbers.Count; i < len; i++)
            {
                int number = inputNumbers[i];

                if (number != sequenceNumber)
                {
                    sequenceNumber = number;
                    if (currentSequence.Count > longestSubsquence.Count)
                    {
                        longestSubsquence = new List<int>(currentSequence);
                    }
                    currentSequence.Clear();
                }

                currentSequence.Add(number);
            }

            if (currentSequence.Count > longestSubsquence.Count)
            {
                longestSubsquence = new List<int>(currentSequence);
            }

            return longestSubsquence;
        }
    }
}
