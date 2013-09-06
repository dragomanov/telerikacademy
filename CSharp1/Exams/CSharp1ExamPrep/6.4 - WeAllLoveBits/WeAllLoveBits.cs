using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            string bitNum = Convert.ToString(nums[i], 2);
            int len = bitNum.Length;
            int newNum;
            string newBitNum = "";
            for (int j = len - 1; j >= 0; j--)
            {
                newBitNum += bitNum[j];
            }
            newNum = Convert.ToInt32(newBitNum, 2);
            Console.WriteLine(newNum);
        }
    }
}
