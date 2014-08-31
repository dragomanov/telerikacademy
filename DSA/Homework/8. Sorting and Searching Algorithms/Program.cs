namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                var collection = new SortableCollection<int>(new[] { 22, 13, 23, 45, -55, 90, 100, 101, -12, 55, 44 });
                var collection1 = new SortableCollection<string>(new[] { "aaaa", "cccc", "dddd", "cccc", "caaa", "aacc", "bbdd", "ccff", "eerr", "rrtt", "assdd" });
                Console.WriteLine("All items before sorting:");
                collection.PrintAllItemsOnConsole();
                Console.WriteLine();

                Console.WriteLine("SelectionSorter result:");
                collection.Sort(new SelectionSorter<int>());
                collection1.Sort(new SelectionSorter<string>());
                collection.PrintAllItemsOnConsole();
                collection1.PrintAllItemsOnConsole();
                Console.WriteLine();

                Console.WriteLine("Quicksorter result:");
                collection.Sort(new Quicksorter<int>());
                collection.PrintAllItemsOnConsole();
                collection1.Sort(new Quicksorter<string>());
                collection1.PrintAllItemsOnConsole();
                Console.WriteLine();

                Console.WriteLine("MergeSorter result:");
                collection.Sort(new MergeSorter<int>());
                collection.PrintAllItemsOnConsole();
                collection1.Sort(new Quicksorter<string>());
                collection1.PrintAllItemsOnConsole();
                Console.WriteLine();

                try
                {
                    Console.WriteLine("Linear search 101:");
                    Console.WriteLine(collection.LinearSearch(101));
                    Console.WriteLine("Linear search 22:");
                    Console.WriteLine(collection.LinearSearch(22));
                    Console.WriteLine("Linear search 301:");
                    Console.WriteLine(collection.LinearSearch(301));
                    Console.WriteLine();

                    Console.WriteLine("Binary search 101:");
                    Console.WriteLine(collection.BinarySearch(101));
                    Console.WriteLine("Linear search 22:");
                    Console.WriteLine(collection.LinearSearch(22));
                    Console.WriteLine("Linear search 301:");
                    Console.WriteLine(collection.LinearSearch(301));
                    Console.WriteLine();

                    Console.WriteLine("Shuffle:");
                    collection.Shuffle();
                    collection1.Shuffle();
                    collection.PrintAllItemsOnConsole();
                    Console.WriteLine();

                    Console.WriteLine("Shuffle again:");
                    collection.Shuffle();
                    collection.PrintAllItemsOnConsole();
                    collection1.Shuffle();
                    collection1.PrintAllItemsOnConsole();
                }
                catch (KeyNotFoundException error) 
                {
                    Console.WriteLine(error.Message);
                }
            }
            catch (NotImplementedException err) 
            {
                Console.Write("\n" + err.Message);
            }
        }
    }
}
