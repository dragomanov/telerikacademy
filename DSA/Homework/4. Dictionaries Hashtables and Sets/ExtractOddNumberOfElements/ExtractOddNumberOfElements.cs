using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionariesHashtablesAndSets.Utils;

namespace ExtractOddNumberOfElements
{
    class ExtractOddNumberOfElements
    {
        static void Main(string[] args)
        {
            string input = "C#, SQL, PHP, PHP, SQL, SQL";
            var stringElements = input.Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var elementsPresentOddTimes =
                Utils.ElementOccuranceCounter(stringElements)
                .Where((k, v) => v % 2 == 0)
                .Select(kv => kv.Key);
            Console.WriteLine("{" + String.Join(", ", elementsPresentOddTimes) + "}");
        }
    }
}
