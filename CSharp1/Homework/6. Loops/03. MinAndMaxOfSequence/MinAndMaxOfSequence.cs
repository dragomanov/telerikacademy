using System;
using System.Collections.Generic;
using System.Linq;

class MinAndMaxOfSequence
{
    static void Main()
    {
        Console.Write("Enter number of integers to enter: ");
        int n = int.Parse(Console.ReadLine());
        
        List<int> nums = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int num;
            // Check if the entered string is a valid integer
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("An integer is a whole number in the range [" + int.MinValue + ", " + int.MaxValue + "]: ");
            }
            nums.Add(num);
        }

        Console.WriteLine("The smallest number is: " + nums.Min());
        Console.WriteLine("The biggest number is: " + nums.Max());
    }
}
