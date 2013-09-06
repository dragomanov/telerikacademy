using System;

class MinAndMaxValue
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter {0} integers:", n);
        int[] nIntegers = new int[n];
        for (int i = 0; i < nIntegers.Length; i++)
        {
            Console.Write("Int{0} = ", i + 1);
            nIntegers[i] = int.Parse(Console.ReadLine());
        }
        int minInt = nIntegers[0];
        int maxInt = nIntegers[0];
        foreach (int value in nIntegers)
        {
            if (value < minInt) minInt = value;
            if (value > maxInt) maxInt = value;
        }
        Console.WriteLine("The minimum number is {0}", minInt);
        Console.WriteLine("The maximum number is {0}", maxInt);
    }
}
