/**********************************************************
 * 
 * 6. You are given a sequence of positive integer values 
 * written into a string, separated by spaces. Write a 
 * function that reads these values from given string 
 * and calculates their sum. Example:
 * string = "43 68 9 23 318" => result = 461
 * 
 **********************************************************/

using System;

class SumStringOfNums
{
    static ulong Sum(string numStr)
    {
        string[] arrNumsStr = numStr.Split(' ');
        uint sum = 0;
        
        foreach (var num in arrNumsStr)
        {
            sum += uint.Parse(num);
        }

        return sum;
    }

    static void Main()
    {
        string nums = "43 68 9 23 318";
        Console.WriteLine("The sum of the numbers {0} = {1}", nums, Sum(nums));
    }
}
