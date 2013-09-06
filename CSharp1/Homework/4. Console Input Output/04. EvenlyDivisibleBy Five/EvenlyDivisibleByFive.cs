using System;

class EvenlyDivisibleByFive
{
    static void Main()
    {
        Console.Write("Enter first positive number: ");
        decimal num1 = decimal.Parse(Console.ReadLine());
        Console.Write("Enter second positive number: ");
        decimal num2 = decimal.Parse(Console.ReadLine());
        int numOfDivisibles = 0;
        for (int i = (int)Math.Min(num1, num2); i <= (int)Math.Max(num1, num2); i++)
        {
            if (i % 5 == 0)
                numOfDivisibles++;
        }

        Console.WriteLine("Total number of divisible by five numbers between {0} and {1} is {2}", 
                            Math.Min(num1, num2), Math.Max(num1, num2), numOfDivisibles);
    }
}
