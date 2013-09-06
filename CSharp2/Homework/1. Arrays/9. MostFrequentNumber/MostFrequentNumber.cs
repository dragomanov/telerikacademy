/*******************************************************
 * Write a program that finds the most frequent 
 * number in an array. Example:
 * {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
 *******************************************************/

using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static int[] MostFreqNumber(int[] array)
    {
        int numberOfDistinctElems = 0;

        int[][] lengthOfElements = new int[array.Length][];
        for (int i = 0, length = array.Length; i < length; i++)
        {
            bool doesntExist = true;
            for (int j = 0; j < numberOfDistinctElems; j++)
            {
                if (array[i] == lengthOfElements[j][0])
                {
                    lengthOfElements[j][1]++;
                    doesntExist = false;
                }
            }

            if (doesntExist)
            {
                lengthOfElements[numberOfDistinctElems] = new int[] { array[i], 1 };
                numberOfDistinctElems++;
            }
        }

        int biggestIndex = 0;
        for (int i = 0; i < numberOfDistinctElems; i++)
        {
            if (lengthOfElements[biggestIndex][1] < lengthOfElements[i][1])
            {
                biggestIndex = i;
            }
        }

        return lengthOfElements[biggestIndex];
    }

    static int[] MostFreqNumbers(int[] array)
    {
        Dictionary<int, int> lengthOfElements = new Dictionary<int, int>();
        for (int i = 0, length = array.Length; i < length; i++)
        {
            if (lengthOfElements.ContainsKey(array[i]))
            {
                lengthOfElements[array[i]]++;
            }
            else
            {
                lengthOfElements.Add(array[i], 1);
            }
        }

        int maxKey = array[0];
        foreach (var number in lengthOfElements)
        {
            if (number.Value > lengthOfElements[maxKey])
            {
                maxKey = number.Key;
            }
        }

        return new int[] { maxKey, lengthOfElements[maxKey] };
    }

    static void Main()
    {
        int[] arrElems = {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3};
        int[] majorant = MostFreqNumber(arrElems);
        Console.WriteLine("Elements in array: {" + String.Join(", ", arrElems) + '}');
        Console.WriteLine("{0} ({1} times)", majorant[0], majorant[1]);
    }
}
