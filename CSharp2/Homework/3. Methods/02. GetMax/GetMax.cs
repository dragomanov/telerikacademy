/*******************************************************
 * Write a method GetMax() with two parameters that 
 * returns the bigger of two integers. Write a program 
 * that reads 3 integers from the console and prints the 
 * biggest of them using the method GetMax().
 *******************************************************/

using System;

class GetMax
{
    static int MaxInt(int a, int b)
    {
        return (a > b) ? a : b;
    }

    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());

        Console.WriteLine("Biggest number is: " + MaxInt(num1, MaxInt(num2, num3)));
    }
}
