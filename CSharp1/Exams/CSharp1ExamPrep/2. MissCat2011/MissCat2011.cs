using System;

class MissCat2011
{
    static void Main()
    {
        int numOfVotes = int.Parse(Console.ReadLine());
        int[] votes = new int[11];
        for (int i = 0; i < numOfVotes; i++)
        {
            int vote = int.Parse(Console.ReadLine());
            votes[vote]++;
        }

        int winner = 1;
        for (int i = 1; i <= 10; i++)
        {
            if (votes[winner] < votes[i])
            {
                winner = i;
            }
        }

        Console.WriteLine(winner);
    }
}
