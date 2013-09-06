/*********************************************************
 * 
 * 4. Write a program to convert hexadecimal numbers to 
 * their decimal representation.
 * 
 *********************************************************/

using System;

class ConvertHexToDecimal
{
    static int HexToDecimal(string hex)
    {
        char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        int dec = 0;
        hex = hex.ToUpper();

        for (int i = hex.Length - 1, j = 0; i >= 0; i--, j++)
        {
            dec += Array.IndexOf(alphabet, hex[j]) * (int)Math.Pow(16, i);
        }

        return dec;
    }

    static void Main()
    {
        Random rng = new Random();
        string hex = Convert.ToString(rng.Next(256), 16);
        Console.WriteLine("Number in hexadecimal: " + hex.ToUpper());
        Console.WriteLine("Number in decimal: " + HexToDecimal(hex));
    }
}
