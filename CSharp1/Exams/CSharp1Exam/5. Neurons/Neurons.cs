using System;

class Neurons
{
    static void Main()
    {
        string[] nums = new string[32];
        string[] newNums = new string[32];
        for (int i = 0; i < 32; i++)
        {
            newNums[i] = new string('0', 32);
        }

        int numLines = 0;
        for (int i = 0; i < 32; i++)
        {
            uint input;
            if (!uint.TryParse(Console.ReadLine(), out input))
            {
                numLines = i;
                break;
            }
            else
            {
                nums[i] = Convert.ToString(input, 2).PadLeft(32, '0');
            }
        }

        for (int line = 0; line < numLines; line++)
        {
            for (int i = 1; i <= 30; i++)
            {
                string neuronLine = '1' + new string('0', i) + '1';
                int foundAt = nums[line].IndexOf(neuronLine);
                if (foundAt > -1)
                {
                    newNums[line] = new string('0', foundAt + 1) + new string('1', i);
                    newNums[line] = newNums[line].PadRight(32, '0');
                }
            }
            Console.WriteLine(Convert.ToInt32(newNums[line], 2));
        }
    }
}
