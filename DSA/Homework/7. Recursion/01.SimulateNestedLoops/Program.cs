using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SimulateNestedLoops
{
    class Program
    {
        static int num;
        static int[] result;

        static void Main(string[] args)
        {
            Console.WriteLine("Number of loops to simulate:");
            num = int.Parse(Console.ReadLine());
            result = new int[num];

            SimulateLoops(0);
        }
  
        private static void SimulateLoops(int index)
        {  
            if (index >= num)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = 1; i <= num; i++)
            {
                result[index] = i;
                SimulateLoops(index + 1);                
            }
            
        }
    }
}
