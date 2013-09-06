

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveWords
{
    static void Main()
    {
        string filename = "words.txt";
        try
        {
            StreamReader sr = new StreamReader(filename);
            var listOfWords = new List<string>();
            string row = sr.ReadLine();
            while (row != null)
            {
                listOfWords.Add(row.Replace(" ", String.Empty));
                row = sr.ReadLine();
            }
            sr.Close();

            filename = "testfile.txt";
            sr = new StreamReader(filename);
            string outputfile = "tempfile.txt";
            StreamWriter sw = new StreamWriter(outputfile, false);
            row = sr.ReadLine();
            while (row != null)
            {
                for (int i = 0; i < listOfWords.Count; i++)
                {
                    string RegularExpression = String.Concat("\\b", listOfWords[i], "\\b");
                    row = Regex.Replace(row, RegularExpression, String.Empty);
                }
                sw.WriteLine(row);
                row = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
            File.Delete(filename);
            File.Move(outputfile, filename);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Null Argument");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Wrong Argument");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory to file not exist");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not exist");
        }
        catch (IOException)
        {
            Console.WriteLine("File exception");
        }
    }
}