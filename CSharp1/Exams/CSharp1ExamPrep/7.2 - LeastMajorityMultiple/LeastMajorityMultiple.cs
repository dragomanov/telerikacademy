using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] nums = new int[5];
        for (int i = 0; i < 5; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int leastMajorityMultiple = 0;
        for (int i = 1; i <= 912576; i++)
        {
            int divisibles = 0;
            for (int j = 0; j < 5; j++)
            {
                if (i % nums[j] == 0)
                {
                    divisibles++;
                }
            }
            if (divisibles >= 3)
            {
                leastMajorityMultiple = i;
                break;
            }
        }

        Console.WriteLine(leastMajorityMultiple);
    }
}
