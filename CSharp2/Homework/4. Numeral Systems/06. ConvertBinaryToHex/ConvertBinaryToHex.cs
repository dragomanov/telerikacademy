/*********************************************************
 * 
 * 6. Write a program to convert binary numbers to 
 * hexadecimal numbers (directly).
 * 
 *********************************************************/

using System;
using System.Collections.Generic;

class ConvertBinaryToHex
{
    static string BinaryToHex(string bin)
    {
        Dictionary<string, char> alphabet = new Dictionary<string, char>()
        {
            {"0000", '0'},
            {"0001", '1'},
            {"0010", '2'},
            {"0011", '3'},
            {"0100", '4'},
            {"0101", '5'},
            {"0110", '6'},
            {"0111", '7'},
            {"1000", '8'},
            {"1001", '9'},
            {"1010", 'A'},
            {"1011", 'B'},
            {"1100", 'C'},
            {"1101", 'D'},
            {"1110", 'E'},
            {"1111", 'F'},
        };

        int zeroes = 4 - (bin.Length % 4);
        if (zeroes != 4)
        {
            bin = new string('0', zeroes) + bin;
        }

        string hex = "";

        for (int i = 0; i < bin.Length; i += 4)
        {
            hex += alphabet[bin.Substring(i, 4)];
        }

        return hex;
    }

    static void Main()
    {
        Random rng = new Random();
        string bin = Convert.ToString(rng.Next(256), 2);
        Console.WriteLine("Number in binary: " + bin);
        Console.WriteLine("Number in hexadecimal: " + BinaryToHex(bin));
    }
}
