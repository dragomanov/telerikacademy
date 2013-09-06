using System;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int fireSize = n / 2;
        int torchSize = n / 2;
        string[] fire = new string[fireSize];

        for (int fireLine = 0; fireLine < fireSize; fireLine++)
        {
            string dots = new string('.', fireSize - fireLine - 1);
            string flame = '#' + new string('.', fireLine * 2) + '#';
            fire[fireLine] = dots + flame + dots;
            Console.WriteLine(fire[fireLine]);
        }

        for (int lowerFireLine = fireSize - 1; lowerFireLine >= fireSize / 2; lowerFireLine--)
        {
            Console.WriteLine(fire[lowerFireLine]);
        }

        Console.WriteLine(new string('-', n));

        for (int torchLine = 0; torchLine < torchSize; torchLine++)
        {
            string torch = new string('\\', torchSize - torchLine) + new string('/', torchSize - torchLine);
            string dots = new string('.', torchLine);
            Console.WriteLine(dots + torch + dots);
        }
    }
}
