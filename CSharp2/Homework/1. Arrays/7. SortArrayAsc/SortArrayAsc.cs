/*******************************************************
 * Sorting an array means to arrange its elements in 
 * increasing order. Write a program to sort an array. 
 * Use the "selection sort" algorithm: Find the smallest 
 * element, move it at the first position, find the 
 * smallest from the rest, move it at the second 
 * position, etc.
 *******************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

class SortArrayAsc
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements in the array:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the elements, each on a new line:");

        int[] arrNums = new int[n];
        for (int i = 0; i < n; i++)
        {
            arrNums[i] = int.Parse(Console.ReadLine());
        }

        PrintSortedArray(arrNums);

        // RunNTests(int.Parse(Console.ReadLine()));
    }

    static void PrintSortedArray(int[] arrNums)
    {
        Console.WriteLine("Original array: {" + String.Join(", ", arrNums) + '}');

        for (int i = 0; i < arrNums.Length; i++)
        {
            int currMin = arrNums[i];
            int currIndex = i;

            for (int j = i; j < arrNums.Length; j++)
            {
                if (arrNums[j] < currMin)
                {
                    currMin = arrNums[j];
                    currIndex = j;
                }
            }

            SwapInts(i, currIndex, arrNums);
        }

        Console.WriteLine("Sorted array: {" + String.Join(", ", arrNums) + '}');
    }

    static void SwapInts(int n, int k, int[] arrElems)
    {
        int tempElement = arrElems[n];
        arrElems[n] = arrElems[k];
        arrElems[k] = tempElement;
    }

    static void RunNTests(int numOfTests)
    {
        Random rng = new Random();
        for (int i = 0; i < numOfTests; i++)
        {
            int n = rng.Next(2, 10);
            List<int> arrNums = new List<int>();
            for (int j = 0; j < n; j++)
            {
                arrNums.Add(rng.Next(1000));
            }
            PrintSortedArray(arrNums.ToArray());
            Console.WriteLine(new string('-', 79));
        }
    }
}