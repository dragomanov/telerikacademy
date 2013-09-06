using System;

class ExchangeKBits
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        uint number;

        // Check if the entered string is a valid integer
        while (!uint.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("An integer is a whole number in the range [" + uint.MinValue + ", " + uint.MaxValue + "]. Try again: ");
        }

        Console.Write("Enter first bit position: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter second bit position: ");
        int q = int.Parse(Console.ReadLine()); ;
        Console.Write("Enter number of bits to exchange: ");
        int k = int.Parse(Console.ReadLine()); ;

        if (Math.Abs(p - q) < k)
        {
            Console.WriteLine("Bits to exchange overlap!");
            return;
        }

        string bitStr = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine(("The number " + number + " is binary is:").PadRight(38) + bitStr);

        // Swap bits
        char[] newStr = new Char[32];
        newStr = bitStr.ToCharArray();
        for (int i = 0; i < k; i++)
        {
            newStr[31 - p - i] = bitStr[31 - q - i];
            newStr[31 - q - i] = bitStr[31 - p - i];
        }

        // Convert the new_bitStr from string to unsigned integer
        string new_bitStr = new String(newStr);
        uint new_num = Convert.ToUInt32(new_bitStr, 2);

        Console.WriteLine(("The new number is: " + new_num).PadRight(37) + "(" + new_bitStr + ")");

        Console.WriteLine();
        Console.Write(" ");
        for (int i = 10; i < 32; i++)
        {
            Console.Write(((42 - i - 1) / 10).ToString().PadLeft(2));
        }
        Console.WriteLine();

        Console.Write(" ");
        for (int i = 0; i < 32; i++)
        {
            Console.Write(((32 - i - 1) % 10).ToString().PadLeft(2));
        }
        Console.WriteLine();

        Console.WriteLine(new String('-', 67));

        Console.Write("| ");
        for (int i = 0; i < 32; i++)
        {
            Console.Write("{0} ", bitStr[i]);
        }
        Console.WriteLine("| " + number);

        Console.WriteLine(new String('-', 67));

        Console.Write("| ");
        for (int i = 0; i < 32; i++)
        {
            Console.Write("{0} ", newStr[i]);
        }
        Console.WriteLine("| " + new_num);

        Console.WriteLine(new String('-', 67));
    }
}
