/********************************************************
 * You are given an array of strings. Write a method 
 * that sorts the array by the length of its elements 
 * (the number of characters composing them).
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;


class SortArrayOfStrings
{
    static void BubbleSort(string[] array)
    {
        int a, b, count = array.Length;
        string tmp = "";

        for (a = 0; a < count; ++a)
        {
            for (b = count - 1; b > a; --b)
            {
                if (array[b - 1].Length > array[b].Length)
                {
                    tmp = array[b - 1];
                    array[b - 1] = array[b];
                    array[b] = tmp;
                }
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter array columns:");
        int n = int.Parse(Console.ReadLine());
        string[] array = new string[n];
        int column = 0;

        for (column = 0; column < n; column++)
        {
            Console.Write("Enter value array element column={0}:", column + 1);
            array[column] = Console.ReadLine();
        }

        BubbleSort(array);

        for (column = 0; column < n; column++)
        {
            Console.WriteLine("{0}", array[column]);
        }
    }
}