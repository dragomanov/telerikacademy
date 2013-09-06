using System;

class PrintTenNumbersFromSequence
{
    static void Main()
    {
        for (int i = 2; i < 12; i++)
        {
            Console.Write((i%2==1)?"-{0}":"{0}", i);
            if (i != 11) Console.Write(", ");
        }
        Console.WriteLine();
    }
}
