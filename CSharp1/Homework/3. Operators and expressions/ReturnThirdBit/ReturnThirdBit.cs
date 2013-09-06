using System;

class ReturnThirdBit
{
    static void Main()
    {
        Console.Write("Enter a number to see if it's 3rd bit (from right starting at 0) is set (is 1): ");
        int number = int.Parse(Console.ReadLine());

        // Bitwise AND with 8, so evaluation of the operation returns 8 or 0 depending if the 3rd bit is set
        // Shift the number 3 positions to the right (dividing the number 3 times by 2, effectively by 8) thus assigning bit 1 or 0
        byte bit = (byte)((number & 8) >> 3);
        Console.WriteLine("The 3rd bit of the number is {0}", bit);
    }
}
