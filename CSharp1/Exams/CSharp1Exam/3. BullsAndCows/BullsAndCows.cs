using System;
using System.Linq;

class BullsAndCows
{
    static void Main()
    {
        string secretNum = Console.ReadLine();
        int guessBulls = int.Parse(Console.ReadLine());
        int guessCows = int.Parse(Console.ReadLine());

        var allNumbers = from d1 in Enumerable.Range(1, 9)
                    from d2 in Enumerable.Range(1, 9)
                    from d3 in Enumerable.Range(1, 9)
                    from d4 in Enumerable.Range(1, 9)
                    select new string(new[]
                    {
                        (char)('0' + d1),
                        (char)('0' + d2),
                        (char)('0' + d3),
                        (char)('0' + d4),
                    });
        string matchingGuesses = "";
        foreach (string guess in allNumbers)
        {
            int bulls = 0;
            int cows = 0;
            string guessNoBulls = "";
            string secretNoBulls = "";
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretNum[i])
                {
                    bulls++;
                }
                else
                {
                    secretNoBulls += secretNum[i];
                    guessNoBulls += guess[i];
                }
            }

            foreach (char guessDigit in guessNoBulls)
            {
                int foundCowAt = secretNoBulls.IndexOf(guessDigit);
                if (foundCowAt > -1)
                {
                    secretNoBulls = secretNoBulls.Remove(foundCowAt, 1);
                    cows++;
                }
            }

            if (bulls == guessBulls && cows == guessCows)
            {
                matchingGuesses += guess + " ";
            }
        }

        if (matchingGuesses == "")
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(matchingGuesses);
        }
    }
}
