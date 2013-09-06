using System;

class SubsetSums
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] nums = new long[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = long.Parse(Console.ReadLine());
        }

        int subsets = 0;
        for (int subset = 1; subset < (1 << n); subset++)
        {
            string numBits = Convert.ToString(subset, 2); // 101
            long subsetSum = 0;
            for (int curBit = 0; curBit < numBits.Length; curBit++)
            {
                int isUsed = subset & (1 << curBit);
                if (isUsed > 0)
                {
                    subsetSum += nums[curBit];
                }
            }

            if (subsetSum == sum)
            {
                subsets++;
            }
        }

        Console.WriteLine(subsets);
    }
}
