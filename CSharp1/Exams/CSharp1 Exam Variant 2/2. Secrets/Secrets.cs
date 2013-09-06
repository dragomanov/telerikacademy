using System;

class Secrets
{
    static void Main()
    {
        string input = Console.ReadLine();

        // Sanitation can be done with for loop checking for digits only and adding them to new string and then trimming start for leading zeros
        string number = input.TrimStart('-'); number = number.TrimStart('0');
        int numOfDigits = number.Length;
        int specialSum = 0;
        string secretAlphaSequence = "";

        for (int position = 1; position <= numOfDigits; position++)
        {
            int digit = number[numOfDigits - position] - '0';
            if (position % 2 == 0)  // Position is even
            {
                specialSum += digit * digit * position;
            }
            else
            {
                specialSum += digit * position * position;
            }
        }

        int startingChar = specialSum % 26;
        int lenSAS = specialSum % 10;

        if (lenSAS == 0)
        {
            secretAlphaSequence = input + " has no secret alpha-sequence";
        }
        else
        {
            for (int offset = 0; offset < lenSAS; offset++)
            {
                int nextChar = 'A' + ((startingChar + offset) % 26);
                secretAlphaSequence += (char)nextChar;
            }
        }

        Console.WriteLine(specialSum);
        Console.WriteLine(secretAlphaSequence);
    }
}
