using System;
using System.Linq;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] nums = new long[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = long.Parse(Console.ReadLine());
        }

        long oddNumber = 0;
        foreach (var group in nums.GroupBy(v => v))
        {
            if (group.Count() % 2 != 0)
            {
                oddNumber = group.Key;
                break;
            }
        }
        Console.WriteLine(oddNumber);
    }
}
