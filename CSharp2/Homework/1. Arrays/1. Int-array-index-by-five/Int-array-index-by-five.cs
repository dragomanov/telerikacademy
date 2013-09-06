/*******************************************************
 * Write a program that allocates array of 20 integers
 * and initializes each element by its index multiplied 
 * by 5. Print the obtained array on the console.
 *******************************************************/

using System;

class IntArrayIndexByFive
{
    static void Main()
    {
        int[] arrNums = new int[20];

        for (int i = 0; i < 20; i++)
        {
            arrNums[i] = i * 5;
            Console.WriteLine("arrNums[{0}] = {1}", i, arrNums[i]);
        }
    }
}
