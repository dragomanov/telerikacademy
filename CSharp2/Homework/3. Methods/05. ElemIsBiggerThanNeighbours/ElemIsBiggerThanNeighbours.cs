using System;

public class ElemIsBiggerThanNeighbours
{
    public static bool IsBiggerThanNeighbours(int index, int[] arrNums)
    {
        if (index == 0)
        {
            return arrNums[index] > arrNums[index + 1] ? true : false;
        }
        else if (index == arrNums.Length - 1)
        {
            return arrNums[index] > arrNums[index - 1] ? true : false;
        }
        else
        {
            return ((arrNums[index] > arrNums[index - 1]) && (arrNums[index] > arrNums[index + 1])) ? true : false;
        }
    }
    
    static void Main()
    {
        int[] arrNums = { 132, 321, 12, 213, 345, 5432, 32, 12, 23, 321, 132 };
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine("Number at index {0} is bigger than it's neighbours: {1}" ,index, IsBiggerThanNeighbours(index, arrNums));
    }
}
