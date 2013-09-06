using System;
using System.Collections.Generic;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        Dictionary< string, int > cardsStrength = new Dictionary< string, int >()
        {
            {"2", 10}, {"3", 9}, {"4", 8}, {"5", 7}, {"6", 6}, {"7", 5}, {"8", 4}, {"9", 3}, {"10", 2}, {"A", 1}, {"J", 11}, {"Q", 12}, {"K", 13}
        };

        int rounds = int.Parse(Console.ReadLine());
        BigInteger p1Score = 0;
        BigInteger p2Score = 0;
        int p1GamesWon = 0;
        int p2GamesWon = 0;
        bool p1XWins = false;
        bool p2XWins = false;

        for (int round = 0; round < rounds; round++)
        {
            int p1HandStrength = 0;
            bool p1XDrawn = false;
            for (int i = 0; i < 3; i++)
            {
                string card = Console.ReadLine();
                if (cardsStrength.ContainsKey(card))
                {
                    p1HandStrength += cardsStrength[card];
                }
                else if (card == "Z")
                {
                    p1Score *= 2;
                }
                else if (card == "Y")
                {
                    p1Score -= 200;
                }
                else if (card == "X")
                {
                    p1XDrawn = true;
                }
            }
            
            int p2HandStrength = 0;
            bool p2XDrawn = false;
            for (int i = 0; i < 3; i++)
            {
                string card = Console.ReadLine();
                if (cardsStrength.ContainsKey(card))
                {
                    p2HandStrength += cardsStrength[card];
                }
                else if (card == "Z")
                {
                    p2Score *= 2;
                }
                else if (card == "Y")
                {
                    p2Score -= 200;
                }
                else if (card == "X")
                {
                    p2XDrawn = true;
                }
            }

            if (p1XDrawn && p2XDrawn)
            {
                p1Score += 50;
                p2Score += 50;
            }
            else if (p1XDrawn && !p2XWins)
            {
                p1XWins = true;
            }
            else if (p2XDrawn && !p1XWins)
            {
                p2XWins = true;
            }
            else if (p1HandStrength > p2HandStrength)
            {
                p1GamesWon++;
                p1Score += p1HandStrength;
            }
            else if (p2HandStrength > p1HandStrength)
            {
                p2GamesWon++;
                p2Score += p2HandStrength;
            }
        }

        if (p1XWins)
        {
            Console.WriteLine("X card drawn! Player one wins the match!");
        }
        else if (p2XWins)
        {
            Console.WriteLine("X card drawn! Player two wins the match!");
        }
        else if (p1GamesWon > p2GamesWon)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: " + p1Score);
            Console.WriteLine("Games won: " + p1GamesWon);
        }
        else if (p2GamesWon > p1GamesWon)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: " + p2Score);
            Console.WriteLine("Games won: " + p2GamesWon);
        }
        else if (p1GamesWon == p2GamesWon)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: " + p1Score);
        }
    }
}
