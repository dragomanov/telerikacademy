/*******************************************************
 * Write a program that finds the maximal increasing 
 * sequence in an array. Example: 
 * {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
 *******************************************************/

using System;
using System.Collections.Generic;

class MaxIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Enter an array of integers (Ex: \"3, 2, 3, 4, 2, 2, 4\"):");
        List<int> arrElems = new List<int>();
        foreach (string num in Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        {
            arrElems.Add(int.Parse(num));
        }
        int longestIndexStart = 0;
        int longestLength = 1;

        for (int i = 0; i < arrElems.Count; i++)
        {
            for (int j = i, count = 1; j < arrElems.Count - 1; j++, count++)
            {
                if (arrElems[j] + 1 != arrElems[j + 1])
                {
                    if (count > longestLength)
                    {
                        longestLength = count;
                        longestIndexStart = i;
                    }
                    break;
                }
            }
        }

        int[] arrMaxSeq = new int[longestLength];
        for (int i = 0; i < longestLength; i++)
        {
            arrMaxSeq[i] = arrElems[longestIndexStart + i];
        }

        foreach (var element in arrMaxSeq)
        {
            Console.WriteLine(element);
        }
    }
}
