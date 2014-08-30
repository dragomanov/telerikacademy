using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomHashSet
{
    class CustomHashTableEntryPoint
    {
        static void Main(string[] args)
        {
            CustomHashTable<string, int> hashTable = new CustomHashTable<string, int>(4);
            hashTable.Add("a", 5);
            hashTable.Add("bb", 6);
            hashTable.Add("ccc", 7);
            hashTable.Add("d", 8);
            hashTable.Add("ee", 9);
            hashTable.Add("fff", 10);
            hashTable.Add("g", 11);
            hashTable.Add("hh", 12);
            hashTable.Add("iii", 13);
            hashTable.Add("j", 14);
            hashTable.Remove("j");
            string searchedKey = "bb";
            Console.WriteLine("Value of {0} is {1}.", searchedKey, hashTable.Find(searchedKey));
            foreach (KeyValuePair<string, int> pair in hashTable)
            {
                Console.WriteLine("Key -> {0}, Value -> {1}", pair.Key, pair.Value);
            }
            string indexKey = "g";
            Console.WriteLine("Indexator: element[{0}] = {1}", indexKey, hashTable[indexKey]);
            hashTable["g"] = 444;
            Console.WriteLine("Indexator: element[{0}](after change) = {1}", indexKey, hashTable[indexKey]);
            List<string> allKeys = hashTable.Keys;
            Console.Write("The keys are: ");
            foreach (string key in allKeys)
            {
                Console.Write("{0},", key);
            }
            Console.WriteLine(".");
            hashTable.Clear();
        }
    }
}
