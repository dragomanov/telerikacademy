/**********************************************************
 * 
 * 2. Write a method ReadNumber(int start, int end) 
 * that enters an integer number in given range 
 * [start…end]. If an invalid number or non-number text 
 * is entered, the method should throw an exception. 
 * Using this method write a program that enters 10 
 * numbers:
 * 	a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 * 
 **********************************************************/

using System;

class ReadTenNumsFromOneToHundred
{
    static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();

        try
        {
            int num = int.Parse(input);
            if (start > num || num > end)
            {
                throw new ArgumentOutOfRangeException(string.Format("Number should be between {0} and {1}. ", start - 1, end + 1), new Exception());
            }
            return num;
        }
        catch (FormatException)
        {
            throw new FormatException("Entered string is not a number. ");
        }
    }

    static void Main()
    {
        int[] nums = new int[10];
        int start = 2;

        for (int i = 0; i < 10; i++)
        {
            while (true)
            {
                try
                {
                    nums[i] = ReadNumber(start, 90 + i);
                    break;
                }
                catch (FormatException fe)
                {
                    Console.Write(fe.Message + "Try again: ");
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.Write(aoore.Message + "Try again: ");
                }
            }
            start = nums[i] + 1;
        }

        Console.WriteLine("Numbers are: 1 < " + String.Join(" < ", nums) + " < 100");
    }
}
