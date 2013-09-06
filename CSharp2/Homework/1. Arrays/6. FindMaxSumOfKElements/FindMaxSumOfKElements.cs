/*******************************************************
 * Write a program that reads two integer numbers N 
 * and K and an array of N elements from the console. 
 * Find in the array those K elements that have 
 * maximal sum.
 *******************************************************/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Linq;

class FindMaxSumOfKElements
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Enter number of elements in array:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numer of elements to sum:");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter elements of the array one on each line:");
        List<decimal> arrNums = new List<decimal>();
        for (int i = 0; i < n; i++)
        {
            arrNums.Add(decimal.Parse(Console.ReadLine()));
        }

        PrintMaxSumOfKElements(n, k, arrNums);

        // RunNTests(int.Parse(Console.ReadLine()));
    }

    static void PrintMaxSumOfKElements(int n, int k, List<decimal> arrNums)
    {
        List<decimal> arrCopyOfNums = arrNums.ToList();
        List<decimal> arrMaxSumElems = new List<decimal>();
        for (int i = 0; i < k; i++)
        {
            arrMaxSumElems.Add(arrCopyOfNums.Max());
            arrCopyOfNums.Remove(arrCopyOfNums.Max());
        }

        Console.WriteLine("Elemets of array: {0}", string.Join(", ", arrNums));
        Console.WriteLine("Elements with maximal sum: {0}", string.Join(", ", arrMaxSumElems));
    }

    static void RunNTests(int numOfTests)
    {
        Random rng = new Random();
        for (int i = 0; i < numOfTests; i++)
        {
            int n = rng.Next(2, 10);
            int k = rng.Next(2, n);
            List<decimal> arrNums = new List<decimal>();
            for (int j = 0; j < n; j++)
            {
                arrNums.Add((decimal)(rng.Next(1000) / Math.Pow(10, rng.Next(3))));
            }
            PrintMaxSumOfKElements(n, k, arrNums);
            Console.WriteLine(new string('-', 79));
        }
    }
}
