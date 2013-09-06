using System;

class BitAtPossitionIsSet
{
    static void Main()
    {
        Console.Write("Enter a number to see if a specific bit is set (is 1): ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter the bit to check (from right starting at 0): ");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine(v + " in binary is: " + Convert.ToString(v, 2));

        // Bitwise AND with 2^p, so evaluation of the operation returns 2^p or 0 depending if the p-th bit is set
        // Shift the number p positions to the right (dividing the number p times by 2, effectively by 2^p) thus assigning bit 1 or 0
        byte bit = (byte)((v & (int)Math.Pow(2, p)) >> p);
        Console.WriteLine("The bit at possition {0} of {1} is {2}", p, v, bit);
    }
}
