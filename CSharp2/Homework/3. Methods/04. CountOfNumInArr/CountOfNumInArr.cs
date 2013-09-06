using System;
using System.Linq;

class CountOfNumInArr
{
    static int TimesNumInArray(decimal num, decimal[] arrNums)
    {
        var groups = arrNums.GroupBy(v => v);
        int count = 0;
        foreach (var group in groups)
        {
            if (group.Key == num)
            {
                count = group.Count();
            }
        }

        return count;
    }

    static void Main()
    {
        decimal[] arrNums = { 132, 321, 12, 213, 345, 123.123m, 5432, 32, 12, 23, 321, 132, 123.123m };
        decimal num = decimal.Parse(Console.ReadLine());
        Console.WriteLine(TimesNumInArray(num, arrNums));
    }

}
