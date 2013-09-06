using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());

        for (int i = 0; i < 3; i++)
        {
            int lastdigit = k % 10;
            k = k / 10;
            k = k + (int)Math.Pow(10, k.ToString().Length) * lastdigit;
        }
        Console.WriteLine(k);
    }
}
