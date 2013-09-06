/*************************************************************
 * 
 * 7. Write a program that replaces all occurrences of the 
 * substring "start" with the substring "finish" in a text 
 * file. Ensure it will work with large files (e.g. 100 MB).
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;

class ReplaceStartWithFinish
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to read and replace occurances of 'start' with 'finish'");
        string fn = Console.ReadLine();
        string newFilename = Path.GetPathRoot(fn) + Path.GetFileNameWithoutExtension(fn) + "-replaced" + Path.GetExtension(fn);
        string fnContents;

        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            Console.WriteLine("Reading file ...");
            fnContents = sr.ReadToEnd();
        }

        Console.WriteLine("Replacing substring ...");
        string modifiedContents = fnContents.Replace("start", "finish");

        StreamWriter sw = new StreamWriter(newFilename);
        using (sw)
        {
            Console.WriteLine("Writing new file ...");
            sw.Write(modifiedContents);
        }

        Process.Start(newFilename);
    }
}