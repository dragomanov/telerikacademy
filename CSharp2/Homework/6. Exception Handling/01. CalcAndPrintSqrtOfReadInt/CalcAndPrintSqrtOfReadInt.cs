/**********************************************************
 * 
 * 1. Write a program that reads an integer number and 
 * calculates and prints its square root. If the number is 
 * invalid or negative, print "Invalid number". In all 
 * cases finally print "Good bye". Use try-catch-finally.
 * 
 **********************************************************/

using System;

class CalcAndPrintSqrtOfReadInt
{
    static void Main()
    {
        Console.WriteLine("Enter an integer number:");
        string num = Console.ReadLine();

        try
        {
            int n = int.Parse(num);
            double sqrt = Math.Sqrt(n);
            if (double.IsNaN(sqrt))
            {
                throw new FormatException();
            }
            Console.WriteLine("The square root of {0} is {1}", num, sqrt);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
