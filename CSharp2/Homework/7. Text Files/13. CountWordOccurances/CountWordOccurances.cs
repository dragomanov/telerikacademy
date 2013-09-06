using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class CountWordOccurances
{
    static bool isContain(string word, string content)
    {
        string pattern = @"\b" + word + @"\b";
        Match result = Regex.Match(content.ToString(), pattern);
        if (result.Length > 0)
        {
            return true;
        }
        return false;
    }

    static Dictionary<string, int> CountWords(string[] allWords, string words)
    {
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        foreach (string word in allWords)
        {
            int count;
            if (string.IsNullOrEmpty(word.Trim()))
            {
                continue;
            }

            if (!wordsCount.TryGetValue(word, out count))
            {
                if (!isContain(word, words))
                {
                    continue;
                }
                count = 0;
            }
            wordsCount[word] = count + 1;
        }
        return wordsCount;
    }

    static void Main(string[] args)
    {
        try
        {
            StreamReader reader1 = new StreamReader(@"text.txt");
            StreamReader reader2 = new StreamReader(@"words.txt");
            StreamWriter writer = new StreamWriter(@"result.txt");

            using (writer)
            {
                string content = reader1.ReadToEnd();
                string contentWords = reader2.ReadToEnd();
                string[] allWords = Regex.Split(content, @"\W+");
                Dictionary<string, int> wordsCount = CountWords(allWords, contentWords);
                foreach (KeyValuePair<string, int> wordEntry in wordsCount.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine("{0} - {1}", wordEntry.Key, wordEntry.Value);
                }

                Console.WriteLine("File is written!");
            }
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Can not find file.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (SecurityException se)
        {
            Console.Error.WriteLine(se.Message);
        }
        catch (IOException ioe)
        {
            Console.Error.WriteLine(ioe.Message);
        }
    }
}