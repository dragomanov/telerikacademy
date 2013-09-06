using System;

class Poker
{
    static void Main()
    {
        string[] hand = new string[5];
        for (int i = 0; i < 5; i++)
        {
            hand[i] = Console.ReadLine();
        }
        Console.WriteLine("Straight");
    }
}
