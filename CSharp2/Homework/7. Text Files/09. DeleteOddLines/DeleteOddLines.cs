/***********************************************************
 * 
 * 9. Write a program that deletes from given text file all 
 * odd lines. The result should be in the same file.
 * 
 ***********************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to delete it's odd lines");
        string fn = Console.ReadLine();
        List<string> modifiedContents = new List<string>();

        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            string line = "";
            bool isOdd = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (!isOdd)
                {
                    modifiedContents.Add(line);
                }
                isOdd = !isOdd;
            }
        }

        File.WriteAllLines(fn, modifiedContents);

        Process.Start("Notepad", Directory.GetCurrentDirectory() + '\\' + fn);
    }
}
