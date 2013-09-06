/*************************************************************
 * 
 * 4. Write a program that compares two text files line by 
 * line and prints the number of lines that are the same 
 * and the number of lines that are different. Assume 
 * the files have equal number of lines.
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.IO;

class PrintNumOfEqualLines
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter two filenames to read");
        string fn1 = Console.ReadLine();
        string fn2 = Console.ReadLine();

        StreamReader sr1 = new StreamReader(fn1);
        using (sr1)
        {
            StreamReader sr2 = new StreamReader(fn2);
            using (sr2)
            {
                string lineFn1 = "";
                string lineFn2 = "";
                int equalLines = 0;
                int diffLines = 0;
                while ((lineFn1 = sr1.ReadLine()) != null && (lineFn2 = sr2.ReadLine()) != null)
                {
                    if (lineFn1 == lineFn2)
                    {
                        equalLines++;
                    }
                    else
                    {
                        diffLines++;
                    }
                }

                Console.WriteLine("Number of same lines: {0}", equalLines);
                Console.WriteLine("Number of different lines: {0}", diffLines);
            }
        }
    }
}
