/*******************************************************
 * Write a program that creates an array containing all 
 * letters from the alphabet (A-Z). Read a word from 
 * the console and print the index of each of its letters 
 * in the array.
 *******************************************************/

using System;

class EncodeWord
{
    static void Main()
    {
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string input;
        Console.WriteLine("Please enter a single word:");
        input = Console.ReadLine();
        string output = new string(input.ToCharArray());
        string outputUpp = output.ToUpper();
        char[] word = outputUpp.ToCharArray();


        for (int i = 0; i < alphabet.Length - 1; i++)
        {
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == alphabet[i])
                {
                    Console.WriteLine("Corresponding index to letter {0} in the array is {1}", word[j], i);
                }
            }
        }
    }
}
