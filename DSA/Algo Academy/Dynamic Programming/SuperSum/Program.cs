using System;
using System.Collections.Generic;

public class Program
{
    static int[,] pascals;
    static int[,] pascalTriangle;

    public static void Main()
    {

        string[] input = Console.ReadLine().Split(' ');
        int k = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        pascalTriangle = new int[n + k + 1, n + k + 1];
        pascals = new int[n, k];

        for (int i = 0; i <= n + k; i++)
        {
            int sum = 1;
            //Console.WriteLine();
            for (int j = 0; j <= i; j++)
            {
                pascalTriangle[i, j] = pascal(i, j);
                //Console.Write(pascalTriangle[i, j]);
                //Console.Write(sum); //print without recursion
                sum = sum * (i - j) / (j + 1);
            }
        }
        //Console.WriteLine();
        Console.WriteLine(pascalTriangle[k + n, n - 1]);
    }

    public static int pascal(int x, int y)
    {
        if ((x + 1) == 1 || (y + 1) == 1 || x == y)
        {
            return 1;
        }
        else if (pascalTriangle[x, y] != 0)
        {
            return pascalTriangle[x, y];
        }
        else
        {
            return pascal(x - 1, y - 1) + pascal(x - 1, y);
        }
    }
}