using System;

class FirstMemberBiggerThanNeighbours
{
    static int IndexOfFirstBiggerInt(int[] arrNums)
    {
        for (int i = 0; i < arrNums.Length; i++)
        {
            if (ElemIsBiggerThanNeighbours.IsBiggerThanNeighbours(i, arrNums))
            {
                return i;
            }
        }

        return -1;
    }

    static void Main()
    {
        int[] arrNums = { 132, 321, 412, 213, 345, 5432, 32, 12, 23, 321, 132 };
        Console.WriteLine("Index of first member bigger than it's neighbours is: {0}", IndexOfFirstBiggerInt(arrNums));
    }
}
