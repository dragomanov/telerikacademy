using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Enter a number to confirm if it's 3rd digit (right to left) is 7: ");
        int number = int.Parse(Console.ReadLine());

        // isSeven is assigned true if 3rd digit is 7 (Ex: 123721 / 100 -> 1237 % 10 -> remainder is 7 -> true)
        // Math.Abs() returns the absolute value, so it works with negative numbers as well
        bool isSeven = Math.Abs((number / 100) % 10) == 7 ? true : false;
        Console.WriteLine("The 3rd digit of the number is 7: " + isSeven);
    }
}

