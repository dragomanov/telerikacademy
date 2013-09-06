/********************************************************
 * 
 * 1. Write a program that reads a year from the console
 * and checks whether it is a leap. Use DateTime.
 * 
 ********************************************************/

using System;

class IsLeapYear
{
    static void Main()
    {
        Console.WriteLine("Enter a year in the yyyy format to check whether it's a leap year");
        int year = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);
        string leapMsg = isLeap ? "is" : "isn't";
        Console.WriteLine("The year {0} {1} a leap year.", year, leapMsg);
    }
}