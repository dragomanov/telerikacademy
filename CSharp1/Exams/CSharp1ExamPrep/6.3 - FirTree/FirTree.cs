using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            string dots = new string('.', n - i - 2);
            string stars = new string('*', 1 + i * 2);
            string str = dots + stars + dots;
            Console.WriteLine(str);
        }

        Console.WriteLine(new string('.', n - 2) + '*' + new string('.', n - 2));
    }
}
