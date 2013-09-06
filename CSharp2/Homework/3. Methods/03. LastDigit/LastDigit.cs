using System;

class LastDigit
{
    static string NameOfLastDigit(int num)
    {
        int digit = num % 10;

        switch (digit)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            default:
                return "Invalid input";
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(NameOfLastDigit(num));
    }
}
