/********************************************************
 * Write a program, that reads from the console an 
 * array of N integers and an integer K, sorts the array 
 * and using the method Array.BinSearch() finds 
 * the largest number in the array which is ≤ K.
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

class BinarySearch
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        int temp = 0;
        int min = 0;
        int answerIs;

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int j = 0; j < arr.Length - 1; j++)
        {
            min = j;
            for (int m = j + 1; m < arr.Length; m++)
            {
                if (arr[m] < arr[min])
                {
                    min = m;
                }
            }
            if (j != min)
            {
                temp = arr[j];
                arr[j] = arr[min];
                arr[min] = temp;
            }
        }

        if (arr[0] > k)
        {
            Console.WriteLine("There is no number that is less than or equal to k");
        }
        else
        {
            int IndexOfElement = Array.BinarySearch(arr, k);
            if (IndexOfElement >= 0) answerIs = arr[IndexOfElement];
            else answerIs = arr[~IndexOfElement - 1];
            Console.WriteLine("K is {0} and the number in this array which's <= K is {1}", k, answerIs);
        }
    }
}