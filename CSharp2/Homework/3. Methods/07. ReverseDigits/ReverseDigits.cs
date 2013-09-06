using System;
using System.Linq;

class ReverseDigits
{
    static decimal ReturnReverseDecimal(decimal num)
    {
        string numStr = num.ToString();
        string reversed = "";

        foreach (var chr in numStr.Reverse())
        {
            reversed += chr;
        }
        return Convert.ToDecimal(reversed);
    }

    static void Main()
    {
        Console.WriteLine("Enter decimal to reverse it's digits:");
        decimal num = decimal.Parse(Console.ReadLine());
        Console.WriteLine(ReturnReverseDecimal(num));
    }
}
