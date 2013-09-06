/*********************************************************
 * 
 * 3. Write a program to convert decimal numbers to their 
 * hexadecimal representation.
 * 
 *********************************************************/

using System;

class ConvertDecimalToHex
{
    static string DecimalToHex(int dec)
    {
        char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        string hex = "";

        do
        {
            int remainder = dec % 16;
            hex = alphabet[remainder] + hex;
            dec = dec / 16;
        } while (dec > 0);

        return hex;
    }

    static void Main()
    {
        Random rng = new Random();
        int dec = rng.Next(256);
        Console.WriteLine("Number in decimal: " + dec);
        Console.WriteLine("Number in hexadecimal: " + DecimalToHex(dec));
    }
}
