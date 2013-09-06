/*************************************************************
 * 
 * 10. Write a program that extracts from given XML file 
 * all the text without the tags. Example:
 * <?xml version="1.0"><student><name>Pesho</name>
 * <age>21</age><interests count="3"><interest> 
 * Games</instrest><interest>C#</instrest><interest> 
 * Java</instrest></interests></student>
 * 
 *************************************************************/

// Comment line below to use program with own filenames
#define TEST

using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractXMLText
{
    static void Main()
    {

#if TEST
        Console.SetIn(new StreamReader("input.txt"));
#endif

        Console.WriteLine("Enter XML filename to extract the text");
        string fn = Console.ReadLine();
        string fnContents;

        StreamReader sr = new StreamReader(fn);
        using (sr)
        {
            fnContents = sr.ReadToEnd();
        }

        string cleanText = "";
        string pattern = @">([^<]\w+?)<";
        MatchCollection matchedText = Regex.Matches(fnContents, pattern);
        foreach (Match match in matchedText)
        {
            cleanText += match.Groups[1];
        }

        Console.WriteLine(cleanText);
    }
}
