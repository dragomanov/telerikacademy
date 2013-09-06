/**********************************************************
 * 
 * 1. Write a program that reads a text file and prints on 
 * the console its odd lines.
 * 
 **********************************************************/

using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        Console.WriteLine("Enter filename to print it's odd lines");
        string fn = Console.ReadLine();
        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            string line = "";
            bool isOdd = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (isOdd)
                {
                    Console.WriteLine(line);
                }
                isOdd = !isOdd;
            }
        }
    }
}
