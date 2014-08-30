/*
 * 3. Write a program that counts how many times each word from given text file words.txt appears in it. 
 * The character casing differences should be ignored. 
 * The result words should be ordered by their number of occurrences in the text. 
 * Example: 
 * "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?"
 * is  2  
 * the  2  
 * this  3  
 * text  6 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DictionariesHashtablesAndSets.Utils;

namespace WordCount
{
    class WordCount
    {
        static readonly char[] wordDelimiters = new char[] { ' ', ',', '.', '!', '?', '-', '–', '\r', '\n' };

        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"..\..\words.txt");
            var wordArray = text.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
            var sortedWordCount = Utils.ElementOccuranceCounter(wordArray).ToList();
            sortedWordCount.Sort((a, b) => a.Value.CompareTo(b.Value));
            foreach (var word in sortedWordCount)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}
