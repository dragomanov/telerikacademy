using System;

class DrunkenNumbers
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        int scoreMitko = 0;
        int scoreVladko = 0;
        for (int currRound = 0; currRound < rounds; currRound++)
        {
            int numWithoutLeadingZeros = Math.Abs(int.Parse(Console.ReadLine()));
            string drunkenNum = numWithoutLeadingZeros.ToString();

            for (int digit = 0; digit < (drunkenNum.Length + 1) / 2; digit++)
            {
                scoreMitko += drunkenNum[digit] - '0';
            }

            for (int digit = drunkenNum.Length / 2; digit < drunkenNum.Length; digit++)
			{
                scoreVladko += drunkenNum[digit] - '0';
			}
        }

        if (scoreMitko > scoreVladko)
        {
            Console.WriteLine("M " + (scoreMitko - scoreVladko));
        }
        else if (scoreVladko > scoreMitko)
        {
            Console.WriteLine("V " + (scoreVladko - scoreMitko));
        }
        else if (scoreMitko == scoreVladko)
        {
            Console.WriteLine("No " + (scoreMitko + scoreVladko));
        }
    }
}
