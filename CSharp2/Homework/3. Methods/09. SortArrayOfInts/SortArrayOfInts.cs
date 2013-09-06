using System;

class SortArrayOfInts
{
    static int GetMaxElement(int[] array, int index)
    {
        int maxElement = array[index];

        for (int i = index; i < array.Length; i++)
        {
            if (maxElement < array[i])
                maxElement = array[i];
        }

        return maxElement;
    }

    static void SortAsscending(int[] array)
    {
        int a, b, count = array.Length;
        for (a = 0; a < count; ++a)
        {
            for (b = count - 1; b > a; --b)
            {
                int[] getMax = new int[2];
                int maxElement = 0;
                int tmp = 0;
                getMax[0] = array[b - 1];
                getMax[1] = array[b];

                maxElement = GetMaxElement(getMax, 0);

                if (maxElement > array[b])
                {
                    tmp = array[b - 1];
                    array[b - 1] = array[b];
                    array[b] = tmp;
                }
            }
        }
    }

    static void SortDescending(int[] array)
    {
        int a, b, count = array.Length;
        for (a = 0; a < count; ++a)
        {
            for (b = count - 1; b > a; --b)
            {
                int[] getMax = new int[2];
                int maxElement = 0;
                int tmp = 0;
                getMax[0] = array[b - 1];
                getMax[1] = array[b];

                maxElement = GetMaxElement(getMax, 0);

                if (maxElement == array[b])
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
        /*Write a method that return the maximal element in a portion of array of integers starting at given index.
          Using it write another method that sorts an array in ascending / descending order.*/

        int[] array = new int[] { 4, 15, 12, 7, 20, 3, 51, 6, 14, 25, 34, 19, 33, 41 };
        Console.WriteLine("array = 4, 15, 12, 7, 20, 3, 51, 6, 14, 25, 34, 19, 33, 41");
        Console.WriteLine("Enter index position (1...{0})", array.Length);
        int x = int.Parse(Console.ReadLine());

        int maxElement = GetMaxElement(array, x - 1);

        Console.WriteLine(maxElement);

        SortAsscending(array);

        Console.WriteLine("Asscending:");
        foreach (int element in array)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();

        SortDescending(array);

        Console.WriteLine("Descending:");
        foreach (int element in array)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();
    }
}