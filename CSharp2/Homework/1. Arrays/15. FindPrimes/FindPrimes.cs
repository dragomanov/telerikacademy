/*******************************************************
 * Write a program that finds all prime numbers in the 
 * range [1...10 000 000]. Use the sieve of Eratosthenes 
 * algorithm (find it in Wikipedia).
 *******************************************************/

using System;

class FindPrimes
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the array:");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        int max = (int)Math.Sqrt(n);

        for (int i = 2; i < max; i++)
        {
            if (array[i] == 0)
            {
                for (int m = (i * i); m < n; m += i)
                {
                    array[m] = 1;
                }
            }
        }
        for (int i = 2; i < n; i++)
        {
            if (array[i] == 1) continue;
            if (i > 2) Console.Write(",");
            Console.Write("{0}", i);
        }
        Console.WriteLine("");
    }
}
