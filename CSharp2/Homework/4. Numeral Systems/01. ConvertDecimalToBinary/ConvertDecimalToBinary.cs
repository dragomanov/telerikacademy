/*********************************************************
 * 
 * 1. Write a program to convert decimal numbers to their 
 * binary representation.
 * 
 *********************************************************/

using System;

class ConvertDecimalToBinary
{
    static string DecimalToBinary(int dec)
    {
        string bin = "";

        do
        {
            int remainder = dec % 2;
            bin = remainder + bin;
            dec = dec / 2;
        } while (dec > 0);

        return bin;
    }

    static void Main()
    {
        Random rng = new Random();
        int dec = rng.Next(256);
        Console.WriteLine("Number in decimal: " + dec);
        Console.WriteLine("Number in binary: " + DecimalToBinary(dec));
    }
}
