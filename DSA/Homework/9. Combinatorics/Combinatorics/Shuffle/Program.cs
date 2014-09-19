using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    class Program
    {
        static Random _random = new Random();

        static void Main(string[] args)
        {
            TestShuffleArray();
        }

        static int[] ShuffleArray(int[] array)
        {
            var random = _random;
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                // Swap.
                int tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }

            return array;
        }

        static int[] GenerateSortedDeck()
        {
            int[] deck = new int[5];

            for (int i = 0, len = deck.Length; i < len; i++)
            {
                deck[i] = i;
            }

            return deck;
        }

        static void TestShuffleArray()
        {
            var shuffledArrays = new Dictionary<string, int>();

            for (int i = 0; i < 1200000; i++)
            {
                var deck = GenerateSortedDeck();
                var shuffledArrayString = String.Join(" ", ShuffleArray(deck));

                if (!shuffledArrays.ContainsKey(shuffledArrayString))
                {
                    shuffledArrays[shuffledArrayString] = 0;
                }

                shuffledArrays[shuffledArrayString]++;
            }

            var sortedByShuffleCount = new SortedList<int, string>();

            foreach (var shuffle in shuffledArrays)
            {
                sortedByShuffleCount.Add(shuffle.Value, shuffle.Key);
            }

            foreach (var shuffle in sortedByShuffleCount)
            {
                Console.WriteLine("{0}: {1} times", shuffle.Value, shuffle.Key);
            }
        }
    }
}
