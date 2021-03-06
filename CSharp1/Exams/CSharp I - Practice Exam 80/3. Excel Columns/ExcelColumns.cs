﻿using System;

class ExcelColumns
{
    static void Main()
    {
        byte numDigits = byte.Parse(Console.ReadLine());
        long decimalIndex = 0L;
        for (int i = numDigits - 1; i >= 0; i--)
        {
            int digit = char.Parse(Console.ReadLine()) - 64;
            decimalIndex += (long)(digit * Math.Pow(26, i));
        }
        Console.WriteLine(decimalIndex);
    }
}
