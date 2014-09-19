using System;
using System.Collections.Generic;
using System.Linq;

namespace Guitar
{
    class Program
    {
        static int c;
        static int b;
        static int m;
        static int[] diff;

        static void Main(string[] args)
        {
            HashSet<int> possibilities = new HashSet<int>();
            HashSet<int> newPossilities = new HashSet<int>();
            ReadInput();
            possibilities.Add(b);

            for (int i = 0; i < c; i++)
            {
                foreach (var possibility in possibilities)
                {
                    if (possibility + diff[i] <= m)
                    {
                        newPossilities.Add(possibility + diff[i]);
                    }
                    
                    if (possibility - diff[i] >= 0)
                    {
                        newPossilities.Add(possibility - diff[i]);
                    }
                }

                possibilities = newPossilities;
                newPossilities.Clear();

                if (possibilities.Count == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            Console.WriteLine(possibilities.Max());
        }

        private static void ReadInput()
        {
            c = int.Parse(Console.ReadLine());
            diff = Console.ReadLine().Split(' ').Select(d => int.Parse(d)).ToArray();
            b = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
        }
    }
}
