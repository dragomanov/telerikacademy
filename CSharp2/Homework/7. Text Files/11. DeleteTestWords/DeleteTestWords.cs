/*************************************************************
 * 
 * 11. Write a program that deletes from a text file all 
 * words that start with the prefix "test". Words 
 * contain only the symbols 0...9, a...z, A…Z, _.
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

class DeleteTestWords
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to read and remove all words with the 'test' prefix");
        string fn = Console.ReadLine();
        string newFilename = Path.GetPathRoot(fn) + Path.GetFileNameWithoutExtension(fn) + "-replaced" + Path.GetExtension(fn);
        string fnContents;

        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            Console.WriteLine("Reading file ...");
            fnContents = sr.ReadToEnd();
        }

        Console.WriteLine("Removing words ...");
        string pattern = @"\btest[a-zA-Z0-9_]*";
        string modifiedContents = Regex.Replace(fnContents, pattern, "");

        StreamWriter sw = new StreamWriter(newFilename);
        using (sw)
        {
            Console.WriteLine("Writing new file ...");
            sw.Write(modifiedContents);
        }

        Process.Start(newFilename);
    }
}
