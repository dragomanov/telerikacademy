﻿using System;

class ReturnBit
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int number;

        // Check if the entered string is a valid integer
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("An integer is a whole number in the range [" + int.MinValue + ", " + int.MaxValue + "]. Try again: ");
        }

        byte bPos;
        Console.Write("Enter a bit the get it's value (from right starting at 0): ");

        // Check if entered string is a valid bit position for an integer
        while (!byte.TryParse(Console.ReadLine(), out bPos) || (bPos < 0) || (bPos > 31))
        {
            Console.Write("An interger has only 32 bits. Enter a whole number in the range [0, 31]: ");
        }

        // Bitwise AND with 2^bPos, so evaluation of the operation returns 2^bPos or 0 depending if the bPos-th bit is set
        // Shift number bPos positions to the right (dividing the number bPos times by 2, effectively by 2^bPos) assigning bit 1 or 0
        byte bit = (byte)((number & (int)Math.Pow(2, bPos)) >> bPos);
        Console.WriteLine("The number " + number + " in binary is: " + Convert.ToString(number, 2));
        Console.WriteLine("The value of bit " + bPos + " of the number is {0}", bit);
    }
}
