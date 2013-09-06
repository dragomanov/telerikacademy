using System;

class OneToN
{
    static void Main()
    {
        Console.Write("Enter a possitive integer number: ");
        uint num;

        // Check if the entered string is a valid integer
        while (!uint.TryParse(Console.ReadLine(), out num) && num == 0)
        {
            Console.Write("An integer is a whole number in the range [" + uint.MinValue + ", " + uint.MaxValue + "]: ");
        }

        Console.WriteLine("Numbers from 1 to " + num + ":");

        for (uint i = 1; i <= num; i++)
        {
            Console.WriteLine(i);
        }
    }
}
