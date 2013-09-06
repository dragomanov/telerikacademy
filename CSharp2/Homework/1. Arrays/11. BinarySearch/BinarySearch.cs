/*******************************************************
 * Write a program that finds the index of given 
 * element in a sorted array of integers by using the 
 * binary search algorithm (find it in Wikipedia).
 *******************************************************/

using System;

class BinarySearch
{ 
    static void Main()
    {
        int[] arrElems = { 1, 3, 4, 5, 8, 10, 14 };
        Console.Write("Enter the wanted number to search: ");
        int x = int.Parse(Console.ReadLine());
 
        int middle = arrElems.Length / 2;
        int lowerIndex = 0;
        int upperIndex = arrElems.Length - 1;

        for (int i = 0; i < Math.Log(arrElems.Length, 2); i++)
        {
            if (x == arrElems[middle])
            {
                break;
            }
            else if (x < arrElems[middle])
            {
                upperIndex = middle - 1;
                middle = middle / 2;
            }
            else if (x > arrElems[middle])
            {
                lowerIndex = middle + 1;
                middle = ((upperIndex + middle) / 2) + 1;
            }

            if (lowerIndex == upperIndex)
            {
                middle = -1;
                break;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Index of number {0} in {{{1}}}: [{2}]", x, String.Join(", ", arrElems), middle);
    }
}
