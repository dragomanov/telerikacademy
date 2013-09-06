using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] map = new string[n];

        for (int i = 0; i < n; i++)
        {
            map[i] = new string('.', i) + '*' + new string('.', n - (i + 1));
            Console.WriteLine(map[i]);
        }

        for (int i = n - 2; i >= 0; i--)
        {
            Console.WriteLine(map[i]);
        }
    }
}
