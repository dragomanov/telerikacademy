/*********************************************************
 * 
 * 7. Write a program to convert from any numeral system 
 * of given base s to any other numeral system of base 
 * d (2 ≤ s, d ≤  16).
 * 
 *********************************************************/

using System;

class ConvertToNumeralBase
{
    static int ToDecimal(string num, int fromBase)
    {
        char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        int dec = 0;
        num = num.ToUpper();

        for (int i = num.Length - 1, j = 0; i >= 0; i--, j++)
        {
            dec += Array.IndexOf(alphabet, num[j]) * (int)Math.Pow(fromBase, i);
        }

        return dec;
    }

    static string DecimalToBase(int num, int toBase)
    {
        char[] alphabet = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        string newNum = "";

        do
        {
            int remainder = num % toBase;
            newNum = alphabet[remainder] + newNum;
            num = num / toBase;
        } while (num > 0);

        return newNum;
    }

    static string ToNumberalBase(string num, int fromBase, int toBase)
    {
        int toDec = ToDecimal(num, fromBase);
        string convertedNum = DecimalToBase(toDec, toBase);

        return convertedNum;
    }

    static void Main()
    {
        Random rng = new Random();
        int num = rng.Next(256);
        string binNum = Convert.ToString(num, 2);
        // string octNum = Convert.ToString(num, 8);
        // string hexNum = Convert.ToString(num, 16);
        string fromBinToOct = ToNumberalBase(binNum, 2, 8);
        string fromOctToHex = ToNumberalBase(fromBinToOct, 8, 16);
        Console.WriteLine("Number in decimal: " + num);
        Console.WriteLine("Number in binary: " + binNum);
        Console.WriteLine("Number in octal: " + fromBinToOct);
        Console.WriteLine("Number in hexadecimal: " + fromOctToHex);
    }
}
