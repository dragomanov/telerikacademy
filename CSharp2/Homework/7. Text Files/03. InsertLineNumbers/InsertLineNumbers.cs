/*************************************************************
 * 
 * 3. Write a program that reads a text file and inserts line 
 * numbers in front of each of its lines. The result 
 * should be written to another text file.
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.Diagnostics;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter filename to copy it with line numbers");
        string fn = Console.ReadLine();
        string newFilename = Path.GetPathRoot(fn) + Path.GetFileNameWithoutExtension(fn) + "-lines" + Path.GetExtension(fn);

        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            string line = "";
            int lineNum = 1;

            // Write to new file
            StreamWriter sw = new StreamWriter(newFilename);
            using (sw)
            {
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(lineNum + ":\t" + line);
                    lineNum++;
                }
            }
        }

        Process.Start("Notepad", Directory.GetCurrentDirectory() + '\\' + newFilename);
    }
}