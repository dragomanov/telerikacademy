/*******************************************************
 * Write a program that reads two numbers N and K 
 * and generates all the combinations of K distinct 
 * elements from the set [1..N]. Example:
 * N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, 
 * {2, 5}, {3, 4}, {3, 5}, {4, 5}
 *******************************************************/

using System;

class Combinations
{
    static void Main()
    {
        Console.Write("Give a positive integer number N = ");
        uint permutationLength;
        while (!uint.TryParse(Console.ReadLine(), out permutationLength)) { }

        Console.Write("Give a positive integer number (K < N) K = ");
        uint combinationLength;
        while (!uint.TryParse(Console.ReadLine(), out combinationLength)) { }

        uint[] combinations = new uint[combinationLength];

        for (uint i = 1; i <= combinations.Length; i++)
        {
            combinations[i - 1] = i;
        }

        long operatorComb;
        if (permutationLength > combinationLength)
        {
            while (true)
            {
                for (uint i = 0; i < combinations.Length; i++)
                {
                    Console.Write("{0} ", combinations[i]);
                }
                Console.WriteLine();

                operatorComb = combinationLength - 1;
                combinations[operatorComb] += 1;
                bool newLevelComb = false;

                while (combinations[operatorComb] > permutationLength || newLevelComb)
                {
                    operatorComb--;
                    if (operatorComb < 0)
                    {
                        return;
                    }
                    combinations[operatorComb] += 1;

                    for (uint i = (uint)(operatorComb + 1); i < combinationLength; i++)
                    {
                        combinations[i] = combinations[i - 1] + 1;
                        if (combinations[i] > permutationLength)
                        {
                            newLevelComb = true;
                        }
                        else
                        {
                            newLevelComb = false;
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Start again and try to give K < N!");
        }
    }
}
