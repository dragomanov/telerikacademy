using System;
using System.Numerics;

class TailOfZeroes
{
    static BigInteger Factorial(double n)
    {
        BigInteger result = 1;
        Console.Write("Calculating factorial ");
        for (int i = 1; i <= n; i++)
        {
            if (i % 5000 == 0)
            {
                Console.Write('.');
            }
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger result = Factorial(n);
        int countOfZeroes = 0;
        Console.WriteLine();
        Console.Write("Calculating number of zeroes ");
        while (result % 10 == 0)
        {
            result /= 10;
            countOfZeroes++;
            if (countOfZeroes % 1000 == 0)
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
        Console.WriteLine("Number of trailing zeroes is: " + countOfZeroes);
    }
}
