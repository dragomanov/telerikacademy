using System;
using System.Numerics;

class NFibonacciMembers
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger member1 = 0;
        BigInteger member2 = 1;
        BigInteger member3 = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += member1;
            member1 = member2;
            member2 = member3;
            member3 = member1 + member2;
        }
        Console.WriteLine("Sum of first N fibonacci members is: " + sum);
    }
}
