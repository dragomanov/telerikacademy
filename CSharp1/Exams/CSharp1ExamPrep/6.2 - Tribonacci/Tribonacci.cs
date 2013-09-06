using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        BigInteger[] t = new BigInteger[n + 1];
        t[1] = t1;
        t[2] = t2;
        t[3] = t3;
        for (int i = 4; i <= n; i++)
        {
            t[i] = t[i - 1] + t[i - 2] + t[i - 3];
        }

        Console.WriteLine(t[n]);
    }
}
