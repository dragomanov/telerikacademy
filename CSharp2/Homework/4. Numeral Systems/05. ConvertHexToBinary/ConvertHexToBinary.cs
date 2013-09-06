/*********************************************************
 * 
 * 5. Write a program to convert hexadecimal numbers to 
 * binary numbers (directly).
 * 
 *********************************************************/

using System;
using System.Collections.Generic;

class ConvertHexToBinary
{
    static string HexToBinary(string hex)
    {
        Dictionary<char, string> alphabet = new Dictionary<char, string>()
        {
            {'0', "0000"},
            {'1', "0001"},
            {'2', "0010"},
            {'3', "0011"},
            {'4', "0100"},
            {'5', "0101"},
            {'6', "0110"},
            {'7', "0111"},
            {'8', "1000"},
            {'9', "1001"},
            {'A', "1010"},
            {'B', "1011"},
            {'C', "1100"},
            {'D', "1101"},
            {'E', "1110"},
            {'F', "1111"},
        };

        string bin = "";
        hex = hex.ToUpper();

        for (int i = 0; i < hex.Length; i++)
        {
            bin += alphabet[hex[i]];
        }

        return bin;
    }

    static void Main()
    {
        Random rng = new Random();
        string hex = Convert.ToString(rng.Next(256), 16);
        Console.WriteLine("Number in hexadecimal: " + hex.ToUpper());
        Console.WriteLine("Number in binary: " + HexToBinary(hex));
    }
}
