using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BitArray64> bitArray = new List<BitArray64> { 1, 2, 3 };
            BitArray64 ba1 = 1;
            BitArray64 ba2 = ba1;
            BitArray64 ba3 = 1;

            Console.WriteLine("List<BitArray64> bitArray = new List<BitArray64> { 1, 2, 3 };");
            Console.WriteLine("Foreach iteration of bitArray:");
            foreach (var item in bitArray)
            {
                foreach (var bit in item)
                {
                    Console.Write(bit);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Bit at 0 of bitArray[1]: " + bitArray[1][0]);
            Console.WriteLine("Change bit at 0 of bitArray[1] to 1");
            bitArray[1][0] = 1;
            Console.WriteLine("bitArray[1]: " + bitArray[1]);

            Console.WriteLine();
            Console.WriteLine("BitArray64 ba1 = 1;");
            Console.WriteLine("BitArray64 ba2 = ba1;");
            Console.WriteLine("BitArray64 ba3 = 1;");
            Console.WriteLine("ba1.Equals(ba2): " + ba1.Equals(ba2));
            Console.WriteLine("ba1.Equals(ba3): " + ba1.Equals(ba3));
            Console.WriteLine("ba1 == ba2: " + (ba1 == ba2));
            Console.WriteLine("ba1 == ba3: " + (ba1 == ba3));
        }
    }
}
