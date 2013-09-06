/**********************************************************
 * 
 * 2. Write a program that concatenates two text files 
 * into another text file.
 * 
 **********************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;


class ConcatTwoFiles
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter two filenames to read");
        string fn1 = Console.ReadLine();
        string fn2 = Console.ReadLine();

        // Read fn1 contents
        StreamReader sr1 = new StreamReader(fn1);
        string fileContents1;
        using (sr1)
        {
            fileContents1 = sr1.ReadToEnd();
        }

        // Read fn2 contents
        StreamReader sr2 = new StreamReader(fn2);
        string fileContents2;
        using (sr2)
        {
            fileContents2 = sr2.ReadToEnd();
        }

        Console.WriteLine("Enter filename of concatenated file");
        string concFile = Console.ReadLine();

        StreamWriter sw = new StreamWriter(concFile);
        using (sw)
        {
            sw.WriteLine(fileContents1);
            sw.Write(fileContents2);
        }

        Process.Start(Directory.GetCurrentDirectory() + '\\' + concFile);
    }
}
