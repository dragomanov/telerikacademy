/*
 * 9. Using the Queue<T> class write a program to print its first 50 members for given N. 
 * Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
 */

using System;
using System.Collections.Generic;

namespace LinearDataStructures
{
    class PrintSequenceFromN
    {
        private const string PrintSequenceStr = "The sequence with N = {0} is: {1}";
        private const string IntroStr = "Enter a starting number for the sequence: ";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";

        static void Main(string[] args)
        {
            var sequenceQueue = new Queue<int>();
            var sequence = new List<int>();
            string inputStr;
            int number;

            Console.Write(IntroStr);
            inputStr = Console.ReadLine();

            while (true)
            {
                try
                {
                    number = Int32.Parse(inputStr);
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(InvalidFormat);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(InvalidNumber);
                }
            }

            int currentS = number;
            sequence.Add(currentS);

            for (int i = 0; i < 16; i++)
            {
                sequenceQueue.Enqueue(currentS + 1);
                sequence.Add(currentS + 1);
                sequenceQueue.Enqueue(2 * currentS + 1);
                sequence.Add(2 * currentS + 1);
                sequenceQueue.Enqueue(currentS + 2);
                sequence.Add(currentS + 2);
                currentS = sequenceQueue.Dequeue();
            }

            sequence.Add(currentS + 1);

            Console.WriteLine(PrintSequenceStr, number, String.Join(", ", sequence));
        }
    }
}
