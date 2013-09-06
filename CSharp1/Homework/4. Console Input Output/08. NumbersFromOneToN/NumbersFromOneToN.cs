using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Enter an integer bigger than 1: ");
        int numberN = int.Parse(Console.ReadLine());
        Console.WriteLine("The numbers from 1 to {0} are: ", numberN);
        for (int i = 1; i <= numberN; i++)
        {
            Console.WriteLine(i);
        }
    }
}
