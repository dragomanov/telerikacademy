/* 
 * 2. Write a program that reads N integers from the console and reverses them using a stack. 
 * Use the Stack<int> class.
 */

using System;
using System.Collections.Generic;

namespace LinearDataStructures
{
    class ReverseInputWithStack
    {
        private const string IntroStr = "Enter a sequence of integers, each on a new line, ending the sequence with an empty line:";
        private const string InvalidFormat = "Invalid format of the integer!";
        private const string InvalidNumber = "The number must be an integer!";
        private const string ReversedStr = "Numbers in reversed order:";

        static void Main(string[] args)
        {
            Stack<int> numbersStack = new Stack<int>();
            IList<int> reversedNumbers = new List<int>();
            string inputStr;
            int number;

            Console.WriteLine(IntroStr);

            while (true)
            {
                inputStr = Console.ReadLine();

                try
                {
                    number = Int32.Parse(inputStr);
                    numbersStack.Push(number);
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

            for (int i = 0, len = numbersStack.Count; i < len; i++)
            {
                reversedNumbers.Add(numbersStack.Pop());
            }

            Console.WriteLine(ReversedStr);

            foreach (var num in reversedNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
