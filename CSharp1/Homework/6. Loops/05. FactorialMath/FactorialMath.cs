using System;
using System.Numerics;

class FactorialMath
{
    static BigInteger Factorial(int n)
    {
        return n > 1 ? n * Factorial(n - 1) : 1;
    }

    static void Main()
    {
        Console.Write("Enter a possitive integer number: ");
        int n;
        // Check if the entered string is a valid integer
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.Write("A possitive integer is a whole number in the range [" + int.MinValue + ", " + int.MaxValue + "]: ");
        }

        Console.Write("Enter another integer number: ");
        int k;
        // Check if the entered string is a valid integer
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("A possitive is a whole number in the range [" + int.MinValue + ", " + int.MaxValue + "]: ");
        }

        Console.WriteLine("{0}! * {1}! / {2}! = {3:e}", n, k, Math.Abs(k - n), Factorial(n) * Factorial(k) / Factorial((int)Math.Abs(k - n)));
    }
}
