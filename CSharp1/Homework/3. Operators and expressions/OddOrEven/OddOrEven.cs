﻿using System;

class DecimalIntegervalue
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << position;
        int resultNumber = number ^ mask;
        Console.WriteLine(resultNumber);

        //We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators
        //that modifies n to hold the value v at the position p from the binary representation of n.
        //Example: n = 5 (00000101), p=3, v=1  13 (00001101)
        //      n = 5 (00000101), p=2, v=0  1 (00000001)

    }
}