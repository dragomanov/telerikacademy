/*********************************************************
 * 
 * 2. Write a program to convert binary numbers to their 
 * decimal representation.
 * 
 *********************************************************/

using System;

class ConvertBinaryToDecimal
{
    static int BinaryToDecimal(string bin)
    {
        int dec = 0;

        for (int i = bin.Length - 1, j = 0; i >= 0; i--, j++)
        {
            dec += (bin[j] - 48) * (int)Math.Pow(2, i);
        }

        return dec;
    }

    static void Main()
    {
        Random rng = new Random();
        string bin = Convert.ToString(rng.Next(256), 2);
        Console.WriteLine("Number in binary: " + bin);
        Console.WriteLine("Number in decimal: " + BinaryToDecimal(bin));
    }
}
