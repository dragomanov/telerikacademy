using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CombinationsWithoutDuplicates
{
    class Program
    {
        static int numbers;
        static int size;
        static int[] result;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter N for elements from 1 to N:");
            numbers = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K for combination size:");
            size = int.Parse(Console.ReadLine());

            result = new int[size];

            GenerateCombinations(0, 1);
        }

        
        private static void GenerateCombinations(int index, int start)
        {
            if (index >= size)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = start; i <= numbers; i++)
            {
                result[index] = i;
                GenerateCombinations(index + 1, i + 1);      //The same as in the previous task, only difference is "i + 1"
            }
        }
    }
}
