/*************************************************************
 * 
 * 6. Write a program that reads a text file containing a 
 * list of strings, sorts them and saves them to another 
 * text file. Example:
 * 	Ivan			George
 * 	Peter			Ivan
 * 	Maria			Maria
 * 	George			Peter
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;

class SortStringsInFile
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to sort it's lines alphabetically");
        string fn = Console.ReadLine();
        string newFilename = Path.GetPathRoot(fn) + Path.GetFileNameWithoutExtension(fn) + "-sorted" + Path.GetExtension(fn);
        string[] fileLines = new string[1000000];

        fileLines = File.ReadAllLines(fn);

        Array.Sort(fileLines);

        // Write sorted array to new file
        File.WriteAllLines(newFilename, fileLines);

        Process.Start(newFilename);
    }
}
