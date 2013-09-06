/********************************************************
 * We are given a matrix of strings of size N x M.
 * Sequences in the matrix we define as sets of several 
 * neighbor elements located on the same line, column 
 * or diagonal. Write a program that finds the longest 
 * sequence of equal strings in the matrix. Example:
 ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

class LongestSequence
{
    static void Main()
    {
        int N, M, HorizontalSum = 0, Horizontal = 1, i, j;
        Console.Write("N: ");
        N = int.Parse(Console.ReadLine());
        Console.Write("M: ");
        M = int.Parse(Console.ReadLine());
        int[,] Matrix = new int[N, M];
        MaxSumInMatrix.RandPopulateMatrix(Matrix);
        Console.WriteLine("Generated matrix is:");
        FillAndPrintMatrix.PrintMatrix(Matrix, 2);
        Console.WriteLine();
        int HorizontalElementMax = -1;

        for (i = 0; i < N; i++)
        {
            for (j = 0; j < M - 1; j++)
            {
                if (Matrix[i, j] == Matrix[i, j + 1])
                {
                    Horizontal++;
                    if (HorizontalSum < Horizontal)
                    {
                        HorizontalSum = Horizontal;
                        HorizontalElementMax = Matrix[i, j];
                    }
                }
                else
                {
                    Horizontal = 1;
                }
            }
            Horizontal = 1;
        }

        int Vertical = 1, VerticalMax = 0;
        int VerticalElement = -1;
        for (j = 0; j < M; j++)
        {
            for (i = 0; i < N - 1; i++)
            {
                if (Matrix[i, j] == Matrix[i + 1, j])
                {
                    Vertical++;
                    if (VerticalMax < Vertical)
                    {
                        VerticalMax = Vertical;
                        VerticalElement = Matrix[i, j];
                    }
                }
                else
                {
                    Vertical = 1;
                }
            }
            Vertical = 1;
        }

        int Dright = 1, DrightMax = 0;
        int DrightElement = -1;
        for (i = 0, j = 0; i < N - 1 && j < M - 1; i++, j++)
        {
            if (j >= M - 1 || i >= N - 1)
            {
                break;
            }
            else
            {
                if (Matrix[i, j] == Matrix[i + 1, j + 1])
                {
                    Dright++;
                    if (Dright > DrightMax)
                    {
                        DrightElement = Matrix[i, j];
                        DrightMax = Dright;
                    }
                    else Dright = 1;
                }
            }
        }

        int DLeft = 1, DleftMax = 0;
        int ElementDLeft = -1;
        for (i = 0, j = M - 1; i < N - 1 && j >= 0; i++, j--)
        {
            if (j <= 0 || i >= N - 1)
            {
                break;
            }
            else
            {
                if (Matrix[i, j] == Matrix[i + 1, j - 1])
                {
                    DLeft++;
                    if (DLeft > DleftMax)
                    {
                        ElementDLeft = Matrix[i, j];
                        DleftMax = DLeft;
                    }
                    else DLeft = 1;
                }
            }
        }

        int[] a = new int[4];
        a[0] = HorizontalSum;
        a[1] = VerticalMax;
        a[2] = DrightMax;
        a[3] = DleftMax;
        Array.Sort(a);
        if (a[3] == HorizontalSum)
        {
            for (i = 0; i < HorizontalSum; i++) Console.Write(HorizontalElementMax + " ");
            Console.WriteLine();
        }
        else if (a[3] == VerticalMax)
        {
            for (i = 0; i < VerticalMax; i++) Console.Write(VerticalElement + " ");
            Console.WriteLine();
        }
        else if (a[3] == DrightMax)
        {
            for (i = 0; i < DrightMax; i++) Console.Write(DrightElement + " ");
            Console.WriteLine();
        }
        else if (a[3] == DleftMax)
        {
            for (i = 0; i < DleftMax; i++) Console.Write(ElementDLeft + " ");
            Console.WriteLine();
        }
    }
}
