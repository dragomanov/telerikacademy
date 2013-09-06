/*******************************************************
 * Write a program that finds the maximal sequence of 
 * equal elements in an array.
 * Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
 *******************************************************/

using System;

class ReturnArrayWithLongestSequenceOfEqualElements
{
    static void Main()
    {
        Console.WriteLine("Enter an array of elements (Ex: \"2, 1, 1, 2, 3, 3, 2, 2, 2, 1\"):");
        string[] arrElems = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int longestIndexStart = 0;
        int longestLength = 1;

        for (int i = 0; i < arrElems.Length; i++)
        {
            for (int j = i, count = 1; j < arrElems.Length - 1; j++, count++)
            {
                if (arrElems[j] != arrElems[j+1])
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

        string[] arrMaxSeq = new string[longestLength];
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
