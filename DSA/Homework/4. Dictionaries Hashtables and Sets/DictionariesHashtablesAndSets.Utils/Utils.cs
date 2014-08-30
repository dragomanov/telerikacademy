using System;
using System.Collections.Generic;

namespace DictionariesHashtablesAndSets.Utils
{
    public static class Utils
    {
        public static IDictionary<T, int> ElementOccuranceCounter<T>(ICollection<T> arr)
        {
            IDictionary<T, int> elements = new Dictionary<T, int>();

            foreach (var item in arr)
            {
                if (elements.ContainsKey(item))
                {
                    elements[item]++;
                }
                else
                {
                    elements.Add(item, 1);
                }
            }

            return elements;
        }

        public static void PrintElementOccurances<T>(ICollection<T> arr)
        {
            var counter = ElementOccuranceCounter(arr);
            ElementCountPrinter(counter);
        }

        private static void ElementCountPrinter<T>(IDictionary<T, int> elements)
        {
            foreach (var elem in elements)
            {
                Console.WriteLine("{0} -> {1}", elem.Key, elem.Value);
            }
        }
    }
}
