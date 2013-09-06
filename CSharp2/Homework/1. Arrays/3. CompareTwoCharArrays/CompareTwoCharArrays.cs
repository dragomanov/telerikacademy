/*******************************************************
 * Write a program that compares two char arrays 
 * lexicographically (letter by letter).
 *******************************************************/

using System;

class CompareTwoCharArrays
{
    static void Main()
    {
        Console.WriteLine("Enter 2 strings to compare them character by character (each on new line): ");
        char[] arrFirstStr = Console.ReadLine().ToCharArray();
        char[] arrSecondStr = Console.ReadLine().ToCharArray();

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| index | arrFirstStr | arrSecondStr | Equal? |");
        Console.WriteLine("-----------------------------------------------");
        for (int i = 0; i < Math.Min(arrFirstStr.Length, arrSecondStr.Length); i++)
        {
            string paddedI = i.ToString().PadLeft(5);
            string paddedFirstStr = arrFirstStr[i] + new string(' ', 10);
            string paddedSecondStr = arrSecondStr[i] + new string(' ', 11);
            string paddedComparison = (arrFirstStr[i] == arrSecondStr[i] ? true : false).ToString().PadRight(6);
            Console.WriteLine("| " + paddedI + " | " + paddedFirstStr + " | " + paddedSecondStr + " | " + paddedComparison + " |");
        }
        Console.WriteLine("-----------------------------------------------");
    }
}
