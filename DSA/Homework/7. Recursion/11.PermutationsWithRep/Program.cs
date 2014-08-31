using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PermutationsWithRep
{
    class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            int[] set = new int[] { 3, 3, 5, 5, 5 };
            
            Array.Sort(set);
            GeneratePermutationsWithRep(set, 0, set.Length);
            Console.WriteLine(counter);
        }

        private static void GeneratePermutationsWithRep(int[] set, int start, int size)
        {
            counter++;
            PrintPerm(set);

            if (start < size)
            {
                for (int left = size - 2; left >= start; left--)
                {
                    for (int right = left + 1; right < size; right++)
                    {
                        if (set[left] != set[right])
                        {
                            Swap(ref set[left], ref set[right]);
                            GeneratePermutationsWithRep(set, left + 1, size);
                        }
                    }

                    var swapValue = set[left];
                    for (int i = left; i < size - 1; i++)
                    {
                        set[i] = set[i + 1];
                    }
                    set[size - 1] = swapValue;
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void PrintPerm(int[] perm)
        {
            foreach (var num in perm)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
