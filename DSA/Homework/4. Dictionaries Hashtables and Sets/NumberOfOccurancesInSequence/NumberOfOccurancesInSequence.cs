/*
 * 1. Write a program that counts in a given array of double values the number of occurrences of each value. 
 * Use Dictionary<TKey,TValue>. 
 * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5} 
 * -2.5 -> 2 times 
 * 3 -> 4 times 
 * 4 -> 3 times
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionariesHashtablesAndSets.Utils;


namespace NumberOfOccurancesInSequence
{
    class NumberOfOccurancesInSequence
    {
        static void Main(string[] args)
        {
            string input = "3, 4, 4, -2,5, 3, 3, 4, 3, -2,5";
            var stringElements = input.Split(new String[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            double[] arr = stringElements.Select(Double.Parse).ToArray();
            Utils.PrintElementOccurances(arr);
        }
    }
}
