/*********************************************************
 * 
 * 8. Write a program that shows the binary 
 * representation of given 16-bit signed integer number 
 * (the C# type short).
 * 
 *********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SignedShortToBinary
{
    static string ShortToBinary(short dec)
    {
        string bin = "";
        char sign = dec < 0 ? '1' : '0';
        if (sign == '1')
        {
            dec += 1;
            dec += short.MaxValue;
        }

        do
        {
            int remainder = dec % 2;
            bin = remainder + bin;
            dec = (short)(dec / 2);
        } while (dec > 0);

        return sign + bin.PadLeft(15, '0');
    }

    static void Main()
    {
        Random rng = new Random();
        short num = (short)rng.Next(short.MinValue, short.MaxValue);
        Console.WriteLine("Number in short: " + num);
        Console.WriteLine("Number in binary: " + ShortToBinary(num));
    }
}