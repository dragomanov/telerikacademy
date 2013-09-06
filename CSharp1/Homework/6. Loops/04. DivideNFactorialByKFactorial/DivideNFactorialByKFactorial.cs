using System;
using System.Numerics;

class DivideNFactorialByKFactorial
{
    static BigInteger Factoriel(uint n)
    {
        return n > 1 ? n * Factoriel(n - 1) : 1;
    }

    static void Main()
    {
        Console.Write("Enter a possitive integer number: ");
        uint n;
        // Check if the entered string is a valid integer
        while (!uint.TryParse(Console.ReadLine(), out n))
        {
            Console.Write("A possitive integer is a whole number in the range [" + uint.MinValue + ", " + uint.MaxValue + "]: ");
        }

        Console.Write("Enter another integer number: ");
        uint k;
        // Check if the entered string is a valid integer
        while (!uint.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("A possitive is a whole number in the range [" + uint.MinValue + ", " + uint.MaxValue + "]: ");
        }

        Console.WriteLine("{0}! / {1}! = {2:e}", n, k, Factoriel(n) / Factoriel(k));
    }
}
