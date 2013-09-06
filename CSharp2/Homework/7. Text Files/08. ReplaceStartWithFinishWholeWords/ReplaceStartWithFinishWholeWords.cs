/*************************************************************
 * 
 * 8. Modify the solution of the previous problem to 
 * replace only whole words (not substrings).
 *
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
class ReplaceStartWithFinishWholeWords
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to read and replace whole-word occurances of 'start' with 'finish'");
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
        string pattern = @"\bstart\b";
        string modifiedContents = Regex.Replace(fnContents, pattern, "finish");

        StreamWriter sw = new StreamWriter(newFilename);
        using (sw)
        {
            Console.WriteLine("Writing new file ...");
            sw.Write(modifiedContents);
        }

        Process.Start(newFilename);
    }
}