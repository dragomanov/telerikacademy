using System;

class ChangeBit
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter bit value: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter the bit position to set to {0} (from right starting at 0): ", v);
        int p = int.Parse(Console.ReadLine());

        // Bitwise AND with 2^p, so evaluation of the operation returns 2^p or 0 depending if the p-th bit is set
        // Shift the number p positions to the right (dividing the number p times by 2, effectively by 2^p) thus assigning bit 1 or 0
        int new_n = n;
        if (v == 0)
        {
            int mask = ~(int)Math.Pow(2, p);
            new_n = n & mask;
        }
        else if (v == 1)
        {
            int mask = (int)Math.Pow(2, p);
            new_n = n | mask;
        }
        else
        {
            Console.WriteLine("Bit value can be either 0 or 1"); // Display error message
            return; // Exit program
        }
        Console.WriteLine("The number " + n + " in binary is: " + Convert.ToString(n, 2));
        Console.WriteLine("The modified number is: {0} ({1})", new_n, Convert.ToString(new_n, 2));
    }
}
