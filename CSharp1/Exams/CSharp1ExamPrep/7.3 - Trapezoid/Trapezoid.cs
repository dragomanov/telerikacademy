using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('.', n) + new string('*', n));

        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine(new string('.', n - i - 1) + '*' + new string('.', n + i - 1) + '*');
        }

        Console.WriteLine(new string('*', 2 *n));
    }
}
