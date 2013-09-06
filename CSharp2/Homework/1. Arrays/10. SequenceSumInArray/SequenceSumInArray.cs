/*******************************************************
 * Write a program that finds in given array of integers
 * a sequence of given sum S (if present). Example:
 * {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
 *******************************************************/

using System;

class SequenceSumInArray
{
    static void Main()
    {
        Console.WriteLine("Enter the sum of the elements:");
        int sum = int.Parse(Console.ReadLine());

        int[] arrElems = { 4, 3, 1, 4, 2, 5, 8 };
        int subSum = 0;
        int endIndex = 0;
        int startIndex = 0;
        for (int i = 0; i < arrElems.Length - 1; i++)
        {
            for (int j = i; j < arrElems.Length; j++)
            {
                subSum = subSum + arrElems[j];

                if (subSum == sum)
                {
                    endIndex = j;
                    Console.Write("Sequence with sum: {");
                    for (int p = startIndex; p <= endIndex; p++)
                    {
                        Console.Write("{0}, ", arrElems[p]);
                    }
                    Console.Write("\b\b}");
                    Console.WriteLine();

                    subSum = 0;
                    break;
                }
                else if (subSum > sum)
                {
                    subSum = 0;
                    startIndex = i + 1;
                    endIndex = j;
                    break;
                }
                else if (subSum < sum)
                {
                    endIndex = endIndex + 1;
                }
            }
        }
    }
}
