﻿using System;

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Enter a number to see if it's divisible by both 5 & 7: ");
        int number = int.Parse(Console.ReadLine());
        int a = 5;
        int b = 7;
        int LCM = 35; // Since 5 & 7 are prime numbers their lease common multiple is their product

        // We check if the number is divisible by the LCM and we assign isDivisible the appropriate string 
        string isDivisible = (number % LCM) == 0 ? "is" : "isn't";
        Console.WriteLine("The number {0} {1} divisible by both 5 & 7.", number, isDivisible);
    }
}

