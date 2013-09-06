using System;

class FallDown
{
    static void FallOnce(ref int[] numbers)
    {
        for (int i = 7; i > 0 ; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                int currCell = numbers[i] >> j & 1;
                int cellAbove = numbers[i - 1] >> j & 1;
                if (currCell == 0 && cellAbove == 1)
                {
                    numbers[i] += 1 << j;
                    numbers[i - 1] -= 1 << j;
                }
            }
        }
    }

    static void Main()
    {
        int[] nums = new int[8];
        for (int i = 0; i < 8; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        int[] newNums = nums;
        for (int j = 0; j < 8; j++)
        {
            FallOnce(ref newNums);
        }

        for (int k = 0; k < 8; k++)
        {
            Console.WriteLine(newNums[k]);
        }
    }
}
